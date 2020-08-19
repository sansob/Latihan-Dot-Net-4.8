using System.Linq;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        sandecEntities db = new sandecEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult ViewUser()
        {
            var getData = db.Users.ToList();
            return View(getData);
        }

        public ActionResult Delete(int Id)
        {
            //pakai find ketika mau nyari data by primary key
            var getData = db.Users.Find(Id);
            db.Users.Remove(getData);
            db.SaveChanges();
            return null;
        }

        public ActionResult EditUser(int Id)
        {
            //ada 2 
            //first or default sama singleordefault == first or default itu, nyari data pertama, kalo ga ada null, data lebih dari 1 d ambil yg palingatas
            // single or default, nyari 1 data, jika data lebih dari 2 maka error!
            //first sama single ==> error exception
            var getUser = db.Users.SingleOrDefault(x => x.Id == Id);
            return View(getUser);
        }

        [HttpPost]
        public ActionResult UpdateUser(Users users)
        {
            var getDataToUpdate = db.Users.SingleOrDefault(x => x.Id == users.Id);

            if (getDataToUpdate != null)
            {
                getDataToUpdate.FirstName = users.FirstName;
                getDataToUpdate.LastName = users.LastName;
            }

            db.SaveChanges();

            return null;
        }

        [HttpPost]
        public ActionResult CreateUser(Users users)
        {
            var userModel = new Users();

            userModel.FirstName = users.FirstName;
            userModel.LastName = users.LastName;

            db.Users.Add(userModel);
            db.SaveChanges();

            return null;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}