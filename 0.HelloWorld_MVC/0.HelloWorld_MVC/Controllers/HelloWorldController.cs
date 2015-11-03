using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _0.HelloWorld_MVC.Controllers
{
    public class HelloWorldController : Controller
    {

        // GET: HelloWorld
        public ActionResult Index()
        {
            ViewBag.Title = "Index";
            ViewBag.Message = "Hellow World.";
            return View();
        }
 
        // 
        // GET: /HelloWorld/Welcome/ 
        // e.g : /HelloWorld/Welcome?name=Eastmoon&numtimes=4
        public ActionResult Welcome(string name = "No-Name", int numTimes = 1 )
        {
            ViewBag.Title = "Welcome";
            ViewBag.Message = "This is the Welcome action method...";
            ViewBag.Name = name;
            ViewBag.numTimes = numTimes;
            return View();
        }

        // GET: /HelloWorld/TestRoute1/ 
        // e.g : /HelloWorld/TestRoute1/3?name=Eastmoon
        // App_Start/RouteConfig : Set MapRoute url: "{controller}/{action}/{id}"
        public string TestRoute1(string name, int ID = 1)
        {
            return HttpUtility.HtmlEncode("Hello World. Test Route {controller}/{action}/{id}, Name: " + name + ", ID: " + ID);
        }

        // GET: /HelloWorld/TestRoute2/ 
        // e.g : /HelloWorld/TestRoute2/Eastmoon/5
        // App_Start/RouteConfig : Set MapRoute url: "{controller}/{action}/{name}/{id}"
        public string TestRoute2(string name, int id = 1)
        {
            return HttpUtility.HtmlEncode("Hello World. Test Route {controller}/{action}/{name}/{id}, Name: " + name + ", ID: " + id);
        }
    }
}