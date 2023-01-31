using Shop.DataModels.CustomModels;
using Shop.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Logic.Services
{
    public interface IUserService
    {
        List<ProductModel> GetProducts();
        List<ProductModel> GetProductByCategoryId(int categoryId);
        ProductModel SaveProduct(ProductModel newProduct);
        List<CategoryModel> GetCategories();
        CategoryModel SaveCategory(CategoryModel newCategory);
        ResponseModel LoginUser(LoginModel loginModel);
        ResponseModel RegisterUser(RegisterModel registerModel);
        ResponseModel Checkout(List<CartModel> cartItems);
        List<CustomerOrder> GetOrdersByCustomerId(int customerId);
        List<CartModel> GetOrderDetailForCustomer(int customerId, string order_number);
        ResponseModel ChangePassword(PasswordModel passwordModel);
        List<string> GetShippingStatusForOrder(string order_number);
        Task<string> MakePaymentStripe(string cardNumber, int expMonth, int expYear, string cvc, decimal value);
        Task<string> MakePaymentPaypal(double total);
    }
}
