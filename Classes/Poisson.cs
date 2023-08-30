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
        private static Random RNG= new Random();
        // Propriété pour indiquer si le poisson est occupé (utilisé pour la reproduction)
        public bool IsOccuped { get; set; }

        // Propriété en lecture seule pour le nom du poisson
        public string Name { get; set; }

        // Propriété en lecture seule pour indiquer si le poisson est mâle
        public bool IsMale { get; set ; }

        // Propriété pour stocker la race du poisson
        public string Race { get; set; }
        public Noms nom = new Noms();
        public Couleurs couleur = new Couleurs();

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

        public Poisson RecherchePartenaire(List<Poisson> poissons)
        {
            //Si il y a partenaire, remplir partenaire;
            Poisson cible = poissons[RNG.Next(poissons.Count)];
            List<Poisson> temp = new List<Poisson>();
            while (temp.Count < poissons.Count && (Race != cible.Race || this == cible || (IsMale == cible.IsMale && this is IHermaOpport) || cible.IsOccuped == true))
            {
                if (!temp.Contains(cible))
                {
                    temp.Add(cible);
                }
                cible = poissons[RNG.Next(poissons.Count)];
            }
            if(temp.Count < poissons.Count) return cible;
            return null;
        }
        public Poisson SeReproduire(Poisson partenaire)
        {
            if (IsMale == partenaire.IsMale && this is IHermaOpport herma)
            {
                herma.ChangerSexe();
            }
            string name = nom.GetNom();
            while(Name == name || partenaire.Name == name)
                {
                    name = nom.GetNom();
                }
            bool sexe = nom.GetSexe();
            object[] parameters = new object[2];
            parameters[0] = name;
            parameters[1] = sexe;
            Poisson newPoisson = (Poisson) GetType().GetConstructors().First().Invoke(parameters);
            newPoisson.IsOccuped = true;
            IsOccuped = true;
            partenaire.IsOccuped = true;
            if (newPoisson.IsMale == true)
            {
                couleur.FormatCouleur("Blue");
            } else { couleur.FormatCouleur("Red"); }
            RaiseMessageSurveillance($"Le miracle de la vie ! {Name} et {partenaire.Name} ont eu un enfant : {name}");
            return newPoisson; // Retourner le nouveau poisson créé
        }

        public void Manger(Poisson repas)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            // Le mérou mange un autre poisson
            RaiseMessageSurveillance($"{Name} a croqué {repas.Name}");
            repas.Pv -= 4; // Réduire les points de vie du poisson repas
            Pv += 4; // Augmenter les points de vie du mérou
            if (repas.Pv <= 0)
            {
                RaiseMessageSurveillance($"{repas.Name} à été mangé. RIP.");
            }
        }
        public void Manger(Algues repas)
        {
            couleur.FormatCouleur("Green");
            // Le poisson mange une algue
            RaiseMessageSurveillance($"{Name} a croqué une algue.");
            repas.Pv -= 2; // Réduire les points de vie de l'algue
            Pv += 3; // Augmenter les points de vie du poisson
        }
    }
}
