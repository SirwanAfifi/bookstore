namespace Owin.Demo_Console_App.Models
{
    public class Movie
    {
        public string Title { get; set; }
        public Genre Genre { get; set; }
        public float Rating { get; set; }
    }

    public enum Genre
    {
        SciFi,
        Comedy,
        Action,
        Horror,
        Crime
    }
}