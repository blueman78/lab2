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
        public ActionResult Postbackgame(int pbgameinput)
        {
            if (Session["correctNumber"] == null)
            {
                var rnd = new Random();
                int randomNumber = rnd.Next(1, 10);
                Session["correctNumber"] = randomNumber;
                Session["tries"] = 0;
            }

            //ViewBag.CorrectNumber = Session["correctNumber"];
            //ViewBag.InputNumber = pbgameinput;

          var correctAnswer =(int) Session["correctNumber"];

          var count = 0;
          if (pbgameinput > correctAnswer)
          {
              ViewBag.GameMessage = "Lower";
              count++;
          }
          else if (pbgameinput < correctAnswer)
          {
              ViewBag.GameMessage = "Higher";
              count++;
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

    }
}
