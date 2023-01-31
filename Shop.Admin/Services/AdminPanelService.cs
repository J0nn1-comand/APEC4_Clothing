using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Shop.DataModels.CustomModels;
using Shop.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Shop.Admin.Services
{
    public class AdminPanelService : IAdminPanelService
    {
        private readonly HttpClient httpClient;
        public AdminPanelService(HttpClient _httpClient)
        {
            this.httpClient = _httpClient;
        }



        public async Task<ResponseModel> AdminLogin(LoginModel loginModel)
        {
            return await httpClient.PostJsonAsync<ResponseModel>("api/admin/AdminLogin", loginModel);
        }
        public async Task<List<ProductModel>> GetProducts()
        {
            return await httpClient.GetJsonAsync<List<ProductModel>>("api/admin/GetProducts");
        }
        public async Task<List<StockModel>> GetProductStock()
        {
            return await httpClient.GetJsonAsync<List<StockModel>>("api/admin/GetProductStock");
        }
        public async Task<StockModel> AddProductStock(StockModel stock)
        {
            return await httpClient.PostJsonAsync<StockModel>("api/admin/AddProductStock", stock);
        }
        public async Task<ProductModel> SaveProduct(ProductModel newProduct)
        {
            return await httpClient.PostJsonAsync<ProductModel>("api/admin/SaveProduct", newProduct);
        }
        public async Task<bool> UpdateProduct(ProductModel productToUpdate)
        {
            return await httpClient.PostJsonAsync<bool>("api/admin/UpdateProduct", productToUpdate);
        }
        public async Task<bool> DeleteProduct(ProductModel productToDelete)
        {
            try
            {
                return await httpClient.PostJsonAsync<bool>("api/admin/DeleteProduct", productToDelete);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<CategoryModel>> GetCategories()
        {
            return await httpClient.GetJsonAsync<List<CategoryModel>>("api/admin/GetCategories");
        }
        public async Task<CategoryModel> SaveCategory(CategoryModel newCategory)
        {
            return await httpClient.PostJsonAsync<CategoryModel>("api/admin/SaveCategory", newCategory);
        }
        public async Task<bool> UpdateCategory(CategoryModel categoryToUpdate)
        {
            return await httpClient.PostJsonAsync<bool>("api/admin/UpdateCategory", categoryToUpdate);
        }
        public async Task<bool> DeleteCategory(CategoryModel categoryToDelete)
        {
            return await httpClient.PostJsonAsync<bool>("api/admin/DeleteCategory", categoryToDelete);
        }
        public async Task<List<CustomerOrder>> GetOrders()
        {
            return await httpClient.GetJsonAsync<List<CustomerOrder>>("api/admin/GetOrders/");
        }
        public async Task<List<CartModel>> GetOrderDetails(string order_number)
        {
            return await httpClient.GetJsonAsync<List<CartModel>>("api/admin/GetOrderDetails/?order_number=" + order_number);
        }
        public async Task<bool> UpdateProductStock(StockModel productStock)
        {
            return await httpClient.PostJsonAsync<bool>("api/admin/UpdateProductStock", productStock);
        }
        public async Task<List<ShippingModel>> GetShippingStatus()
        {
            return await httpClient.GetJsonAsync<List<ShippingModel>>("api/admin/GetShippingStatus");
        }
        public async Task<ShippingModel> SaveShippingStatus(ShippingModel newShippingStatus)
        {
            return await httpClient.PostJsonAsync<ShippingModel>("api/admin/SaveShippingStatus", newShippingStatus);
        }
        public async Task<bool> UpdateShippingStatus(ShippingModel shippingStatusToUpdate)
        {
            return await httpClient.PostJsonAsync<bool>("api/admin/UpdateShippingStatus", shippingStatusToUpdate);
        }
        public async Task<bool> DeleteShippingStatus(ShippingModel shippingStatusToDelete)
        {
            return await httpClient.PostJsonAsync<bool>("api/admin/DeleteShippingStatus", shippingStatusToDelete);
        }
        public async Task<List<string>> UpdateShippingStatusForOrder(string orderNumber, string shippingText)
        {
            return await httpClient.GetJsonAsync<List<string>>("api/admin/UpdateShippingStatusForOrder/?order_number=" + orderNumber + "&shippingText=" + shippingText);
        }
        public async Task<List<string>> GetShippingStatusForOrder(string order_number)
        {
            return await httpClient.GetJsonAsync<List<string>>("api/admin/GetShippingStatusForOrder/?order_number=" + order_number);
        }
    }
}
