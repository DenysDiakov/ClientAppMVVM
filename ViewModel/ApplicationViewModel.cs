using ClientAppMVVM.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientAppMVVM.ViewModel
{
    class ApplicationViewModel : INotifyPropertyChanged
    {
        private Product selectedProduct;

        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<Product> CartProducts { get; set; }

        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
                OnPropertyChanged("SelectedProduct");
            }
        }

        private int sum;
        public int Sum
        {
            get
            {
                return sum;
            }
            set
            {
                sum = value;
                OnPropertyChanged("Sum");
            }
        }

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand(obj =>
                    {                        
                        var result = Task.Run(async () => await SendPostRequest(SelectedProduct));
                        result.Wait();
                        var result2 = Task.Run(async () => await SendGetRequestToCart());
                        result2.Wait();

                        Sum = CalculateSum();
                        OnPropertyChanged("CartProducts");
                        OnPropertyChanged("Sum");
                    }));
            }
        }

        private RelayCommand reloadCommand;
        public RelayCommand ReloadCommand
        {
            get
            {
                return reloadCommand ??
                    (reloadCommand = new RelayCommand(obj =>
                    { 
                        var result2 = Task.Run(async () => await SendGetRequestToCart());
                        result2.Wait();

                        Sum = CalculateSum();

                        OnPropertyChanged("CartProducts");
                        OnPropertyChanged("Sum");

                    }));
            }
        }


        private RelayCommand deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                    (deleteCommand = new RelayCommand(obj =>
                    {
                        Request.DeleteRequest(SelectedProduct);

                        var result = Task.Run(async () => await SendGetRequestToCart());
                        result.Wait();

                        Sum = CalculateSum();

                        OnPropertyChanged("CartProducts");
                        OnPropertyChanged("Sum");
                    }
                    ));
            }
        }



        public ApplicationViewModel()
        {
            var result = Task.Run(async () => await GetAllProducts());
            result.Wait();

            var result2 = Task.Run(async () => await SendGetRequestToCart());
            result2.Wait();

            Sum = CalculateSum();
            OnPropertyChanged("Sum");


        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }


        private async Task GetAllProducts()
        {
            Products = await Request.SendGetRequest();
            OnPropertyChanged("Products");
        } 
        
        private async Task SendPostRequest(Product selectedProduct)
        {
           await Request.SendPostRequest(selectedProduct);
        }

        private async Task SendGetRequestToCart()
        {
            CartProducts = await Request.SendGetRequestToCart();
            OnPropertyChanged("CartProducts");
        }

        private int CalculateSum()
        {
            int price = 0;

            foreach (var product in CartProducts)
            {
                if (product != null)
                    price += product.Price;
            }
            return price;
        }
    }

}