using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;





using CinemaApp.Models;

// for mail
using System.Web.Security;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.IO;

namespace CinemaApp.Controllers
{
    public class AccountController : Controller
    {
        AlicanContext db = new AlicanContext();

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Register(UserAccount useraccount)
        {
            if (Session["Role"] == null)
                return RedirectToAction("Login");

            if (!Request.IsAuthenticated && !Session["Role"].Equals(250))
                return RedirectToAction("Login");

            if (ModelState.IsValid)
            {
                using (AlicanContext db = new AlicanContext())
                {
                    useraccount.Active = true;
                    useraccount.Role = 255;
                    db.UserAccounts.Add(useraccount);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = useraccount.Name + " " + useraccount.Surname + " registered.";
            }

            return RedirectToAction("ListReceptionists");
        }

        //Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserAccount useraccount)
        {
            using (AlicanContext db = new AlicanContext())
            {
                var user = db.UserAccounts.FirstOrDefault(u => u.Username == useraccount.Username && u.Password == useraccount.Password);
                if (user != null)
                {
                    Session["Id"] = user.Id;
                    Session["Role"] = user.Role;
                    Session["Name"] = user.Name.ToString();
                    Session["Surname"] = user.Surname.ToString();
                    if (Session["Role"].Equals(250))
                    {
                        return RedirectToAction("AdminPanel");
                    }
                    else
                    {
                        return RedirectToAction("Homepage");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password incorrect.");
                }
            }
            return View();
        }

        public ActionResult Homepage()
        {
            if (Session["Role"] != null)
            {
                if (Session["Role"].Equals(255))
                {
                    List<Movie> lm = db.Movies.Include("Category").ToList();
                    ViewData["MovieList"] = lm;

                    return View();

                }
                else
                {
                    return RedirectToAction("Login");
                }
            }

            return RedirectToAction("Login");
        }

        public ActionResult Logout()
        {
            Session["Role"] = null;
            Session["Name"] = null;
            Session["Surname"] = null;
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            return RedirectToAction("Login");
        }

        [HttpPost]
        public ActionResult AddMovie(Movie addMovie, HttpPostedFileBase image)
        {
            List<Category> categories = db.Categories.ToList();
            ViewData["cats"] = categories;


            if (ModelState.IsValid)
            {
                byte[] imagee = null;
                if (Request.Files.Count > 0)
                {
                    image = Request.Files[0];
                    using (BinaryReader br = new BinaryReader(image.InputStream))
                    {
                        imagee = br.ReadBytes(image.ContentLength);
                    }
                }
                //if (picture != null && picture.ContentLength > 0)
                // {
                //     var path = Server.MapPath("~/Images/" + picture.FileName);
                //     picture.SaveAs(path);
                //     ViewBag.Path = "Picture has been saved in " + path + "\nNamed: " + addMovie.Name;
                // } 
                using (AlicanContext db = new AlicanContext())
                {
                    //  addMovie.PicturePath = picture.FileName;
                    addMovie.Image = imagee;
                    db.Movies.Add(addMovie);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = addMovie.Name + " registered.";
                ViewBag.GoBack = "@Html.ActionLink('Go Back', 'AdminPanel')";
            }
            return RedirectToAction("ListMovies");
        }

        public ActionResult ListMovies(Movie addMovie)
        {
            if (Session["Role"] == null)
                return RedirectToAction("Login");

            if (!Session["Role"].Equals(250))
                return RedirectToAction("Login");


            List<Movie> lm = db.Movies.Include("Category").ToList();
            ViewData["MovieList"] = lm;

            List<Category> categories = db.Categories.ToList();
            ViewData["cats"] = categories;

            return View();
        }

        public ActionResult ListReceptionists(UserAccount useraccount)
        {
            if (Session["Role"] == null)
                return RedirectToAction("Login");


            if (!Session["Role"].Equals(250))
                return RedirectToAction("Login");



            List<UserAccount> ua = db.UserAccounts.ToList();
            ViewData["Receptionist"] = ua;

            return View();
        }


        public ActionResult Edit(int? MovieId)
        {
            if (Session["Role"] == null)
                return RedirectToAction("Login");

            if (!Session["Role"].Equals(250))
                return RedirectToAction("Login");

            Movie editMovie = db.Movies.Find(MovieId);
            ViewData["movie"] = editMovie;

            List<Category> categories = db.Categories.ToList();
            ViewData["cats"] = categories;

            return View();
        }

        public ActionResult DeleteMovie(int? MovieId)
        {
            if (Session["Role"] == null)
                return RedirectToAction("Login");

            if (!Session["Role"].Equals(250))
                return RedirectToAction("Login");

            Movie mv = db.Movies.Find(MovieId);
            db.Movies.Remove(mv);
            db.SaveChanges();

            return RedirectToAction("ListMovies");
        }


        public ActionResult EditReceptionist(int? UserId)
        {
            if (Session["Role"] == null)
                return RedirectToAction("Login");

            if (!Session["Role"].Equals(250))
                return RedirectToAction("Login");

            UserAccount editReceptionist = db.UserAccounts.Find(UserId);
            ViewData["receptionist"] = editReceptionist;
            return View();
        }

        [HttpPost]
        public ActionResult UpdateReceptionist(int? UserId, string name, string surname, DateTime birthday, string placeofbirth, string address, string telephone, int salary)
        {
            UserAccount ReceptionistToEdit = db.UserAccounts.Find(UserId);
            ReceptionistToEdit.Name = name;
            ReceptionistToEdit.Surname = surname;
            ReceptionistToEdit.Birthday = birthday;
            ReceptionistToEdit.PlaceOfBirth = placeofbirth;
            ReceptionistToEdit.Address = address;
            ReceptionistToEdit.Telephone = telephone;
            ReceptionistToEdit.Salary = salary;
            db.SaveChanges();
            return RedirectToAction("ListReceptionists");
        }

        [HttpPost]
        public ActionResult Update(int? MovieId, string name, string stars, string director, string information, string time1, string time2, string time3, string screenlink1, string screenlink2, string screenlink3)
        {
            Movie MovieToEdit = db.Movies.Find(MovieId);
            MovieToEdit.Name = name;
            MovieToEdit.Stars = stars;
            MovieToEdit.Director = director;
            MovieToEdit.Information = information;
            MovieToEdit.Time1 = time1;
            MovieToEdit.Time2 = time2;
            MovieToEdit.Time3 = time3;
            MovieToEdit.ScreenLinkTime1 = screenlink1;
            MovieToEdit.ScreenLinkTime2 = screenlink2;
            MovieToEdit.ScreenLinkTime3 = screenlink3;
            db.SaveChanges();
            return RedirectToAction("ListMovies");
        }


        public ActionResult Unemployee(int? UserId)
        {
            UserAccount ua = db.UserAccounts.Find(UserId);
            ua.Active = false;
            ua.Role = 260;
            db.SaveChanges();

            return RedirectToAction("ListReceptionists");
        }


        public ActionResult Employee(int? UserId)
        {
            UserAccount ua = db.UserAccounts.Find(UserId);
            ua.Active = true;
            ua.Role = 255;
            db.SaveChanges();

            return RedirectToAction("ListReceptionists");
        }

        public ActionResult AdminPanel()
        {
            if (Session["Role"] != null)
            {
                if (Session["Role"].Equals(250))
                {
                    List<Report> reports = db.Reports.ToList();
                    ViewData["ReportList"] = reports;

                    return View();
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }

            return RedirectToAction("Login");
        }

        public ActionResult ClearSeatScreen1()
        {
            if (Session["Role"] == null)
                return RedirectToAction("Login");

            if (!Session["Role"].Equals(250))
                return RedirectToAction("Login");

            var arraySeat = new string[] { "A1", "A2", "A3", "A4", "A5", "A6", "A7", "A8", "A9", "B1", "B2", "B3", "B4","B5", "B6", "B7", "B8", "B9",
                "C1", "C2", "C3", "C4", "C5", "C6", "C7", "C8", "C9", "D1", "D2", "D3", "D4", "D5", "D6", "D7", "D8", "D9", "E1", "E2", "E3", "E4", "E5", "E6", "E7", "E8", "E9",
            "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "G1", "G2", "G3", "G4", "G5", "G6", "G7", "G8", "G9"};

            using (AlicanContext db = new AlicanContext())
            {
                var clear = db.Screen1.Where(c => arraySeat.Contains(c.SeatNumber)).ToList();
                clear.ForEach(a => a.isReserved = false);
                var clear2 = db.Screen12.Where(c => arraySeat.Contains(c.SeatNumber)).ToList();
                clear2.ForEach(a => a.isReserved = false);
                var clear3 = db.Screen13.Where(c => arraySeat.Contains(c.SeatNumber)).ToList();
                clear3.ForEach(a => a.isReserved = false);
                db.SaveChanges();
            }


            return RedirectToAction("AdminPanel");
        }
        public ActionResult ClearSeatScreen2()
        {
            if (Session["Role"] == null)
                return RedirectToAction("Login");

            if (!Session["Role"].Equals(250))
                return RedirectToAction("Login");

            var arraySeat = new string[] { "A1", "A2", "A3", "A4", "A5", "A6", "A7", "A8", "A9", "B1", "B2", "B3", "B4","B5", "B6", "B7", "B8", "B9",
                "C1", "C2", "C3", "C4", "C5", "C6", "C7", "C8", "C9", "D1", "D2", "D3", "D4", "D5", "D6", "D7", "D8", "D9", "E1", "E2", "E3", "E4", "E5", "E6", "E7", "E8", "E9",
            "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "G1", "G2", "G3", "G4", "G5", "G6", "G7", "G8", "G9"};

            using (AlicanContext db = new AlicanContext())
            {
                var clear = db.Screen2.Where(c => arraySeat.Contains(c.SeatNumber)).ToList();
                clear.ForEach(a => a.isReserved = false);
                var clear2 = db.Screen22.Where(c => arraySeat.Contains(c.SeatNumber)).ToList();
                clear2.ForEach(a => a.isReserved = false);
                var clear3 = db.Screen23.Where(c => arraySeat.Contains(c.SeatNumber)).ToList();
                clear3.ForEach(a => a.isReserved = false);
                db.SaveChanges();
            }


            return RedirectToAction("AdminPanel");
        }
        public ActionResult ClearSeatScreen3()
        {
            if (Session["Role"] == null)
                return RedirectToAction("Login");

            if (!Session["Role"].Equals(250))
                return RedirectToAction("Login");


            var arraySeat = new string[] { "A1", "A2", "A3", "A4", "A5", "A6", "A7", "A8", "A9", "B1", "B2", "B3", "B4","B5", "B6", "B7", "B8", "B9",
                "C1", "C2", "C3", "C4", "C5", "C6", "C7", "C8", "C9", "D1", "D2", "D3", "D4", "D5", "D6", "D7", "D8", "D9", "E1", "E2", "E3", "E4", "E5", "E6", "E7", "E8", "E9",
            "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "G1", "G2", "G3", "G4", "G5", "G6", "G7", "G8", "G9"};

            using (AlicanContext db = new AlicanContext())
            {
                var clear = db.Screen3.Where(c => arraySeat.Contains(c.SeatNumber)).ToList();
                clear.ForEach(a => a.isReserved = false);
                var clear2 = db.Screen32.Where(c => arraySeat.Contains(c.SeatNumber)).ToList();
                clear2.ForEach(a => a.isReserved = false);
                var clear3 = db.Screen33.Where(c => arraySeat.Contains(c.SeatNumber)).ToList();
                clear3.ForEach(a => a.isReserved = false);
                db.SaveChanges();
            }


            return RedirectToAction("AdminPanel");
        }
    }
}

// provjera da li radi github sync