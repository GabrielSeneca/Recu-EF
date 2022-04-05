using System;
using Microsoft.EntityFrameworkCore;

namespace Recu
{
    class program
    {/* /*
         static void Main(string[] args)
        {
            var db = new MoviesDbContext();
            ShowMenu(db);

            System.Console.WriteLine("Presione cualquier tecla para salir...");
            Console.ReadLine();
        }
        

        private static void Show(MoviesDbContext db)
        {
            var all = db.Movies.ToListAsync().Result;

            if (all!=null){
                foreach (var movie in all){
                    System.Console.WriteLine(movie.Name);
                }
            }

            ShowMenu(db);
        }

        static void ShowMenu(){
            Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine();
            System.Console.WriteLine("Seleccione la opción deseada");
            System.Console.WriteLine("1.- Consultar Películas");
            System.Console.WriteLine("2.- Crear Película");
            System.Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;

            var option = Console.ReadLine();

            if (option == "1"){
                Show(db);
            }
            else{
                Create(db);
            } */

        

        static void Main(string[] args){

            System.Console.WriteLine("Escriba el nombre de la película");
            var name = Console.ReadLine();
            System.Console.WriteLine("Escriba el año de estreno:");
            var year = Console.ReadLine();

            var newMovie = new Movie();
            newMovie.Name = name;
            newMovie.Year = int.Parse(year);

            var db = new MoviesDbContext();
            db.Movies.Add(newMovie);

            var result = db.SaveChanges();

            if (result == 1){
                System:Console.WriteLine("La película ha sido guardada exitosamente");
            }
            else{
                System.Console.WriteLine("Error");
            } 
                
            System.Console.WriteLine("Presione cualquier tecla para salir...");
            Console.ReadLine();
         
        }

    }
    class Movie {
        public int Id { get; set;}
        public string Name { get; set;}
        public int Year { get; set;}
        
    }
    class MoviesDbContext : DbContext
    { 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseSqlServer(@"Data source=(localdb)\MSSQLLocalDB; Initial Catalog=Movies;Integrated Security=true");
        }

        /* protected MoviesDbContext()
        {
            
        } */
       
        public DbSet<Movie> Movies {get; set;}

    }
}

