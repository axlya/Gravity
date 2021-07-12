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


namespace Gravity
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
        //Вызов окна паспортных данных
        private void PropertiesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            PasportPropertiesWindow win = new PasportPropertiesWindow();
            win.ShowDialog();
        }
        //Вызов окна данных для измерений
        private void MeasuringMenuItem_Click(object sender, RoutedEventArgs e)
        {
            DataForMeasurementWindow win = new DataForMeasurementWindow();
            win.ShowDialog();
        }
        //Параметры подключений
        private void CommunicationMenuItem_Click(object sender, RoutedEventArgs e)
        {
            CommunicationWindows win = new CommunicationWindows();
            win.ShowDialog();

        }
    }
}
