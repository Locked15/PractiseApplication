using PractiseApplication.Models.Entities;
using System;
using System.Linq;
using System.Windows;

namespace PractiseApplication.Controllers.Standalone
{
    class RequestController
    {
        public static bool GenerateNewRequestInContext(string title, User author, Location location, RequestType type, bool verbose = true)
        {
            var newStatus = BaseContext.Instance.RequestStatuses.First(s => s.Status.StartsWith("Нов"));
            Request request = new Request()
            {
                Title = title,
                Requester = author,
                RequesterId = author.Id,
                Location = location,
                LocationId = location.Id,
                RequestType = type,
                RequestTypeId = type.Id,
                RequestStatus = newStatus,
                RequestStatusId = newStatus.Id,
                BeginDate = DateTime.Now
            };

            try
            {
                BaseContext.Instance.Requests.Add(request);
                BaseContext.Instance.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                if (verbose)
                    MessageBox.Show($"При добавлении заявки произошла ошибка: {ex.Message}.", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        public static bool GenerateNewRequestInContext(Request request, bool verbose = true)
        {
            try
            {
                BaseContext.Instance.Requests.Add(request);
                BaseContext.Instance.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                if (verbose)
                    MessageBox.Show($"При добавлении заявки произошла ошибка: {ex.Message}.", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        public static bool GenerateMessageToRequestInContext(string text, User author, Request request, bool verbose = true)
        {
            RequestChat chat = new()
            {
                AuthorId = author.Id,
                Author = author,
                Request = request,
                RequestId = request.Id,
                Message = text,
                SentDate = DateTime.Now
            };
            try
            {
                BaseContext.Instance.RequestChats.Add(chat);
                BaseContext.Instance.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                if (verbose)
                    MessageBox.Show($"Возникла ошибка генерации сообщения:\n{ex.Message}.", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
    }
}
