using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Desktop
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Page
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailTextBox.Text;
            string password = PasswordBox1.Text;
            string password1 = PasswordBox2.Text;
            string name = NameTextBox.Text;

            if (ValidateEmail(email) && ValidatePassword(password) && ValidateName(name) && password == password1)
            {
                MessageBox.Show("Регистрация успешно проведена!");
                NavigationService.Navigate(new Main_empty());
            }
            else
            {

                string errorMessage = "";

                if (!ValidateEmail(email))
                {
                    errorMessage += "Неверный формат почты\n";
                }

                if (!ValidatePassword(password))
                {
                    errorMessage += "Пароль меньше 6 симв.\n";
                }

                if (!ValidateName(name))
                {
                    errorMessage += "Имя короче 3 симв.\n";
                }

                MessageBox.Show(errorMessage, "Ошибка регистрации", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool ValidateName(string name)
        {
            throw new NotImplementedException();
        }

        private bool ValidatePassword(string password)
        {
            throw new NotImplementedException();
        }

        private bool ValidateEmail(string email)
        {
            throw new NotImplementedException();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Istoria());
        }
    }
    }

