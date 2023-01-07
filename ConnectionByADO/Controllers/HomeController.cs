/*
 * Important While You Implement Dependency Injection to Services Use IFetchServerInformation instance
 */
using ConnectionByADO.Implementations;
using ConnectionByADO.Models;
using Microsoft.AspNetCore.Mvc;
using ConnectionByADO.Services;

namespace ConnectionByADO.Controllers
{
    public class HomeController : Controller
    {
        public IFetchServerInformation ifi;
        public ICountOrders iC;
       public HomeController(IFetchServerInformation _ifi, ICountOrders _ic)
       {
           ifi = _ifi;    
           iC = _ic;
       }
        public IActionResult Index()
        {
           // var cc = ifi.GetInformationOfDataServer();
           List<ServerData>cc = new List<ServerData>();
            //ViewData["string"] = cc;
            return View(cc);
        }
        [HttpPost]
        public IActionResult Index(string isD)
        {
            List<ServerData> cc = new List<ServerData>();

            if (isD == "ServerInfo")
            {
                ViewData["scalar"] = isD;
                 cc = ifi.GetInformationOfDataServer();
                //ViewData["string"] = cc;
                ViewData["str"] = "";
                return View(cc);
            }

            if (isD == "Scalar")
            {
                var str = iC.CountOrdersByScalar();
                ViewData["scalar"] = isD;
                ViewData["str"] = str;
                return View(cc);
            }
            else
            {
                
            }
            
            return View(cc);
        }


    }
}
