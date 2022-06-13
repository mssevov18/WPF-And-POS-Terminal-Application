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
    /// Interaction logic for PayMixed.xaml
    /// </summary>
    public partial class PayMixed : UserControl, IPayment
    {
        public PayMixed()
        {
            InitializeComponent();
        }

        public float Total { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Update(float Total)
        {
            throw new NotImplementedException();
        }
    }
}
