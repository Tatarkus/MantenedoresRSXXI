using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Documents;
using MantenedoresSigloXXI.Contracts.ViewModels;
using MantenedoresSigloXXI.Controllers;
using MantenedoresSigloXXI.Core.Contracts.Services;
using MantenedoresSigloXXI.Core.Models;
using MantenedoresSigloXXI.Helpers;
using MantenedoresSigloXXI.Models;

namespace MantenedoresSigloXXI.ViewModels
{
    public class CustomersViewMode : Observable, INavigationAware
    {
        private Customer _selected;
        public List<Customer> Customers;

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

        public CustomersViewMode()
        {
            Initialize();
        }

        private void Initialize()
        {
            Customers = CustomerController.DeserializeCustomers();
            listOfCustomers = new ObservableCollection<Customer>(Customers);
            
            //Customers = CustomerController.DeserializeCustomers();
        }

        public void OnNavigatedTo(object parameter)
        {
            //We call the controller here to get the json
            //var data = await _sampleDataService.GetMasterDetailDataAsync();

            JsonResult jsonresult = new JsonResult();
            //Customers = CustomerController.DeserializeCustomers();
            //Gets the list of Customers from an example json



        }

        public void OnNavigatedFrom()
        {

           
        }

        public void FilterByUsername(string filterBy)
        {
            listOfCustomers.Clear();

            foreach (Customer c in Customers)
            {
                if (c.Username.StartsWith(filterBy))
                {
                    listOfCustomers.Add(c);
                }
            }

        }

        public void FilterByName(string filterBy)
        {
            listOfCustomers.Clear();

            foreach (Customer c in Customers)
            {
                if (c.Name.StartsWith(filterBy) || c.LastName.StartsWith(filterBy))
                {
                    listOfCustomers.Add(c);
                }
            }

        }
    }
}
