using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BusinessObjects
{
    public class Student
    {
        private int _matricNo;
        private string firstName;
        private string surname;
        private int courseworkMark;
        private int examMark;
        private DateTime DOB;
        private string finalMark;


       

        public int Matric
        {
            get
            {
                return _matricNo;
            }
            set
            {
                if (value < 10001 || value > 50000)
                {
                    throw new ArgumentException("Matriculation number needs to be betweeb 10001 and 50000");
                } 
                _matricNo = value;
            }
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if (value == "")
                {
                    throw new ArgumentException("Cannot leave first name blank");
                }

                firstName = value;
            }
        }

        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                if (value == "")
                {
                    throw new ArgumentException("Cannot leave surname name blank");
                }
                surname = value;
            }
        }

        public int CourseWorkMark
        {
            get
            {
                return courseworkMark;
            }
            set
            {
                if (value < 0 || value > 20)
                {
                    throw new ArgumentException("Coursework Mark must be between 0 and 20");
                }
                courseworkMark = value;
            }
        }

        public int ExamMark
        {
            get
            {
                return examMark;
            }
            set
            {
                if (value < 0 || value > 40)
                {
                    throw new ArgumentException("Exam Mark must be between 0 and 40");
                }
                examMark = value;
            }
        }

        public DateTime Dob
        {
            get
            {
                return DOB;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Cannot leave the date  blank");
                }
                DOB = value;
            }
        }

        public string FinalMark
        {
            get
            {
                return finalMark;
            }

            set
            {
                finalMark = value;
            }
        }
        public string getMark()
        {
           double mark = (courseworkMark/2) + (examMark/2);
           double finalMark = ((mark / 30) * 100);
           
            return Convert.ToString(finalMark);

        }
       





    }
}
