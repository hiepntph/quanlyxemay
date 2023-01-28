using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EF_CODEFIRST_FLUENT_API.DomainClass;
using System.Collections.Generic;
using Graduation_API.Services.ClassServices;
using Graduation_API.Services.InterfaceServices;
using System;
using System.Linq;

namespace Graduation_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private IInvoiceService iInvoiceService;

        public InvoiceController()
        {
            iInvoiceService = new InvoiceService();
        }

        /// <summary>
        /// Lấy toàn bộ danh sách
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get-all-Invoice")]
        public List<Invoice> GetInvoice()
        {
            try
            {
                return iInvoiceService.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="Invoice"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("add-Invoice")]
        public bool AddInvoice([FromBody]Invoice Invoice)
        {
            try
            {
                iInvoiceService.Create(Invoice);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="Invoice"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("update-Invoice")]
        public bool UpdateInvoice([FromBody] Invoice Invoice)
        {
            try
            {
                iInvoiceService.Update(Invoice);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
