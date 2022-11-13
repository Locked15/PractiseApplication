using NPOI.OpenXmlFormats.Wordprocessing;
using NPOI.XWPF.UserModel;
using PractiseApplication.Controllers.Standalone.Documentation;
using PractiseApplication.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace PractiseApplication.Controllers.Standalone
{
    class ReportController : BaseController
    {
        #region Constants.

        private const string _placeholderContent = "____";

        private const string _userName = "Header_UserName";

        private const string _userInfo = "Header_UserInformation";

        private const string _userRole = "Header_UserRole";

        private const string _requestTitle = "Table_RequestTitle";

        private const string _requestType = "Table_RequestType";

        private const string _requestStatus = "Table_RequestStatus";

        private const string _requestLocation = "Table_RequestLocation";

        private const string _requestCompletionTime = "Table_RequestTiming";

        private const string _totalRequestsCount = "Footer_TotalRequestsCount";
        #endregion

        #region Properties.

        public User CurrentUser { get; private set; }

        public List<Request> AvailableRequests { get; set; }
        #endregion

        #region Constructors.

        public ReportController(string path, User user) : base(path)
        {
            CurrentUser = user;

            AvailableRequests = CurrentUser.RequestRequesters.ToList();
            AvailableRequests.AddRange(CurrentUser.RequestExecutioners);
            AvailableRequests.Distinct();
        }
        #endregion

        #region Functions.

        public override void BeginDocumentCreation()
        {
            var bookmarks = GetBookmarks();
            FillDocumentPlaceholders(bookmarks);

            SaveDocument();
        }

        private void FillDocumentPlaceholders(List<(XWPFParagraph paragraph, CT_Bookmark bookmark)> marks)
        {
            foreach (var mark in marks)
            {
                switch (mark.bookmark.name)
                {
                    case _userName:
                        mark.paragraph.ReplaceText(_placeholderContent, CurrentUser.Login);
                        break;
                    case _userInfo:
                        mark.paragraph.ReplaceText(_placeholderContent, $"{CurrentUser.Bind_UserName} {CurrentUser.Patronymic}");
                        break;
                    case _userRole:
                        mark.paragraph.ReplaceText(_placeholderContent, CurrentUser.Role?.Title ?? "[ДАННЫЕ_УДАЛЕНЫ]");
                        break;
                    case _requestTitle:
                        InsertInfoAboutRequestTitles(mark.paragraph);
                        break;
                    case _requestType:
                        InsertInfoAboutRequestTypes(mark.paragraph);
                        break;
                    case _requestStatus:
                        InsertInfoAboutRequestStatus(mark.paragraph);
                        break;
                    case _requestLocation:
                        InsertInfoAboutRequestLocation(mark.paragraph);
                        break;
                    case _requestCompletionTime:
                        InsertInfoAboutRequestCompletionTime(mark.paragraph);
                        break;
                    case _totalRequestsCount:
                        mark.paragraph.ReplaceText(_placeholderContent, AvailableRequests.Count.ToString());
                        break;

                    default:
                        MessageBox.Show("В процессе создания документа был обнаружен неизвестный тэг.",
                                        "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;
                }
            }
        }

        #region Table Values Filling.

        private void InsertInfoAboutRequestTitles(XWPFParagraph paragraph)
        {
            foreach (var request in AvailableRequests)
            {
                XWPFRun run = paragraph.CreateRun();
                run.SetText(request.Title);

                if (request != AvailableRequests.Last())
                    run.AddBreak(BreakType.TEXTWRAPPING);
            }
        }

        private void InsertInfoAboutRequestTypes(XWPFParagraph paragraph)
        {
            foreach (var request in AvailableRequests)
            {
                XWPFRun run = paragraph.CreateRun();
                run.SetText(request.RequestType?.Type ?? "Неопределенный");

                if (request != AvailableRequests.Last())
                    run.AddBreak(BreakType.TEXTWRAPPING);
            }
        }

        private void InsertInfoAboutRequestStatus(XWPFParagraph paragraph)
        {
            foreach (var request in AvailableRequests)
            {
                XWPFRun run = paragraph.CreateRun();
                run.SetColor(request.RequestStatus?.ColorRgbStringValue ?? "0, 0, 0");
                run.SetText(request.RequestStatus?.Status ?? "Неизвестно");

                if (request != AvailableRequests.Last())
                    run.AddBreak(BreakType.TEXTWRAPPING);
            }
        }

        private void InsertInfoAboutRequestLocation(XWPFParagraph paragraph)
        {
            foreach (var request in AvailableRequests)
            {
                XWPFRun run = paragraph.CreateRun();
                run.SetText(request.Location?.Bind_ComplexValue ?? "[ДАННЫЕ_УДАЛЕНЫ]");

                if (request != AvailableRequests.Last())
                    run.AddBreak(BreakType.TEXTWRAPPING);
            }
        }

        private void InsertInfoAboutRequestCompletionTime(XWPFParagraph paragraph)
        {
            foreach (var request in AvailableRequests)
            {
                XWPFRun run = paragraph.CreateRun();
                run.SetText(request.RequestCompletionTime.ToString("hh:mm"));

                if (request != AvailableRequests.Last())
                    run.AddBreak(BreakType.TEXTWRAPPING);
            }
        }
        #endregion
        #endregion
    }
}