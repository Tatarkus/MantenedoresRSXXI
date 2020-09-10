using MantenedoresSigloXXI.Contracts.Services;
using MantenedoresSigloXXI.Contracts.ViewModels;
using MantenedoresSigloXXI.Helpers;
using MantenedoresSigloXXI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace MantenedoresSigloXXI.ViewModels
{
    public class CustomerUpdateViewModel : Observable, INavigationAware
    {
        private readonly INavigationService _navigationService;

       // Customer _updatingCustomer;
        //Observable name = new Observable();
        private Customer updatingCustomer;
        public Customer UpdatingCustomer
        {
            get { return updatingCustomer; }
            set
            {
                if (updatingCustomer != value)
                {
                    updatingCustomer = value;
                    OnPropertyChanged("UpdatingCustomer");
                }
            }
        }

        public CustomerUpdateViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        

        public void OnNavigatedFrom()
        {
            
        }

        public void OnNavigatedTo(object sender)
        {
            UpdatingCustomer = (Customer)sender;
           
        }


        public void Back()
        {
            _navigationService.GoBack();
        }
    }
}
