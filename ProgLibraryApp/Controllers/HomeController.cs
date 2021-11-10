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
    public static class DictionaryExtensions
    {

        //code attribution
        //this code for shuffling dictionaries was adapted from the following source:
        //Author: Jignesh Beladiya
        //Author profile:https://www.blogger.com/profile/11275105948467239303
        //url: http://jigneshon.blogspot.com/2013/08/c-snippet-shuffling-dictionary-beginner.html
        //end of code attribution
        public static Dictionary<TKey, TValue> Shuffle<TKey, TValue>(
           this Dictionary<TKey, TValue> source)
        {
            Random r = new Random();
            return source.OrderBy(x => r.Next())
               .ToDictionary(item => item.Key, item => item.Value);
        }
        //end of attributed code
    }
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

            var slist1 = new Dictionary<string, int>()
            {
                 {"3 | Sociology and anthropology  ", 301},
                 {"1 | Social interaction  ", 302},
                 {"2 | Social processes  ", 303},
                 {".", 308},
                 {"..", 309}
            };

            var slist2 = new Dictionary<string, int>()
            {
                 {"5 | Factors affecting social behavior ", 304},
                 {"4 | Groups of people ", 305},
            };


            //code attribution
            //this code for shuffling dictionaries was adapted from the following source:
            //Author: Jignesh Beladiya
            //Author profile:https://www.blogger.com/profile/11275105948467239303
            //url: http://jigneshon.blogspot.com/2013/08/c-snippet-shuffling-dictionary-beginner.html
            //end of code attribution
            Dictionary<string, int> shuffled = slist1.Shuffle();
            Dictionary<string, int> shuffled2 = slist2.Shuffle();
            //end of attributed code

            ViewBag.Slist = shuffled;
            ViewBag.SSlist = shuffled2;

            return View();
        }
    }
}
