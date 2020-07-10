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
using System.Windows.Shapes;
using BusinessObjects;
using System.Collections;


namespace Demo
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private static ModuleList store = new ModuleList();
        MainWindow win;

        public Window1(MainWindow win)
        {
           this.win = win;
           InitializeComponent();
           datagrid();
            
        }

         public void datagrid()
        {
            Student studentData = new Student();

            dataGrid.ItemsSource = ModuleList.getData();
         
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow newWin = new MainWindow();
            newWin.Show();

            this.Hide();

        }

      
    }
}

