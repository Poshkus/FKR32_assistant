using FKR32_assistant.Processing;
using FKR32_assistant.Structures;
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

        private bool flag;

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            bool newFlag = checkBox1.IsChecked == true;
            if (newFlag == true)
                flag = newFlag;
            else flag = false;
        }
        private void DatePicker_SelectedDateChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            DateTime selectedDate = (DateTime)((DatePicker)sender).SelectedDate;
            bool newFlag = flag;

            StagesTender stagesTender = new StagesTender();
            stagesTender.CalculationOfDates(selectedDate, flag);

            DataContext = stagesTender;
        }

    }

}
