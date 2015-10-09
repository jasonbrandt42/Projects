using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechEval.Interface;

namespace TechEval.Controllers
{
    public class HomeController : Controller
    {
        private IWords _words;

        public HomeController(IWords words)
        {
            this._words = words;
        }

        public ActionResult Index()
        {
            //string wordInfo = this._words.GetWord();
            //return View(wordInfo as object);

            return View();
        }

        public ActionResult ConvertNumber(FormCollection collection)
        {
            string inputNumber = collection.Get("txbxInputNumber");

            string numberAsWord = this._words.GetWord(inputNumber);
            return View("Index", numberAsWord as object);
        }
    }
}
