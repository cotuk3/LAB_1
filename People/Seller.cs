namespace People
{
    public class Seller : Person
    {
        public Seller()
        {

        }
        public Seller(string firstName, string lastName, string sex, string residence, string product)
            : base(firstName, lastName, sex, residence)
        {
            Product = product;
        }
        public string Product { get; set; }
        public string Sell()
        {
            string res = $"Seller with name: {FirstName} {LastName} is now selling {Product}";
            return res;
        }
        public override string ToString()
        {
            string res = $"Seller {FirstName}{LastName}\n" +
                $"\"{{ \"firstname\": \"{FirstName}\",\n" +
                $"\"lastname\": \"{LastName}\",\n" +
                $"\"sex\": \"{Sex}\",\n" +
                $"\"residence\": \"{Residence}\",\n" +
                $"\"product\": \"{Product}\"}};";

            return res;
        }
    }
}
