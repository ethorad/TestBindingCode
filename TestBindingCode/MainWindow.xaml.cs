using System;
using System.Windows;

namespace TestBindingCode
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Temp foo;

        public MainWindow()
        {
            InitializeComponent();
            foo = new Temp();
            this.DataContext = foo;
        }
    }
}
