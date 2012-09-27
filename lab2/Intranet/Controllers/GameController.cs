using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Intranet.Controllers
{
    public class GameController : Controller
    {
        //
        // GET: /Game/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Postbackgame()
        {
            if (Session["correctNumber"] == null)
            {
                var rnd = new Random();
                int randomNumber = rnd.Next(1, 10);
                Session["correctNumber"] = randomNumber;
                Session["tries"] = 0;
            }

            ViewBag.CorrectNumber = Session["correctNumber"];


            return View();
        }

      [HttpPost]
        public ActionResult Postbackgame(string pbgameinput=null)
        {
            if (Session["correctNumber"] == null)
            {
                var rnd = new Random();
                int randomNumber = rnd.Next(1, 10);
                Session["correctNumber"] = randomNumber;
                Session["tries"] = 0;
                ViewBag.error = null;
            }

            int num;
            bool isNum = int.TryParse(pbgameinput, out num);
            if(!isNum)
                ViewBag.error = "Ange ett nummer!";
      

          var correctAnswer =(int) Session["correctNumber"];

          var count =(int) Session["tries"]+1;

          if (num > correctAnswer)
          {
              ViewBag.GameMessage = "Lower";
             
          }
          else if (num < correctAnswer)
          {
              ViewBag.GameMessage = "Higher";
            
          }
          else
          {
              ViewBag.GameMessage = "done";
          }
          Session["tries"] = count;
          ViewBag.tries = count;
          return View();
        }
       

        public ActionResult Jsgame()
        {
            return View();
        }

        public ActionResult Reset(int limit=10)
        {
            var rnd = new Random();
            int randomNumber = rnd.Next(1, limit);
            Session["correctNumber"] = randomNumber;
            Session["tries"] = 0;

            return View();
        }

    }
}
