using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Csharquarium.Classes
{
    internal class Noms
    {
        // Liste de noms possibles pour les poissons
        List<string> noms = new List<string>() { "Tito", "Damaged", "Venus", "Merry", "Wings", "Feline", "Beehive", "Arctic", "Enigma", "Imaginary", "Willow", "Robin", "Cool", "Supernova", "Funny", "Halo", "Flat", "Angler", "White", "Pebble", "Plain", "Darling","Théodore", "Lahaye", "Auguste", "DembéléJean-Guy", "LaFromboise", "Lionel", "Gainsbourg", "Marius", "Beaubois", "Lucas", "Vigouroux", "Théodore", "Abbadie", "Armel", "Durand", "Wilfried", "Chapelle", "Augustin", "Favre" };

        // Liste de sexes possibles (true pour mâle, false pour femelle)
        List<bool> sexes = new List<bool>() { true, false };

        // Méthode pour obtenir un nom aléatoire
        public string GetNom()
        {
            Random random = new Random();
            string nom = noms[random.Next(noms.Count)];// Sélection aléatoire d'un nom de la liste
            noms.Remove(nom);
            return nom;
        }

        // Méthode pour obtenir un sexe aléatoire
        public bool GetSexe()
        {
            Random random = new Random();
            bool sexe = sexes[random.Next(sexes.Count)]; // Sélection aléatoire d'un sexe de la liste
            return sexe;
        }
    }

}
