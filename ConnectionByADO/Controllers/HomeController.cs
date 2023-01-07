/*
 * Important While You Implement Dependency Injection to Services Use IFetchServerInformation instance
 */
using ConnectionByADO.Implementations;
using Microsoft.AspNetCore.Mvc;
using ConnectionByADO.Services;

namespace ConnectionByADO.Controllers
{
    public class HomeController : Controller
    {
        public IFetchServerInformation ifi;
        public IConfiguration config;
       public HomeController(IFetchServerInformation _ifi)
       {
           ifi = _ifi;    
       }
        public IActionResult Index()
        {
            var cc = ifi.GetInformationOfDataServer();
            //ViewData["string"] = cc;
            return View(cc);
        }




    }
}
