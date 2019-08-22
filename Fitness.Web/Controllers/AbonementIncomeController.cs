﻿using Fitness.Business.Services;
using Fitness.DataObjects.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fitness.Web.Controllers
{
    public class AbonementIncomeController : Controller
    {
        private readonly IAbonementIncomeService _abonementIncomeService;

        public AbonementIncomeController(IAbonementIncomeService abonementIncomeService)
        {
            _abonementIncomeService = abonementIncomeService;
        }

        // GET: AbonementIncome
        public ActionResult Index()
        {
            var result = _abonementIncomeService.GetList();

            return View(result);
        }

        // GET: AbonementIncome/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AbonementIncome/Create
        [HttpPost]
        public ActionResult Create(AbonementIncome elem)
        {
           
                _abonementIncomeService.Create(elem);

                return RedirectToAction("Index");
            
         
        }

        // GET: AbonementIncome/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AbonementIncome/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AbonementIncome/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AbonementIncome/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
