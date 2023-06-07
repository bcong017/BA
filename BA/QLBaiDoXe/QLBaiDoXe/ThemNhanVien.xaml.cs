using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using QLBaiDoXe.DBClasses;
using System.Text.RegularExpressions;

namespace QLBaiDoXe
{
    /// <summary>
    /// Interaction logic for ThemNhanVien.xaml
    /// </summary>
    public partial class ThemNhanVien : Window
    {
        public ThemNhanVien()
        {
            InitializeComponent();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (cbxRole.Text == "Quản trị viên")
            {
                if (string.IsNullOrEmpty(DatePicker.Text))
                    Staffing.AddAdminInfo(txbName.Text, txbCivilID.Text, txbPhoneNumb.Text, txbAddress.Text, null, txbAccName.Text, txbCivilID.Text);
                else
                    Staffing.AddAdminInfo(txbName.Text, txbCivilID.Text, txbPhoneNumb.Text, txbAddress.Text, DateTime.Parse(DatePicker.Text), txbAccName.Text, txbCivilID.Text);
                
            }
            else
            {
                if (string.IsNullOrEmpty(DatePicker.Text))
                    Staffing.AddStaffInfo(txbName.Text, txbCivilID.Text, txbPhoneNumb.Text, txbAddress.Text, null, txbAccName.Text, txbCivilID.Text);
                else
                    Staffing.AddStaffInfo(txbName.Text, txbCivilID.Text, txbPhoneNumb.Text, txbAddress.Text, DateTime.Parse(DatePicker.Text), txbAccName.Text, txbCivilID.Text);
                
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private static readonly Regex _regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text

        private void NumbericPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = _regex.IsMatch(e.Text);
        }
    }
}
