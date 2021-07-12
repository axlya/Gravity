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
using System.Windows.Shapes;

namespace Gravity
{
    /// <summary>
    /// Interaction logic for DataForMeasurementWindow.xaml
    /// </summary>
    public partial class DataForMeasurementWindow : Window
    {
        public DataForMeasurementWindow()
        {
            InitializeComponent();
        }

        private void TextBox_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            UIExtended.TextBox_OnPreviewTextInput(sender, e);
        }

        private void OnClose(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void OnOK(object sender, RoutedEventArgs e)
        {

        }
    }
}
