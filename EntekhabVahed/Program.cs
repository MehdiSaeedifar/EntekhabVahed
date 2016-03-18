using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EntekhabVahed
{
    public class Program
    {
        public static List<Table> Main(List<Unit> lstInput, UnitConfig unitConfig)
        {
            //var lstInput = DummyData2.GetList();

            var lstResults = new List<List<Unit>>();

            var lstResultTables = new List<Table>();

            int? minesp = unitConfig.MinEspUnitNumber;
            int? maxEsp = unitConfig.MaxEspUnitNumber;

            int? minGeneral = unitConfig.MinGeneralUnitNumber;
            int? maxGeneral = unitConfig.MaxGeneralUnitNumber;


            int? minLab = unitConfig.MinLabUnitNumber;
            int? maxlab = unitConfig.MaxLabUnitNumber;

            var maxUnit = unitConfig.MaxUnitNumber;
            var minUnit = unitConfig.MinUnitNumber;







            for (int l = 0; l < lstInput.Count; l++)
            {
                for (int mm = 0; mm < lstInput.Count; mm++)
                {


                    var lstUnits = new List<Unit>(lstInput);

                var candidateUnitList = new List<Unit>();


                candidateUnitList.Add(lstUnits[l]);

                lstUnits = lstUnits.Where(x => !x.CourseName.Equals(lstUnits[l].CourseName, StringComparison.InvariantCultureIgnoreCase)).ToList();

                int i = mm;
                while (i < lstUnits.Count)
                {
                    var candidListUnitNumber = candidateUnitList.Sum(x => x.UnitNumber);

                    var candidListespUnitNumber =
                    candidateUnitList.Where(x => x.UnitType == UnitType.Specialized).Sum(x => x.UnitNumber);

                    var candidListgeneralUnitNumber =
                        candidateUnitList.Where(x => x.UnitType == UnitType.General).Sum(x => x.UnitNumber);

                    var candidListlabUnitNumber =
                        candidateUnitList.Where(x => x.UnitType == UnitType.Lab).Sum(x => x.UnitNumber);

                    var shoudSkip = false;

                    if (maxUnit < candidListUnitNumber + lstUnits[i].UnitNumber)
                    {
                        shoudSkip = true;
                    }
                    else if (maxEsp != null && lstUnits[i].UnitType == UnitType.Specialized && maxEsp < candidListespUnitNumber + lstUnits[i].UnitNumber)
                    {
                        shoudSkip = true;
                    }

                    else if (maxGeneral != null && lstUnits[i].UnitType == UnitType.General && maxGeneral < candidListgeneralUnitNumber + lstUnits[i].UnitNumber)
                    {
                        shoudSkip = true;
                    }
                    else if (maxlab != null && lstUnits[i].UnitType == UnitType.General && maxlab < candidListlabUnitNumber + lstUnits[i].UnitNumber)
                    {
                        shoudSkip = true;
                    }

                    if (!shoudSkip)
                    {
                        var hasConflict = false;
                        int j = 0;
                        while (j < candidateUnitList.Count)
                        {
                            if (ChooseUnit.HasConflict(lstUnits[i].ClassDateTimes, candidateUnitList[j].ClassDateTimes))
                            {
                                hasConflict = true;
                            }
                            j++;
                        }
                        if (hasConflict == false)
                        {
                            candidateUnitList.Add(lstUnits[i]);
                            lstUnits = lstUnits.Where(x => !x.CourseName.Equals(lstUnits[i].CourseName, StringComparison.InvariantCultureIgnoreCase)).ToList();
                        }
                        else
                        {
                                lstUnits.RemoveAt(i);
                                //i++;
                        }
                            if (i == lstUnits.Count - 1)
                            {
                                i = 0;
                            }
                        }
                    else
                    {
                        i++;
                    }
                }


                //var result = ChooseUnit.GetDataTable(candidateUnitList);

                var unitNumber = candidateUnitList.Sum(x => x.UnitNumber);

                var espUnitNumber =
                    candidateUnitList.Where(x => x.UnitType == UnitType.Specialized).Sum(x => x.UnitNumber);

                var generalUnitNumber =
                    candidateUnitList.Where(x => x.UnitType == UnitType.General).Sum(x => x.UnitNumber);

                var labUnitNumber =
                    candidateUnitList.Where(x => x.UnitType == UnitType.Lab).Sum(x => x.UnitNumber);

                if (unitNumber <= maxUnit && unitNumber >= minUnit)
                {
                    var result = true;

                    if (minesp != null && minesp > espUnitNumber)
                    {
                        result = false;
                    }
                    else if (maxEsp != null && maxEsp < espUnitNumber)
                    {
                        result = false;
                    }
                    else if (minGeneral != null && minGeneral > generalUnitNumber)
                    {
                        result = false;
                    }
                    else if (maxGeneral != null && maxGeneral < generalUnitNumber)
                    {
                        result = false;
                    }
                    else if (minLab != null && minLab > labUnitNumber)
                    {
                        result = false;
                    }
                    else if (maxlab != null && maxlab < labUnitNumber)
                    {
                        result = false;
                    }

                    if (result)
                    {
                        bool isDuplicate = false;


                        foreach (var units in lstResults)
                        {
                            if (ChooseUnit.IsDuplicate(candidateUnitList.OrderBy(x => x.Id).ToList(), units))
                            {
                                isDuplicate = true;
                            }
                        }

                        if (!isDuplicate)
                        {
                            lstResults.Add(candidateUnitList.OrderBy(x => x.Id).ToList());

                            var tbl = ChooseUnit.GetDataTable(candidateUnitList);
                            tbl.UnitsNumber = unitNumber;
                            tbl.SpecializedUnitsNumber = espUnitNumber;
                            tbl.GeneralUnitsNumber = generalUnitNumber;
                            tbl.LabUnitsNumber = labUnitNumber;
                            lstResultTables.Add(tbl);
                        }

                    }

                }

            }

        }

            //foreach (var tbl in lstResultTables)
            //{

            //}

            return lstResultTables.OrderByDescending(x => x.UnitsNumber).ToList();

            //string s = "";
            //foreach (var unit1 in lstResults)
            //{
            //    foreach (var unit in unit1)
            //    {
            //        var ss = "";
            //        foreach (var classDateTime in unit.ClassDateTimes)
            //        {
            //            if (classDateTime.DayOfWeek == 1)
            //            {
            //                s += "شنبه:   ";
            //                s += string.Format("{0} {1} {2} {3}", unit.CourseName, unit.TeacherName, ss, Environment.NewLine);
            //            }
            //            if (classDateTime.DayOfWeek == 2)
            //            {
            //                s += "یکشنبه:   ";
            //                s += string.Format("{0} {1} {2} {3}", unit.CourseName, unit.TeacherName, ss, Environment.NewLine);
            //            }
            //            if (classDateTime.DayOfWeek == 3)
            //            {
            //                s += "دوشنبه:   ";
            //                s += string.Format("{0} {1} {2} {3}", unit.CourseName, unit.TeacherName, ss, Environment.NewLine);
            //            }
            //            if (classDateTime.DayOfWeek == 4)
            //            {
            //                s += "سه شنبه:   ";
            //                s += string.Format("{0} {1} {2} {3}", unit.CourseName, unit.TeacherName, ss, Environment.NewLine);
            //            }
            //            if (classDateTime.DayOfWeek == 5)
            //            {
            //                s += "چهار شنبه:   ";
            //                s += string.Format("{0} {1} {2} {3}", unit.CourseName, unit.TeacherName, ss, Environment.NewLine);
            //            }

            //        }

            //        //unit.ClassDateTimes.ForEach(x => ss += x.DayOfWeek + " " + x.StartTime + " - " + x.EndTime + " ");




            //    }
            //    s += Environment.NewLine + "--------------------------" + Environment.NewLine;
            //}
            //File.WriteAllText("file.txt", s);




        }
    }
}
