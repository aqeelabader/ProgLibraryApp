using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProgLibraryApp.Models;
using System;
using System.Collections;
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

        public IActionResult findingcallnumbers() 
        {

            //code attribution
            //this code for the following tree structure was adapted from the following source:
            //Author: Marcus Mangelsdorf
            //Author profile: https://stackoverflow.com/users/2822719/marcus-mangelsdorf
            //url: https://stackoverflow.com/questions/9860207/build-a-simple-high-performance-tree-data-structure-in-c-sharp
            //end of code attribution

            //Filling nodes temporarily

            var sciencestree = new TreeNode("Root")
            {
                new TreeNode(" A |320 Political science"),              
                new TreeNode(" B |330 Economics"),
                new TreeNode(" C |340 Law")

            };

            var insciencestree = new TreeNode("Root")
            {
                new TreeNode(" A |321 Systems of governments & states"),
                new TreeNode(" B |322 Relation of state to organized groups"),
                new TreeNode(" C |323 Civil & political rights"),
                new TreeNode(" D |324 The political process"),
                new TreeNode(" E |325 International migration & colonization"),
                new TreeNode(" F |326 Slavery & emancipation"),
                new TreeNode(" G |327 International relations"),
                new TreeNode(" H |328 The legislative process"),
                new TreeNode(" I |329 Not assigned or no longer used")

            };

            var nsmath = new TreeNode("Root")
            {
                new TreeNode(" A |520 Astronomy & allied sciences"),
                new TreeNode(" B |540 Chemistry & allied sciences"),
                new TreeNode(" C |580 Botanical sciences")
            };

            var innsmath = new TreeNode("Root")
            {
                new TreeNode(" A |521 Celestial mechanics"),
                new TreeNode(" B |522 Techniques, equipment, materials"),
                new TreeNode(" C |523 Specific celestial bodies & phenomena"),
                new TreeNode(" D |524 Not assigned or no longer used"),
                new TreeNode(" E |525 Earth (Astronomical geography)"),
                new TreeNode(" F |526 Mathematical geography"),
                new TreeNode(" G |527 Celestial navigation"),
                new TreeNode(" H |528 Ephemerides"),
                new TreeNode(" I |529 Chronology")

            };

            var arts = new TreeNode("Root")
            {
                new TreeNode(" A |710 Civic & landscape art"),
                new TreeNode(" B |720 Architecture"),
                new TreeNode(" C |750 Painting & paintings")
            };

            var inarts = new TreeNode("Root")
            {
                new TreeNode(" A |711 Area planning (Civic art)"),
                new TreeNode(" B |712 Landscape architecture"),
                new TreeNode(" C |713 Landscape architecture of trafficways"),
                new TreeNode(" D |714 Water features"),
                new TreeNode(" E |715 Woody plants"),
                new TreeNode(" F |716 Herbaceous plants"),
                new TreeNode(" G |717 Structures"),
                new TreeNode(" H |718 Landscape design of cemeteries"),
                new TreeNode(" I |719 Natural landscapes")

            };

            var lit = new TreeNode("Root")
            {
                new TreeNode(" A |810 American literature in English"),
                new TreeNode(" B |820 English & Old English literatures"),
                new TreeNode(" C |830 Literatures of Germanic languages")
            };

            var inlit = new TreeNode("Root")
            {
                new TreeNode(" A |811 Poetry"),
                new TreeNode(" B |812 Drama"),
                new TreeNode(" C |813 Fiction"),
                new TreeNode(" D |814 Essays"),
                new TreeNode(" E |815 Speeches"),
                new TreeNode(" F |816 Letters"),
                new TreeNode(" G |817 Satire & humour"),
                new TreeNode(" H |818 Miscellaneous writings"),
                new TreeNode(" I |819 Not used")

            };

            //passing children to view 
            ViewBag.lit = lit.children.ToList();
            ViewBag.inlit = inlit.children.ToList();
            ViewBag.arts = arts.children.ToList();
            ViewBag.inarts = inarts.children.ToList();
            ViewBag.nsmath = nsmath.children.ToList();
            ViewBag.innsmath = innsmath.children.ToList();
            ViewBag.sciencestree = sciencestree.children.ToList();
            ViewBag.insciencestree = insciencestree.children.ToList();

            return View();      
        
        }
        //Creating structure of tree
        //code attribution
        //this code for the following tree structure was adapted from the following source:
        //Author: Marcus Mangelsdorf
        //Author profile: https://stackoverflow.com/users/2822719/marcus-mangelsdorf
        //url: https://stackoverflow.com/questions/9860207/build-a-simple-high-performance-tree-data-structure-in-c-sharp
        //end of code attribution
        public class TreeNode : IEnumerable<TreeNode>
        {
            public readonly Dictionary<string, TreeNode> children = new Dictionary<string, TreeNode>();

            public readonly string Id;
            public TreeNode Parent { get; set; }

            public TreeNode(string id)
            {
                this.Id = id;
            }

            public TreeNode GetChild(string id)
            {
                return this.children[id];
            }

            public void Add(TreeNode item)
            {
                if (item.Parent != null)
                {
                    item.Parent.children.Remove(item.Id);
                }

                item.Parent = this;
                this.children.Add(item.Id, item);
            }

            public IEnumerator<TreeNode> GetEnumerator()
            {
                return this.children.Values.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return (IEnumerator)GetEnumerator();
            }

            public int Count
            {
                get { return this.children.Count; }
            }
        }
        //end tree structure


        public IActionResult IdentifyingAreas()
        {
            //creating dictionaries
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


            //passing dictionaries to view
            ViewBag.Slist = shuffled;
            ViewBag.SSlist = shuffled2;

            return View();
        }
    }
}
