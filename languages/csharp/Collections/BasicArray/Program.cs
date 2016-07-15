namespace BasicArray
{
    class Program
    {
        static void Main(string[] args)
        {
            string monday = "Monday";
            string[] daysOfWeek = {
                                        "Monday",
                                        "Tuesday",
                                        "Wednesday",
                                        "Thursday",
                                        "Friday",
                                        "Saturday",
                                        "Sunday"
                                    };
            System.Console.WriteLine(daysOfWeek[8]);
            daysOfWeek[5] = "PartyDay";
            foreach (var day in daysOfWeek)
            {
                System.Console.WriteLine(day);
            }

            System.Console.ReadLine();
        }
    }
}
