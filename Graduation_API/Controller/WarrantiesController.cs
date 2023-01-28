using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EF_CODEFIRST_FLUENT_API.Context;
using EF_CODEFIRST_FLUENT_API.DomainClass;
using Graduation_API.Services.InterfaceServices;
using Graduation_API.Services.ClassServices;

namespace Graduation_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarrantiesController : ControllerBase
    {
        private IWarrantyService iWarrantyService;
        public WarrantiesController()
        {
            iWarrantyService = new WarrantyService();
        }

        [HttpGet]
        [Route("get-all-warranty")]
        public List<Warranty> GetAll()
        {
            try
            {
                var data = iWarrantyService.GetAll();
                Console.WriteLine(data);
                return data;
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpPost]
        [Route("add-warranty")]
        public bool Add([FromBody] Warranty wh)
        {
            try
            {
                iWarrantyService.Create(wh);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost]
        [Route("update-warranty")]
        public bool UpdateCustomer(Warranty wh)
        {
            try
            {
                iWarrantyService.Update(wh);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
