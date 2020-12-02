using DAL;
using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TamirHaneApp.Controllers
{
    public class UserController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork(new TamirhaneContext());

        public ActionResult Index()
        {
            var result = unitOfWork.UserRepository.GetAll();

            return View(result);
        }

        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(User user)
        {
            user.CreatedDate = DateTime.Now;

            unitOfWork.UserRepository.Add(user);

            unitOfWork.Complete();

            return RedirectToAction("/");
        }

        public ActionResult EditUser(int id)
        {
            var result = unitOfWork.UserRepository.GetById(id);

            return View(result);
        }

        [HttpPost]
        public ActionResult EditUser(User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var currentUser = unitOfWork.UserRepository.GetById(user.Id);

                    currentUser.Name = user.Name;
                    currentUser.LastName = user.LastName;
                    currentUser.Telephone = user.Telephone;
                    currentUser.CreatedDate = user.CreatedDate;
                    currentUser.UpdateDate = DateTime.Now;
                    currentUser.IsActive = user.IsActive;
                    currentUser.Email = user.Email;

                    unitOfWork.Complete();
                }
                catch (Exception)
                {

                    throw;
                }

            }

            return RedirectToAction("/");
        }

        public ActionResult Delete(int id)
        {
            try
            {
                unitOfWork.UserRepository.Remove(id);
                unitOfWork.Complete();

                return RedirectToAction("/");
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}