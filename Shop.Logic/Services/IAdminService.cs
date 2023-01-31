using Shop.DataModels.CustomModels;
using Shop.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Logic.Services
{
    public interface IAdminService
    {
        ResponseModel AdminLogin(LoginModel loginModel);
        int GetNewProductId();
        List<ProductModel> GetProducts();
        List<StockModel> GetProductStock();
        ProductModel SaveProduct(ProductModel newProduct);
        bool UpdateProduct(ProductModel productToUpdate);
        bool DeleteProduct(ProductModel productToDelete);
        List<CategoryModel> GetCategories();
        CategoryModel SaveCategory(CategoryModel newCategory);
        bool UpdateCategory(CategoryModel categoryToUpdate);
        bool DeleteCategory(CategoryModel categoryToDelete);
        List<CustomerOrder> GetOrders();
        List<CartModel> GetOrderDetails(string order_number);
        bool UpdateProductStock(StockModel stock);
        List<ShippingModel> GetShippingStatus();
        ShippingModel SaveShippingStatus(ShippingModel newShippingStatus);
        bool UpdateShippingStatus(ShippingModel shippingStatusToUpdate);
        bool DeleteShippingStatus(ShippingModel shippingStatusToDelete);
        List<string> UpdateShippingStatusForOrder(string order_number, string shippingText);
        List<string> GetShippingStatusForOrder(string order_number);
    }
}
