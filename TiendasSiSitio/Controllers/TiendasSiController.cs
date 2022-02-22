using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TiendasSiSitio.Models;

namespace TiendasSiSitio.Controllers
{
    public class TiendasSiController : Controller
    {
        
        Uri baseAddress = new Uri("https://localhost:44316/api");
        HttpClient cliente;

        public TiendasSiController()
        {
            cliente = new HttpClient();
            cliente.BaseAddress = baseAddress;
        }
        public IActionResult Index()
        {
            List<Producto> lsProducto = new List<Producto>();
            try
            {

                HttpResponseMessage responseMessage = cliente.GetAsync(cliente.BaseAddress + "/TiendasSiProducto").Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    string response = responseMessage.Content.ReadAsStringAsync().Result;
                    lsProducto = JsonConvert.DeserializeObject<List<Producto>>(response);
                }

                }

            catch (Exception)
            {

                throw;
            }
            return View(lsProducto);
        }

       
        public ActionResult ViewProductByMovie()
        {
            List<Producto> lsProducto = new List<Producto>();
            try
            {

                HttpResponseMessage responseMessage = cliente.GetAsync(cliente.BaseAddress + "/TiendasSiProducto/GetTiendasSiProductoByTipo/1").Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    string response = responseMessage.Content.ReadAsStringAsync().Result;
                    
                    lsProducto = JsonConvert.DeserializeObject<List<Producto>>(response);

            
                }
            }
            catch (Exception) 
            {

                throw;
            }

            return View(lsProducto);

        }
      
        
        public ActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Create(Producto productoModel)
        {

            try
            {
                string data = JsonConvert.SerializeObject(productoModel);
                StringContent stringContent = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = cliente.PostAsync(cliente.BaseAddress + "/TiendasSiProducto", stringContent).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

            }
            catch (Exception)
            {

                throw;
            }

            return View();
        }


        public ActionResult Edit(int id)
        {
            Producto producto = new Producto();
            try
            {

           
                HttpResponseMessage responseMessage = cliente.GetAsync(cliente.BaseAddress + "/TiendasSiProducto/" + id).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    string response = responseMessage.Content.ReadAsStringAsync().Result;
                    producto = JsonConvert.DeserializeObject<Producto>(response);
                }

            }
            catch (Exception)
            {

                throw;
            }
            return View("Edit", producto);
        }

        [HttpPost]
        public ActionResult Edit(Producto productoModel)
        {
            try
            {
                string data = JsonConvert.SerializeObject(productoModel);
                StringContent stringContent = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = cliente.PutAsync(cliente.BaseAddress + "/TiendasSiProducto/"+ productoModel.id, stringContent).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {

                throw;
            }

            return View("Edit", productoModel);
        }
    }
}
