using Microsoft.AspNetCore.Mvc;
using Motorcycle_Shop_Project.Models;
using Newtonsoft.Json;
using EF_CODEFIRST_FLUENT_API.Repositories.InterfaceRepo;
using EF_CODEFIRST_FLUENT_API.Repositories;
using EF_CODEFIRST_FLUENT_API.DomainClass;
using Motorcycle_Shop_Project.Helpers;
using NPOI.SS.UserModel;

namespace Motorcycle_Shop_Project.Controllers
{
    public class ProductController : Controller
    {
        /// <summary>
        /// Hiển thị dữ liệu 
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            try
            {
                var lstCategories = await Commons.GetAll<Category>(String.Concat(Commons.mylocalhost, "Category/get-all-Category"));
                var data = await GetViewModel();
                return View(new Tuple<List<ProductViewModel>?, List<Category>>(data, lstCategories));
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Sự kiện lọc theo tên loại sản phẩm
        /// </summary>
        /// <param name="category_name"></param>
        /// <returns></returns>
        public async Task<ActionResult> FilterByCategoryName(string category_name)
        {
            try
            {
                var lstCategories = await Commons.GetAll<Category>(String.Concat(Commons.mylocalhost, "Category/get-all-Category"));
                var data = await getViewModel_ByCategoryName(category_name);

                //var data = await FilterByCategoryName(category_name);
                return View(new Tuple<List<ProductViewModel>?, List<Category>>(data, lstCategories));
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Sự kiện lọc theo tên loại sản phẩm
        /// </summary>
        /// <param name="category_name"></param>
        /// <returns></returns>
        public async Task<ActionResult> FilterByCategoryNameForInvoice(string category_name)
        {
            try
            {
                var lstCategories = await Commons.GetAll<Category>(String.Concat(Commons.mylocalhost, "Category/get-all-Category"));
                var data = await getViewModel_ByCategoryName(category_name);

                //var data = await FilterByCategoryName(category_name);
                return View(new Tuple<List<ProductViewModel>?, List<Category>>(data, lstCategories));
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Sự kiện lọc theo tên loại sản phẩm
        /// </summary>
        /// <param name="category_name"></param>
        /// <returns></returns>
        public async Task<ActionResult> FilterByCategoryNameForWarranty(string category_name)
        {
            try
            {
                var lstCategories = await Commons.GetAll<Category>(String.Concat(Commons.mylocalhost, "Category/get-all-Category"));
                var data = await getViewModel_ByCategoryName(category_name);

                //var data = await FilterByCategoryName(category_name);
                return View(new Tuple<List<ProductViewModel>?, List<Category>>(data, lstCategories));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("/product/product-hot")]
        public async Task<ActionResult> ProductHot()
        {
            try
            {
                var lstCategories = await Commons.GetAll<Category>(String.Concat(Commons.mylocalhost, "Category/get-all-Category"));
                var data = await GetProductEvent();
                Console.WriteLine(data);
                //var data = await FilterByCategoryName(category_name);
                return View(new Tuple<List<ProductViewModel>?, List<Category>>(data, lstCategories));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("/productdetail/{product_dt_id}")]
        public async Task<IActionResult> ProductDetail(Guid product_dt_id)
        {
            try
            {
                var lstSaveProducts = await Commons.GetAll<EF_CODEFIRST_FLUENT_API.DomainClass.Save_Product>(String.Concat(Commons.mylocalhost, "Save_Product/get-all-save-product"));
                var lstSave_Product_Details = await Commons.GetAll<EF_CODEFIRST_FLUENT_API.DomainClass.Save_Product_Detail>(String.Concat(Commons.mylocalhost, "Save_Product_Detail/get-all-save-product-detail"));
                var customer = HttpContext.Session.GetObjectFromJson<Customer>("user_info");
                if (customer != null)
                {
                    var saveProduct = lstSaveProducts.FirstOrDefault(c => c.Customer_Id == customer?.Id);
                    if (saveProduct != null)
                    {
                        var result = lstSave_Product_Details.Where(c => c.Product_Detail_Id == product_dt_id && c.Save_Product_Id == saveProduct.Id).FirstOrDefault();
                        if (result != null)
                        {
                            ViewBag.IsExists = "Exist";
                        }
                        //if (lstSave_Product_Details.Any(c => c.Product_Detail_Id == product_dt_id && c.Save_Product_Id == saveProduct.Id)) ViewBag.IsExists = "Exist";
                    }
                }
                var data = await GetViewModel();
                return View(data?.FirstOrDefault(c => c.Product_Detail.Id == product_dt_id));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IActionResult> Cart()
        {
            try
            {
                var lstSaveProducts = await Commons.GetAll<EF_CODEFIRST_FLUENT_API.DomainClass.Save_Product>(String.Concat(Commons.mylocalhost, "Save_Product/get-all-save-product"));
                var lstSave_Product_Details = await Commons.GetAll<EF_CODEFIRST_FLUENT_API.DomainClass.Save_Product_Detail>(String.Concat(Commons.mylocalhost, "Save_Product_Detail/get-all-save-product-detail"));
                var lstCategories = await Commons.GetAll<Category>(String.Concat(Commons.mylocalhost, "Category/get-all-Category"));
                var customer = HttpContext.Session.GetObjectFromJson<Customer>("user_info");
                if (customer == null) return RedirectToAction("Index", "Login");
                if (customer != null)
                {
                    ViewBag.Categories = lstCategories;
                    var cart = lstSave_Product_Details.Join(lstSaveProducts, a => a.Save_Product_Id, b => b.Id, (a, b) => new
                    {
                        Save_Product_Detail = a,
                        Save_Product = b
                    }).Where(c => c.Save_Product.Customer_Id == customer.Id);

                    var data = await GetViewModel();
                    return View(new Tuple<List<ProductViewModel>?, List<CartViewModel>?>(data, Commons.ConverObject<List<CartViewModel>>(cart)));
                }
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("product/addcart/{customer_id}/{product_dt_id}")]
        public async Task<IActionResult> AddCart(Guid customer_id, Guid product_dt_id)
        {
            try
            {
                //-- Lấy dữ liệu từ api
                var lstSaveProducts = await Commons.GetAll<EF_CODEFIRST_FLUENT_API.DomainClass.Save_Product>(String.Concat(Commons.mylocalhost, "Save_Product/get-all-save-product"));
                var lstProduct_Details = await Commons.GetAll<Product_Detail>(String.Concat(Commons.mylocalhost, "Product_Detail/get-all-Product_Detail"));
               
                //-- Kiểm tra khách hàng này đã lưu sản phẩm nào chưa,chưa thì add vô save_product,có r thì add vô save_product_detail
                if (!lstSaveProducts.Any(c => c.Customer_Id == customer_id))
                {
                    var save_prd = new EF_CODEFIRST_FLUENT_API.DomainClass.Save_Product() { Customer_Id = customer_id, Save_Date = DateTime.Now, Save_Product_Id = Commons.RandomString(6), Description = "Được lưu ngày " + DateTime.Now.ToString("dd/MM/yyyy") };
                    await Commons.Add_or_UpdateAsync(save_prd, String.Concat(Commons.mylocalhost, "Save_Product/add-save-product"));
                }

                //-- kiểm tra lần nữa trước khi tiến hành add vào save_product_detail
                var SaveProductList = await Commons.GetAll<EF_CODEFIRST_FLUENT_API.DomainClass.Save_Product>(String.Concat(Commons.mylocalhost, "Save_Product/get-all-save-product"));
                var lstSave_Product_Details = await Commons.GetAll<EF_CODEFIRST_FLUENT_API.DomainClass.Save_Product_Detail>(String.Concat(Commons.mylocalhost, "Save_Product_Detail/get-all-save-product-detail"));
                var cart = SaveProductList.FirstOrDefault(c => c.Customer_Id == customer_id);
                var product = lstProduct_Details.FirstOrDefault(c => c.Id == product_dt_id);

                if (product != null && cart != null)
                {
                    //-- Kiểm tra xem khách hàng này đã lưu sản phẩm này chưa,nếu đã lưu r k cho lưu nữa,nếu chưa có thì ms cho lưu
                    var save_product_dt = lstSave_Product_Details.Where(c => c.Save_Product_Id == cart.Id && c.Product_Detail_Id == product_dt_id).FirstOrDefault();
                    if (save_product_dt == null)
                    {
                        var save_prd_dt = new EF_CODEFIRST_FLUENT_API.DomainClass.Save_Product_Detail() { Product_Detail_Id = product_dt_id, Save_Product_Id = cart.Id, Unit_Price = (decimal)product.Price };
                        await Commons.Add_or_UpdateAsync(save_prd_dt, String.Concat(Commons.mylocalhost, "Save_Product_Detail/add-save-product-detail"));
                    }
                }
                
                var data = await GetViewModel();
                //View("ProductDetail", data?.FirstOrDefault(c => c.Product_Detail.Id == product_dt_id));
                return RedirectToAction("ProductDetail", new { product_dt_id = product_dt_id });
            }
            catch (Exception ex)
            {
                return Content("[Lỗi không xác định] " + ex.Message);
            }
        }

        [Route("product/removecart/{customer_id}/{product_dt_id}")]
        public async Task<IActionResult> RemoveCart(Guid customer_id, Guid product_dt_id)
        {
            try
            {
                //-- Lấy danh sách
                var lstSaveProducts = await Commons.GetAll<EF_CODEFIRST_FLUENT_API.DomainClass.Save_Product>(String.Concat(Commons.mylocalhost, "Save_Product/get-all-save-product"));
                var lstSave_Product_Details = await Commons.GetAll<EF_CODEFIRST_FLUENT_API.DomainClass.Save_Product_Detail>(String.Concat(Commons.mylocalhost, "Save_Product_Detail/get-all-save-product-detail"));
                var lstCategories = await Commons.GetAll<Category>(String.Concat(Commons.mylocalhost, "Category/get-all-Category"));
                var saveProduct = lstSaveProducts.FirstOrDefault(c => c.Customer_Id == customer_id);
                if (saveProduct != null)
                {
                    //-- Xóa khỏi lưu chi tiết
                    var result = lstSave_Product_Details.FirstOrDefault(c => c.Product_Detail_Id == product_dt_id && c.Save_Product_Id == saveProduct.Id);
                    await Commons.Add_or_UpdateAsync(result, String.Concat(Commons.mylocalhost, "Save_Product_Detail/delete-save-product-detail"));
                }
                var data = await GetViewModel();
                return View("ProductDetail", data?.FirstOrDefault(c => c.Product_Detail.Id == product_dt_id));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [NonAction]
        private async Task<List<ProductViewModel>?> GetViewModel()
        {
            try
            {
                //-- Lấy dữ liệu từ api
                var lstProducts = await Commons.GetAll<Product>(String.Concat(Commons.mylocalhost, "ProductMGRAPI/get-all-product"));
                var lstProduct_Details = await Commons.GetAll<Product_Detail>(String.Concat(Commons.mylocalhost, "Product_Detail/get-all-Product_Detail"));
                var lstCategories = await Commons.GetAll<Category>(String.Concat(Commons.mylocalhost, "Category/get-all-Category"));
                var lstProducers = await Commons.GetAll<Producer>(String.Concat(Commons.mylocalhost, "Producer/get-all-Producer"));
                var lstColors = await Commons.GetAll<Color>(String.Concat(Commons.mylocalhost, "Color/get-all-Color"));

                //-- Join dữ liệu
                var data = from prddts in lstProduct_Details join prds in lstProducts on prddts.Product_Id equals prds.Id join cols in lstColors on prddts.Color_Id equals cols.Id join cats in lstCategories on prddts.Category_Id equals cats.Id join prcs in lstProducers on prddts.Producer_Id equals prcs.Id select new { Producers = prcs, Category = cats, Color = cols, Product = prds, Product_Detail = prddts };
                
                //var result = _product_DetailRepository.GetAll().Join(_productRepository.GetAll(), a => a.Product_Id, b => b.Id, (a, b) => new { a, b }).Join(_colorRepository.GetAll(), c => c.a.Color_Id, d => d.Id, (c, d) => new { c, d }).Join(_categoryRepository.GetAll(), e => e.c.a.Category_Id, f => f.Id, (e, f) => new { e, f }).Join(_producerRepository.GetAll(), g => g.e.c.a.Producer_Id, h => h.Id, (g, h) => new { g, h }).Select(i => new { Producer = i.h, Category = i.g.f, Color = i.g.e.d, Product = i.g.e.c.b, Product_Detail = i.g.e.c.a });
                return Commons.ConverObject<List<ProductViewModel>>(data);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Phương thức Filter sản phẩm theo category
        /// </summary>
        /// <param name="category_name"></param>
        /// <returns></returns>
        private async Task<List<ProductViewModel>?> getViewModel_ByCategoryName(string category_name)
        {
            try
            {
                //-- Lấy dữ liệu từ api
                var lstProducts = await Commons.GetAll<Product>(String.Concat(Commons.mylocalhost, "ProductMGRAPI/get-all-product"));
                var lstProduct_Details = await Commons.GetAll<Product_Detail>(String.Concat(Commons.mylocalhost, "Product_Detail/get-all-Product_Detail"));
                var lstCategories = await Commons.GetAll<Category>(String.Concat(Commons.mylocalhost, "Category/get-all-Category"));
                var lstProducers = await Commons.GetAll<Producer>(String.Concat(Commons.mylocalhost, "Producer/get-all-Producer"));
                var lstColors = await Commons.GetAll<Color>(String.Concat(Commons.mylocalhost, "Color/get-all-Color"));

                var data = from prddts in lstProduct_Details join prds in lstProducts on prddts.Product_Id equals prds.Id join cols in lstColors on prddts.Color_Id equals cols.Id join cats in lstCategories on prddts.Category_Id equals cats.Id join prcs in lstProducers on prddts.Producer_Id equals prcs.Id where cats.Category_Name.ToLower() == category_name.ToLower() select new { Producers = prcs, Category = cats, Color = cols, Product = prds, Product_Detail = prddts };
                return Commons.ConverObject<List<ProductViewModel>>(data);
            }
            catch (Exception)
            {

                throw;
            }
        }


        private async Task<List<ProductViewModel>?> GetProductEvent()
        {
            try
            {
                //-- Lấy dữ liệu từ api
                var lstProducts = await Commons.GetAll<Product>(String.Concat(Commons.mylocalhost, "ProductMGRAPI/get-all-product"));
                var lstProduct_Details = await Commons.GetAll<Product_Detail>(String.Concat(Commons.mylocalhost, "Product_Detail/get-all-Product_Detail"));
                var lstCategories = await Commons.GetAll<Category>(String.Concat(Commons.mylocalhost, "Category/get-all-Category"));
                var lstProducers = await Commons.GetAll<Producer>(String.Concat(Commons.mylocalhost, "Producer/get-all-Producer"));
                var lstColors = await Commons.GetAll<Color>(String.Concat(Commons.mylocalhost, "Color/get-all-Color"));
                var lstEvents = await Commons.GetAll<Event>(string.Concat(Commons.mylocalhost, "Event/get-all-Event-active"));
                var lstEventDetails = await Commons.GetAll<Event_Detail>(string.Concat(Commons.mylocalhost, "Event/get-all-Event-detail"));

                //-- Join dữ liệu
                var data = from prddts in lstProduct_Details
                           join prds in lstProducts on prddts.Product_Id equals prds.Id 
                           join cols in lstColors on prddts.Color_Id equals cols.Id 
                           join cats in lstCategories on prddts.Category_Id equals cats.Id 
                           join prcs in lstProducers on prddts.Producer_Id equals prcs.Id
                           from evdts in lstEventDetails where evdts.Product_Detail_Id == prddts.Id
                           join evts in lstEvents on evdts.Event_Id equals evts.Id
                           select new { Producers = prcs, Category = cats, Color = cols, Product = prds, Product_Detail = prddts,Event = evts,Event_Detail = evdts };
                Console.WriteLine(data);
                //var result = _product_DetailRepository.GetAll().Join(_productRepository.GetAll(), a => a.Product_Id, b => b.Id, (a, b) => new { a, b }).Join(_colorRepository.GetAll(), c => c.a.Color_Id, d => d.Id, (c, d) => new { c, d }).Join(_categoryRepository.GetAll(), e => e.c.a.Category_Id, f => f.Id, (e, f) => new { e, f }).Join(_producerRepository.GetAll(), g => g.e.c.a.Producer_Id, h => h.Id, (g, h) => new { g, h }).Select(i => new { Producer = i.h, Category = i.g.f, Color = i.g.e.d, Product = i.g.e.c.b, Product_Detail = i.g.e.c.a });
                return Commons.ConverObject<List<ProductViewModel>>(data);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
