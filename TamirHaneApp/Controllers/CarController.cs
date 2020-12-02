using DAL;
using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TamirHaneApp.Controllers
{
    public class CarController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork(new TamirhaneContext());

        // GET: Car
        public ActionResult Index()
        {
            var result = unitOfWork.CarRepository.GetAll().ToList();

            return View(result);
        }

        public ActionResult CreateCar()
        {
            ViewBag.userId = new SelectList(unitOfWork.UserRepository.GetAll(), "Id", "Name");

            return View();
        }

        [HttpPost]
        public ActionResult CreateCar(Car car, int userId)
        {
            try
            {
                car.User = unitOfWork.UserRepository.GetById(userId);
                car.CreatedDate = DateTime.Now;
                car.IsActive = true;

                unitOfWork.CarRepository.Add(car);
                unitOfWork.Complete();

                return RedirectToAction("Index", car);
            }
            catch (Exception)
            {

                throw;
            }

        }
        public ActionResult Edit(int id)
        {
            var result = unitOfWork.CarRepository.GetById(id);

            return View("Edit", result);
        }

        [HttpPost]
        public ActionResult Edit(Car car)
        {
            try
            {
                var currentCar = unitOfWork.CarRepository.GetById(car.Id);

                currentCar.User = car.User;
                currentCar.Plate = car.Plate;
                currentCar.Brand = car.Brand;
                currentCar.Model = car.Model;
                currentCar.ModelYear = car.ModelYear;
                currentCar.IsActive = true;
                currentCar.UpdateDate = DateTime.Now;

                unitOfWork.Complete();
            }
            catch (Exception ex)
            {

                throw;
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            unitOfWork.CarRepository.Remove(id);
            unitOfWork.Complete();

            return RedirectToAction("/");
        }
    }
}