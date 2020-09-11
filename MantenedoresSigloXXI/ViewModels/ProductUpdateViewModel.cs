using MantenedoresSigloXXI.Contracts.Services;
using MantenedoresSigloXXI.Contracts.ViewModels;
using MantenedoresSigloXXI.Controllers;
using MantenedoresSigloXXI.Helpers;
using MantenedoresSigloXXI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MantenedoresSigloXXI.ViewModels
{
    public class ProductUpdateViewModel : Observable, INavigationAware
    {
        private readonly INavigationService _navigationService;
        private ICommand _editProduct;
        private ICommand _deleteProduct;

        public ICommand EditProduct => _editProduct ?? (_editProduct = new RelayCommand(OnEditProduct));
        public ICommand DeleteProduct => _deleteProduct ?? (_deleteProduct = new RelayCommand(OnDeleteProduct));
        // Product _updatingProduct;
        //Observable name = new Observable();
        private Product originalProduct;
        private Product updatingProduct;
        public Product UpdatingProduct
        {
            get { return updatingProduct; }
            set
            {
                if (updatingProduct != value)
                {
                    updatingProduct = value;
                    OnPropertyChanged("UpdatingProduct");
                }
            }
        }

        public ProductUpdateViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        private void OnDeleteProduct()
        {
            if(UpdatingProduct != null)
            {
                MessageBoxResult result = MessageBox.Show(Properties.Resources.WarningMsgBoxDeleteProduct, Properties.Resources.WarningMsgBoxTitle, MessageBoxButton.OKCancel);
                switch (result)
                {
                    case MessageBoxResult.OK:
                        ProductController.DeleteProduct(UpdatingProduct);
                        Back();
                        break;
                    case MessageBoxResult.Cancel:
                        break;

                }
            }
            else
            {
                MessageBox.Show(Properties.Resources.WarningMsgBoxChooseOneProduct, Properties.Resources.WarningMsgBoxTitle, MessageBoxButton.OK);
            }
            
            
            
        }

        private void OnEditProduct()
        {
            if(IsValid())
            { 
                MessageBoxResult result = MessageBox.Show(Properties.Resources.WarningMsgBoxEdit, Properties.Resources.WarningMsgBoxTitle, MessageBoxButton.OKCancel);
                switch (result)
                {
                    case MessageBoxResult.OK:
                        ProductController.EditProduct(UpdatingProduct);
                        Back();
                        break;
                    case MessageBoxResult.Cancel:
                        break;

                }
            }
    
        }

        public bool IsValid()
        {
            /*if (originalProduct.Name == updatingProduct.Name &&
                originalProduct.Email == updatingProduct.Email &&
                originalProduct.LastName == updatingProduct.LastName)
            {
                Debug.WriteLine("son iguales");
                Back();
                return false;
            }
            var email = new EmailAddressAttribute();
            if (!email.IsValid(updatingProduct.Email))
            {
                MessageBox.Show(Properties.Resources.WarningMsgBoxInvalidEmail,Properties.Resources.WarningMsgBoxTitle , MessageBoxButton.OK);
                return false;
            }

            if (!Regex.IsMatch(updatingProduct.Name, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show(Properties.Resources.WarningMsgBoxInvalidName, Properties.Resources.WarningMsgBoxTitle, MessageBoxButton.OK);
                return false;
            }
                
            if (!Regex.IsMatch(updatingProduct.LastName, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show(Properties.Resources.WarningMsgBoxInvalidLastName, Properties.Resources.WarningMsgBoxTitle, MessageBoxButton.OK);
                return false;
            }*/
            return true;
        }

        public void OnNavigatedFrom()
        {
            
        }

        public void OnNavigatedTo(object sender)
        {
            UpdatingProduct = (Product)sender;
            originalProduct = new Product
            {
                //UpdatingProduct;
            };

        }


        public void Back()
        {
            _navigationService.GoBack();
        }
    }
}
