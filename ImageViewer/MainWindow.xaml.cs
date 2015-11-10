using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ImageViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CGlobal.imgSource = new BitmapImage(new Uri("Images/01.jpg", UriKind.Relative));
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
                DragMove();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                Application.Current.Shutdown();
        }

        Image imgSelected = new Image();
        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ViewImage((Image)sender);
        }

        private void ViewImage(Image sender)
        {
            imgSelected.Opacity = 1;
            imgSelected = sender;
            imgSelected.Opacity = 0.5;
            imgCenter.Source = imgSelected.Source;
            CGlobal.imgSource = imgSelected.Source;
            _index = int.Parse(imgSelected.Tag.ToString());
            sld.Value = 310;
        }

        int _index = 0;
        int ChooseImage(int _index)
        {
            if (_index < 0)
                _index = 19;
            else if (_index > 19)
                _index = 0;

            ViewImage((Image)grdMain.Children[_index]);
            return _index;
        }

        private void btnPlus_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            frmView frm = new frmView();
            frm.ShowDialog();
        }

        private void btnPrev_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _index = ChooseImage(_index - 1);

        }

        private void btnNext_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _index = ChooseImage(_index + 1);

        }

        private void sld_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            imgCenter.Height = sld.Value;
        }


    }
}
