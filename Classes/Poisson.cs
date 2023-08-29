using Csharquarium.Classes.Races;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Csharquarium.Classes
{
    // Déclaration de la classe Poisson qui hérite de la classe EtresVivant
    internal class Poisson : EtresVivant
    {
        // Propriété pour indiquer si le poisson est occupé (utilisé pour la reproduction)
        public bool IsOccuped { get; set; }

        // Propriété en lecture seule pour le nom du poisson
        public string Name { get; set; }

        // Propriété en lecture seule pour indiquer si le poisson est mâle
        public bool IsMale { get; set ; }

        // Propriété pour stocker la race du poisson
        public string Race { get; set; }
        public Noms nom = new Noms();

        public Poisson() { }
        // Constructeur de la classe Poisson
        public Poisson(string name, bool isMale)
        {
            Name = name; // Initialiser la propriété Name avec le nom passé en argument
            IsMale = isMale; // Initialiser la propriété IsMale avec la valeur passée en argument
        }

        // Méthode pour obtenir une chaîne de caractères représentant le sexe du poisson
        public string GetSexe()
        {
            return IsMale ? "Male" : "Femelle"; // Si IsMale est vrai, retourner "Male", sinon retourner "Femelle"
        }
        public Poisson SeReproduire(Poisson homme, Poisson femme)
        {
            string name = nom.GetNom();
            while(homme.Name == name || femme.Name == name)
                {
                    name = nom.GetNom();
                }
            bool sexe = nom.GetSexe();
            object[] parameters = new object[2];
            parameters[0] = name;
            parameters[1] = sexe;
            Poisson newPoisson = (Poisson) homme.GetType().GetConstructors().First().Invoke(parameters);
            newPoisson.IsOccuped = true;
            homme.IsOccuped = true;
            femme.IsOccuped = true;
            if (newPoisson.IsMale == true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            } else { Console.ForegroundColor = ConsoleColor.Red; }
            RaiseMessageSurveillance($"Le miracle de la vie ! {homme.Name} et {femme.Name} ont eu un enfant : {name}");
            return newPoisson; // Retourner le nouveau poisson créé
        }

        public void Manger(Poisson repas, List<Poisson> poissons)
        {
            // Le mérou mange un autre poisson
            RaiseMessageSurveillance($"{Name} a croqué {repas.Name}");
            repas.Pv -= 4; // Réduire les points de vie du poisson repas
            Pv += 4; // Augmenter les points de vie du mérou
            if (repas.Pv <= 0)
            {
                poissons.Remove(repas);
                RaiseMessageSurveillance($"{repas.Name} à été mangé. RIP.");
            }
        }
        public void Manger(Poisson poisson, Algues repas, List<Algues> algues)
        {
            // Le poisson mange une algue
            RaiseMessageSurveillance($"{poisson.Name} a croqué une algue.");
            repas.Pv -= 2; // Réduire les points de vie de l'algue
            Pv += 3; // Augmenter les points de vie du poisson
        }
        // Méthode pour changer le sexe du poisson
        public void ChangerSexe(Poisson poisson)
        {
            // Inversion simple du sexe
            if (poisson.IsMale)
            {
                poisson.IsMale = false;
            }
            else
            {
                poisson.IsMale = true;
            }
        }
    }
}
