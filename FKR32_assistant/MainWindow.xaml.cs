using System.Windows;
using System.Windows.Controls;

namespace FKR32_assistant
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
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

        }

        private string DatePicker_SelectedDateChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            string datePickerDate = (sender as DatePicker).SelectedDate.ToString();
            
            return datePickerDate;
        }

    }
}
