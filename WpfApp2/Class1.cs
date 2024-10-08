using System;

namespace WpfAppNotifications
{
    // Класс, представляющий систему уведомлений
    public class Notification
    {
        // События для разных типов уведомлений
        public event EventHandler<string> OnMessageSent;    // Событие отправки сообщения
        public event EventHandler<string> OnCallMade;       // Событие совершения звонка
        public event EventHandler<string> OnEmailSent;      // Событие отправки email

        // Метод для отправки сообщения
        public void SendMessage(string message)
        {
            Console.WriteLine($"Сообщение отправлено: {message}");
            OnMessageSent?.Invoke(this, message);
        }

        // Метод для звонка
        public void MakeCall(string phoneNumber)
        {
            Console.WriteLine($"Звонок на номер: {phoneNumber}");
            OnCallMade?.Invoke(this, phoneNumber);
        }

        // Метод для отправки email
        public void SendEmail(string email)
        {
            Console.WriteLine($"Email отправлен на: {email}");
            OnEmailSent?.Invoke(this, email);
        }
    }
}
