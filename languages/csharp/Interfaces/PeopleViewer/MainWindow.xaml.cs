using System.Collections;
using System.Collections.Generic;
using System.Windows;
using PersonLibrary;

namespace PeopleViewer
{
    public partial class MainWindow : Window
    {
        readonly PeopleRepository _peopleRepo = new PeopleRepository();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ConcreteFetchButton_Click(object sender, RoutedEventArgs e)
        {
            ClearListBox();

            List<Person> people;
            people = _peopleRepo.GetPeople();
            PersonListBox.ItemsSource = people;
            //foreach (var person in people)
            //    PersonListBox.Items.Add(person);
        }

        private void InterfaceFetchButton_Click(object sender, RoutedEventArgs e)
        {
            ClearListBox();

            IEnumerable<Person> people;
            people = _peopleRepo.GetPeople();
            PersonListBox.ItemsSource = people;
            //foreach (var person in people)
            //    PersonListBox.Items.Add(person);
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ClearListBox();
        }

        private void ClearListBox()
        {
            //PersonListBox.Items.Clear();
            PersonListBox.ItemsSource = null;
        }
    }

}
