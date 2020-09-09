using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Documents;
using MantenedoresSigloXXI.Contracts.Services;
using MantenedoresSigloXXI.Contracts.ViewModels;
using MantenedoresSigloXXI.Controllers;
using MantenedoresSigloXXI.Core.Contracts.Services;
using MantenedoresSigloXXI.Core.Models;
using MantenedoresSigloXXI.Helpers;
using MantenedoresSigloXXI.Models;

namespace MantenedoresSigloXXI.ViewModels
{
    public class CustomersViewModel : Observable, INavigationAware
    {
        private Customer _selected;
        public List<Customer> Customers;
        private readonly INavigationService _navigationService;

        public Customer Selected
        {
            get { return _selected; }
            set { Set(ref _selected, value); }
        }

        private ObservableCollection<Customer> listOfCustomers;
        public ObservableCollection<Customer> ListOfCustomers
        {
            get { return listOfCustomers; }
            set
            {
                if (listOfCustomers != value)
                {
                    listOfCustomers = value;                
                }
            }
        }

        public CustomersViewModel()
        {
            Initialize();
        }

        public void Test()
        {
            _navigationService.NavigateTo("CustomerUpdatePage");
        }

        private void Initialize()
        {
            UpdateCustomerList();

            //Customers = CustomerController.DeserializeCustomers();
        }

        public void UpdateCustomerList()
        {
            Customers = CustomerController.DeserializeCustomers();
            ListOfCustomers = new ObservableCollection<Customer>(Customers);
            //Customers = CustomerController.DeserializeCustomers();
        }

        public void OnNavigatedTo(object parameter)
        {


        }

        public void OnNavigatedFrom()
        {


        }


        
        public void FilterByUsername(string filterBy)
        {
            ListOfCustomers.Clear();

            foreach (Customer c in Customers)
            {
                if (c.Username.StartsWith(filterBy))
                {
                    ListOfCustomers.Add(c);
                }
            }

        }

        public void FilterByName(string filterBy)
        {
            ListOfCustomers.Clear();

            foreach (Customer c in Customers)
            {
                if (c.Name.StartsWith(filterBy) || c.LastName.StartsWith(filterBy))
                {
                    ListOfCustomers.Add(c);
                }
            }

        }
    }
}
