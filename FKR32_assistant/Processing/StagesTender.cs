using System;
using System.Collections.Generic;
using System.IO;

namespace FKR32_assistant.Processing

{
    public class StagesTender
    {

        public bool CheckingNoWorkingDays(string date) // проверка на нерабочий день
        {
            string path = @"C:\Git\FKR32_assistant\FKR32_assistant\Docs\WeekendsAndHolidays.txt";
            bool result = false;

            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    int count = String.Compare(date, line);
                    if (count == 1) result = true;
                }

                return result;
            }
        }

        public DateTime AddDaysIfNoWorkingDays(DateTime date)  // добавляем дни до понедельника
        {
            DateTime dateTime = date;
            string stDate = date.ToString();
            stDate = stDate.Substring(0, stDate.Length - 8);
            
            for (int i = 0; i == 2; i++)
            {
                bool flag = CheckingNoWorkingDays(stDate);
                if (flag == true) dateTime.AddDays(1);
            }

            return dateTime;
        }

        public List<Structures.StagesTenderForListView> stagesTenders { get; set; }

        public void CalculationOfDates(DateTime selectDate, bool flag)
        {
            stagesTenders = new List<Structures.StagesTenderForListView>();
            
            DateTime dateTime = selectDate.AddDays(20);

            Structures.StagesTenderForListView stage1 = new Structures.StagesTenderForListView
            {
                NameStage = "Дата окончания приема заявок",
                StageDate = AddDaysIfNoWorkingDays(dateTime).ToShortDateString(),
                DayWeek = "Четверг"
            };

            stagesTenders.Add(stage1);

        }


        





    }
}
