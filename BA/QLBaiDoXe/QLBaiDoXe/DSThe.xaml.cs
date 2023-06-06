using System.Windows;
using System.Windows.Controls;
using MaterialDesignThemes.Wpf;
using QLBaiDoXe.DBClasses;
using QLBaiDoXe.ParkingLotModel;

namespace QLBaiDoXe
{
    /// <summary>
    /// Interaction logic for DSThe.xaml
    /// </summary>
    public partial class DSThe : UserControl
    {
        public DSThe()
        {
            InitializeComponent();
            ListThe.ItemsSource = Cards.GetAllParkingCards();
            StateCbx.SelectedIndex = 2;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ThemThe add = new ThemThe();
            add.ShowDialog();
            ListThe.ItemsSource = Cards.GetAllParkingCards();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (ListThe.Items.Count == 0)
            {
                MessageBox.Show("Danh sách thẻ rỗng!");
                return;
            }
            if (ListThe.SelectedItems == null)
            {
                MessageBox.Show("Hãy chọn thẻ cần xóa!");
            }
            else
            {


                if (MessageBox.Show("Bạn có muốn xóa thẻ đã chọn?", "Xác nhận", MessageBoxButton.YesNo) == MessageBoxResult.No)
                    return;
                if (ListThe.SelectedItems[0] is long value)
                {
                    if (Cards.CheckCardState(value) == 1)
                    {
                        MessageBox.Show("Thẻ đang được sử dụng", "Lỗi!");
                        return;
                    }
                    Cards.DeleteCard(value);
                }
                else
                {
                    MessageBox.Show("Không nhận dạng được mã thẻ", "Lỗi");
                }
                MessageBox.Show("Đã xóa thẻ thành công!", "Thông báo!");
                ListThe.ItemsSource = null;
                ListThe.ItemsSource = Cards.GetAllParkingCards();
            }
        }

        private void CardSearchTxb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(CardSearchTxb.Text) == true)
            {
                if (StateCbx.SelectedIndex == 2)
                {
                    ListThe.ItemsSource = Cards.GetAllParkingCards();
                }
                else if(StateCbx.SelectedIndex == 0)
                {
                    ListThe.ItemsSource = Cards.GetCardsByState(0);
                }
                else if (StateCbx.SelectedIndex == 1)
                {
                    ListThe.ItemsSource = Cards.GetCardsByState(1);
                }
            }
            else 
            if (long.TryParse(CardSearchTxb.Text, out long cardId))
            {
                if (StateCbx.SelectedIndex == 1)
                {
                    ListThe.ItemsSource = Cards.GetCardsFromId(cardId, 1);
                }
                else
                if (StateCbx.SelectedIndex == 0)
                {
                    ListThe.ItemsSource = Cards.GetCardsFromId(cardId, 0);
                }
                else
                {
                    ListThe.ItemsSource = Cards.GetCardsFromIdNoState(cardId);
                }
            }
            
        }

        private void StateCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (StateCbx.SelectedIndex == 2)
            {
                CardSearchTxb.IsEnabled = false;
                ListThe.ItemsSource = Cards.GetAllParkingCards();
            }
            else
            {
                CardSearchTxb.IsEnabled = true;
                
                if (string.IsNullOrEmpty(CardSearchTxb.Text) == true)
                {
                    if (StateCbx.SelectedIndex == 0)
                    {
                        ListThe.ItemsSource = Cards.GetCardsByState(0);

                    } else
                        if (StateCbx.SelectedIndex == 1)
                       {
                        ListThe.ItemsSource = Cards.GetCardsByState(1);
                       }
                }
                else
                {
                    if (long.TryParse(CardSearchTxb.Text, out long cardId))
                    {
                        if (StateCbx.SelectedIndex == 0)
                        {
                            ListThe.ItemsSource = Cards.GetCardsByState(0);

                        }
                        else
                       if (StateCbx.SelectedIndex == 1)
                        {
                            ListThe.ItemsSource = Cards.GetCardsByState(1);
                        }
                    }

                }
            }
        }
    }
}
