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

namespace WPF_And_POS_Terminal_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SerialPort port;
        private System.Windows.Threading.DispatcherTimer timer;

        public MainWindow()
        {
            port = new SerialPort();
            port.BaudRate = 9600;
            port.PortName = "COM5";
            port.Open();

            InitializeComponent();

        }

        private void click(object sender, EventArgs e)
        {
            string line = port.ReadLine();
            COMTextBox.Text = line;
            if (line == "True")
                COMRectangle.Fill = Brushes.Green;
            else if (line == "False")
                COMRectangle.Fill = Brushes.Yellow;
            else
                COMRectangle.Fill = Brushes.Red;
        }
    }
}
