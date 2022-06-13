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
using WPF_And_POS_Terminal_App.Interfaces;

namespace WPF_And_POS_Terminal_App.UserControls
{
    /// <summary>
    /// Interaction logic for PayByCash.xaml
    /// </summary>
    public partial class PayByCash : UserControl, IPayment
    {
        private float total;
        public float Total { get => total; set => total = value; }

        public PayByCash()
        {
            InitializeComponent();
            DataContext = this;
        }

        public void Update(float Total)
        {
            this.Total = Total;
            TotalTextBox.Text = this.total.ToString();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            Submit();
        }

        private void CashAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                Submit();
        }

        private void Submit()
        {
            try
            {
                ReturnTextBlock.Text = (float.Parse(CashAmount.Text) - total).ToString();
            }
            catch (FormatException e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
