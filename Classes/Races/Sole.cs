﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharquarium.Classes.Races
{
    // Déclaration de la classe Sole qui hérite de la classe Poisson et implémente l'interface iHerbivore
    internal class Sole : Poisson, IHerbivore, IHermaOpport
    {
        // Constructeur de la classe Sole qui appelle le constructeur de la classe de base (Poisson)
        public Sole(string name, bool isMale) : base(name, isMale)
        {
            Race = "Sole";
            IsOccuped = false;
            // Aucune autre initialisation requise pour le moment
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

        // Implémentation de la méthode Manger de l'interface IHerbivore
        public void Manger(Algues repas)
        {
            // Le poisson mange une algue
            Console.WriteLine($"{Name} a croqué une algue.");
            repas.Pv -= 2; // Réduire les points de vie de l'algue
            Pv += 3; // Augmenter les points de vie du poisson
        }

        // Implémentation de la méthode SeReproduire de l'interface IHermaOpport
        Poisson IHermaOpport.SeReproduire(Poisson homme, Poisson femme)
        {
            Noms nom = new Noms();
            string name = nom.GetNom();
            bool sexe = nom.GetSexe();
            Poisson newPoisson = new Sole(name, sexe); // Créer un nouvel objet de type Sole
            Console.WriteLine($"Le miracle de la vie ! {homme.Name} et {femme.Name} ont eu un enfant : {name}");
            return newPoisson; // Retourner le nouveau poisson créé
        }
    }
}
