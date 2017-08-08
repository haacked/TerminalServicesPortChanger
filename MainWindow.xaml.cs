using Microsoft.Win32;
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

namespace TerminalServicesPortChanger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var portKey = Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Control\TerminalServer\WinStations\RDP-Tcp"))
                {
                    port.Text = portKey.GetValue("PortNumber")?.ToString() ?? "3389";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void changeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var portKey = Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Control\TerminalServer\WinStations\RDP-Tcp"))
                {
                    portKey.SetValue("PortNumber", Convert.ToInt32(port.Text), RegistryValueKind.DWord);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
