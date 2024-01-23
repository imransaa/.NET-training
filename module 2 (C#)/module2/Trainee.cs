namespace module2
{
    public class Trainee
    {
        public string Name { get; set; }
        public string University { get; set; }
        public static List<Trainee> TraineeList() => new List<Trainee> {
            new Trainee {Name = "Saad", University = "Fast"},
            new Trainee {Name = "Abdullah", University = "Fast"},
            new Trainee {Name = "Zain", University = "Maju"},
            new Trainee {Name = "Ali", University = "Iba"},
        };
    }
}