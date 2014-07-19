namespace NativeToolTip
{
    using System;
    using System.ComponentModel;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    using System.Windows.Media;
    using System.Windows.Threading;

    using Microsoft.Windows.Themes;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        private DispatcherTimer timer;

        public MainWindow()
        {
            InitializeComponent();

            timer = new DispatcherTimer();
            timer.Tick += (sender, args) => NotifyPropertyChanged("UpdatingString");
            timer.Interval = TimeSpan.FromSeconds(1.0);
            timer.Start();

            this.DataContext = this;
        }

        private int x = 5;

        public string UpdatingString
        {
            get
            {
                if (x > 25) x = 5;
                return new string('x', x++);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (new MainWindow()).Show();
        }
    }
}
