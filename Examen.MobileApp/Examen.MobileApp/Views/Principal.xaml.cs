using Examen.MobileApp.Models;
using Examen.MobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Examen.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Principal : ContentPage
    {
        private ProductViewModel productViewModel;

        public Principal()
        {
            InitializeComponent();

            BindingContext = productViewModel = new ProductViewModel();

            //Get
            productViewModel.GetProducts();
            //GetById
            //productViewModel.GetProductById(1);
            //Insert
            //productViewModel.InsertProduct(new Product { Name = "Pepsi", Price = 14.50 });
            //Update
            //productViewModel.UpdateProduct(new Product { Id = 1, Name = "Pepsi Kick", Price = 14.50 });
            //Delete
            //productViewModel.DeleteProduct(1);
        }
    }
}