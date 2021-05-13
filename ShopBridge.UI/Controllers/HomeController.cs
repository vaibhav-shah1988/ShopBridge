using Newtonsoft.Json;
using RestSharp;
using ShopBridge.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopBridge.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var client = new RestClient("https://localhost:44382/api/Inventory");
            var request = new RestRequest();

            var response = client.Get<List<Inventory>>(request);

            List<Inventory> inv = JsonConvert.DeserializeObject<List<Inventory>>(response.Content);

            return View(inv);
        }

        public ActionResult Create()
        {

            Inventory inv = new Inventory();
            return View("AddEdit", inv);

        }

        public ActionResult Edit(int Id)
        {

            var client = new RestClient("https://localhost:44382/api/Inventory/GetInventory");
            var request = new RestRequest();
            request.AddParameter("Id", Id);

            var response = client.Get(request);

            Inventory inv = JsonConvert.DeserializeObject<Inventory>(response.Content);

            return View("AddEdit", inv);

        }

        [HttpPost]
        public ActionResult AddEdit(Inventory inventory)
        {
            var client = new RestClient("https://localhost:44382/api/Inventory/PostInventory");
            var request = new RestRequest();
            request.AddJsonBody(inventory);

            //request.AddParameter("Id", Id);

            var response = client.Post(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "An Error Occured";
                return View(inventory);
            }
        }

        public ActionResult Delete(int Id)
        {
            var client = new RestClient("https://localhost:44382/api/Inventory/DeleteInventory");
            var request = new RestRequest();
            request.AddParameter("Id", Id);

            var response = client.Delete(request);

            return RedirectToAction("Index");
        }
    }
}