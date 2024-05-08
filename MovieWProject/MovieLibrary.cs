public class MovieLibrary
{
    private List<Movie> movies;
    private List<User> users;

    public MovieLibrary()
    {
        movies = new List<Movie>();
        users = new List<User>();
    }

    public void AddMovie(string title, string director, int year)
    {
        movies.Add(new Movie(title, director, year));
        Console.WriteLine($"Movie added: {title} by {director}, {year}");
    }

    public void ListMovies()
    {
        foreach(Movie movie in movies)
        {
            Console.WriteLine($"{movie.Title} by {movie.Director}, {movie.Year}, Available: {movie.IsAvailable}");
        }
    }

    public void RegisterUser(string name)
    {
        users.Add(new User(name));
        Console.WriteLine($"User registered: {name}");
    }

    public Movie FindMovie(string title)
    {
        return movies.Find(movie => movie.Title == title);
    }

    public User FindUser(string name) {
        return users.Find(user => user.Name == name);
    }
}