/*
*----------------------------------------------------------------------------------
*          Filename:	ShellViewModel.cs
*          Date:        2020.06.23 17:27:49
*          All rights reserved
*
*----------------------------------------------------------------------------------
* @author Patrick Robin <support@rietrob.de>
*/

using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace WpfProjectTemplate.ViewModels

{
    public class ShellViewModel : Conductor<object>
    {

        #region Fields

        

        #endregion

        #region Properties

        #endregion

        #region Constructor

        public ShellViewModel()
        {
            ActivateItemAsync(IoC.Get<DemoViewModel>(), new CancellationToken());
        }

        #endregion

        #region Methods

        #endregion

        #region EventHandler

        #endregion


    }
}