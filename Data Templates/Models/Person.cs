namespace Data_Templates.Models
{
    public class Person
    {
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        public int Age { get; init; }
        public Sex Sex { get; init; }

        public override string ToString() => $"{FirstName} {LastName} (Age: {Age}, Sex: {Sex})";
    }
}
