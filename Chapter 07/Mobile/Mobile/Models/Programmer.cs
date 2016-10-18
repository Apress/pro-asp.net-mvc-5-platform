namespace Mobile.Models {

    public class Programmer {

        public Programmer(string firstName, string lastName, string title,
                string city, string country, string language) {
            FirstName = firstName; LastName = lastName; Title = title;
            City = city; Country = country; Language = language;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Language { get; set; }
    }
}
