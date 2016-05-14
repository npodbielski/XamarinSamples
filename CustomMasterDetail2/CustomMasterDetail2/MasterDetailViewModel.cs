// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MasterDetailViewModel.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2016 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Windows.Input;
using CustomMasterDetailControl;
using Xamarin.Forms;

namespace CustomMasterDetail2
{
    public class MasterDetailViewModel : MasterDetailControlViewModel
    {
        private ICommand _toDetail1;
        private ICommand _toDetail2;
        private ICommand _toDetail3;

        private ICommand _toNoMenuDetail;

        public ICommand ToDetail1
        {
            get { return _toDetail1 ?? (_toDetail1 = new Command(OnToDetail1)); }
        }

        public ICommand ToNoMenuDetail
        {
            get { return _toNoMenuDetail ?? (_toNoMenuDetail = new Command(OnToNoMenuDetail)); }
        }

        public ICommand ToDetail2
        {
            get { return _toDetail2 ?? (_toDetail2 = new Command(OnToDetail2)); }
        }

        public ICommand ToDetail3
        {
            get { return _toDetail3 ?? (_toDetail3 = new Command(OnToDetail3)); }
        }

        private void OnToNoMenuDetail()
        {
            Detail = new NoMenuDetail();
        }

        private void OnToDetail1()
        {
            Detail = new Detail1();
        }

        private void OnToDetail2()
        {
            Detail = new Detail2();
        }

        private void OnToDetail3()
        {
            Detail = new Detail3();
        }
    }
}