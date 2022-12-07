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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Lib;

namespace WPF_PR9
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            comboBoxGender.ItemsSource = new List<string>() { "Мужчина", "Женщина" };


            listPerson.Add(new Person("Козин Александр Романович", "Мужчина", "Русский", "Москва", 2004));
            listPerson.Add(new Person("Казакова Валерия Кирилловна", "Женщина", "Русская", "рязань", 1998));
            listPerson.Add(new Person("Яковлева Полина Григорьевна", "Женщина", "Русская", "Донецк", 2001));
            listPerson.Add(new Person("Попов Матвей Максимович", "Мужчина", "Еврей", "Санкт-Петербург", 1990));
            listPerson.Add(new Person("Жмышенко Валерий Альбертович", "Мужчина", "Украинец", "Одесса", 1968));

            dataGrid.ItemsSource = listPerson.ToDataTable().DefaultView;
        }
        Int16 currentYear = (Int16)DateTime.Now.Year;
        List<Person> listPerson = new List<Person>();

        private void ButtonCreate_Click(object sender, RoutedEventArgs e)
        {
            string[] fioMas = textBoxFIO.Text.Split(' ');

            if (fioMas.Length == 3 && textBoxNationality.Text != String.Empty && Int16.TryParse(textBoxYearOfBirth.Text, out Int16 yearOfBirth))
            {
                string fio = $"{fioMas[0]} {fioMas[1]} {fioMas[2]}";

                Person person = new Person(fio, comboBoxGender.SelectedItem.ToString(), textBoxNationality.Text, textBoxPlaceOfBirth.Text,yearOfBirth);

                listPerson.Add(person);

                dataGrid.ItemsSource = listPerson.ToDataTable().DefaultView;
            }
            else
            {
                MessageBox.Show("Данные введены не верно", "Error");
            }

        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(textBoxIndex.Text, out int index) && index >= 1 && index <= listPerson.Count )
            {
                listPerson.RemoveAt(index-1);
                dataGrid.ItemsSource = listPerson.ToDataTable().DefaultView;
            }
            else
            {
                MessageBox.Show("Введите номер.", "Error");
            }
        }

        private void MenuItemInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Заполнить таблицу анкетных данных на 5 человек с полями: ФИО, пол, год \r\nрождения, место рождения, национальность. Вывести результат на экран. Вывести \r\nсредний возраст.", "О программе");
        }

        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonRas_Click(object sender, RoutedEventArgs e)
        {
            int result = 0;
            for (int i = 0; i < listPerson.Count; i++)
            {
                result += currentYear - listPerson[i].YearOfBirth;
            }
            
            textBoxSrVozrost.Text = Convert.ToString(result/listPerson.Count);
        }
    }
}