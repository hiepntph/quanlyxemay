using EF_CODEFIRST_FLUENT_API.DomainClass;
using Motorcycle_Shop_Project.Helpers;
using Motorcycle_Shop_Project.Models;
using Graduation_API.Services.ClassServices;
using Graduation_API.Services.InterfaceServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Motorcycle_Shop_Project.Controllers
{
    public class WarrantyController : Controller
    {
        private IWarrantyService iWarrantyService;

        public WarrantyController()
        {
            iWarrantyService = new WarrantyService();
        }

        [Route("/warranty/policy-over-350cc")]
        public ActionResult Policy()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("/warranty/policy-less-than-350cc")]
        public ActionResult PolicyLessThan350()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("/warranty/my-warranty")]
        public async Task<ActionResult> MyWarranty()
        {
            try
            {
                var lstWarranties = await Commons.GetAll<Warranty>(String.Concat(Commons.mylocalhost, "Warranties/get-all-warranty"));
                var data = await GetViewModel();
                var lstDatas = (from x in data
                                join y in lstWarranties on x.Product_Detail.Id equals y.Product_Detail_Id
                                select new
                                {
                                    Product_Name = x.Product.Product_Name,
                                    Start_Date = y.Start_Date,
                                    End_Date = y.End_Date,
                                    Licient_Plate = y.License_Plate,
                                    Status = y.Status,
                                    Image = x.Product_Detail.Image
                                }).ToList();
                ViewBag.Datas = lstDatas;
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("/warranty/load-product")]
        public async Task<ActionResult> Load()
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

        [Route("/warranty/WarrantyPage/{product_dt_id}")]
        public async Task<ActionResult> WarrantyPage(Guid product_dt_id)
        {
            try
            {
                SetViewBagInt();
                var data = await GetViewModel();
                ViewBag.Data = data?.FirstOrDefault(c => c.Product_Detail.Id == product_dt_id);
                Commons.setObjectAsJson(HttpContext.Session, "product_dt_id_warranty", product_dt_id);
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void SetViewBagInt(int? selected_id = null)
        {
            List<StatusDTO> StatusSTO = new List<StatusDTO>()
            {
                new StatusDTO { Status = 0, Status_Name = "Chưa bảo hành"},
                new StatusDTO { Status = 1, Status_Name = "Đang còn bảo hành"},
                new StatusDTO { Status = 2, Status_Name = "Đã hết bảo hành"},
            };
            ViewBag.Status = new SelectList(StatusSTO, "Status", "Status_Name", selected_id);
        }
        [HttpGet]
        public async Task<ActionResult> GetAllWarranty()
        {
            try
            {
                var lstObjs = await Commons.GetAll<Warranty>(String.Concat(Commons.mylocalhost, "Warranties/get-all-warranty"));
                var data = new WarrantyDTO() { WarrantyList = lstObjs };
                return View(data);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult> Search_Warranty(WarrantyDTO inv)
        {
            try
            {
                var lstWarranties = await Commons.GetAll<Warranty>(String.Concat(Commons.mylocalhost, "Warranties/get-all-warranty"));
                var lstCustomers = await Commons.GetAll<Customer>(String.Concat(Commons.mylocalhost, "Customer/get-all-Customer"));
                var results = (from w in lstWarranties join c in lstCustomers on w.Customer_Id equals c.Id where c.Customer_Name.ToLower().Contains(inv.Keyword.ToLower()) || c.Customer_Id.ToLower().Contains(inv.Keyword.ToLower()) || c.Email.ToLower().Contains(inv.Keyword.ToLower()) || w.License_Plate.ToLower().Contains(inv.Keyword.ToLower()) select w).ToList();
                var data = new WarrantyDTO() { WarrantyList = results };
                return View(data);

            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Thêm mới sản phẩm
        /// </summary>
        /// <param name="Warranty"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> WarrantyCUPage(WarrantyDTO Warranty)
        {
            try
            {
                SetViewBagInt(Warranty.Status);
                string url = "";

                //-- Lấy thông tin khách hàng
                var lstCustomers = await Commons.GetAll<Customer>(String.Concat(Commons.mylocalhost, "Customer/get-all-Customer"));
                var customer = lstCustomers.Where(c => c.Customer_Name.ToLower().Contains(Warranty.Customer_Name.ToLower()) && c.Email.ToLower().Contains(Warranty.Email.ToLower()) && c.Phone_number.Contains(Warranty.Phone_Number)).FirstOrDefault();
                if (customer == null) return Content("Error");

                //-- Lấy thông tin nhân viên
                var employee = HttpContext.Session.GetObjectFromJson<Employee>("user_info");

                //-- Lấy thông tin chi tiết sản phẩm
                var lstProduct_Details = await Commons.GetAll<Product_Detail>(String.Concat(Commons.mylocalhost, "Product_Detail/get-all-Product_Detail"));
                Guid product_dt_id = HttpContext.Session.GetObjectFromJson<Guid>("product_dt_id_warranty");
                var prd_dt = lstProduct_Details.Where(c => c.Id == product_dt_id).FirstOrDefault();
                if (prd_dt == null) return Content("Error");

                //-- Lây danh scah hóa đơn,khách hàng phải đã mua sản phẩm này thì ms cho phép bảo hành
                var lstInvoices = await Commons.GetAll<EF_CODEFIRST_FLUENT_API.DomainClass.Invoice>(String.Concat(Commons.mylocalhost, "Invoice/get-all-Invoice"));
                var lstInvoice_Details = await Commons.GetAll<EF_CODEFIRST_FLUENT_API.DomainClass.Invoice_Detail>(String.Concat(Commons.mylocalhost, "Invoice_Detail/get-all-Invoice_Detail"));
                var lstInvoiceViewModels = lstInvoices.Join(lstInvoice_Details, a => a.Id, b => b.Invoice_Id, (a, b) => new { Invoice = a, Invoice_Detail = b });
                var lstInvoiceVMs = JsonConvert.DeserializeObject<List<InvoiceViewModel>>(JsonConvert.SerializeObject(lstInvoiceViewModels));
                var exist_invoice = lstInvoiceVMs.Where(c => c.Invoice.Customer_Id == customer.Id && c.Invoice_Detail.Product_Detail_Id == prd_dt.Id).FirstOrDefault();

                //-- Nếu tất cả đều hợp lệ thì tiến hành chuẩn hóa dữ liệu
                if (ModelState.IsValid)
                {
                    if (prd_dt != null && customer != null && employee != null && exist_invoice != null)
                    {
                        var prd = new Warranty() { Customer_Id = customer.Id, Employee_Id = employee.Id, Product_Detail_Id = prd_dt.Id, Start_Date = Warranty.Start_Date, End_Date = Warranty.Start_Date.AddMonths(prd_dt.Month_Warranty), License_Plate = Warranty.License_Plate, Status = Warranty.Status, Description = Warranty.Description };

                        //-- Kiểm tra xem đã tồn tại bảo hành này chưa,nếu tồn tại rồi thì là update
                        var lstWarranties = await Commons.GetAll<Warranty>(String.Concat(Commons.mylocalhost, "Warranties/get-all-warranty"));
                        var exist_Warranty = lstWarranties.Where(c => c.Customer_Id == customer.Id && c.Product_Detail_Id == prd_dt.Id).FirstOrDefault();
                        if (exist_Warranty == null) { url = string.Concat(Commons.mylocalhost, "Warranties/add-warranty"); }
                        else { url = string.Concat(Commons.mylocalhost, "Warranties/update-warranty"); }

                        //-- GTuwir Request cho thằng kia sử lí
                        await Commons.Add_or_UpdateAsync(prd, url);
                    }
                    return RedirectToAction("Load");
                }
                else
                {
                    var data = await GetViewModel();
                    ViewBag.Data = data?.FirstOrDefault(c => c.Product_Detail.Id == product_dt_id);
                    ViewBag.Message = "Failed !";
                    return View();
                }
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
    }
}
