using System;
using System.Reflection;

namespace MinimalApis
{
    public class Personne
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }

        // public static bool TryParse(string value, out Personne? personne)
        // {
        //     try
        //     {
        //         var data = value.Split(' ');
        //         personne = new Personne 
        //         {
        //             Nom = data[0],
        //             Prenom = data[1]

        //         };
        //         return true;
        //     }
        //     catch (Exception)
        //     {
        //         personne = null;
        //         return false;
        //     }
        // }

        public static async ValueTask<Personne> BindAsync(
            HttpContext context, ParameterInfo parameterInfo)
            {
              try
            {
                using var StreamReader = new StreamReader(context.Request.Body);
                var body = await StreamReader.ReadToEndAsync();

                var data = body.Split(' ');
                var person = new Personne 
                {
                    Nom = data[0],
                    Prenom = data[1]

                };
                return person;
            }
            catch (Exception)
            {
                return null;
            }

            }

    }
}
