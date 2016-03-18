using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntekhabVahed
{
    public class Unit
    {
        public Unit()
        {
            ClassDateTimes = new List<UnitDateTime>();
        }

        public int Id { get; set; }
        public string CourseName { get; set; }
        public int UnitNumber { get; set; }
        public string TeacherName { get; set; }
        public UnitType UnitType { get; set; }
        public List<UnitDateTime> ClassDateTimes { get; set; }
    }
}
