using Examen.MobileApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Examen.MobileApp.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        private DataService dataService;

        public ObservableCollection<Product> ListaProductos { get; set; }
        public Product Producto { get; set; }

        public ProductViewModel()
        {
            ListaProductos = new ObservableCollection<Product>();
            dataService = new DataService();
        }

        public Boolean GetProducts()
        {
            Boolean result = true;

            try
            {
                ListaProductos.Clear();

                foreach (var item in dataService.GetProductsAsync().Result)
                {
                    ListaProductos.Add(item);
                }
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }

        public Boolean GetProductById(Int32 iID)
        {
            Boolean result = true;

            try
            {
                Producto = dataService.GetProductById(iID);
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }

        public Boolean InsertProduct(Product product)
        {
            Boolean bResult = true;

            try
            {
                Producto = dataService.InsertProduct(JsonConvert.SerializeObject(product));
            }
            catch (Exception)
            {
                bResult = false;
            }

            return bResult;
        }

        public Boolean UpdateProduct(Product product)
        {
            Boolean bResult = true;

            try
            {
                String sResult = dataService.UpdateProduct(product.Id, JsonConvert.SerializeObject(product));
            }
            catch (Exception)
            {
                bResult = false;
            }

            return bResult;
        }

        public Boolean DeleteProduct(Int32 iID)
        {
            Boolean bResult = true;

            try
            {
                String sResult = dataService.DeleteProduct(iID);
            }
            catch (Exception)
            {
                bResult = false;
            }

            return bResult;
        }
    }
}
