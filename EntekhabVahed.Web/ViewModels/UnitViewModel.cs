using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntekhabVahed.Web.ViewModels
{
    public class UnitViewModel
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string TeacherName { get; set; }
        public int UnitNumber { get; set; }
        public UnitType UnitType { get; set; }
        public List<ClassDateTimesViewModel> ClassDateTimes { get; set; }

    }

    public class ClassDateTimesViewModel
    {
        public int Day { get; set; }
        public int StartTimeHour { get; set; }
        public int StartTimeMinute { get; set; }

        public int EndTimeHour { get; set; }
        public int EndTimeMinute { get; set; }
    }
}