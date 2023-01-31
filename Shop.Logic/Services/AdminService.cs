using Microsoft.EntityFrameworkCore;
using Shop.DataModels.CustomModels;
using Shop.DataModels.Models;
using Shop.Logic.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Logic.Services
{
    public class AdminService : IAdminService
    {
        private readonly ShoppingDBContext _dbContext = null;
        public AdminService(ShoppingDBContext appDbContext)
        {
            this._dbContext = appDbContext;
        }

        public ResponseModel AdminLogin(LoginModel loginModel)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                var userData = _dbContext.AdminInfos.Where(x => x.Email == loginModel.EmailId).FirstOrDefault();
                if (userData != null)
                {
                    if (userData.Password == loginModel.Password)
                    {
                        response.Status = true;
                        response.Message = Convert.ToString(userData.Id) + "|" + userData.Name + "|" + userData.Email;
                    }
                    else
                    {
                        response.Status = false;
                        response.Message = "Your Password is Incorrect";
                    }
                }
                else
                {
                    response.Status = false;
                    response.Message = "Email not registered. Please check your Email Id";
                }

                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "An Error has occurred. Please try again !";

                return response;
            }
        }
       
        public List<ProductModel> GetProducts()
        {
            List<Category> categoryData = _dbContext.Categories.ToList();
            List<Product> productData = _dbContext.Products.ToList();
            List<ProductModel> _productList = new List<ProductModel>();
            foreach (var p in productData)
            {
                ProductModel _productModel = new ProductModel();
                _productModel.Id = p.Id;
                _productModel.Name = p.Name;
                _productModel.Price = p.Price;
                _productModel.Stock = p.Stock;
                _productModel.ImageUrl = p.ImageUrl;
                _productModel.CategoryId = p.CategoryId;
                _productModel.CategoryName = categoryData.Where(x => x.Id == p.CategoryId).Select(x => x.Name).FirstOrDefault();
                _productList.Add(_productModel);
            }

            return _productList;
        }
        public int GetNewProductId()
        {
            try
            {
                int nextProductId = _dbContext.Products.ToList().OrderByDescending(x => x.Id).Select(x => x.Id).FirstOrDefault();
                return nextProductId;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ProductModel SaveProduct(ProductModel newProduct)
        {
            try
            {
                Product _product = new Product();
                _product.Name = newProduct.Name;
                _product.Price = newProduct.Price;
                _product.ImageUrl = newProduct.ImageUrl;
                _product.CategoryId = newProduct.CategoryId;
                _product.Stock = newProduct.Stock;
                _dbContext.Add(_product);
                _dbContext.SaveChanges();
                return newProduct;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public bool UpdateProduct(ProductModel productToUpdate)
        {
            bool flag = false;
            var _product = _dbContext.Products.Where(x => x.Id == productToUpdate.Id).First();
            if (_product != null)
            {
                _product.CategoryId = productToUpdate.CategoryId;
                _product.Name = productToUpdate.Name;
                _product.Price = productToUpdate.Price;
                _dbContext.Products.Update(_product);
                _dbContext.SaveChanges();
                flag = true;
            }
            return flag;
        }
        public bool DeleteProduct(ProductModel productToDelete)
        {
            bool flag = false;
            var _product = _dbContext.Products.Where(x => x.Id == productToDelete.Id).First();
            if (_product != null)
            {
                _dbContext.Products.Remove(_product);
                _dbContext.SaveChanges();
                flag = true;
            }
            return flag;
        }
        public List<CategoryModel> GetCategories()
        {
            var data = _dbContext.Categories.ToList();
            List<CategoryModel> _categoryList = new List<CategoryModel>();
            foreach (var c in data)
            {
                CategoryModel _categoryModel = new CategoryModel();
                _categoryModel.Id = c.Id;
                _categoryModel.Name = c.Name;
                _categoryList.Add(_categoryModel);
            }
            return _categoryList;
        }
        public CategoryModel SaveCategory(CategoryModel newCategory)
        {
            try
            {
                Category _category = new Category();
                _category.Name = newCategory.Name;
                _dbContext.Add(_category);
                _dbContext.SaveChanges();
                return newCategory;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public bool UpdateCategory(CategoryModel categoryToUpdate)
        {
            bool flag = false;
            var _category = _dbContext.Categories.Where(x => x.Id == categoryToUpdate.Id).First();
            if (_category != null)
            {
                _category.Name = categoryToUpdate.Name;
                _dbContext.Categories.Update(_category);
                _dbContext.SaveChanges();
                flag = true;
            }
            return flag;
        }
        public bool DeleteCategory(CategoryModel categoryToDelete)
        {
            bool flag = false;
            var _category = _dbContext.Categories.Where(x => x.Id == categoryToDelete.Id).First();
            if (_category != null)
            {
                _dbContext.Categories.Remove(_category);
                _dbContext.SaveChanges();
                flag = true;
            }
            return flag;
        }
        public List<StockModel> GetProductStock()
        {
            List<StockModel> productStock = new List<StockModel>();

            List<Category> categoryData = _dbContext.Categories.ToList();
            List<Product> productData = _dbContext.Products.ToList();
            foreach (var p in productData)
            {
                StockModel _productModel = new StockModel();
                _productModel.Id = p.Id;
                _productModel.Name = p.Name;
                _productModel.Stock = p.Stock;
                _productModel.CategoryName = categoryData.Where(x => x.Id == p.CategoryId).Select(x => x.Name).FirstOrDefault();
                productStock.Add(_productModel);
            }

            return productStock;
        }
        public bool UpdateProductStock(StockModel stock)
        {
            bool flag = false;
            var _product = _dbContext.Products.Where(x => x.Id == stock.Id).First();
            if (_product != null)
            {
                _product.Stock = stock.Stock + stock.NewStock;
                _dbContext.Products.Update(_product);
                _dbContext.SaveChanges();
                flag = true;
            }
            return flag;
        }
        public List<CustomerOrder> GetOrders()
        {
            var _customerOrders = _dbContext.CustomerOrders.OrderByDescending(x => x.Id).ToList();
            return _customerOrders;
        }
        public List<CartModel> GetOrderDetails(string order_number)
        {
            List<CartModel> cart_details = new List<CartModel>();

            var customer_order = _dbContext.CustomerOrders.Where(x => x.OrderId == order_number).FirstOrDefault();
            if (customer_order != null)
            {
                var order_detail = _dbContext.OrderDetails.Where(x => x.OrderId == order_number).ToList();
                var product_list = _dbContext.Products.ToList();

                foreach (var order in order_detail)
                {
                    var prod = product_list.Where(x => x.Id == order.ProductId).FirstOrDefault();
                    CartModel _cartModel = new CartModel();
                    _cartModel.ProductName = prod.Name;
                    _cartModel.Price = Convert.ToInt32(order.Price);
                    _cartModel.ProductImage = prod.ImageUrl;
                    _cartModel.Quantity = Convert.ToInt32(order.Quantity);
                    cart_details.Add(_cartModel);
                }

                cart_details.FirstOrDefault().ShippingAddress = customer_order.ShippingAddress;
                cart_details.FirstOrDefault().ShippingCharges = Convert.ToInt32(customer_order.ShippingCharges);
                cart_details.FirstOrDefault().SubTotal = Convert.ToInt32(customer_order.SubTotal);
                cart_details.FirstOrDefault().Total = Convert.ToInt32(customer_order.Total);
                cart_details.FirstOrDefault().PaymentMode = customer_order.PaymentMode;
            }

            return cart_details;
        }
       
        public List<ShippingModel> GetShippingStatus()
        {
            var data = _dbContext.ShippingStatuses.ToList();
            List<ShippingModel> _shippingStatusList = new List<ShippingModel>();
            foreach (var c in data)
            {
                ShippingModel _shippingModel = new ShippingModel();
                _shippingModel.Id = c.Id;
                _shippingModel.Name = c.Name;
                _shippingStatusList.Add(_shippingModel);
            }
            return _shippingStatusList;
        }
        public ShippingModel SaveShippingStatus(ShippingModel newShippingStatus)
        {
            try
            {
                ShippingStatus _shippingStatus = new ShippingStatus();
                _shippingStatus.Name = newShippingStatus.Name;
                _dbContext.Add(_shippingStatus);
                _dbContext.SaveChanges();
                return newShippingStatus;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public bool UpdateShippingStatus(ShippingModel shippingStatusToUpdate)
        {
            bool flag = false;
            var _shipping = _dbContext.ShippingStatuses.Where(x => x.Id == shippingStatusToUpdate.Id).First();
            if (_shipping != null)
            {
                _shipping.Name = shippingStatusToUpdate.Name;
                _dbContext.ShippingStatuses.Update(_shipping);
                _dbContext.SaveChanges();
                flag = true;
            }
            return flag;
        }
        public bool DeleteShippingStatus(ShippingModel shippingStatusToDelete)
        {
            bool flag = false;
            var _shipping = _dbContext.ShippingStatuses.Where(x => x.Id == shippingStatusToDelete.Id).First();
            if (_shipping != null)
            {
                _dbContext.ShippingStatuses.Remove(_shipping);
                _dbContext.SaveChanges();
                flag = true;
            }
            return flag;
        }
        public List<string> UpdateShippingStatusForOrder(string order_number, string shippingText)
        {
            List<string> shipping_status = new List<string>();
            var order = _dbContext.CustomerOrders.Where(x => x.OrderId == order_number).FirstOrDefault();
            if (order != null)
            {
                if (order.ShippingStatus == null)
                {
                    order.ShippingStatus = Utility.getIndianDateTime() + " " + shippingText;
                }
                else
                {
                    order.ShippingStatus = order.ShippingStatus + "|" + Utility.getIndianDateTime() + " " + shippingText;
                }

                _dbContext.CustomerOrders.Update(order);
                _dbContext.SaveChanges();
                shipping_status = GetShippingStatusForOrder(order_number);
            }

            return shipping_status;
        }
        public List<string> GetShippingStatusForOrder(string order_number)
        {
            List<string> shipping_status = new List<string>();
            var order = _dbContext.CustomerOrders.Where(x => x.OrderId == order_number).FirstOrDefault();
            if (order != null && order.ShippingStatus!=null)
            {
                shipping_status = order.ShippingStatus.Split("|").ToList();
            }

            return shipping_status;
        }
    }
}




















//public async Task<ProductModel> SaveProduct(ProductModel newProduct)
//{
//    var data = await _dbContext.Products.ToListAsync();
//    List<ProductModel> _products = new List<ProductModel>();
//    return newProduct;
//}