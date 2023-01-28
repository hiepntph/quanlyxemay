using EF_CODEFIRST_FLUENT_API.Repositories.InterfaceRepo;
using EF_CODEFIRST_FLUENT_API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Motorcycle_Shop_Project.Models;
using Newtonsoft.Json;
using Motorcycle_Shop_Project.Services;
using Motorcycle_Shop_Project.Helpers;
using EF_CODEFIRST_FLUENT_API.DomainClass;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Motorcycle_Shop_Project.Controllers
{
    public class InvoiceController : Controller
    {
        //public IActionResult Index()
        //{
        //    var customer = HttpContext.Session.GetObjectFromJson<EF_CODEFIRST_FLUENT_API.DomainClass.Customer>("isLogin");
        //    if(customer != null)
        //    {
        //        var result = _invoiceRepository.GetAll().Join(_invoice_DetailRepository.GetAll(), a => a.Id, b => b.Invoice_Id, (a, b) => new
        //        {
        //            Invoice = a,
        //            Invoice_Detail = b
        //        }).Where(c => c.Invoice.Customer_Id == customer.Id);
        //        return View(new Tuple<List<InvoiceViewModel>?, List<ProductViewModel>?>(JsonConvert.DeserializeObject<List<InvoiceViewModel>>(JsonConvert.SerializeObject(result)), _productService.GetAll()));
        //    }
        //    return RedirectToAction("Index", "Product");
        //}

        /// <summary>
        /// Load sản phẩm để chọn vào hóa đơn
        /// </summary>
        /// <returns></returns>
        [Route("/invoice/load-product")]
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

        [Route("/invoice/get-all-invoice")]
        public async Task<ActionResult> GetAllInvoice()
        {
            try
            {
                var employee = HttpContext.Session.GetObjectFromJson<Employee>("user_info");
                var lstInvoices = await Commons.GetAll<EF_CODEFIRST_FLUENT_API.DomainClass.Invoice>(String.Concat(Commons.mylocalhost, "Invoice/get-all-Invoice"));
                var lstInvoice_Details = await Commons.GetAll<EF_CODEFIRST_FLUENT_API.DomainClass.Invoice_Detail>(String.Concat(Commons.mylocalhost, "Invoice_Detail/get-all-Invoice_Detail"));
                if (employee == null) return RedirectToAction("Index", "Login");
                var result = lstInvoices.Join(lstInvoice_Details, a => a.Id, b => b.Invoice_Id, (a, b) => new { Invoice = a, Invoice_Detail = b });
                var data = JsonConvert.DeserializeObject<List<InvoiceViewModel>>(JsonConvert.SerializeObject(result));
                ViewBag.Dataa = JsonConvert.DeserializeObject<List<InvoiceViewModel>>(JsonConvert.SerializeObject(result));
                Console.WriteLine(data);
                return View();

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult> Search_invoice(InvoiceDTO inv)
        {
            try
            {
                string keyword = inv.Keyword == null ?"":inv.Keyword.ToLower();
                var employee = HttpContext.Session.GetObjectFromJson<Employee>("user_info");
                var lstInvoices = await Commons.GetAll<EF_CODEFIRST_FLUENT_API.DomainClass.Invoice>(String.Concat(Commons.mylocalhost, "Invoice/get-all-Invoice"));
                var lstInvoice_Details = await Commons.GetAll<EF_CODEFIRST_FLUENT_API.DomainClass.Invoice_Detail>(String.Concat(Commons.mylocalhost, "Invoice_Detail/get-all-Invoice_Detail"));
                if (employee == null) return RedirectToAction("Index", "Login");
                var result = lstInvoices.Join(lstInvoice_Details, a => a.Id, b => b.Invoice_Id, (a, b) => new { Invoice = a, Invoice_Detail = b }).Where(c=>c.Invoice.Invoice_Id.ToLower().Contains(keyword) || c.Invoice.Customer_Name.ToLower().Contains(keyword) || c.Invoice.Phone_Number.ToLower().Contains(keyword));

                ViewBag.Dataa = JsonConvert.DeserializeObject<List<InvoiceViewModel>>(JsonConvert.SerializeObject(result));
                return View();

            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Sau khi chọn sản phẩm để thêm vào hóa đơn
        /// tiến hành nhập các thông tn khác
        /// </summary>
        /// <param name="product_dt_id"></param>
        /// <returns></returns>
        [Route("/invoice/InvoicePage/{product_dt_id}")]
        public async Task<ActionResult> InvoicePage(Guid product_dt_id)
        {
            try
            {
                SetViewBagInt();
                var data = await GetViewModel();
                var result = data?.FirstOrDefault(c => c.Product_Detail.Id == product_dt_id);
                ViewBag.Data = result;

                var lstEvents = await Commons.GetAll<Event>(string.Concat(Commons.mylocalhost, "Event/get-all-Event-active"));
                var lstEventDetails = await Commons.GetAll<Event_Detail>(string.Concat(Commons.mylocalhost, "Event/get-all-Event-detail"));
                double total_money = 0, amount_reduced = 0;
                if (result != null) total_money = Convert.ToDouble(result.Product_Detail.Price);

                var exist_event = lstEventDetails.Where(c => c.Product_Detail_Id == product_dt_id).FirstOrDefault();
                if (exist_event != null)
                {
                    var eve = lstEvents.Where(c => c.Id == exist_event.Event_Id).FirstOrDefault();
                    if (eve.Discount_Unit == 0) amount_reduced = Convert.ToDouble(result.Product_Detail.Price) * Convert.ToDouble(eve.Discount_Rate) / 100;
                    else amount_reduced = Convert.ToDouble(eve.Discount_Rate);

                    total_money = Convert.ToDouble(result.Product_Detail.Price) - amount_reduced;
                }
                ViewBag.Amount_reduced = amount_reduced;
                ViewBag.Total_Money = total_money;
                Commons.setObjectAsJson(HttpContext.Session, "product_dt_id", product_dt_id);
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Thêm vào hóa đơn
        /// </summary>
        /// <param name="inv"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Create(InvoiceDTO inv)
        {
            try
            {
                SetViewBagInt(inv.Status);
                //-- Lấy thông tin khách hàng
                var lstCustomers = await Commons.GetAll<Customer>(String.Concat(Commons.mylocalhost, "Customer/get-all-Customer"));
                var customer = lstCustomers.Where(c => c.Customer_Name.ToLower().Contains(inv.Customer_Name.ToLower()) && c.Email.ToLower().Contains(inv.Email.ToLower()) && c.Phone_number.Contains(inv.Phone_Number)).FirstOrDefault();
                if (customer == null) return Content("Lỗi không tìm thấy khách hàng");

                //-- Lấy thông tin nhân viên và product_detail
                var employee = HttpContext.Session.GetObjectFromJson<Employee>("user_info");
                var lstProduct_Details = await Commons.GetAll<Product_Detail>(String.Concat(Commons.mylocalhost, "Product_Detail/get-all-Product_Detail"));
                Guid product_dt_id = HttpContext.Session.GetObjectFromJson<Guid>("product_dt_id");
                var prd_dt = lstProduct_Details.Where(c => c.Id == product_dt_id).FirstOrDefault();
                if (prd_dt == null) return Content("Lỗi không tìm thấy Sản phẩm");
                Guid invoice_id = Guid.NewGuid();
                
                if (ModelState.IsValid)
                {
                    
                    //-- Thêm vào hóa đơn
                    var invoice = new EF_CODEFIRST_FLUENT_API.DomainClass.Invoice() { Id = invoice_id, Customer_Id = customer.Id, Employee_Id = employee.Id, Invoice_Id = DateTime.Now.ToString("ddMMyy") + Commons.RandomString(4), Create_Date = DateTime.Now, Date_of_Payment = inv.Date_of_Payment, Customer_Name = inv.Customer_Name, Phone_Number = inv.Phone_Number, Address = inv.Address, Total_Money = inv.Total_Money, Amound_Paid = inv.Amound_Paid, Status = inv.Status };
                    await Commons.Add_or_UpdateAsync(invoice, String.Concat(Commons.mylocalhost, "Invoice/add-Invoice"));

                    //-- Thêm vào hóa đơn chi tiết
                    var invoice_dt = new EF_CODEFIRST_FLUENT_API.DomainClass.Invoice_Detail() { Invoice_Id = invoice_id, Product_Detail_Id = product_dt_id, Quantity = 1, Price = prd_dt.Price, Unit_price_when_reduced = 0, Total_Money = inv.Total_Money, };
                    await Commons.Add_or_UpdateAsync(invoice_dt, String.Concat(Commons.mylocalhost, "Invoice_Detail/add-invoice-detail"));

                    //-- Giảm số lượng còn lại xuống
                    await Commons.Add_or_UpdateAsync(prd_dt, String.Concat(Commons.mylocalhost, "Product_Detail/update-Product_Detail-quantity-instock"));
                    ViewBag.Message = "Successfully !";
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
            catch (Exception e)
            {
                return Content(e.Message);
            }
        }

        public void SetViewBagInt(int? selected_id = null)
        {
            List<StatusDTO> StatusSTO = new List<StatusDTO>()
            {
                new StatusDTO { Status = 0, Status_Name = "Đã thanh toán"},
                new StatusDTO { Status = 1, Status_Name = "Chưa thanh toán"},
                new StatusDTO { Status = 2, Status_Name = "Thanh toán chưa đủ"},
            };
            ViewBag.Status = new SelectList(StatusSTO, "Status", "Status_Name", selected_id);
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
