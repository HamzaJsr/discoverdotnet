using System;

namespace MinimalApis
{
    public class Personne
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }

        public static bool TryParse(string value, out Personne? personne)
        {
            try
            {
                var data = value.Split(' ');
                personne = new Personne 
                {
                    Nom = data[0],
                    Prenom = data[1]

                };
                return true;
            }
            catch (Exception)
            {
                personne = null;
                return false;
            }
        }

    }
}
