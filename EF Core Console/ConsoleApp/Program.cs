using System;

#region Additional Namespaces
using ConsoleApp.Models;
using ConsoleApp.DAL;
using System.Linq;
#endregion

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new JsonUtils();
            //on json files check properties ensure Copy to Output Directory is
            // set to Copy if newer
            var courses = app.ReadData<Course>("./data/courses.json");
            var terms = app.ReadData<Term>("./data/terms.json");

            //load database once with json data
            using (var context = new SchoolCatalogContext())
            {
                if (!context.Courses.Any())
                    context.Courses.AddRange(courses);
                if (!context.Terms.Any())
                    context.Terms.AddRange(terms);
                context.SaveChanges();
            }

            //read and display database contents
            using (var context = new SchoolCatalogContext())
            {
                foreach (var item in context.Courses)
                    Console.WriteLine(item);

                foreach (var item in context.Terms)
                    Console.WriteLine(item);
            }
        }
    }
}
