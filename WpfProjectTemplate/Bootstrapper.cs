/*
 * -----------------------------------------------------------------------------
 *	 
 *   Filename		:   Bootstrapper.cs
 *   Date			:   2020-06-23 15:30:55
 *   All rights reserved
 * 
 * -----------------------------------------------------------------------------
 * @author     Patrick Robin <support@rietrob.de>
 * @Version      1.0.0
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Caliburn.Micro;
using WpfProjectTemplate.ViewModels;

namespace WpfProjectTemplate
{
    public class Bootstrapper : BootstrapperBase
    {

        #region Fields

        private SimpleContainer _container = new SimpleContainer();

        #endregion

        #region Properties

        #endregion

        #region Constructor

        public Bootstrapper()
        {
            Initialize();
        }

        #endregion

        #region Methods

        protected override void Configure()
        {
            _container
                .Singleton<IWindowManager, WindowManager>()
                .Singleton<IEventAggregator, EventAggregator>();
            GetType().Assembly.GetTypes()
                .Where(type => type.IsClass)
                .Where(type => type.Name.EndsWith("ViewModel"))
                .ToList()
                .ForEach(viewModelType => _container.RegisterPerRequest(
                    viewModelType, viewModelType.ToString(), viewModelType));
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        #region Overrides of BootstrapperBase

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }

        #endregion

        #endregion

    }
}