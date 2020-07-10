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
using BusinessObjects;
using System.Data;
using System.Collections;


namespace Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ModuleList store = new ModuleList();


        public MainWindow()
        {
            InitializeComponent();
        }

        int counter = 10001;
        Boolean deleted = false;

        private bool updateDeleted()
        {
            deleted = true;

            return deleted;

        }

        private bool updateDeleted2()
        {
            deleted = false;

            return deleted;

        }



        private void addStudent_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                Student studentData = new Student();

                studentData.Matric = counter;
                studentData.FirstName = txtFirstName.Text;
                studentData.Surname = txtSurname.Text;
                studentData.CourseWorkMark = int.Parse(txtCourseworkMark.Text);
                studentData.ExamMark = int.Parse(txtExamMark.Text);

                DateTime date = Convert.ToDateTime(datepicker.ToString());
                studentData.Dob = Convert.ToDateTime(date.Date.ToShortDateString());

                studentData.FinalMark = studentData.getMark();
                ModuleList.add(studentData);

                txtMatricNo.Text = string.Empty;
                txtFirstName.Text = string.Empty;
                txtSurname.Text = string.Empty;
                txtCourseworkMark.Text = string.Empty;
                txtExamMark.Text = string.Empty;
                datepicker.Text = string.Empty;
                counter++;

                MessageBox.Show("Student has been successfully added");

                listbox2.Items.Add(studentData.Matric);
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }

        }



        private void findStudent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                listbox1.Items.Clear();

                Student StudentData = new Student();

                if (txtMatricNo.Text == "")
                {
                    MessageBox.Show("A Matriculation Number must be entered");
                }
                else
                {
                    int marticNo = int.Parse(txtMatricNo.Text);

                    StudentData = store.find(marticNo);
                    StudentData.Matric = marticNo;


                    if (StudentData == null)
                    {
                        MessageBox.Show("The Matriculation Number " + marticNo + " cannot be found");
                        txtMatricNo.Text = string.Empty;
                    }
                    else
                    {

                        listbox1.Items.Add("Matriculation Number: " + StudentData.Matric);
                        listbox1.Items.Add("First Name: " + StudentData.FirstName);
                        listbox1.Items.Add("Second Name: " + StudentData.Surname);
                        listbox1.Items.Add("Coursework Mark: " + StudentData.CourseWorkMark);
                        listbox1.Items.Add("Exam Mark: " + StudentData.ExamMark);
                        listbox1.Items.Add("DOB: " + StudentData.Dob.ToShortDateString());
                        listbox1.Items.Add("Mark: " + StudentData.getMark() + "%");


                        txtMatricNo.Text = string.Empty;
                    }
                }

            }

            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }


    

         
        

        private void deleteStudent_Click(object sender, RoutedEventArgs e)
        {
           updateDeleted();

            if (txtMatricNo.Text == "")
            {
                MessageBox.Show("A Matriculation Number must be entered");
            }
            else
            {
                int matricNo = int.Parse(txtMatricNo.Text);

                store.delete(matricNo);

                MessageBox.Show("Student has been deleted");

                listbox2.Items.Remove(matricNo);
                listbox2.Items.Refresh();
                listbox1.Items.Clear();
                txtMatricNo.Text = string.Empty;
               
            }
        }

       

        private void listbox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listbox1.Items.Clear();
           

            if (deleted == false)
            {
               
                string matricNoSelected = listbox2.SelectedItem.ToString();
                int matricNo = int.Parse(matricNoSelected);

                Student studentData = store.find(matricNo);
            
                listbox1.Items.Add("Matriculation Number: " + studentData.Matric);
                listbox1.Items.Add("First Name: " + studentData.FirstName);
                listbox1.Items.Add("Second Name: " + studentData.Surname);
                listbox1.Items.Add("Coursework Mark: " + studentData.CourseWorkMark);
                listbox1.Items.Add("Exam Mark: " + studentData.ExamMark);
                listbox1.Items.Add("DOB: " + studentData.Dob.ToShortDateString());
                listbox1.Items.Add("Mark: " + studentData.getMark() + "%");
            }
            updateDeleted2();
        }
        
        private void listAll_Click(object sender, RoutedEventArgs e)
        {
            Window1 newWin = new Window1(this);
            newWin.Show();


            this.Hide();

        }
    }
}
