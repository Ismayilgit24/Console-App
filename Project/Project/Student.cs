using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Project
{
	internal class Student
	{
        public string _name { get; set; }

		public string _surname { get; set; }
        public Group[] _group { get; set; }
        public string _groupNo { get; set; }
		public string _type { get; set; }
        
       



        public Student(string name, string surname)
        {
            _name = name;
            _surname = surname;
            
           
        }

    }
}
