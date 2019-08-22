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
    }
}