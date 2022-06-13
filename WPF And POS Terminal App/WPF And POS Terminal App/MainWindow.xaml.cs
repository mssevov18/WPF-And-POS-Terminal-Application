using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO.Ports;
using System.Threading;

using WPF_And_POS_Terminal_App.UserControls;
using WPF_And_POS_Terminal_App.Interfaces;

namespace WPF_And_POS_Terminal_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private SerialPort port;
        private Dictionary<string, IPayment> ucDictionary;

        private float Total
        {
            get
            {
                try
                {
                    return float.Parse(TotalTextBlock.Text);
                }
                catch (FormatException e)
                {
                    MessageBox.Show(e.Message);
                }
                return float.NaN;
            }
        }

        public MainWindow()
        {
            //port = new SerialPort();
            //port.BaudRate = 9600;
            //port.PortName = "COM5";
            //port.Open();

            ucDictionary = new Dictionary<string, IPayment>();
            ucDictionary.Add("Card", new PayByCard());
            ucDictionary.Add("Cash", new PayByCash());
            ucDictionary.Add("Mix", new PayMixed());

            InitializeComponent();
        }

        private void UpdateTotalTextBlock()
        {
            float i = 0;
            foreach (float item in ItemsListBox.Items)
                i += item;
            TotalTextBlock.Text = i.ToString();
            NewItemTextBox.Text = string.Empty;
            NewItemTextBox.Focus();
        }

        private void AddItem(bool isNegative = false)
        {
            try
            {
                ItemsListBox.Items.Add(float.Parse(NewItemTextBox.Text) * (isNegative ? -1 : 1));
                UpdateTotalTextBlock();
            }
            catch (FormatException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddItem();
        }

        private void SubtractButton_Click(object sender, RoutedEventArgs e)
        {
            AddItem(true);
        }

        private void NewItemTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                AddItem();
        }

        private void ChangeUserControl_Click(object sender, RoutedEventArgs e)
        {
            if (Total <= 0)
            {
                MessageBox.Show("Empty Basket!");
                return;
            }

            try
            {
                //UserControlFrame.Content = (UserControl)ucDictionary[((Button)sender).Content.ToString()];
                UserControlFrame.Content = ucDictionary[((Button)sender).Content.ToString()];
                ((IPayment)ucDictionary[((Button)sender).Content.ToString()]).Update(Total);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        //private void CashButton_Click(object sender, RoutedEventArgs e)
        //{
        //    ucCash.Update(Total);
        //    UserControlFrame.Content = ucCash;
        //}

        //private void CardButton_Click(object sender, RoutedEventArgs e)
        //{
        //    UserControlFrame.Content = ucCard;
        //}

        //private void MixButton_Click(object sender, RoutedEventArgs e)
        //{
        //    UserControlFrame.Content = ucMixed;
        //}

        //private void click(object sender, EventArgs e)
        //{
        //    string line = port.ReadLine();
        //    COMTextBox.Text = line;
        //    if (line == "True")
        //        COMRectangle.Fill = Brushes.Green;
        //    else if (line == "False")
        //        COMRectangle.Fill = Brushes.Yellow;
        //    else
        //        COMRectangle.Fill = Brushes.Red;
        //}
    }
}
