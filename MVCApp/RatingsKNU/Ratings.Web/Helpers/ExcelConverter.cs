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
            var xlApp = new Application();

            var wb = xlApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            var ws = (Worksheet) wb.Worksheets[1];
            ws.Name = rating.Name;

            var i = 1;
            foreach (var indexValue in indexValues)
            {
                var aRange = ws.Range["A" + i];
                var args = new object[1];
                args[0] = indexValue.Index.Name;
                aRange.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, aRange, args);

                aRange = ws.Range["B" + i];
                args = new object[1];
                args[0] = indexValue.Value;
                aRange.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, aRange, args);
                i++;
            }

            ws.Range["A" + 1].EntireColumn.AutoFit();
            xlApp.Visible = true;
        }
    }
}