using System;
using System.Text.RegularExpressions;

namespace People
{
    public class Student : Person
    {
        string residence;
        string studentId;
        string course;

        public Student()
        {
        }
        public Student(string firstName, string lastName, string sex, bool isLivingInDorm, string residence,
             string studentId, string course)
        {
            FirstName = firstName;
            LastName = lastName;
            Sex = sex;
            StudentId = studentId;
            IsLivingInDorm = isLivingInDorm;
            Residence = residence;
            Course = course;
        }

        public bool IsLivingInDorm { get; set; }
        public string StudentId
        {
            get
            {
                return studentId;
            }
            set
            {
                Regex regex = new Regex(@"^[A-Z]{2}\s\d{8}$");
                if (regex.IsMatch(value))
                    studentId = value;
                else
                    throw new ArgumentException("Wrong Student Id!");
            }
        }
        new public string Residence
        {
            get { return residence; }
            set
            {
                if (IsLivingInDorm)
                {
                    Regex regexDorm = new Regex(@"^\d{1,2}-\d{3}$");
                    if (regexDorm.IsMatch(value))
                        residence = value;
                    else                    
                        throw new ArgumentException("Wrong Format of Residence!");                    
                }
                else
                    residence = value;

            }
        }
        public string Course
        {
            get { return course; }
            set
            {
                Regex regex = new Regex("[1-6]");
                if (regex.IsMatch(value))
                    course = value;
                else
                    throw new ArgumentException("Wrong Course!");
            }
        }
    
        public string Study()
        {
            string res = $"Student with name: {FirstName} {LastName} is studying in {Course} year";
            return res;
        }
        public override string SleepVertical()
        {
            string res = $"{Regex.Replace(this.GetType().ToString(), @"\w+.(?<name>\w+)", @"${name}")}" +
                $" with name: {FirstName} {LastName} is sleeping vertical in {Residence}";
            return res;
        }

        public override string ToString()
        {
            string res = $"Student {FirstName}{LastName}\n" +
                $"\"{{ \"firstname\": \"{FirstName}\",\n" +
                $"\"lastname\": \"{LastName}\",\n" +
                $"\"sex\": \"{Sex}\",\n" +
                $"\"residence\": \"{Residence}\",\n" +
                $"\"course\": \"{Course}\",\n" +
                $"\"studentId\": \"{StudentId}\"}};";

            return res;
        }
    }
}
