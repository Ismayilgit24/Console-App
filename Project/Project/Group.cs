using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
	internal class Group
	{
        public string _no { get; set; }
        public string _category { get; set; } 
        public bool _isOnline { get; set; }
        public int _limit { get; set; }
		public List<Student> Students { get; set; } = new List<Student>();


		public Group(string no, string category, bool isonline)
        {
            
            _no = no;
			_category = category;
            _isOnline = isonline;
            
		}
    }
}
