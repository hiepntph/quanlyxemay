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

namespace ASM_CSharp4.Controllers
{
    public class Ware_House_DetailController : Controller
    {
        #region k có đủ thời gian,nên hoàn thiện các tính năng khác trước

        //private IWare_House_DetailService iWare_House_DetailService;

        //public Ware_House_DetailController()
        //{
        //    iWare_House_DetailService = new Ware_House_DetailService();
        //}

        //[HttpGet]
        //public async Task<ActionResult> Ware_House_DetailPage()
        //{
        //    try
        //    {
        //        var lstObjs = await Commons.GetAll<Ware_House_DetailDTO>(String.Concat(Commons.mylocalhost, "Ware_House_Detail/get-all-Ware_House_Detail"));
        //        return View(lstObjs);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        ///// <summary>
        ///// Thêm mới sản phẩm
        ///// </summary>
        ///// <param name="Ware_House_Detail"></param>
        ///// <returns></returns>
        //[HttpPost]
        //public async Task<ActionResult> Ware_House_DetailCUPage(Ware_House_DetailDTO Ware_House_Detail)
        //{
        //    try
        //    {
        //        string url = "";
        //        List<Ware_House_Detail> objs = new List<Ware_House_Detail>();
        //        if (ModelState.IsValid)
        //        {
        //            //var prd = new Ware_House_Detail()
        //            //{
        //            //    Ware_House_Id = Ware_House_Detail.Ware_House_Id,
        //            //    Product_Detail_Id = Ware_House_Detail.Product_Detail_Id,
        //            //    Quantity_entered = Ware_House_Detail.Quantity_entered,
        //            //    Quantity_in_stock = Ware_House_Detail.Quantity_in_stock
        //            //};
        //            //if (Ware_House_Detail.Id == Guid.Empty){ url = string.Concat(Commons.mylocalhost, "Ware_House_Detail/add-Ware_House_Detail");}
        //            //else{ url = string.Concat(Commons.mylocalhost, "Ware_House_Detail/update-Ware_House_Detail"); }

        //            ////-- GTuwir Request cho thằng kia sử lí
        //            //await Commons.Add_or_UpdateAsync(prd, url);
        //            return RedirectToAction("Ware_House_DetailPage");
        //        }
        //        else
        //        {
        //            var lstobjs = new Ware_House_DetailDTO() { Ware_House_DetailList = objs };
        //            return View(lstobjs);
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //}


        ///// <summary>
        ///// Chi tiết màu sắc
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public ActionResult Detail(Guid id)
        //{
        //    try
        //    {
        //        var data = new Ware_House_DetailDTO();
        //        //var lst = iWare_House_DetailService.GetAll().FirstOrDefault(c => c.Id == id);
        //        //var data = new Ware_House_DetailDTO()
        //        //{
        //        //    Ware_House_DetailList = iWare_House_DetailService.GetAll(),
        //        //    Ware_House_DetailData = lst,
        //        //    Id = lst.Id,
        //        //    Ware_House_Detail_Name = lst.Ware_House_Detail_Name,
        //        //    Id_Ware_House_Detail = lst.Ware_House_Detail_Id,
        //        //    Description = lst.Description
        //        //};

        //        return View("Ware_House_DetailCUPage", data);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        ///// <summary>
        ///// Xóa màu
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public async Task<ActionResult> Delete(Guid id)
        //{
        //    try
        //    {
        //        //string url = String.Concat(Commons.mylocalhost, "Ware_House_Detail/delete-Ware_House_Detail?id=", id.NullToString());
        //        //var Rest = new RestSharpHelper(url);
        //        //var Response = await Rest.RequestBaseAsync(url, RestSharp.Method.Delete);
        //        //Console.WriteLine(Response);
        //        return RedirectToAction("Ware_House_DetailPage");
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        #endregion
    }
}
