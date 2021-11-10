using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProgLibraryApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ProgLibraryApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        //code attribution
        //this code for random number and character generation was adapted from the following source:
        //Author: Mahesh Chand - C# Corner
        //Author profile: https://www.c-sharpcorner.com/members/mahesh-chand
        //url: https://www.c-sharpcorner.com/article/generating-random-number-and-string-in-C-Sharp/
        //end of code attribution
        public class RandomGenerator
        {
            private readonly Random _random = new Random();
            public int RandomNumber(int min, int max)
            {
                return _random.Next(min, max);
            }
        }

        public string random()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var stringChars = new char[3];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            var generator = new RandomGenerator();
            var randomNumber = generator.RandomNumber(100, 999);
            string rand = (randomNumber + "." + finalString);
            return rand.ToString();
        }

        //end of attributed code

        public IActionResult Sortbooks(int[] book)
        {
            var books = new List<string>();
            books.Add("001.ABC");
            books.Add("009.ABC");
            books.Add("002.ABC");
            books.Add("007.ABC");
            books.Add("008.ABC");
            books.Add("010.ABC");
            books.Add("003.ABC");
            books.Add("006.ABC");
            books.Add("004.ABC");
            books.Add("005.ABC");

            List<string> usbooks = new List<string>();
            usbooks.AddRange(books);
            usbooks.Sort();



            //code attribution
            //this code for selection sort algorithms was adapted from the following source:
            //Author: Wade - .net core tutorials
            //Author profile:https://dotnetcoretutorials.com/author/admin/
            //url: https://www.c-sharpcorner.com/article/generating-random-number-and-string-in-C-Sharp/
            //end of code attribution

            for (var i = 0; i < book.Length; i++)
            {
                var min = i;
                for (var j = i + 1; j < book.Length; j++)
                {
                    if (book[min] > book[j])
                    {
                        min = j;
                    }
                }

                if (min != i)
                {
                    var lowerValue = book[min];
                    book[min] = book[i];
                    book[i] = lowerValue;
                }
            }

            //end of attributed code


            List<string> sbooks = new List<string>();
            sbooks.AddRange(usbooks);

            return View(books);
        }

        public ActionResult ModalPopUp()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult IdentifyingAreas()
        {

            var slist1 = new Dictionary<string, string>()
            {
                 {"1 | 020 ", "A | Library and information sciences"},
                 {"2 | 027 ", "B | General libraries"},
                 {"3 | 034 ", "C | Encyclopedias in French, Occitan, and Catalan"},
                 {"4 | Serials in other Germanic languages ", "D | 053"},
                 {"5 | Serials in Slavic languages ", "E | 057"},
                 {".", "F | 042"},
                 {"..", "G | Encyclopedias in Occitan"}
            };
            var slist2 = new Dictionary<string, string>()
            {
                 {"1 | 060  ", "A | General organizations and museum science"},
                 {"2 | 064  ", "B | Organizations in France and Monaco"},
                 {"3 | 068  ", "C | Organizations in other geographic areas"},
                 {"4 | Organizations in Iberian peninsula and adjacent islands ", "D | 066"},
                 {"5 | Museum science ", "E | 069"},
                 {".", "F | 057"},
                 {"..", "G |  Newspapers in France and Monaco"}
            };
            var slist3 = new Dictionary<string, string>()
            {
                 {"1 | 097 ", "A | Books notable for ownership or origin"},
                 {"2 | 094 ", "B | Printed books"},
                 {"3 | 091 ", "C | Manuscripts"},
                 {"4 | Manuscripts and rare books ", "D | 090"},
                 {"5 | Books notable for illustrations ", "E | 096"},
                 {".", "F | 098 "},
                 {"..", "G | Books notable for format"}
            };

            ViewBag.Slist1 = slist1;
            return View();
        }
    }
}
