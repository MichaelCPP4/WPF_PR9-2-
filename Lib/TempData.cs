using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public static class TempData
    {/// <summary>
     /// Создаёт визуализацию даннных на DataGrid из передаваемого списка структуры person
     /// </summary>
     /// <param name="personLict">Список содержащий экземпляры структуры person</param>
     /// <returns>Представление таблицы</returns>
        public static DataTable ToDataTable(this List<Person> personLict)
        {

            var tempData = new DataTable();


            tempData.Columns.Add("Номер", typeof(int));
            tempData.Columns.Add("ФИО", typeof(string));
            tempData.Columns.Add("Пол", typeof(string));
            tempData.Columns.Add("Год Рождения", typeof(Int16));
            tempData.Columns.Add("Место рождения", typeof(string));
            tempData.Columns.Add("национальность", typeof(string));


            tempData.Columns[0].AutoIncrementSeed = 1;
            tempData.Columns[0].AutoIncrement = true;


            for (int i = 0; i < personLict.Count; i++)
            {
                DataRow row = tempData.NewRow();


                row[1] = personLict[i].Fio;
                row[2] = personLict[i].Gender;
                row[3] = personLict[i].YearOfBirth;
                row[4] = personLict[i].PlaceOfBirth;
                row[5] = personLict[i].Nationality;


                tempData.Rows.Add(row);
            }


            return tempData;
        }
    }
}
