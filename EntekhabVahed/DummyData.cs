using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntekhabVahed
{
    internal class DummyData
    {
        public static List<Unit> GetList()
        {
            var lstUnits = new List<Unit>
            {

                new Unit
                {
                    Id = 13255,
                    TeacherName = "نيكيان - عليرضا",
                    CourseName = "شبكه هاي عصبي",
                    UnitNumber = 3,
                    UnitType = UnitType.Specialized,
                    ClassDateTimes = new List<UnitDateTime>
                    {
                        new UnitDateTime()
                        {
                            DayOfWeek = 2,
                            StartTime = "14:25",
                            EndTime = "15:50"
                        },
                        new UnitDateTime()
                        {
                            DayOfWeek = 4,
                            StartTime = "14:25",
                            EndTime = "15:50"
                        }
                    }
                },
                new Unit
                {
                    Id = 13256,
                    TeacherName = "مظاهري - ميلاد",
                    CourseName = "1 مدارهاي الكتريكي",
                    UnitNumber = 3,
                    UnitType = UnitType.Specialized,
                    ClassDateTimes = new List<UnitDateTime>
                    {
                        new UnitDateTime()
                        {
                            DayOfWeek = 5,
                            StartTime = "13:00",
                            EndTime = "14:15"
                        },
                        new UnitDateTime()
                        {
                            DayOfWeek = 5,
                            StartTime = "10:50",
                            EndTime = "12:00"
                        }
                    }
                },
                new Unit
                {
                    Id = 13130,
                    TeacherName = "نورافزا - نسيم",
                    CourseName = "هوش مصنوعي",
                    UnitNumber = 3,
                    UnitType = UnitType.Specialized,
                    ClassDateTimes = new List<UnitDateTime>
                    {
                        new UnitDateTime()
                        {
                            DayOfWeek = 1,
                            StartTime = "9:25",
                            EndTime = "10:40"
                        },
                        new UnitDateTime()
                        {
                            DayOfWeek = 1,
                            StartTime = "10:50",
                            EndTime = "12:00"
                        }
                    }
                },
                  new Unit
                {
                    Id = 13279,
                    TeacherName = "سلطاني خوراسگاني - صفورا",
                    CourseName = "مهندسي نرم افزار 2",
                    UnitNumber = 3,
                    UnitType = UnitType.Specialized,
                    ClassDateTimes = new List<UnitDateTime>
                    {
                        new UnitDateTime()
                        {
                            DayOfWeek = 5,
                            StartTime = "10:50",
                            EndTime = "12:00"
                        },
                        new UnitDateTime()
                        {
                            DayOfWeek = 5,
                            StartTime = "13:00",
                            EndTime = "14:15"
                        }

                    }
                },
                new Unit
                {
                    Id = 12725,
                    TeacherName = "سليماني چم خرمي - خسرو",
                    CourseName = "نظريه مجموعه هاي فازي",
                    UnitNumber = 3,
                    UnitType = UnitType.Specialized,
                    ClassDateTimes = new List<UnitDateTime>
                    {
                        new UnitDateTime()
                        {
                            DayOfWeek = 5,
                            StartTime = "13:00",
                            EndTime = "14:25"
                        },
                        new UnitDateTime()
                        {
                            DayOfWeek = 5,
                            StartTime = "10:50",
                            EndTime = "12:00"
                        }
                    }
                },
                new Unit
                {
                    Id = 13728,
                    TeacherName = "سليماني چم خرمي - خسرو",
                    CourseName = "نظريه مجموعه هاي فازي",
                    UnitNumber = 3,
                    UnitType = UnitType.Specialized,
                    ClassDateTimes = new List<UnitDateTime>
                    {
                        new UnitDateTime()
                        {
                            DayOfWeek = 4,
                            StartTime = "8:00",
                            EndTime = "9:15"
                        },
                        new UnitDateTime()
                        {
                            DayOfWeek = 4,
                            StartTime = "9:25",
                            EndTime = "10:40"
                        }
                    }
                },
                new Unit
                {
                    Id = 13269,
                    TeacherName = "آجودانيان - شهره",
                    CourseName = "مهندسي نرم افزار 2",
                    UnitNumber = 3,
                    UnitType = UnitType.Specialized,
                    ClassDateTimes = new List<UnitDateTime>
                    {
                        new UnitDateTime()
                        {
                            DayOfWeek = 4,
                            StartTime = "8:00",
                            EndTime = "9:15"
                        },
                        new UnitDateTime()
                        {
                            DayOfWeek = 2,
                            StartTime = "8:00",
                            EndTime = "9:15"
                        }
                    }
                },


                 new Unit
                {
                    Id = 12849,
                    TeacherName = "نورمحمدي نجف آبادي - رضا",
                    CourseName = "ريزپردازنده 1",
                    UnitNumber = 3,
                    UnitType = UnitType.Specialized,
                    ClassDateTimes = new List<UnitDateTime>
                    {
                        new UnitDateTime()
                        {
                            DayOfWeek = 2,
                            StartTime = "13:00",
                            EndTime = "14:15"
                        },
                        new UnitDateTime()
                        {
                            DayOfWeek = 4,
                            StartTime = "13:00",
                            EndTime = "14:15"
                        }
                    }
                },
                 new Unit
                {
                    Id = 12847,
                    TeacherName = "محمدشفيعي - احمد",
                    CourseName = "ريزپردازنده 1",
                    UnitNumber = 3,
                    UnitType = UnitType.Specialized,
                    ClassDateTimes = new List<UnitDateTime>
                    {
                        new UnitDateTime()
                        {
                            DayOfWeek = 2,
                            StartTime = "9:25",
                            EndTime = "10:40"
                        },
                        new UnitDateTime()
                        {
                            DayOfWeek = 4,
                            StartTime = "9:25",
                            EndTime = "10:40"
                        }
                    }
                },
                  new Unit
                {
                    Id = 10159,
                    TeacherName = "حقيقي نجف آبادي - محمود",
                    CourseName = "انديشه اسلامي 2 (نبوت و امامت)",
                    UnitNumber = 2,
                    UnitType = UnitType.General,
                    ClassDateTimes = new List<UnitDateTime>
                    {
                        new UnitDateTime()
                        {
                            DayOfWeek = 4,
                            StartTime = "13:00",
                            EndTime = "14:45"
                        },
                    }
                },
                      new Unit
                {
                    Id = 10873,
                    TeacherName = "حقيقي نجف آبادي - محمود",
                    CourseName = "انديشه اسلامي 2 (نبوت و امامت)",
                    UnitNumber = 2,
                    UnitType = UnitType.General,
                    ClassDateTimes = new List<UnitDateTime>
                    {
                        new UnitDateTime()
                        {
                            DayOfWeek = 4,
                            StartTime = "14:55",
                            EndTime = "16:40"
                        },
                    }
                },
                          new Unit
                {
                    Id = 10874,
                    TeacherName = "شريعتي نجف ابادي - رحمت اله",
                    CourseName = "انديشه اسلامي 2 (نبوت و امامت)",
                    UnitNumber = 2,
                    UnitType = UnitType.General,
                    ClassDateTimes = new List<UnitDateTime>
                    {
                        new UnitDateTime()
                        {
                            DayOfWeek = 2,
                            StartTime = "8:15",
                            EndTime = "10:00"
                        },
                    }
                },
                             new Unit
                {
                    Id = 13433,
                    TeacherName = "رستمي - محمد",
                    CourseName = "آزمايشگاه پايگاه داده ها",
                    UnitNumber = 1,
                    UnitType = UnitType.Lab,
                    ClassDateTimes = new List<UnitDateTime>
                    {
                        new UnitDateTime()
                        {
                            DayOfWeek = 3,
                            StartTime = "16:15",
                            EndTime = "18:30"
                        },
                    }
                },
                                           new Unit
                {
                    Id = 13434,
                    TeacherName = "رستمي - محمد",
                    CourseName = "آزمايشگاه پايگاه داده ها",
                    UnitNumber = 1,
                    UnitType = UnitType.Lab,
                    ClassDateTimes = new List<UnitDateTime>
                    {
                        new UnitDateTime()
                        {
                            DayOfWeek = 5,
                            StartTime = "13:00",
                            EndTime = "14:45"
                        },
                    }
                },
                                                                       new Unit
                {
                    Id = 10990,
                    TeacherName = "خزاييلي نجف آبادي - محمدباقر",
                    CourseName = "تاريخ تحليلي صدر اسلام",
                    UnitNumber = 2,
                    UnitType = UnitType.General,
                    ClassDateTimes = new List<UnitDateTime>
                    {
                        new UnitDateTime()
                        {
                            DayOfWeek = 3,
                            StartTime = "13:00",
                            EndTime = "14:45"
                        },
                    }
                },




            };

            return lstUnits;
        }
    }
}
