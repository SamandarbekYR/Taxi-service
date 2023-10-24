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

namespace Car_service.Windows
{
    /// <summary>
    /// Interaction logic for Score.xaml
    /// </summary>
    public partial class Score : Window
    {
        public int count = 0;
        public Score()
        {
            InitializeComponent();
        }

        private void star1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            star1.Fill = new SolidColorBrush(Colors.Cyan);
            count = 1;
        }

        private void star2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            star1.Fill = new SolidColorBrush(Colors.Cyan);
            star2.Fill = new SolidColorBrush(Colors.Cyan);
            count = 2;
        }

        private void star3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            star1.Fill = new SolidColorBrush(Colors.Cyan);
            star2.Fill = new SolidColorBrush(Colors.Cyan);
            star3.Fill = new SolidColorBrush(Colors.Cyan);
            count = 3;
        }

        private void star4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            star1.Fill = new SolidColorBrush(Colors.Cyan);
            star2.Fill = new SolidColorBrush(Colors.Cyan);
            star3.Fill = new SolidColorBrush(Colors.Cyan);
            star4.Fill = new SolidColorBrush(Colors.Cyan);
            count = 4;
        }

        private void star5_MouseDown(object sender, MouseButtonEventArgs e)
        {
            star1.Fill = new SolidColorBrush(Colors.Cyan);
            star2.Fill = new SolidColorBrush(Colors.Cyan);
            star3.Fill = new SolidColorBrush(Colors.Cyan);
            star4.Fill = new SolidColorBrush(Colors.Cyan);
            star4.Fill = new SolidColorBrush(Colors.Cyan);
            count = 5;
        }
    }
}
