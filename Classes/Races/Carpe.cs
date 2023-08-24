using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharquarium.Classes.Races
{
    // Déclaration de la classe Carpe qui hérite de la classe Poisson et implémente l'interface iHerbivore
    internal class Carpe : Poisson, IHerbivore, IMonosexue
    {
        // Constructeur de la classe Carpe qui appelle le constructeur de la classe de base (Poisson)
        public Carpe(string name, bool isMale) : base(name, isMale)
        {
            Race = "Carpe";
            IsOccuped = false;
            // Aucune autre initialisation requise pour le moment
        }

        // Implémentation de la méthode Manger de l'interface IHerbivore
        public void Manger(Algues repas)
        {
            // La carpe mange une algue
            Console.WriteLine($"{Name} a croqué une algue.");
            repas.Pv -= 2; // Réduire les points de vie de l'algue
            Pv += 3; // Augmenter les points de vie de la carpe
        }

        // Implémentation de la méthode SeReproduire de l'interface IMonosexue
        //Poisson IMonosexue.SeReproduire(Poisson homme, Poisson femme)
        //{
        //    Noms nom = new Noms();
        //    string name = nom.GetNom();
        //    bool sexe = nom.GetSexe();
        //    Poisson newPoisson = new Carpe(name, sexe); // Créer un nouvel objet de type Carpe
        //    Console.WriteLine($"Le miracle de la vie ! {homme.Name} et {femme.Name} ont eu un enfant : {name}");
        //    return newPoisson; // Retourner le nouveau poisson créé
        //}
    }
}