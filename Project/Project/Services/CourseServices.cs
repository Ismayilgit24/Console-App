using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Project.Services
{
	internal class CourseServices
	{
		List<Group> groups = new List<Group>();
		List<Student> students = new List<Student>();
		public void CreateGroup()
		{
			Console.WriteLine("Please Enter Category:\n1.Programming\n2.System Administration\n3.Design");
			string _category = Console.ReadLine();
			string _no = "";
			switch (_category)
			{
				case "1":
					do
					{
						Console.WriteLine("Please Enter Group Number: ");
						string no1 = Console.ReadLine().Trim();

						bool groupExists = false;
						foreach (var Group in groups)
						{
							if (Group._no == $"P{no1}")
							{
								Console.WriteLine("A group with this number already exists. Please try again!");
								groupExists = true;
								break;
							}
						}
						if (!groupExists)
						{
							if (Regex.IsMatch(no1, @"^\d{3}$"))
							{
								_no = $"P{no1}";
								Console.WriteLine($"{_no} was created.");
								break; 
							}
							else
							{
								Console.WriteLine("Group number must consist of 3 digits!");
							}
						}

					} while (true);
					break;

				case "2":
					do
					{
						Console.WriteLine("Please Enter Group Number: ");
						string no1 = Console.ReadLine().Trim();

						bool groupExists = false;
						foreach (var Group in groups)
						{
							if (Group._no == $"S{no1}")
							{
								Console.WriteLine("A group with this number already exists. Please try again!");
								groupExists = true;
								break;
							}
						}
						if (!groupExists)
						{
							if (Regex.IsMatch(no1, @"^\d{3}$"))
							{
								_no = $"S{no1}";
								Console.WriteLine($"{_no} was created.");
								break;
							}
							else
							{
								Console.WriteLine("Group number must consist of 3 digits!");
							}
						}

					} while (true);
					break;
				case "3":
					do
					{
						Console.WriteLine("Please Enter Group Number: ");
						string no1 = Console.ReadLine().Trim();

						bool groupExists = false;
						foreach (var Group in groups)
						{
							if (Group._no == $"D{no1}")
							{
								Console.WriteLine("A group with this number already exists. Please try again!");
								groupExists = true;
								break;
							}
						}
						if (!groupExists)
						{
							if (Regex.IsMatch(no1, @"^\d{3}$"))
							{
								_no = $"D{no1}";
								Console.WriteLine($"{_no} was created.");
								break;
							}
							else
							{
								Console.WriteLine("Group number must consist of 3 digits!");
							}
						}

					} while (true);
					break;
			}

			bool _isonline = false;
			string word;
			int limit = 0;

			do
			{
				Console.WriteLine("Is Group Online? (Yes/No)");
				word = Console.ReadLine().Trim();

				if (word == "Yes" || word == "yes" && limit< 15)
				{
					_isonline = true;
					

				}
				else if (word == "No" || word == "no" && limit < 10)
				{
					_isonline = false;
				}
				else
				{
					Console.WriteLine("Wrong input! Please enter 'Yes' or 'No'.");
				}
			} while (word != "Yes" && word != "No" && word!="yes" && word!="no");
			
			Group group = new Group(_no, _category, _isonline);
			groups.Add(group);
		}

		public void ShowAllGroups()
		{
			foreach(var group in groups)
			{
				string onlinestatus = "";
				if (group._isOnline)
				{
					onlinestatus = "Online";
				}else if (!group._isOnline)
				{
					onlinestatus = "Offline";
				}
                Console.WriteLine($"\nGroup Name: {group._no} Type: {onlinestatus} Student count: {group.Students.Count}");
			}
			
				
			
		}

		public void ChangeGroupNumber()


		{
			if (groups.Count == 0)
			{
				Console.WriteLine("There is not any group.");
			}

			Console.WriteLine("Please Enter group number that you want to change: ");
			string no = Console.ReadLine().Trim();
			Group existingGroup = null;


			foreach (var group in groups)
			{
				if (no == group._no)
				{
					existingGroup = group;
					break;
				}
			}

			if (existingGroup != null)
			{
				string newNo;
				bool exists;

				do
				{
					Console.WriteLine("Enter the new number of group: ");
					newNo = Console.ReadLine().Trim();

					exists = false;
					foreach (var group in groups)
					{
						if (newNo == group._no)
						{
							exists = true;
							break;
						}
					}

					if (!exists)
					{
						if (Regex.IsMatch(newNo, @"^\d{3}$"))
						{
							existingGroup._no = newNo;
							Console.WriteLine($"Group number changed to {newNo}.");
							break;
						}
						else
						{
							Console.WriteLine("Group number must consist of 3 digits!");
						}
					}
					else
					{
						Console.WriteLine($"There is already a group with number {newNo}. Please try again.");
					}

				} while (true);
			}
			else
			{
				Console.WriteLine("There is no group with this number.");
			}





		}

		public void ShowStudentsinGroup()
		{
			Console.WriteLine("Enter group name: ");
			string groupName = Console.ReadLine().Trim();

			
			bool groupFound = false;

			foreach (Group group in groups)
			{
				if (groupName == group._no)
				{
					groupFound = true; 

				
					if (group.Students.Count > 0)
					{
						Console.WriteLine($"Students in group {groupName}:");
						foreach (Student student in group.Students)
						{
							Console.WriteLine($"{student._name.Substring(0, 1).ToUpper() + student._name.Substring(1).ToLower()} " +
											  $"{student._surname.Substring(0, 1).ToUpper() + student._surname.Substring(1).ToLower()}");
						}
					}
					else
					{
						Console.WriteLine($"There are no students in group {groupName}.");
					}
					break; 
				}
			}

			
			if (!groupFound)
			{
				Console.WriteLine("There is not any group with this number.");
			}
		}

		public void ShowAllStudents()
		{
			foreach(Group group in groups)
			{
				foreach(Student student in students)
				{
					string onlinestatus = "";
					if (group._isOnline)
					{
						onlinestatus = "Online";
					}
					else if (!group._isOnline)
					{
						onlinestatus = "Offline";
					}
					Console.WriteLine($"Full Name: {student._name.Substring(0,1).ToUpper() + student._name.Substring(1).ToLower()} {student._surname.Substring(0, 1).ToUpper() + student._surname.Substring(1).ToLower()} Group: {group._no} Type: {onlinestatus}");
				}
			}
		}

		public void CreateStudent()
		{
			string name;
			string surname;
			do
			{
				Console.WriteLine("Enter Student's Name (3-25 characters): ");
				name = Console.ReadLine().Trim();

				if (name.Length < 3 || name.Length > 25)
				{
					Console.WriteLine("Name must be between 3 and 25 characters. Please try again!");
				}
			} while (name.Length < 3 || name.Length > 25);

			Console.WriteLine("Enter Student's Surname: ");
		    surname = Console.ReadLine().Trim();
			do
			{
				if (surname.Length < 3 || surname.Length > 25)
				{
					Console.WriteLine("Surname must be between 3 and 25 characters. Please try again!");
					
				}

			} while (surname.Length < 3 || surname.Length > 25);

			Console.WriteLine("Enter Group: ");
			string groupname = Console.ReadLine().Trim();
			
			foreach(Group group in groups)
			{
				if(groupname != group._no)
				{
                    Console.WriteLine("There is not group with this number");
				}
				else
				{
					Student student = new Student(name, surname);
					group.Students.Add(student);
				    students.Add(student);
                    Console.WriteLine($"{name.Substring(0,1).ToUpper() + name.Substring(1).ToLower()} {surname.Substring(0, 1).ToUpper() + surname.Substring(1).ToLower()} added to {groupname.Substring(0, 1).ToUpper() + groupname.Substring(1)}");
				}
			}
			
		}

	}
}

 

