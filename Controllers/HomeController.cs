using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TransStateUnescapeApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace TransStateUnescapeApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string json)
        {
            try{
            var jsonResult = JObject.Parse(UnescapeHtml(json));
            return Json(jsonResult);
            }
            catch(Exception ex){
                return  Json(ex);
            }
        }

        public string UnescapeHtml(string escapedHtml)
        {
            var result = escapedHtml
                            .Replace("&a;", "&")
                            .Replace("&q;", "\"")
                            .Replace("&l;", "<")
                            .Replace("&g;", ">");
            return result;
        }
    }
}
