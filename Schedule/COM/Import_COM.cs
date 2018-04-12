using Schedule.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Excel = Microsoft.Office.Interop.Excel;

namespace Schedule.COM
{
    public static class Release
    {

        public static void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception)
            {
                obj = null;
            }
            GC.Collect();
        }
    }


    public static class Import_COM
    {
        public static List<TableDataDTO> Import_Excel(string pathfile)
        {
            List<TableDataDTO> list = new List<TableDataDTO>();
           

            Microsoft.Office.Interop.Excel.Application xlApp = new Excel.Application();
            xlApp.Visible = false;

            Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;

            Microsoft.Office.Interop.Excel.Workbook xlBook = workbooks.Open(pathfile,
             Type.Missing, Type.Missing, Type.Missing, Type.Missing,
             Type.Missing, Type.Missing, Type.Missing, Type.Missing,
             Type.Missing, Type.Missing, Type.Missing, Type.Missing,
             Type.Missing, Type.Missing);

            TableInEx(xlBook, list);

            try
            {
                xlBook.Saved = true;
                xlBook.Close();
                xlApp.Quit();
            }
            finally
            {
                Release.ReleaseObject(workbooks);
                Release.ReleaseObject(xlBook);
                Release.ReleaseObject(xlApp);
            }
            return list;
        }

        static void TableInEx(Excel.Workbook wb, List<TableDataDTO> data)
        {
            try
            {
                Excel.Worksheet xlSheet = (Excel.Worksheet)wb.Worksheets.get_Item(1);
                Excel.Range excelcells;
                int count = 11;
                for (; ; )
                {
                    excelcells = xlSheet.get_Range("A" + count.ToString(), Type.Missing);
                    String num_r = Convert.ToString(excelcells.Value);
                    if (num_r == null)
                    {
                        break;
                    }
                    TableDataDTO temp = new TableDataDTO();

                    temp.id = Convert.ToInt32(num_r);
                    excelcells = xlSheet.get_Range("B" + count.ToString(), Type.Missing);
                    temp.SubjectName = Convert.ToString(excelcells.Value);
                    excelcells = xlSheet.get_Range("C" + count.ToString(), Type.Missing);
                    temp.Faculty = Convert.ToString(excelcells.Value);
                    excelcells = xlSheet.get_Range("D" + count.ToString(), Type.Missing);
                    temp.Caf = Convert.ToString(excelcells.Value);
                    excelcells = xlSheet.get_Range("E" + count.ToString(), Type.Missing);
                    temp.Speciality = Convert.ToString(excelcells.Value);
                    excelcells = xlSheet.get_Range("F" + count.ToString(), Type.Missing);
                    temp.Grade = Convert.ToInt32(excelcells.Value);
                    excelcells = xlSheet.get_Range("G" + count.ToString(), Type.Missing);
                    temp.Term = Convert.ToInt32(excelcells.Value);
                    excelcells = xlSheet.get_Range("H" + count.ToString(), Type.Missing);
                    temp.Groups = Convert.ToString(excelcells.Value);
                    excelcells = xlSheet.get_Range("I" + count.ToString(), Type.Missing);
                    temp.GroupCount = Convert.ToInt32(excelcells.Value);
                    excelcells = xlSheet.get_Range("J" + count.ToString(), Type.Missing);
                    temp.StudentCount = Convert.ToInt32(excelcells.Value);


                    //Hours first half
                    excelcells = xlSheet.get_Range("K" + count.ToString(), Type.Missing);
                    temp.LectionCountAWeekPerFirstHalf = Convert.ToInt32(excelcells.Value);
                    excelcells = xlSheet.get_Range("L" + count.ToString(), Type.Missing);
                    temp.LectionCountPerFirstHalf = Convert.ToInt32(excelcells.Value);
                    excelcells = xlSheet.get_Range("M" + count.ToString(), Type.Missing);
                    temp.LabCountAWeekPerFirstHalf = Convert.ToInt32(excelcells.Value);
                    excelcells = xlSheet.get_Range("N" + count.ToString(), Type.Missing);
                    temp.LabCountPerFirstHalf = Convert.ToInt32(excelcells.Value);
                    excelcells = xlSheet.get_Range("O" + count.ToString(), Type.Missing);
                    temp.PracticeCountAWeekPerFirstHalf = Convert.ToInt32(excelcells.Value);
                    excelcells = xlSheet.get_Range("P" + count.ToString(), Type.Missing);
                    temp.PracticeCountPerFirstHalf = Convert.ToInt32(excelcells.Value);

                    //hours second half
                    excelcells = xlSheet.get_Range("Q" + count.ToString(), Type.Missing);
                    temp.LectionCountAWeekPerSecondHalf = Convert.ToInt32(excelcells.Value);
                    excelcells = xlSheet.get_Range("R" + count.ToString(), Type.Missing);
                    temp.LectionCountPerSecondHalf = Convert.ToInt32(excelcells.Value);
                    excelcells = xlSheet.get_Range("S" + count.ToString(), Type.Missing);
                    temp.LabCountAWeekPerSecondHalf = Convert.ToInt32(excelcells.Value);
                    excelcells = xlSheet.get_Range("T" + count.ToString(), Type.Missing);
                    temp.LabCountPerSecondHalf = Convert.ToInt32(excelcells.Value);
                    excelcells = xlSheet.get_Range("U" + count.ToString(), Type.Missing);
                    temp.PracticeCountAWeekPerSecondHalf = Convert.ToInt32(excelcells.Value);
                    excelcells = xlSheet.get_Range("V" + count.ToString(), Type.Missing);
                    temp.PracticeCountPerSecondHalf = Convert.ToInt32(excelcells.Value);


                    //works
                    excelcells = xlSheet.get_Range("W" + count.ToString(), Type.Missing);
                    temp.RGR = Convert.ToInt32(excelcells.Value);
                    excelcells = xlSheet.get_Range("X" + count.ToString(), Type.Missing);
                    temp.RR = Convert.ToInt32(excelcells.Value);
                    excelcells = xlSheet.get_Range("Y" + count.ToString(), Type.Missing);
                    temp.RK = Convert.ToInt32(excelcells.Value);
                    excelcells = xlSheet.get_Range("Z" + count.ToString(), Type.Missing);
                    temp.CourserWork = Convert.ToInt32(excelcells.Value);
                    excelcells = xlSheet.get_Range("AA" + count.ToString(), Type.Missing);
                    temp.CourseProject = Convert.ToInt32(excelcells.Value);



                    //Form control
                    excelcells = xlSheet.get_Range("AB" + count.ToString(), Type.Missing);
                    temp.FormControlZach = Convert.ToBoolean(excelcells.Value);
                    excelcells = xlSheet.get_Range("AC" + count.ToString(), Type.Missing);
                    temp.FormControlDiv = Convert.ToBoolean(excelcells.Value);
                    excelcells = xlSheet.get_Range("AD" + count.ToString(), Type.Missing);
                    temp.FormControlExam = Convert.ToBoolean(excelcells.Value);


                    //load
                    excelcells = xlSheet.get_Range("AE" + count.ToString(), Type.Missing);
                    temp.AllCredits = Convert.ToDouble(excelcells.Value);
                    excelcells = xlSheet.get_Range("AF" + count.ToString(), Type.Missing);
                    temp.SelfWorkHours = Convert.ToDouble(excelcells.Value);
                    excelcells = xlSheet.get_Range("AG" + count.ToString(), Type.Missing);
                    temp.StudyLoad = Convert.ToDouble(excelcells.Value);
                    excelcells = xlSheet.get_Range("AH" + count.ToString(), Type.Missing);
                    temp.Npr = Convert.ToDouble(excelcells.Value);

                    data.Add(temp);
                    count++;
                }

            }
            catch { }

        }

    }
}