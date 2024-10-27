using Project.Services;

namespace Project
{
	internal class Program
	{
		static void Main(string[] args)
		{
			CourseServices courseservices = new CourseServices();

			string choose;
			do
			{
                Console.WriteLine("1.Create Group\n2.Show All Groups\n3.Change Group Number\n4.Show All Students in a special Group\n5.Show All Students\n6.Create Student\n\n0.Exit");
				choose = Console.ReadLine().Trim();

				switch (choose)
				{
					case "1":
						courseservices.CreateGroup();
						break;
					case "2":
						courseservices.ShowAllGroups();
						break;
					case "3":
						courseservices.ChangeGroupNumber();
						break;
					case "4":
						courseservices.ShowStudentsinGroup();
						break;
					case "5":
						courseservices.ShowAllStudents();
						break;
					case "6":
						courseservices.CreateStudent();
						break;
				}

			} while (choose != "0");
		}
	}
}

