using Shop.DataModels.CustomModels;
using Shop.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Services
{
    public interface IUserPanelService
    {
        Task<bool> IsUserLoggedIn();
        Task<List<ProductModel>> GetProducts();
        Task<List<ProductModel>> GetProductByCategoryId(int categoryId);
        Task<ProductModel> SaveProduct(ProductModel newProduct);
        Task<List<CategoryModel>> GetCategories();
        Task<CategoryModel> SaveCategory(CategoryModel newCategory);
        Task<ResponseModel> RegisterUser(RegisterModel registerModel);
        Task<ResponseModel> LoginUser(LoginModel loginModel);
        Task<ResponseModel> Checkout(List<CartModel> cartItems);
        Task<List<CustomerOrder>> GetOrdersByCustomerId(int customerId);
        Task<List<CartModel>> GetOrderDetailForCustomer(int customerId, string order_number);
        Task<ResponseModel> ChangePassword(PasswordModel passwordModel);
        Task<List<string>> GetShippingStatusForOrder(string order_number);
    }
}
