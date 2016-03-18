using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntekhabVahed.Web.Infrastructure;
using EntekhabVahed.Web.ViewModels;

namespace EntekhabVahed.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult GetData(ChooseUnitViewModel model)
        {
            var lstUnits = new List<Unit>();

            foreach (var unit in model.UnitsList)
            {
                var currentUnit = new Unit
                {
                    Id = unit.Id,
                    CourseName = unit.CourseName,
                    UnitType = unit.UnitType,
                    TeacherName = unit.TeacherName,
                    UnitNumber = unit.UnitNumber,

                };

                foreach (var classDateTime in unit.ClassDateTimes)
                {
                    currentUnit.ClassDateTimes.Add(new UnitDateTime
                    {
                        DayOfWeek = classDateTime.Day,
                        StartTime = $"{classDateTime.StartTimeHour}:{classDateTime.StartTimeMinute}",
                        EndTime = $"{classDateTime.EndTimeHour}:{classDateTime.EndTimeMinute}"
                    });
                }

                lstUnits.Add(currentUnit);
            }

            var unitConfig = new UnitConfig
            {
                MinUnitNumber = model.UnitsConfig.MinUnitNumber,
                MaxUnitNumber = model.UnitsConfig.MaxUnitNumber,
                MinEspUnitNumber = model.UnitsConfig.MinEspUnitNumber,
                MaxEspUnitNumber = model.UnitsConfig.MaxEspUnitNumber,
                MinGeneralUnitNumber = model.UnitsConfig.MinGeneralUnitNumber,
                MaxGeneralUnitNumber = model.UnitsConfig.MaxGeneralUnitNumber,
                MinLabUnitNumber = model.UnitsConfig.MinLabUnitNumber,
                MaxLabUnitNumber = model.UnitsConfig.MaxLabUnitNumber
            };


            return new JsonCamelCaseResult(Program.Main(lstUnits, unitConfig), JsonRequestBehavior.DenyGet);
        }

    }
}