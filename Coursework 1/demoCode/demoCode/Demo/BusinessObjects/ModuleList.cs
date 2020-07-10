using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.ObjectModel;

namespace BusinessObjects
{
    public class ModuleList
    {
        private List<Student> _list = new List<Student>();

        private static ObservableCollection<Student> student = new ObservableCollection<Student>();

        public static void add(Student newStudent)
        {
            student.Add(newStudent);
            
        }

        public Student find(int matric)
        {
            foreach (Student p in student)
            {
                if (matric == p.Matric)
                {
                    return p;
                }
            }

            return null;

        }

        public void delete(int matric)
        {
            Student p = this.find(matric);
            if (p != null)
            {
                student.Remove(p);
            }

        }

        public List<int> matrics
        {
            get
            {
               List<int> res = new List<int>();
               foreach(Student p in _list)
                   res.Add(p.Matric);
                return res;
            }
           
        }

        public static ObservableCollection<Student> getData()
        {
            return student;
            
        }
    }
}
