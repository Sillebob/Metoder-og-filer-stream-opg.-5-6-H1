using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Metoder_og_filer_stream_opg._5_6_H1
{
    class Program
    {
        static void Main(string[] args)
        {
            File.WriteAllText(@".\Movies.txt", "Star wars\nThe Empire Strikes Back\nReturn Of The Jedi\n");
            var file = new FileStream(@".\Movies.txt", FileMode.Open);
            var reader = new StreamReader(file);

            while (!reader.EndOfStream)
            {
                string movie = reader.ReadLine();//tildeler en linje, ellers skulle man bruge Read.ToEnd();
                Console.WriteLine(movie);
            }

            file.Close();//lukker filen for at sparer ressourcer. Kan også lukke selve streamen ved reader.Close();

            //Stream opgave 6: Skriv til fil
            file = new FileStream(@".\Actors.txt", FileMode.Create); //overskriver den eksisterende variabel file som indeholdt Movies
            var writer = new StreamWriter(file);

            List<string> actors = new List<string>()
            {
                "Mark Hamill",
                "Harrison Ford",
                "Carrie Fisher"
            };

            foreach (string actor in actors)
            {
                writer.WriteLine(actor);//skriver hver string/navn fra List Actor ind i filen
            }
            file.Close();

            Console.ReadKey();
        }
    }
}
