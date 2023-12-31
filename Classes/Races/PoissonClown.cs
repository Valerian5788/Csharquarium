﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharquarium.Classes.Races
{
    // Déclaration de la classe PoissonClown qui hérite de la classe Poisson et implémente l'interface iHerbivore
    internal class PoissonClown : Poisson, ICarnivore, IHermaOpport
    {
        // Constructeur de la classe PoissonClown qui appelle le constructeur de la classe de base (Poisson)
        public PoissonClown(string name, bool isMale) : base(name, isMale)
        {
            Race = "PoissonClown";
            IsOccuped = false;
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

        // Implémentation de la méthode Manger de l'interface ICarnivore
    }


}
