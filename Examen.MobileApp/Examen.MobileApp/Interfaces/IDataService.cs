using Examen.MobileApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Examen.MobileApp.Interfaces
{
    public interface IDataService
    {
        Task<ObservableCollection<Product>> GetProductsAsync();
        Product GetProductById(Int32 iID);
        Product InsertProduct(String sProductJson);
        String UpdateProduct(Int32 iID, String sProductJson);
        String DeleteProduct(Int32 iID);
    }
}
