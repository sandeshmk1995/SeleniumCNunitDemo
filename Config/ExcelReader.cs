using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace SeleniumCAzure.Config
{
    public static class ExcelReader
    {
        public static string GetExcelValue(int row, int col)
        {
            using(var fs = new FileStream("C:\\SeleniumCAzure\\TestData\\TestDataFile.xlsx", FileMode.Open,FileAccess.Read))
            {
                XSSFWorkbook wb = new XSSFWorkbook(fs);
                return wb.GetSheetAt(0).GetRow(row).GetCell(col).ToString()!;
            }
        }

        public static IEnumerable<TestCaseData> GetAccountData(){
            using(var fs = new FileStream("C:\\SeleniumCAzure\\TestData\\TestDataFile.xlsx", FileMode.Open, FileAccess.Read))
            {
                XSSFWorkbook workbook = new XSSFWorkbook(fs);
                NPOI.SS.UserModel.ISheet sheet = workbook.GetSheetAt(0);
                int rowCount = sheet.LastRowNum;
                int colCount = sheet.GetRow(0).LastCellNum;
                for (int i = 0; i<=rowCount; i++)
                {   
                    IRow row = sheet.GetRow(i);
                    string[] list = new string[colCount];
                    for (int j = 0; j < colCount; j++)
                    {
                      string value = row.GetCell(j).ToString()!;
                      list[j]=value;
                    }
                   yield return new TestCaseData(new object[] { list });

                }
            }
        }
    }
}
