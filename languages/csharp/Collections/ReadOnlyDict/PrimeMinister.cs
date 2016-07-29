namespace ReadOnlyDict
{
    public class PrimeMinister
    {
        public string Name { get; set; }
        public int YearElected { get; set; }

        public PrimeMinister(string name, int yearElected)
        {
            this.Name = name;
            this.YearElected = yearElected;
        }

        public override string ToString()
        {
            return $"{Name}, elected: {YearElected}";
        }
    }
}