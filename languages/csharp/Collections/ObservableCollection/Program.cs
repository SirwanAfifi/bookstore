using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace ObservableCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            ObservableCollection<string> presidents = new
                ObservableCollection<string>
            {
                "Jimmy Carter",
                "Ronald Regan",
                "Georg HW Bush"
            };
            presidents.CollectionChanged += OnCollectionChanged;

            presidents.Add("Bill Clinton");
            presidents.Remove("Jimmy Carter");

            foreach (string president in presidents)
                Console.WriteLine(president);


            Console.ReadLine();
        }

        static void OnCollectionChanged(object sender,
            NotifyCollectionChangedEventArgs e)
        {
            
        }
    }
}
