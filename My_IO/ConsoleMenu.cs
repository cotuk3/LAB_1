using People;
using System;
using System.Reflection;
using System.Text.RegularExpressions;
using System.IO;


namespace My_IO
{
    public static class ConsoleMenu
    {
        public static void Info()
        {
            Console.WriteLine(
            "All commands:\n" +
            " /add - add new person to file;\n" +
            " /delete - delete selected person from file;\n" +
            " /clear - clears file;\n" +
            " /getfiles - show all txt files in directory;\n\n" +

            " /info - show list of commands;\n" +
            " /persons - show list of persons, who you can add to file;\n" +
            " /search - show students who live in dorm and study in the 3rd year;\n" +
            " /show - show whole file; \n\n" +

            " /sleepvertical - all persons in file start to sleep vertical;\n" +
            " /study - all student starts to study;\n\n" +
            
   
            " /end - end program.");
        } //+
        public static void Persons()
        {
            //Assembly asm = Assembly.Load("People"); 
            foreach (Type t in Assembly.Load("People").GetTypes()) // Type T in asm.GetTypes()
            {
                Type person = typeof(Person);
                //Type person = Type.GetType("People.Person");
                //Type person = Type.GetType("People.Person, People", false, true);
                if (t.IsSubclassOf(person))
                    Console.WriteLine(t.Name);
            }
        } //+

        public static void AddPersonToFile(IO my)
        {
            Console.WriteLine("Enter who you want to add to file:");
            Persons();
            Console.Write("Person: ");
            string person = Console.ReadLine();

            switch (person.ToLower())
            {
                case ("student"):
                    Student student = new Student();
                    FillInfoAboutPerson(student, my);
                    break;
                case ("seller"):
                    Seller seller = new Seller();
                    FillInfoAboutPerson(seller, my);
                    break;
                case ("gardener"):
                    Gardener gardener = new Gardener();
                    FillInfoAboutPerson(gardener, my);
                    break;
                default:
                    Console.WriteLine("Wrong type of person");
                    break;

            }
        } //+
        static void FillInfoAboutPerson<T>(T person, IO my) where T : Person
        {
            string name = Regex.Replace(person.GetType().ToString(), @"\w+.(?<name>\w+)", @"${name}");

            Console.Write($"Enter First Name of a {name}: ");
            person.FirstName = Console.ReadLine();

            Console.Write($"Enter Last Name of a {name}: ");
            person.LastName = Console.ReadLine();

            Console.Write($"Enter Sex of a {name}: ");
            person.Sex = Console.ReadLine();

            if (person is Student)
            {
                Student student = person as Student;

                Console.Write($"Enter Course of a {name}: ");
                student.Course = Console.ReadLine();

                Console.Write($"Enter Student Id of a {name}: ");
                student.StudentId = Console.ReadLine();

                Console.Write("Does student live in dorm: ");
                string dorm = Console.ReadLine();

                if (dorm.ToLower() == "yes")
                    student.IsLivingInDorm = true;
                else
                    student.IsLivingInDorm = false;
            }
            else if (person is Seller)
            {
                Seller seller = person as Seller;
                Console.Write($"Enter Product of a {name}: ");
                seller.Product = Console.ReadLine();
            }
            else if (person is Gardener)
            {
                Gardener gardener = person as Gardener;
                Console.Write($"Enter Empolyer of a {name}: ");
                gardener.Employer = Console.ReadLine();
            }

            Console.Write($"Enter Residence of a {name}: ");
            person.Residence = Console.ReadLine();
            my.WriteDownPerson(person);
        } //+

        public static void Search(IO my)
        {
            var search = my.SearchString();
            Console.WriteLine($"There are {search.count} students who live in dorm and study in 3rd course\n");

            Person[] persons = my.Search();
            if (persons == null)
                return;

            for(int i = 0; i < search.count; i++)
            {
                Console.WriteLine($"{i+1}." + persons[i] + Environment.NewLine);
            }
        } //+

        public static void Show(IO my)
        {
            Person[] persons = my.ReadAllFromFile();
            if (persons == null)
                throw new FileNotFoundException("File is empty!!!"); ;

            for (int i = 0; i < persons.Length; i++)
            {
                Console.WriteLine($"{i+1}." + persons[i] + Environment.NewLine);
            }
        } //+

        public static void ClearFile(IO my)
        {
            my.ClearFile();
            Console.WriteLine("File was cleared");
        } //+

        public static void ShowAllFiles()
        {
            Console.Write("Enter Path to Directory: ");
            string path = Console.ReadLine();
            DirectoryInfo directory = new DirectoryInfo(path);

            foreach (var file in directory.GetFiles("*.txt"))
            {
                Console.WriteLine(file.Name);
            }
        } //+

        public static void Delete(IO my)
        {
            Show(my);
            Console.Write("\nEnter index of person who you want to deleter from file:");
            int index = int.Parse(Console.ReadLine());

            Person[] persons = my.ReadAllFromFile();
            my.ClearFile();

            Array.Copy(persons, index, persons, index-1,
                persons.Length - index);

            persons[persons.Length - 1] = null;
            if (persons.Length <= 1)
            {
                Show(my);
                return;
            }
            
            for(int i = 0; i < persons.Length -1; i++)
            {
                my.WriteDownPerson(persons[i]);
            }
        }  //+

        public static void SleepVertical(IO my)
        {
            Person[] people = my.ReadAllFromFile();
            if (people == null)
            {
                Console.WriteLine("File is empty!!!");
                return;
            }
            foreach (Person person in people)
            {
                Console.WriteLine(person.SleepVertical());
            }
        }

        public static void Study(IO my)
        {
            Person[] people = my.ReadAllFromFile();
            if (people == null)
            {
                Console.WriteLine("File is empty!!!");
                return;
            }
            foreach (Student student in people)
            {
                Console.WriteLine(student.Study());
            }
        }
    }
}
