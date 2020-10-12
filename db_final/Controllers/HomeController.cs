using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using db_final.Models;
using System.Dynamic;

namespace db_final.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult MainPage()
        {
            return View();
        }

        public ActionResult VenuesPage()
        {

            List<Venue> venue = CRUD.getAllVenues();
            if (venue == null)
            {
                RedirectToAction("MainPage");
            }
            Console.Write(venue);
            return View(venue);
        }

        public ActionResult SignupPage()
        {
            return View();
        }

        public ActionResult LoginPage()
        {
            return View();
        }

        public ActionResult PhotographersPage()
        {
            List<Photographer> photographer = CRUD.getAllPhotographers();
            if (photographer == null)
            {
                RedirectToAction("MainPage");
            }
            Console.Write(photographer);
            return View(photographer);
        }

        public ActionResult DJsPage()
        {
            List<DJ> dj = CRUD.getAllDJs();
            if (dj == null)
            {
                RedirectToAction("MainPage");
            }
            Console.Write(dj);
            return View(dj);
        }

        public ActionResult CaterersPage()
        {
            List<Caterer> c = CRUD.getAllCaterers();
            if (c == null)
            {
                RedirectToAction("MainPage");
            }
            Console.Write(c);
            return View(c);
        }

        public ActionResult DecoratorsPage()
        {
            List<Decorator> c = CRUD.getAllDecorators();
            if (c == null)
            {
                RedirectToAction("MainPage");
            }
            Console.Write(c);
            return View(c);
        }

        public ActionResult SP_SignupPage()
        {
            return View();
        }

        public ActionResult SP_LoginPage()
        {
            return View();
        }

        public ActionResult SP_ProfilePage()
        {
            if (Session["SP_username"] != null)
            {
                ServiceProvider sp = new ServiceProvider();
                sp = CRUD.getDetailsOfSP(Session["SP_username"].ToString());
                return View(sp);
            }
            else
                return RedirectToAction("LoginServiceProvider");
        }
        
        public ActionResult SP_DetailsPage(string serviceProviderUsername, string serviceCategory)
        {
            dynamic myModel = new ExpandoObject();
            myModel.Reviews = CRUD.getReviewsOfSP(serviceProviderUsername,serviceCategory);
            myModel.SP_Details = CRUD.getDetailsOfSP(serviceProviderUsername);
            myModel.avgRating = CRUD.getAverageRatingOfSP(serviceProviderUsername, serviceCategory);
            myModel.serviceCategory = serviceCategory;

            

            return View(myModel);

        }

        public ActionResult SP_ChangePassword(string oldPassword, string newPassword)
        {
            if (Session["SP_username"] != null)
            {
                int result = CRUD.changePasswordOfSP(Session["SP_username"].ToString(), oldPassword, newPassword);
                if (result == 0)
                {
                    String data = "Old Password Incorrect. Please Log-in Again!";
                    return View("SP_LoginPage", (object)data);
                }
                else if (result == -1)
                {
                    String data = "Unknwon Error. Please Log-in Again!";
                    return View("SP_LoginPage", (object)data);
                }
                else
                    return RedirectToAction("SP_ProfilePage");
            }
            else
                return RedirectToAction("LoginServiceProvider");
        }

        public ActionResult SP_ChangeDetails(string contactNum, string email)
        {
            if (Session["SP_username"] != null)
            {
                int result = CRUD.changeDetailsOfSP(Session["SP_username"].ToString(), contactNum,email);
                if (result == 0)
                {
                    String data = "Invalid Details. Please Log-in Again";
                    return View("SP_LoginPage", (object)data);
                }
                else if (result == -1)
                {
                    String data = "Unknwon Error. Please Log-in Again!";
                    return View("SP_LoginPage", (object)data);
                }
                else
                    return RedirectToAction("SP_ProfilePage");
            }
            else
                return RedirectToAction("LoginServiceProvider");
        }

        public ActionResult SP_nullifySession()
        {
            Session["SP_username"] = null;
            return RedirectToAction("MainPage");
        }

        public ActionResult Customer_nullifySession()
        {
            Session["Cust_username"] = null;
            return RedirectToAction("MainPage");
        }

        public ActionResult SignupServiceProvider(string username, string cnic, string email, string contactNum, string password)
        {

            int result = CRUD.signupNewServiceProvider(username, cnic, email, contactNum, password);

            if (result == 0) //user already exists
            {
                String data = "Username already exists.";
                return View("SP_SignupPage", (object)data);
            }
            else if (result == -1)   //error connecting to DB
            {
                String data = "Unknown error occurred";
                return View("SP_SignupPage", (object)data);
            }
            else if (result == 1)  //email already exists
            {
                String data = "Email already exists.";
                return View("SP_SignupPage", (object)data);
            }
            else
            {
                Session["SP_username"] = username;
                return RedirectToAction("SP_ProfilePage");
            }
        }

        public ActionResult LoginServiceProvider(string username,  string password)
        {

            int result = CRUD.loginServiceProvider(username, password);

            if (result == 0) 
            {
                String data = "Username does not exist.";
                return View("SP_LoginPage", (object)data);
            }
            else if (result == -1)   //error connecting to DB
            {
                String data = "Unknown error occurred";
                return View("SP_LoginPage", (object)data);
            }
            else if (result == 1)  //email already exists
            {
                String data = "Incorrect Password.";
                return View("SP_LoginPage", (object)data);
            }
            else
            {
                Session["SP_username"] = username;
                return RedirectToAction("SP_ProfilePage");
            }
        }

        public ActionResult ProfilePage()
        {
            if (Session["Cust_username"] != null)
            {
                Customer sp = new Customer();
                sp = CRUD.getDetailsOfCustomer(Session["Cust_username"].ToString());
                return View(sp);
            }
            else
                return RedirectToAction("LoginUser");
        }

        public ActionResult LoginUser(string username, string password)
        {
            int result = CRUD.loginUser(username, password);

            if (result == 0) //user already exists
            {
                String data = "Username does not exist.";
                return View("LoginPage", (object)data);
            }
            else if (result == -1)   //error connecting to DB
            {
                String data = "Unknown error occurred";
                return View("LoginPage", (object)data);
            }
            else if (result == 1)  //email already exists
            {
                String data = "Incorrect Password.";
                return View("LoginPage", (object)data);
            }
            else
            {
                Session["Cust_username"] = username;
                return RedirectToAction("MainPage");
            }
        }

        public ActionResult SignupUser(string username, string name, string email, string contactNum, string password)
        {

            int result = CRUD.signupNewUser(username, name, email, contactNum, password);

            if (result == 0) //user already exists
            {
                String data = "Username already exists.";
                return View("SignupPage", (object)data);
            }
            else if (result == -1)   //error connecting to DB
            {
                String data = "Unknown error occurred";
                return View("SignupPage", (object)data);
            }
            else if (result == 1)  //email already exists
            {
                String data = "Email already exists.";
                return View("SignupPage", (object)data);
            }
            else
            {
                Session["Cust_username"] = username;
                return RedirectToAction("MainPage");
            }
        }

        public ActionResult Customer_ChangePassword(string oldPassword, string newPassword)
        {
            if (Session["Cust_username"] != null)
            {
                int result = CRUD.changePasswordOfCustomer(Session["Cust_username"].ToString(), oldPassword, newPassword);
                if (result == 0)
                {
                    String data = "Old Password Incorrect. Please Log-in Again!";
                    return View("LoginPage", (object)data);
                }
                else if (result == -1)
                {
                    String data = "Unknwon Error. Please Log-in Again!";
                    return View("LoginPage", (object)data);
                }
                else
                    return RedirectToAction("ProfilePage");
            }
            else
                return RedirectToAction("LoginUser");
        }

        public ActionResult Customer_ChangeDetails(string name, string contactNum, string email)
        {
            if (Session["Cust_username"] != null)
            {
                int result = CRUD.changeDetailsOfCustomer(Session["Cust_username"].ToString(), name,contactNum, email);
                if (result == 0)
                {
                    String data = "Invalid Details. Please Log-in Again";
                    return View("LoginPage", (object)data);
                }
                else if (result == -1)
                {
                    String data = "Unknwon Error. Please Log-in Again!";
                    return View("LoginPage", (object)data);
                }
                else
                    return RedirectToAction("ProfilePage");
            }
            else
                return RedirectToAction("LoginUser");
        }

        public ActionResult SearchVenues(string searchName, string searchAddress, int maxPrice, int minPrice)
        {
            List<Venue> venue;
            if (searchName == "" && searchAddress == "" && maxPrice == 2147483647 && minPrice == 0)
                venue = CRUD.getAllVenues();
            else
                venue = CRUD.getSearchedVenues(searchName, searchAddress, maxPrice,minPrice);
            Console.Write(venue);
            return View("VenuesPage",venue);
        }

        public ActionResult SearchPhotographers(int maxPrice, int minPrice)
        {
            List<Photographer> p;
            if (maxPrice == 2147483647 && minPrice == 0)
                p = CRUD.getAllPhotographers();
            else
                p = CRUD.getSearchedPhotographers(maxPrice, minPrice);
            Console.Write(p);
            return View("PhotographersPage", p);
        }

        public ActionResult SearchDJs(int maxPrice, int minPrice)
        {
            List<DJ> p;
            if (maxPrice == 2147483647 && minPrice == 0)
                p = CRUD.getAllDJs() ;
            else
                p = CRUD.getSearchedDJs(maxPrice, minPrice);
            Console.Write(p);
            return View("DJsPage", p);
        }

        public ActionResult SearchCaterers(int maxPrice, int minPrice)
        {
            List<Caterer> p;
            if (maxPrice == 2147483647 && minPrice == 0)
                p = CRUD.getAllCaterers();
            else
                p = CRUD.getSearchedCaterers(maxPrice, minPrice);
            Console.Write(p);
            return View("CaterersPage", p);
        }

        public ActionResult SearchDecorators(int maxPrice, int minPrice)
        {
            List<Decorator> p;
            if (maxPrice == 2147483647 && minPrice == 0)
                p = CRUD.getAllDecorators();
            else
                p = CRUD.getSearchedDecorators(maxPrice, minPrice);
            Console.Write(p);
            return View("DecoratorsPage", p);
        }

        public ActionResult PostComment(string SP_username, string Cust_username, string category, string reviewRating, string reviewComment)
        {
            int result = CRUD.postComment(SP_username, Cust_username, category, reviewComment, Int32.Parse(reviewRating));

            if (result == -1) //user already exists
            {
                String data = "Unknown Error! Please Login Again";
                return View("LoginPage", (object)data);
            }


            else
            {

                return RedirectToAction("SP_DetailsPage", "Home", new
                {
                    serviceProviderUsername = SP_username,
                    serviceCategory = category,
                    comment = ""
                 });
            }
        }

        public ActionResult VenuesBySp()
        {
            List<Venue> venue = CRUD.getAllVenuesbySp(Session["SP_username"].ToString());
            if (venue == null)
            {
                RedirectToAction("MainPage");
            }
            Console.Write(venue);
            return View(venue);
        }

        public ActionResult SP_AddVenue()
        {
            return View();
        }

        public ActionResult addNewVenue(string spid, string vname, string vadd, int price, int discount)
        {
            int result = CRUD.addNewVenue(spid, vname, vadd,price,discount);
            
            if (result == -1)   //error connecting to DB
            {
                string data = "Unknown error occurred";
                return View("SP_AddVenue", (object)data);
            }
            else if (result == 0)  //venue with this name already exists
            {
                string data = "Venue with this name/address already exists";
                return View("SP_AddVenue", (object)data);
            }
            else
            {
                
                return RedirectToAction("VenuesBySp");
            }
        }

        public ActionResult SP_DeleteVenue()
        {
            return View();
        }

        public ActionResult deleteVenue(string username, string venueName)
        {
            int result = CRUD.deleteVenue(username,venueName);

            if (result == -1)   //error connecting to DB
            {
                string data = "Unknown error occurred";
                return View("SP_DeleteVenue", (object)data);
            }
            else if (result == 0)  //venue with this name already exists
            {
                string data = "Venue with this name does not exist";
                return View("SP_DeleteVenue", (object)data);
            }
            else
            {

                return RedirectToAction("VenuesBySp");
            }
        }

        public ActionResult SP_UpdateVenue()
        {
            return View();
        }

        public ActionResult updateVenue(String venuename, int? updprice, int? upddiscount)
        {
            int upd = CRUD.updateVenue(Session["SP_username"].ToString(), venuename, updprice, upddiscount);
            if (upd == -1)
            {
                String data = "Something went wrong while connecting with the database.";
                return View("SP_UpdateVenue", (object)data);
            }
            else if (upd == 0)
            {
                String data = "Venue does not exist";
                return View("SP_UpdateVenue", (object)data);
            }
            else
                return RedirectToAction("VenuesBySp");
        }

        public ActionResult DJsBySP()
        {
            DJ dj = CRUD.getAllDJsBySP(Session["SP_username"].ToString());
            if (dj == null)
            {
                RedirectToAction("DJsBySP");
            }
            Console.Write(dj);
            return View(dj);
        }

        public ActionResult DJ_Add()
        {
            return View();
        }

        public ActionResult DJ_Delete()
        {
            return View();
        }

        public ActionResult DJ_Update()
        {
            return View();
        }

        public ActionResult addDJ(String spid, String djname, int? price, int? discount)
        {
            int checkSP = CRUD.checkSP(spid);
            if (checkSP == 0)
            {
                String data = "Incorrect Service Provider Id. This provider does not exist.";
                return View("DJ_Add", (object)data);
            }
            else if (checkSP == 1)
            {
                int result = CRUD.signupDJ(spid, djname, price, discount);

                if (result == -1)
                {
                    String data = "Something went wrong while connecting with the database.";
                    return View("DJ_Add", (object)data);
                }
                else if (result == 0)
                {

                    String data = "DJ already exists for this provider";
                    return View("DJ_Add", (object)data);
                }
            }
            return RedirectToAction("DJsBySP");
        }

        public ActionResult deleteDJ(String deletedj)
        {
            int del = CRUD.deleteDJ(Session["SP_username"].ToString(), deletedj);
            if (del == -1)
            {
                String data = "Something went wrong while connecting with the database.";
                return View("DJ_Delete", (object)data);
            }

            else if (del == 0)
            {
                String data = "DJ does not exist";
                return View("DJ_Delete", (object)data);
            }
            else
            {
                return RedirectToAction("DJsBySP");
            }
        }

        public ActionResult UpdateDJ(String djname, int? updprice, int? upddiscount)
        {
            int upd = CRUD.updateDJ(Session["SP_username"].ToString(), djname, updprice, upddiscount);
            if (upd == -1)
            {
                String data = "Something went wrong while connecting with the database.";
                return View("DJ_Update", (object)data);
            }
            else if (upd == 0)
            {
                String data = "DJ does not exist";
                return View("DJ_Update", (object)data);
            }
            else
                return RedirectToAction("DJsBySP");
        }

        public ActionResult DecoratorsBySP()
        {
             Decorator Deco = CRUD.getAllDecoratorsBySP(Session["SP_username"].ToString());
            if (Deco == null)
            {
                RedirectToAction("MainPage");
            }
            Console.Write(Deco);
            return View(Deco);
        }

        public ActionResult Decorator_SignUp()
        {
            return View();
        }

        public ActionResult Decorator_Deletion()
        {
            return View();
        }

        public ActionResult Decorator_Update()
        {
            return View();
        }

        public ActionResult addDecorator(String spid, String vname, int? price, int? discount, string samples)
        {

            int checkSP = CRUD.checkSP(spid);
            if (checkSP == 0)
            {
                String data = "Incorrect Service Provider Id. This provider does not exist.";
                return View("Decorator_Signup", (object)data);
            }
            else if (checkSP == 1)
            {
                int result = CRUD.signupDecorator(spid, vname, price, discount,samples);

                if (result == -1)
                {
                    String data = "Something went wrong while connecting with the database.";
                    return View("Decorator_Signup", (object)data);
                }
                else if (result == 0)
                {

                    String data = "Decorator already exists for this provider";
                    return View("Decorator_Signup", (object)data);
                }
            }
            return RedirectToAction("DecoratorsBySp");

        }

        public ActionResult deleteDecorator(String deletedecorator)
        {
            int del = CRUD.DeletingDecorator(Session["SP_username"].ToString(), deletedecorator);
            if (del == -1)
            {
                String data = "Something went wrong while connecting with the database.";
                return View("Decorator_Deletion", (object)data);
            }

            else if (del == 0)
            {
                String data = "Decorator does not exist";
                return View("Decorator_Deletion", (object)data);
            }
            else
            {
                return RedirectToAction("DecoratorsBySp");
            }
        }

        public ActionResult UpdateDecorator(String Decoratorname, int? updprice, int? upddiscount, string samples)
        {
            int upd = CRUD.updatedecorator(Session["SP_username"].ToString(), Decoratorname, updprice, upddiscount,samples);
            if (upd == -1)
            {
                String data = "Something went wrong while connecting with the database.";
                return View("Decorator_Update", (object)data);
            }
            else if (upd == 0)
            {
                String data = "Decorator does not exist";
                return View("Decorator_Update", (object)data);
            }
            else
                return RedirectToAction("DecoratorsBySp");
        }

        public ActionResult PhotographersBySP()
        {
            Photographer Deco = CRUD.getAllPhotographersBySP(Session["SP_username"].ToString());
            if (Deco == null)
            {
                RedirectToAction("MainPage");
            }
            Console.Write(Deco);
            return View(Deco);
        }

        public ActionResult CaterersBySP()
        {
            Caterer Deco = CRUD.getAllCaterersBySP(Session["SP_username"].ToString());
            if (Deco == null)
            {
                RedirectToAction("MainPage");
            }
            Console.Write(Deco);
            return View(Deco);
        }

        public ActionResult Photographer_SignUp()
        {
            return View();
        }

        public ActionResult Photographer_Deletion()
        {
            return View("Photographer_Delete");
        }

        public ActionResult Photographer_Update()
        {
            return View();
        }

        public ActionResult Caterer_Add()
        {
            return View();
        }

        public ActionResult Caterer_Deletion()
        {
            return View();
        }

        public ActionResult Caterer_Update()
        {
            return View();
        }

        public ActionResult addPhotographer(String spid, String vname, int? price, int? discount, string samples)
        {

            int checkSP = CRUD.checkSP(spid);
            if (checkSP == 0)
            {
                String data = "Incorrect Service Provider Id. This provider does not exist.";
                return View("Photographer_Signup", (object)data);
            }
            else if (checkSP == 1)
            {
                int result = CRUD.signupPhotographer(spid, vname, price, discount, samples);

                if (result == -1)
                {
                    String data = "Something went wrong while connecting with the database.";
                    return View("Photographer_Signup", (object)data);
                }
                else if (result == 0)
                {

                    String data = "Photographer already exists for this provider";
                    return View("Photographer_Signup", (object)data);
                }
            }
            return RedirectToAction("PhotographersBySP");

        }

        public ActionResult deletePhotographer(String deletedecorator)
        {
            int del = CRUD.DeletingPhotographer(Session["SP_username"].ToString(), deletedecorator);
            if (del == -1)
            {
                String data = "Something went wrong while connecting with the database.";
                return View("Photographer_Deletion", (object)data);
            }

            else if (del == 0)
            {
                String data = "Photographer does not exist";
                return View("Photographer_Deletion", (object)data);
            }
            else
            {
                return RedirectToAction("PhotographersBySP");
            }
        }

        public ActionResult UpdatePhotographer(String Decoratorname, int? updprice, int? upddiscount, string samples)
        {
            int upd = CRUD.updatePhotographer(Session["SP_username"].ToString(), Decoratorname, updprice, upddiscount, samples);
            if (upd == -1)
            {
                String data = "Something went wrong while connecting with the database.";
                return View("Photographer_Update", (object)data);
            }
            else if (upd == 0)
            {
                String data = "Photographer does not exist";
                return View("Photographer_Update", (object)data);
            }
            else
                return RedirectToAction("PhotographersBySP");
        }

        public ActionResult addCaterer(String spid, String vname, int? price, int? discount, string samples)
        {
            int checkSP = CRUD.checkSP(spid);
            if (checkSP == 0)
            {
                String data = "Incorrect Service Provider Id. This provider does not exist.";
                return View("Caterer_Add", (object)data);
            }
            else if (checkSP == 1)
            {
                int result = CRUD.signupCaterer(spid, vname, price, discount,samples);

                if (result == -1)
                {
                    String data = "Something went wrong while connecting with the database.";
                    return View("Caterer_Add", (object)data);
                }
                else if (result == 0)
                {

                    String data = "Caterer already exists for this provider";
                    return View("Caterer_Add", (object)data);
                }
            }
            return RedirectToAction("CaterersBySP");
        }

        public ActionResult deleteCaterer(String deletedecorator)
        {
            int del = CRUD.DeletingCaterer(Session["SP_username"].ToString(), deletedecorator);
            if (del == -1)
            {
                String data = "Something went wrong while connecting with the database.";
                return View("Caterer_Deletion", (object)data);
            }

            else if (del == 0)
            {
                String data = "Decorator does not exist";
                return View("Caterer_Deletion", (object)data);
            }
            else
            {
                return RedirectToAction("CaterersBySP");
            }
        }

        public ActionResult UpdateCaterer(String Decoratorname, int? updprice, int? upddiscount, string samples)
        {
            int upd = CRUD.updateCaterer(Session["SP_username"].ToString(), Decoratorname, updprice, upddiscount, samples);
            if (upd == -1)
            {
                String data = "Something went wrong while connecting with the database.";
                return View("Caterer_Update", (object)data);
            }
            else if (upd == 0)
            {
                String data = "Caterer does not exist";
                return View("Caterer_Update", (object)data);
            }
            else
                return RedirectToAction("CaterersBySP");
        }

    }

}