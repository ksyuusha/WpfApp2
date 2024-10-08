using System;

public class NotificationHandlers
{
    // Обработчик для отправки сообщения
    public void HandleMessageSent(string message)
    {
        Console.WriteLine($"Сообщение отправлено: {message}");
    }

    // Обработчик для совершения звонка
    public void HandleCallMade(string phoneNumber)
    {
        Console.WriteLine($"Звонок совершен на номер: {phoneNumber}");
    }

    // Обработчик для отправки email
    public void HandleEmailSent(string email)
    {
        Console.WriteLine($"Email отправлен на адрес: {email}");
    }
}
