using DAL;
using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TamirHaneApp.Controllers
{
    public class AppointmentController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork(new TamirhaneContext());

        // GET: Appointment
        public ActionResult Index()
        {
            var result = unitOfWork.AppointmentRepository.GetAll();
            return View(result);
        }

        public ActionResult Create()
        {
            ViewBag.carId = new SelectList(unitOfWork.CarRepository.GetAll(), "Id", "Plate");
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(int carId,Appointment entity)
        {
            try
            {
                entity.Car = unitOfWork.CarRepository.GetById(carId);
                unitOfWork.AppointmentRepository.Add(entity);
                unitOfWork.Complete();
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction("/");
        }

        public ActionResult Edit(int id)
        {
            return View("Edit", unitOfWork.AppointmentRepository.GetById(id));
        }


        [HttpPost]
        public ActionResult Edit(Appointment entity)
        {
            try
            {
                var currentAppoiment = unitOfWork.AppointmentRepository.GetById(entity.Id);
                currentAppoiment.UpdateDate = DateTime.Now;
                currentAppoiment.Datetime = entity.Datetime;

                unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }

        }

        public ActionResult Delete(int id)
        {
            unitOfWork.AppointmentRepository.Remove(id);
            unitOfWork.Complete();

            return RedirectToAction("/");
        }
    }
}