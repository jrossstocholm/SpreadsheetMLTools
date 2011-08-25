using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace Create
{
    public class MostlyGeneratedClass
    {
        // Creates a SpreadsheetDocument
        public void CreatePackage(string filePath)
        {
            using (SpreadsheetDocument package = SpreadsheetDocument.Create(filePath, SpreadsheetDocumentType.Workbook))
            {
                CreateParts(package);
            }
        }

        // Adds child parts and generates content of the specified part
        private void CreateParts(SpreadsheetDocument document)
        {
            WorkbookPart workbookPart1 = document.AddWorkbookPart();
            GenerateWorkbookPart1Content(workbookPart1);

            WorksheetPart worksheetPart1 = workbookPart1.AddNewPart<WorksheetPart>("rId1");
            GenerateWorksheetPart1Content(worksheetPart1);
        }

        // Generates content of workbookPart1. 
        private void GenerateWorkbookPart1Content(WorkbookPart workbookPart1)
        {
            Workbook workbook1 = new Workbook();
            workbook1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");

            Sheets sheets1 = new Sheets();
            Sheet sheet1 = new Sheet() { Name = "Sheet1", SheetId = (UInt32Value)1U, Id = "rId1" };
            sheets1.Append(sheet1);

            workbook1.Append(sheets1);
            workbookPart1.Workbook = workbook1;
        }

        // Generates content of worksheetPart1. 
        private void GenerateWorksheetPart1Content(WorksheetPart worksheetPart1)
        {
            Worksheet worksheet1 = new Worksheet();
            SheetData sheetData1 = new SheetData();

            Row row1 = new Row();
            Cell cell1 = new Cell() { CellReference = "A1", DataType = CellValues.InlineString };
            InlineString inlineString1 = new InlineString();
            Text text1 = new Text();
            text1.Text = "hello";
            inlineString1.Append(text1);
            cell1.Append(inlineString1);
            row1.Append(cell1);

            sheetData1.Append(row1);
            worksheet1.Append(sheetData1);
            worksheetPart1.Worksheet = worksheet1;
        }
    }
}
