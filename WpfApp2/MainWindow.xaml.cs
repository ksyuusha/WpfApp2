using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp2
{
    public partial class MainWindow : Window
    {
        // Импортируем функцию для выделения консоли
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        public MainWindow()
        {
            InitializeComponent();
            AllocConsole();  // Вызываем консоль для вывода сообщений

            SetPlaceholder(messageTextBox);
            SetPlaceholder(phoneTextBox);
            SetPlaceholder(emailTextBox);
        }

        // Метод для установки placeholder
        private void SetPlaceholder(TextBox textBox)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = textBox.Tag.ToString();
                textBox.Foreground = System.Windows.Media.Brushes.Gray;
            }
        }

        // Обработчик события получения фокуса
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text == textBox.Tag.ToString())
            {
                textBox.Text = string.Empty;
                textBox.Foreground = System.Windows.Media.Brushes.Black;
            }
        }

        // Обработчик события потери фокуса
        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = textBox.Tag.ToString();
                textBox.Foreground = System.Windows.Media.Brushes.Gray;
            }
        }

        // Пример отправки сообщения
        private void SendMessage_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(messageTextBox.Text) && messageTextBox.Text != messageTextBox.Tag.ToString())
            {
                resultTextBlock.Text = "Сообщение отправлено: " + messageTextBox.Text;
                Console.WriteLine("Сообщение отправлено: " + messageTextBox.Text); // Вывод в консоль
            }
            else
            {
                resultTextBlock.Text = "Введите сообщение!";
                Console.WriteLine("Ошибка: сообщение не введено."); // Вывод ошибки в консоль
            }
        }

        // Пример звонка
        private void MakeCall_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(phoneTextBox.Text) && phoneTextBox.Text != phoneTextBox.Tag.ToString())
            {
                resultTextBlock.Text = "Звонок на номер: " + phoneTextBox.Text;
                Console.WriteLine("Звонок на номер: " + phoneTextBox.Text); // Вывод в консоль
            }
            else
            {
                resultTextBlock.Text = "Введите номер телефона!";
                Console.WriteLine("Ошибка: номер телефона не введен."); // Вывод ошибки в консоль
            }
        }

        // Пример отправки email
        private void SendEmail_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(emailTextBox.Text) && emailTextBox.Text != emailTextBox.Tag.ToString())
            {
                resultTextBlock.Text = "Email отправлен на: " + emailTextBox.Text;
                Console.WriteLine("Email отправлен на: " + emailTextBox.Text); // Вывод в консоль
            }
            else
            {
                resultTextBlock.Text = "Введите email!";
                Console.WriteLine("Ошибка: email не введен."); // Вывод ошибки в консоль
            }
        }
    }
}
