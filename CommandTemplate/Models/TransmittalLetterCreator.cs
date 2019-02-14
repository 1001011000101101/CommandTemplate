using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OfficeOpenXml;
using Xceed.Words.NET;

namespace CommandTemplate.Models
{
    public class TransmittalLetterCreator : Combinator, IDisposable
    {
        private string templateFilePath;
        private string dataFilePath;
        private string outputFolder;
        private string[] allowedFileExtensions = { ".doc", ".xls", ".xlsx", ".docx" };
        private string outputFileName = "Output-#.docx";

        private ExcelPackage excelPackage;
        private DocX documentTemplate;

        public TransmittalLetterCreator(string templateFilePath, string dataFilePath, string outputFolder)
        {
            this.templateFilePath = templateFilePath;
            this.dataFilePath = dataFilePath;
            this.outputFolder = outputFolder;
        }

        public override void OpenFiles()
        {
            if (!allowedFileExtensions.Contains(Path.GetExtension(templateFilePath)) || !allowedFileExtensions.Contains(Path.GetExtension(dataFilePath)))
                return;

            excelPackage = new ExcelPackage(new FileInfo(dataFilePath));
            documentTemplate = DocX.Load(templateFilePath);
        }

        public override void CreateFiles()
        {
            //Implement combine logic
            int i = 1;
            foreach (var e in excelPackage.Workbook.Worksheets[1].Cells)
            {
                string fileName = outputFileName.Replace("#", i.ToString());
                using (var document = DocX.Create(Path.Combine(outputFolder, fileName)))
                {
                    document.Save();
                }
                i++;
            }
        }

        public override void CloseFiles()
        {
            Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // get rid of managed resources

                if (excelPackage != null)
                    excelPackage.Dispose();

                if (documentTemplate != null)
                    documentTemplate.Dispose();
            }
            // get rid of unmanaged resources
        }
    }
}
