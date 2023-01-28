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
    public class Invoice_DetailController : ControllerBase
    {
        private IInvoice_DetailService iInvoice_DetailService;
        // GET: api/<SanPhamsController>

        public Invoice_DetailController()
        {
            iInvoice_DetailService = new Invoice_DetailService();
        }

        /// <summary>
        /// Lấy toàn bộ danh sách
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get-all-Invoice_Detail")]
        public List<Invoice_Detail> GetInvoice_Detail()
        {
            try
            {
                return iInvoice_DetailService.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="Position"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("add-invoice-detail")]
        public bool AddInvoice_Detail(Invoice_Detail obj)
        {
            try
            {
                iInvoice_DetailService.Create(obj);
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
        /// <param name="Position"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("update-invoice-detail")]
        public bool UpdateInvoice_Detail(Invoice_Detail obj)
        {
            try
            {
                iInvoice_DetailService.Update(obj);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
