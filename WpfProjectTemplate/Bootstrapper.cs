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

using System.Linq;
using Caliburn.Micro;

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

        #endregion

    }
}