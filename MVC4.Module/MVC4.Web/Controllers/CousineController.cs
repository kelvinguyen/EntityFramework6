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

        /*
         * Action Filter : implement logic that execute before and after a controller action execute
         *  + OutputCache : cache ouput of this action to the cache memory for a set amount of time
         *  + HandleError : handle error raise when action executes
         *  + Authorize : restrict access to a particular user or role 
         *  + ValidateInput : turn off the request validation and allow dangerous input
         *  + ValidateAntiForgeryToken : help to prevent cross site request forgeries
         */
         [OutputCache(Duration = 10)]
         [HandleError] // redirect to mvc error page
         [Authorize] // allow only login user
         [Authorize(Roles = "admin")]
        public ActionResult ActionFilterSample()
        {
            return Json(new List<string>(), JsonRequestBehavior.AllowGet);
        }
    }
}