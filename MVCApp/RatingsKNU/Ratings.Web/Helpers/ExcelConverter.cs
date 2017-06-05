using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ratings.Data.Entities;
using Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace Ratings.Web.Helpers
{
    public static class ExportExcel
    {
        public static void ExportRatingsToExel(IEnumerable<IndexValue> indexValues, Rating rating)
        {
            if (RatingExcelAnalyzer.IsRatingFull(indexValues))
            {
                Application xlApp = new Application();

                xlApp.Visible = true;

                Workbook wb = xlApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
                Worksheet ws = (Worksheet)wb.Worksheets[1];
                ws.Name = rating.Name;

                int i = 1;
                foreach (IndexValue indexValue in indexValues)
                { 
                    Range aRange = ws.get_Range("A"+i);
                    object[] args = new object[1];
                    args[0] = indexValue.Index.Name;
                    aRange.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, aRange, args);

                    aRange = ws.get_Range("B" + i);
                    args = new object[1];
                    args[0] = indexValue.Value;
                    aRange.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, aRange, args);
                }
            }
            else
            {
                throw new Exception();
            }

        }
    }
    public static class RatingExcelAnalyzer
    {
        public static bool IsRatingFull(IEnumerable<IndexValue> indexValues)
        {
            bool isRatingFull = true;
            foreach (IndexValue indexValue in indexValues)
            {
                if (indexValue.Value == null)
                {
                    isRatingFull = false;
                }
            }
            return isRatingFull;
        }
    }
}