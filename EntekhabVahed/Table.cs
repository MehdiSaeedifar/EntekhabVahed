using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntekhabVahed
{
    public class Table
    {
        public int UnitsNumber { get; set; }
        public int SpecializedUnitsNumber { get; set; }
        public int GeneralUnitsNumber { get; set; }
        public int LabUnitsNumber { get; set; }
        public Table()
        {

        }

        public List<string> Columns
        {
            get { return _columns; }
            set
            {
                Init(value.Count);
                _columns = value;
            }
        }

        private List<string> _columns;

        public List<ScheduleRow> Rows { get; set; }


        void Init(int columnNumber)
        {
            Rows = new List<ScheduleRow>(6)
            {
                new ScheduleRow(columnNumber)
                {
                    Day = "شنبه",
                },
                new ScheduleRow(columnNumber)
                {
                    Day = "یک شنبه",
                },
                new ScheduleRow(columnNumber)
                {
                    Day = "دوشنبه",
                },
                new ScheduleRow(columnNumber)
                {
                    Day = "سه شنبه",
                },
                new ScheduleRow(columnNumber)
                {
                    Day = "چهارشنبه",
                },
                new ScheduleRow(columnNumber)
                {
                    Day = "پنج شنبه",
                }
            };
        }
    }
}
