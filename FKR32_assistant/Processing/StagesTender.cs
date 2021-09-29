using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FKR32_assistant.Processing

{
    public class StagesTender
    {
        //publik bool flag 

        public DateTime CheckingNoWorkingDays(DateTime date) // проверка на нерабочий день
        {
            DateTime check = date;
            string[] weekend = new string[2] { "Saturday", "Sunday" }; // создание массива

            string pathHolidays = @"C:\Git\FKR32_assistant\FKR32_assistant\Docs\Holidays.txt";
            List<string> listWH = new List<string>();
            StreamReader srHolidays = new StreamReader(pathHolidays, System.Text.Encoding.Default);
            while (!srHolidays.EndOfStream) listWH.Add(srHolidays.ReadLine()); // создание списка

            bool wik = true;
            bool hol = true;
            while (wik == true | hol == true) // цыкл проверки на нерабочий день
            {
                string dayOfWeek = check.DayOfWeek.ToString();
                string dateChecking = check.ToShortDateString();
                wik = weekend.Contains(dayOfWeek);
                hol = listWH.Contains(dateChecking);
                if (wik == true | hol == true) check = check.AddDays(1);
            }
            
            DateTime result = check;
            return result;

        }

        public string DayOfWeekTranslation(DateTime date)
        {
            string dayOfWeek = date.DayOfWeek.ToString();
            Dictionary<string, string> dic = new Dictionary<string, string>
            {
                ["Monday"] = "Понедельник",
                ["Tuesday"] = "Вторник",
                ["Wednesday"] = "Среда",
                ["Thursday"] = "Четверг",
                ["Friday"] = "Пятница"
            };
            dayOfWeek = dic[dayOfWeek];
            return dayOfWeek; 
        }

        public List<Structures.StagesTenderForListView> stagesTenders { get; set; }

        public void CalculationOfDates(DateTime selectDate, bool flag)
        {
            stagesTenders = new List<Structures.StagesTenderForListView>();

            DateTime dateTime = selectDate.AddDays(20); 
            dateTime = CheckingNoWorkingDays(dateTime);
            string dayOfWeek = DayOfWeekTranslation(dateTime);

            Structures.StagesTenderForListView stage1 = new Structures.StagesTenderForListView
            {
                NameStage = "Дата окончания приема заявок",
                StageDate = dateTime.ToShortDateString(),
                DayWeek = dayOfWeek,
            };

            stagesTenders.Add(stage1);

            if (flag != true)
            {
                dateTime = dateTime.AddDays(1);
                dateTime = CheckingNoWorkingDays(dateTime);
                dayOfWeek = DayOfWeekTranslation(dateTime);
            }

            Structures.StagesTenderForListView stage2 = new Structures.StagesTenderForListView
            {
                NameStage = "Дата рассмотрения заявок",
                StageDate = dateTime.ToShortDateString(),
                DayWeek = dayOfWeek,
            };

            stagesTenders.Add(stage2);

            dateTime = dateTime.AddDays(3);
            dateTime = CheckingNoWorkingDays(dateTime);
            dayOfWeek = DayOfWeekTranslation(dateTime);

            Structures.StagesTenderForListView stage3 = new Structures.StagesTenderForListView
            {
                NameStage = "Дата подведения итогов ЭА",
                StageDate = dateTime.ToShortDateString(),
                DayWeek = dayOfWeek,
            };

            stagesTenders.Add(stage3);

            dateTime = dateTime.AddDays(10);
            dateTime = CheckingNoWorkingDays(dateTime);
            dayOfWeek = DayOfWeekTranslation(dateTime);

            Structures.StagesTenderForListView stage4 = new Structures.StagesTenderForListView
            {
                NameStage = "Дата начала периода заключения договора",
                StageDate = dateTime.ToShortDateString(),
                DayWeek = dayOfWeek,
            };

            stagesTenders.Add(stage4);

            dateTime = dateTime.AddDays(9);
            dateTime = CheckingNoWorkingDays(dateTime);
            dayOfWeek = DayOfWeekTranslation(dateTime);

            Structures.StagesTenderForListView stage5 = new Structures.StagesTenderForListView
            {
                NameStage = "Дата окончания периода заключения договора",
                StageDate = dateTime.ToShortDateString(),
                DayWeek = dayOfWeek,
            };

            stagesTenders.Add(stage5);

        }
    }
}
