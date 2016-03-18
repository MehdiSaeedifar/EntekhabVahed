using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntekhabVahed
{
    class ChooseUnit
    {
        public static bool HasConflict(List<UnitDateTime> candidUnitDateTimes, List<UnitDateTime> targetUnitDateTimes)
        {
            foreach (var candidUnitDateTime in candidUnitDateTimes)
            {
                foreach (var targetUnitDateTime in targetUnitDateTimes)
                {
                    if (HasTimeConflict(candidUnitDateTime.DayOfWeek, targetUnitDateTime.DayOfWeek,
                        TimeSpan.Parse(candidUnitDateTime.StartTime), TimeSpan.Parse(candidUnitDateTime.EndTime),
                        TimeSpan.Parse(targetUnitDateTime.StartTime)))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static bool HasTimeConflict(int candidUnitDay, int targetUnitDay,
            TimeSpan candidUnitStartTime, TimeSpan firstClassEndTime, TimeSpan targetUnitStartTime)
        {
            if (candidUnitDay != targetUnitDay)
            {
                return false;
            }

            var firstClassTimeRange = Math.Abs((firstClassEndTime - candidUnitStartTime).TotalMinutes);

            var diffStartMinute = Math.Abs((candidUnitStartTime - targetUnitStartTime).TotalMinutes);

            var result = firstClassTimeRange - diffStartMinute;

            return result > 0;
        }


        public static List<ClassTime> TimeExtractor(List<Unit> lstUnits)
        {
            var timeList = new List<ClassTime>();
            foreach (var unit in lstUnits)
            {
                foreach (var classDateTime in unit.ClassDateTimes)
                {
                    timeList.Add(new ClassTime()
                    {
                        StartTime = TimeSpan.Parse(classDateTime.StartTime),
                        EndTime = TimeSpan.Parse(classDateTime.EndTime)
                    });
                }
            }
            timeList = timeList.OrderBy(x => x.StartTime).ToList();

            return timeList.DistinctBy(x => new { x.StartTime, x.EndTime }).ToList();
        }

        public static Table GetDataTable(List<Unit> lstUnits)
        {
            var classTimes = TimeExtractor(lstUnits);

            var table = new Table();

            table.Columns = classTimes.Select(ct => ct.EndTime.ToString(@"hh\:mm") + " - " + ct.StartTime.ToString(@"hh\:mm")).ToList();

            foreach (var unit in lstUnits)
            {
                foreach (var classDateTime in unit.ClassDateTimes)
                {
                    if (classDateTime.DayOfWeek == 1)
                    {
                        for (int i = 0; i < classTimes.Count; i++)
                        {
                            if (classTimes[i].StartTime == TimeSpan.Parse(classDateTime.StartTime) &&
                                classTimes[i].EndTime == TimeSpan.Parse(classDateTime.EndTime)
                                )
                            {
                                table.Rows[0].Units[i] = new UnitDetail
                                {
                                    Id = unit.Id,
                                    CourseName = unit.CourseName,
                                    TeacherName = unit.TeacherName
                                };
                            }

                        }

                    }
                    if (classDateTime.DayOfWeek == 2)
                    {
                        for (int i = 0; i < classTimes.Count; i++)
                        {
                            if (classTimes[i].StartTime == TimeSpan.Parse(classDateTime.StartTime) &&
                                classTimes[i].EndTime == TimeSpan.Parse(classDateTime.EndTime)
                                )
                            {
                                table.Rows[1].Units[i] = new UnitDetail
                                {
                                    Id = unit.Id,
                                    CourseName = unit.CourseName,
                                    TeacherName = unit.TeacherName
                                };
                            }

                        }
                    }
                    if (classDateTime.DayOfWeek == 3)
                    {
                        for (int i = 0; i < classTimes.Count; i++)
                        {
                            if (classTimes[i].StartTime == TimeSpan.Parse(classDateTime.StartTime) &&
                                classTimes[i].EndTime == TimeSpan.Parse(classDateTime.EndTime)
                                )
                            {
                                table.Rows[2].Units[i] = new UnitDetail
                                {
                                    Id = unit.Id,
                                    CourseName = unit.CourseName,
                                    TeacherName = unit.TeacherName
                                };
                            }

                        }
                    }
                    if (classDateTime.DayOfWeek == 4)
                    {
                        for (int i = 0; i < classTimes.Count; i++)
                        {
                            if (classTimes[i].StartTime == TimeSpan.Parse(classDateTime.StartTime) &&
                                classTimes[i].EndTime == TimeSpan.Parse(classDateTime.EndTime)
                                )
                            {
                                table.Rows[3].Units[i] = new UnitDetail
                                {
                                    Id = unit.Id,
                                    CourseName = unit.CourseName,
                                    TeacherName = unit.TeacherName
                                };
                            }

                        }
                    }
                    if (classDateTime.DayOfWeek == 5)
                    {
                        for (int i = 0; i < classTimes.Count; i++)
                        {
                            if (classTimes[i].StartTime == TimeSpan.Parse(classDateTime.StartTime) &&
                                classTimes[i].EndTime == TimeSpan.Parse(classDateTime.EndTime)
                                )
                            {
                                table.Rows[4].Units[i] = new UnitDetail
                                {
                                    Id = unit.Id,
                                    CourseName = unit.CourseName,
                                    TeacherName = unit.TeacherName
                                };
                            }

                        }
                    }

                }
            }
            return table;
        }


        public static bool IsDuplicate(List<Unit> firstList, List<Unit> secondList)
        {
            if (firstList.Count != secondList.Count)
            {
                return false;
            }
            for (int i = 0; i < firstList.Count; i++)
            {
                if (firstList[i].Id != secondList[i].Id)
                    return false;
            }

            return true;
        }
    }


}
