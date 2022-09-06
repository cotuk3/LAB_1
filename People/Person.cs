using System.Text.RegularExpressions;

namespace People
{
    public abstract class Person : IVerticalSleep
    {
        string firstName;
        string lastName;
        string sex;
        string residence;
        protected Regex validName = new Regex(@"^[A-Za-z ]+$");
        System.ArgumentException nameIsNotValid = new System.ArgumentException("Text is not valid!!!");

        public Person()
        {

        }
        public Person(string firstName, string lastName, string sex, string residence)
        {
            FirstName = firstName;
            LastName = lastName;
            Sex = sex;
            Residence = residence;
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if (validName.IsMatch(value))
                    firstName = value;
                else
                    throw nameIsNotValid;
            }
        }
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                if (validName.IsMatch(value))
                    lastName = value;
                else
                    throw nameIsNotValid;
            }
        }
        public string Sex
        {
            get { return sex; }
            set
            {
                if (validName.IsMatch(value))
                    sex = value;
                else
                    throw nameIsNotValid;

            }
        }
        public string Residence
        {
            get { return residence; }
            set
            {
                if (validName.IsMatch(value))
                    residence = value;
                else
                    throw nameIsNotValid;
            }
        }
        public virtual string SleepVertical()
        {
            string res = $"{Regex.Replace(this.GetType().ToString(), @"\w+.(?<name>\w+)", @"${name}")}" +
                $" with name {FirstName} {LastName} is sleeping vertical in {Residence}";
            return res;
        }
    }
}
