using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC4.Web.Controllers
{
    public class CousineController : Controller
    {
        // GET: Cousine
        
        public ActionResult Search(string name)
        {
            // encode so no html inject
            var message = Server.HtmlEncode(name);
            return Content($"Hello {name}");
        }

        /*
            action selector
                - ActionName : url is /ChangeName instead of SampleActionSelector
                - NonAction : public method of controller is not action method
                - ActionVerb : GET,POST,PUT,HEAD,OPTIONS,DELETE,PATCH
                    + GET : retrieve data
                    + POST : add new data
                    + PUT : update data
                    + HEAD : identical to GET but server do not return message body
                    + OPTIONS :  is used by client to find out the HTTP method is support by server side
                    + DELETE : delete the existing result
                    + PATCH : to full or partial update the result
                    + AcceptVerbs : allow to apply multiple ActionVerbs 
         */
         [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
         [HttpGet] [HttpPost] [HttpPut] [HttpHead] [HttpOptions] [HttpDelete] [HttpPatch] 
         [NonAction]
         [ActionName("ChangeName")]
        public ActionResult SampleActionSelector()
        {
            return View();
        }
    }
}