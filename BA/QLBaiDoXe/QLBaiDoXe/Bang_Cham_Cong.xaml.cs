using Microsoft.SqlServer.Server;
using QLBaiDoXe.DBClasses;
using QLBaiDoXe.ViewModel;
using System;
using System.Globalization;
using System.Windows.Controls;

namespace QLBaiDoXe
{
    /// <summary>
    /// Interaction logic for Bang_Cham_Cong.xaml
    /// </summary>
    public partial class Bang_Cham_Cong : UserControl
    {
        public Bang_Cham_Cong()
        {
            InitializeComponent();
            this.DataContext = new BangChamCongViewModel();
            StartDateDP.Text = EndDateDP.Text = DateTime.Now.Date.ToString();
            StartDateDP.DisplayDateStart = Staffing.GetFirstLogin();
            StartDateDP.DisplayDateEnd = Staffing.GetLastLogin();
            EndDateDP.DisplayDateEnd = StartDateDP.DisplayDateEnd;
        }

        private void StaffNameTxb_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (string.IsNullOrEmpty(StartDateDP.Text) || string.IsNullOrEmpty(EndDateDP.Text))
                TimekeepLV.ItemsSource = Staffing.GetTimekeepForStaff(StaffNameTxb.Text);
            else if (DateTime.TryParseExact(StartDateDP.Text + " 00:00:00", "d/M/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime startDate)
                && DateTime.TryParseExact(EndDateDP.Text + " 23:59:59", "d/M/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime endDate))
            {
                TimekeepLV.ItemsSource = Staffing.GetSpecificTimekeeps(StaffNameTxb.Text, startDate, endDate);
            }
        }

        private void StartDateDP_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(StartDateDP.Text) == false
                && DateTime.TryParseExact(StartDateDP.Text + " 00:00:00", "d/M/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime startDate))
            {
                EndDateDP.DisplayDateStart = startDate;
                if (EndDateDP.SelectedDate?.CompareTo(startDate) < 0)
                {
                    EndDateDP.SelectedDate = startDate.Date;
                }
                DateTime endDate = DateTime.MinValue;
                bool hasEndDate = string.IsNullOrWhiteSpace(EndDateDP.Text) == false
                    && DateTime.TryParseExact(EndDateDP.Text + " 23:59:59", "d/M/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out endDate);
                if (string.IsNullOrWhiteSpace(StaffNameTxb.Text) == false)
                {
                    TimekeepLV.ItemsSource = hasEndDate ? Staffing.GetSpecificTimekeeps(StaffNameTxb.Text, startDate, endDate) : Staffing.GetTimekeepForStartDateAndName(StaffNameTxb.Text, startDate);
                }
                else
                {
                    TimekeepLV.ItemsSource = hasEndDate ? Staffing.GetTimekeepForDate(startDate, endDate) : Staffing.GetTimekeepForStartDate(startDate);
                }
            }
        }

        private void EndDateDP_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EndDateDP.Text) == false
                && DateTime.TryParseExact(EndDateDP.Text + " 23:59:59", "d/M/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime endDate))
            {
                DateTime startDate = DateTime.MinValue;
                bool hasStartDate = string.IsNullOrWhiteSpace(StartDateDP.Text) == false
                    && DateTime.TryParseExact(StartDateDP.Text + " 00:00:00", "d/M/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out startDate);
                if (string.IsNullOrWhiteSpace(StaffNameTxb.Text) == false)
                {
                    TimekeepLV.ItemsSource = hasStartDate ? Staffing.GetSpecificTimekeeps(StaffNameTxb.Text, startDate, endDate) : Staffing.GetTimekeepForEndDateAndName(StaffNameTxb.Text, endDate);
                }
                else
                {
                    TimekeepLV.ItemsSource = hasStartDate ? Staffing.GetTimekeepForDate(startDate, endDate) : Staffing.GetTimekeepForEndDate(endDate);
                }
            }
        }
    }
}
