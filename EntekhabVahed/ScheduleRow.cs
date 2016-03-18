using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntekhabVahed
{
    public class ScheduleRow
    {
        public ScheduleRow(int columnsNumber)
        {
            Units = new List<UnitDetail>(columnsNumber);
            for (int i = 0; i < columnsNumber; i++)
            {
                Units.Add(null);
            }
        }
        public string Day { get; set; }
        public List<UnitDetail> Units { get; set; }
    }
}
