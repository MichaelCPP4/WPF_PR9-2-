using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    /// <summary>
    /// Структура Person
    /// </summary>
    public struct Person
    {
        public string Fio { get; set; }
        public string Gender { get; set; }
        public Int16 YearOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Nationality { get; set; }
        /// <summary>
        /// Конструктор структуры Person
        /// </summary>
        /// <param name="fio">Фамилия Имя Отчество</param>
        /// <param name="gender">Пол</param>
        /// <param name="nationality">Национальность</param>
        /// <param name="placeOfBirth">Место рождения</param>
        /// <param name="yearOfBirth">Год рождения</param>
        public Person(string fio, string gender, string nationality, string placeOfBirth, Int16 yearOfBirth)
        {
            Fio = fio;
            Gender = gender;
            Nationality = nationality;
            PlaceOfBirth = placeOfBirth;
            YearOfBirth = yearOfBirth;
        }
    }
}