﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using QLBaiDoXe.DBClasses;
using System.Text.RegularExpressions;
using QLBaiDoXe.Classes;

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
            if (!Classes.Validation.isPhoneNumber.IsMatch(txbPhoneNumb.Text))
            {
                MessageBox.Show("Số điện thoại không hợp lệ!");
                return;
            }
            else if (!Classes.Validation.isCivilId.IsMatch(txbCivilID.Text))
            {
                MessageBox.Show("CMND/CCCD không hợp lệ!");
                return;
            }
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

        private void NumbericPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Classes.Validation.isNumber.IsMatch(e.Text);
        }
    }
}
