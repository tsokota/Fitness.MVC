using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fitness.AdoNet.Repositories;
using Fitness.Business.Services;
using Fitness.DataObjects.Data;

namespace Fitness.Web.Controllers
{
    public class ChargesController : Controller
    {
        private readonly IChargeService _chargeService;
        public ChargesController(IChargeService chargeServ)
        {
            _chargeService = chargeServ;
        }
   
        // GET: Charges
        public ActionResult Index()
        {
            var result = _chargeService.GetList();

            return View(result);
        }

        // GET: Charge/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Charge/Create
        [HttpPost]
        public ActionResult Create(Charge elem)
        {

            _chargeService.Create(elem);

            return RedirectToAction("Index");


        }

        // GET: Charge/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_chargeService.GetItem(id));
        }

        // POST: Charge/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Charge elem)
        {

            _chargeService.Edit(id, elem);

            return RedirectToAction("Index");

        }

        // GET: Charge/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_chargeService.GetItem(id));
        }

        // POST: Charge/Delete/5
        [HttpPost]
        public ActionResult Delete(Charge elem)
        {
            try
            {
                _chargeService.Delete(elem.Id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
