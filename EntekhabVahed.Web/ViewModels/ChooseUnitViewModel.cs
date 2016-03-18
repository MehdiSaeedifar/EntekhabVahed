using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntekhabVahed.Web.ViewModels
{
    public class ChooseUnitViewModel
    {
        public List<UnitViewModel> UnitsList { get; set; }
        public UnitConfigViewModel UnitsConfig { get; set; }
    }

    public class UnitConfigViewModel
    {
        public int MinUnitNumber { get; set; }
        public int MaxUnitNumber { get; set; }

        public int? MinEspUnitNumber { get; set; }
        public int? MaxEspUnitNumber { get; set; }

        public int? MinGeneralUnitNumber { get; set; }
        public int? MaxGeneralUnitNumber { get; set; }

        public int? MinLabUnitNumber { get; set; }
        public int? MaxLabUnitNumber { get; set; }

    }
}