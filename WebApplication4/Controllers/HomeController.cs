using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult IndexDriver()
        {
            return View();
        }
        public ActionResult Login(String Email,String Password)
        {
            bool check=DataAccessLayer.UserLogin(Email,Password);
            if (check == true)
            {
                Session["Email"] = Email;
                return View("HomePagePerson");
            }
            else
            {
                return View("Index", (object)"Check Credentials Or SignUp");
            }
        }
        public ActionResult LoginDriver(String Email, String Password)
        {
            bool check = DataAccessLayer.DriverLogin(Email, Password);
            if (check == true)
            {
                Session["Email"] = Email;
                return View("HomePageDriver");
            }
            else
            {
                return View("IndexDriver", (object)"Check Credentials Or SignUp");
            }
        }
        public ActionResult signup()
        {
            return View();
        }
        public ActionResult signupcheck(String Cnic, String Name, String Password, String PhoneNo, String Email)
        {
            bool check = DataAccessLayer.PeopleRegister(Cnic,Name,Password,PhoneNo,Email);
            if (check == true)
            {
                Session["Email"] = Email;
                return View("HomePagePerson");
            }
            else
            {
                return View("signup", (object)"Check Credentials Or Login");
            }
        }
        public ActionResult signupdriver()
        {
            return View();
        }
        public ActionResult signupcheckdriver(String Name, String Email, String Address, String Password,  String PhoneNo, String Cnic, int YearsOfExperience)
        {
            bool check = DataAccessLayer.DriverRegister(Name, Email, Address, Password, PhoneNo, Cnic, YearsOfExperience);
            if (check == true)
            {
                Session["Email"] = Email;
                return View("HomePageDriver");
            }
            else
            {
                return View("signupdriver", (object)"Check Credentials Or Login");
            }
        }
        public ActionResult logoutperson()
        {
            Session.Abandon();
            return View("index");
        }
        public ActionResult logoutdriver()
        {
            Session.Abandon();
            return View("IndexDriver");
        }
        public ActionResult HomePagePerson()
        {
            return View();
        }
        public ActionResult HomePageDriver()
        {
            return View();
        }
        public ActionResult RentACar()
        {
            return View();
        }
        public ActionResult RentYourCar()
        {
            return View();
        }
        public ActionResult AddCar()
        {
            return View();
        }
        public ActionResult AddCarToDataBase(String NumberPlate, String Name, int Model, String Make, double PetrolInLitres, double DrivenInKms, String Cnic, int EngineCC)
        {
            if(DataAccessLayer.AddCar( NumberPlate,  Name,  Model,  Make,  PetrolInLitres,  DrivenInKms,  Cnic,EngineCC)==true)
            {
                return View("AddCar", (object)"Car Added, Successfully!");
            }
            else
            {
                return View("AddCar", (object)"Same Car Already Exists, Check Credentials");
            }

        }
        public ActionResult ReturnCar()
        {
            return View();

        }
        //public ActionResult BillView()
        //{

        //}
        //public ActionResult GenerateBill()
        //{
        //    String data=DataAccessLayer.GetBill();
        //    return View("BillView",(object)data);
        //}
        public ActionResult ShowsCars()
        {
            List<String> m = DataAccessLayer.ShowCarsFromDataBase();
            return View(m);
        }
        public ActionResult ShowsCarsAdd()
        {
            
            return View("ShowsCars",(object)"Car Added SuccessFully");
        }
        public ActionResult CarsList()
        {
            return View();
        }

    }
}