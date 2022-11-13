using NPOI.OpenXmlFormats.Wordprocessing;
using NPOI.XWPF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;

namespace PractiseApplication.Controllers.Standalone.Documentation
{
    abstract class BaseController
    {
        #region Properties.

        public string Path { get; set; }

        public XWPFDocument Document { get; set; }
        #endregion

        #region Initializers.

        public BaseController(string path)
        {
            Path = path;

            using Stream stream = new FileStream(GetPath(), FileMode.Open);
            Document = new XWPFDocument(stream);
        }

        private string GetPath()
        {
            String currentDir = ResourceController.GetProjectDirectory();
            currentDir = System.IO.Path.Combine(currentDir, "Resources", "Templates", "Report.docx");

            return currentDir;
        }
        #endregion

        #region Functions.

        public abstract void BeginDocumentCreation();

        protected List<(XWPFParagraph paragraph, CT_Bookmark bookmark)> GetBookmarks()
        {
            List<(XWPFParagraph paragraph, CT_Bookmark bookmark)> marks = new List<(XWPFParagraph paragraph, CT_Bookmark bookmark)>(1);

            marks.AddRange(GetBookmarksInText());
            marks.AddRange(GetBookmarksInTables());

            return marks;
        }

        protected List<(XWPFParagraph paragraph, CT_Bookmark bookmark)> GetBookmarksInText()
        {
            List<(XWPFParagraph paragraph, CT_Bookmark bookmark)> marks = new List<(XWPFParagraph paragraph, CT_Bookmark bookmark)>(1);

            foreach (XWPFParagraph paragraph in Document.Paragraphs)
            {
                CT_P info = paragraph.GetCTP();

                foreach (CT_Bookmark mark in info.GetBookmarkStartList())
                {
                    marks.Add((paragraph, mark));
                }
            }

            return marks;
        }

        protected List<(XWPFParagraph paragraph, CT_Bookmark bookmark)> GetBookmarksInTables()
        {
            List<(XWPFParagraph paragraph, CT_Bookmark bookmark)> marks = new List<(XWPFParagraph paragraph, CT_Bookmark bookmark)>(1);

            foreach (XWPFTable table in Document.Tables)
            {
                foreach (XWPFTableRow row in table.Rows)
                {
                    foreach (XWPFTableCell cell in row.GetTableCells())
                    {
                        foreach (XWPFParagraph paragraph in cell.Paragraphs)
                        {
                            CT_P info = paragraph.GetCTP();

                            foreach (CT_Bookmark bookmark in info.GetBookmarkStartList())
                            {
                                marks.Add((paragraph, bookmark));
                            }
                        }
                    }
                }
            }

            return marks;
        }

        protected void SaveDocument()
        {
            using (Stream stream = new FileStream(Path, FileMode.Create))
            {
                Document.Write(stream);
            }
        }
        #endregion
    }
}
