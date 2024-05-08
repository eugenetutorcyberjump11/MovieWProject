class Program
{
    static void Main(string[] args)
    {
        MovieLibrary library = new MovieLibrary();
        library.AddMovie("Inception", "Christopher Nolan", 2010);
        library.AddMovie("The Social Network", "David Fincher", 2010);

        library.RegisterUser("Alice");

        while(true)
        {
            Console.WriteLine("\nMovie Library System");
            Console.WriteLine("1. List all movies");
            Console.WriteLine("2. Add a movie");
            Console.WriteLine("3. Register a user");
            Console.WriteLine("4. Watch a movie");
            Console.WriteLine("5. Return a movie");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());
            
            switch(choice)
            {
                case 1:
                    library.ListMovies();
                    break;
                case 2:
                    AddMovieToLibrary(library);
                    break;
                case 3:
                    RegisterUserToLibrary(library);
                    break;
                case 4:
                    WatchMovieFromLibrary(library);
                    break;
                case 5:
                    ReturnMovieToLibrary(library);  
                    break;
                case 6:
                    return;
                case 7:
                    Console.WriteLine("Invilid choice, please try again!");
                    break;
            }
        }
    }

    private static  void AddMovieToLibrary(MovieLibrary library)
    {
        Console.Write("Enter movie title: ");
        string title = Console.ReadLine();
        Console.Write("Enter director name: ");
        string director = Console.ReadLine();
        Console.Write("Enter ralease year: ");
        int year = int.Parse(Console.ReadLine());
        library.AddMovie(title, director, year);
    }

    private static void RegisterUserToLibrary(MovieLibrary library)
    {
        Console.Write("Enter user name: ");
        string name = Console.ReadLine();
        library.RegisterUser(name);
    }

    private static void WatchMovieFromLibrary(MovieLibrary library)
    {
        Console.WriteLine("Enter user name: ");
        string userName = Console.ReadLine();
        User user = library.FindUser(userName);
        if(user == null)
        {
            Console.WriteLine("User not found");
            return;
        }

        Console.Write("Enter movie title to watch: ");
        string movieTitle = Console.ReadLine();
        Movie movie = library.FindMovie(movieTitle);
        if (movie == null || !movie.IsAvailable)
        {
            Console.WriteLine("Movie not available");
            return;
        }

        user.WatchMovie(movie);
    }

    private static void ReturnMovieToLibrary(MovieLibrary library)
    {
        Console.WriteLine("Enter user name: ");
        string userName = Console.ReadLine();
        User user = library.FindUser(userName);
        if (user == null)
        {
            Console.WriteLine("User not found");
            return;
        }

        Console.Write("Enter movie title to return: ");
        string movieTitle = Console.ReadLine();
        Movie movie = user.WatchedMovies.FirstOrDefault(m => m.Title == movieTitle);
        if(movie == null)
        {
            Console.WriteLine("Movie not found on user account");
            return;
        }

        user.ReturnMovie(movie);

    }
}