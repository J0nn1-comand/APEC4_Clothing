using Shop.DataModels.CustomModels;
using Shop.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Admin.Services
{
    public interface IAdminPanelService
    {
        Task<ResponseModel> AdminLogin(LoginModel loginModel);
        Task<List<ProductModel>> GetProducts();
        Task<List<StockModel>> GetProductStock();
        Task<StockModel> AddProductStock(StockModel stock);
        Task<ProductModel> SaveProduct(ProductModel newProduct);
        Task<bool> UpdateProduct(ProductModel productToUpdate);
        Task<bool> DeleteProduct(ProductModel productToDelete);
        Task<List<CategoryModel>> GetCategories();
        Task<CategoryModel> SaveCategory(CategoryModel newCategory);
        Task<bool> UpdateCategory(CategoryModel categoryToUpdate);
        Task<bool> DeleteCategory(CategoryModel categoryToDelete);
        Task<List<CustomerOrder>> GetOrders();
        Task<List<CartModel>> GetOrderDetails(string order_number);
        Task<bool> UpdateProductStock(StockModel productStock);
        Task<List<ShippingModel>> GetShippingStatus();
        Task<ShippingModel> SaveShippingStatus(ShippingModel newShippingStatus);
        Task<bool> UpdateShippingStatus(ShippingModel shippingStatusToUpdate);
        Task<bool> DeleteShippingStatus(ShippingModel shippingStatusToDelete);
        Task<List<string>> UpdateShippingStatusForOrder(string orderNumber, string shippingText);
        Task<List<string>> GetShippingStatusForOrder(string order_number);
    }
}
