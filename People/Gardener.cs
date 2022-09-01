namespace People
{
    public class Gardener : Person, IVerticalSleep
    {
        public Gardener()
        {

        }
        public Gardener(string firstName, string lastName, string sex, string residence, string employer)
            : base(firstName, lastName, sex, residence)
        {
            Employer = employer;
        }

        public string Employer { get; set; }
        public string CutTheLawn()
        {
            string res = $"Gardener with name: {FirstName} {LastName} is now cutting the lawn in {Employer} residence";
            return res;
        }
        public override string ToString()
        {
            string res = $"Gardener {FirstName}{LastName}\n" +
                $"\"{{ \"firstname\": \"{FirstName}\",\n" +
                $"\"lastname\": \"{LastName}\",\n" +
                $"\"sex\": \"{Sex}\",\n" +
                $"\"residence\": \"{Residence}\",\n" +
                $"\"employer\": \"{Employer}\"}};";

            return res;
        }
    }
}
