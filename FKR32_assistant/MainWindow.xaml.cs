using FKR32_assistant.Processing;
using System;
using System.Windows;
using System.Windows.Controls;

namespace FKR32_assistant
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MinButton_Click(object sender, RoutedEventArgs e)
        {

            this.Hide();

        }

        private void TaskbarIcon_TrayLeftMouseDown(object sender, RoutedEventArgs e)
        {
            this.Show();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            //bool newcbFlag = false;
            //if (cbFlag.IsChecked == true) newcbFlag = true;
            //StagesTender flag = new StagesTender();
            //flag.flag = newcbFlag;
        }
        private void DatePicker_SelectedDateChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            DateTime selectedDate = (DateTime)((DatePicker)sender).SelectedDate;
            bool flag = false;

            StagesTender stagesTender = new StagesTender();
            stagesTender.CalculationOfDates(selectedDate, flag);

            this.DataContext = stagesTender;
        }

    }

}
