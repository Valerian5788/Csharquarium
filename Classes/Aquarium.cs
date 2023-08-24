using Csharquarium.Classes.Races;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharquarium.Classes
{
    internal class Aquarium 
    {
        private static Random RNG = new Random();

        public List<Poisson> poissons = new List<Poisson>(); // Liste de poissons dans l'aquarium
        public List<Algues> algues = new List<Algues>(); // Liste d'algues dans l'aquarium

        // Méthode pour ajouter un poisson à l'aquarium
        public void AddFish(Poisson nouveauPoisson)
        {
            poissons.Add(nouveauPoisson); // Ajoute le poisson à la liste de poissons
        }

        // Méthode pour ajouter des algues à l'aquarium
        public void AddAlgues(int nombreAlgues)
        {
            for (int j = 0; j < nombreAlgues; j++)
            {
                // Créer une nouvelle algue et l'ajouter à la liste des algues
                Algues nouvelleAlgue = new Algues();
                algues.Add(nouvelleAlgue);
            }
        }

        // Méthode pour faire passer du temps dans l'aquarium et afficher son état
        public void FairePasserTemps()
        {
            Console.WriteLine($"Nombre d'algues dans l'aquarium : {algues.Count}");
            foreach (Algues algue in algues)
            {
                Console.WriteLine($"Algue avec {algue.Pv}");
            }

            foreach (Poisson poisson in poissons)
            {
                Console.WriteLine($"{poisson.Name} de sexe {poisson.GetSexe()}, de race {poisson.Race} avec {poisson.Pv} PV est présent dans l'aquarium");
            }
            foreach (Algues algue in algues)
            {
                algue.Pv += 1;
                algue.Reproduction = false;
            }
            foreach (Poisson poisson in poissons)
            {
                poisson.Pv -= 1;
                poisson.age += 1;
                if (poisson is IHermaAge hermoop && poisson.age > 10)
                {
                    hermoop.ChangerSexe(poisson);
                }
                poisson.IsOccuped = false;
            }
            
            for ( int i = 0; i < poissons.Count; i++)
            {
                Poisson p = poissons[i];
                if (p.age >= 20)
                {
                    p.MourirPoisson(p, poissons);
                }
                if (p is IHerbivore herb && algues.Count >= 0)
                {
                    if (p.Pv > 5)
                    {
                        if (p.IsOccuped == false)
                        {
                            Poisson cible = poissons[RNG.Next(poissons.Count)];
                            if (p is IMonosexue || p is IHermaAge)
                            {
                                List<Poisson> temp = new List<Poisson>();
                                while (temp.Count < poissons.Count && (p.Race != cible.Race || p.Name == cible.Name || p.IsMale == cible.IsMale))
                                {
                                    cible = poissons[RNG.Next(poissons.Count)];
                                    if(!temp.Contains(cible))
                                    {
                                        temp.Add(cible);
                                    }
                                }
                                if (temp.Count < poissons.Count)
                                {
                                    if (p is IMonosexue mono)
                                    {
                                        Poisson np = p.SeReproduire(p, cible);
                                        np.IsOccuped = true;
                                        p.IsOccuped = true;
                                        cible.IsOccuped = true;
                                        poissons.Add(np);
                                    }
                                    else if (p is IHermaAge hermaage)
                                    {
                                        Poisson np = hermaage.SeReproduire(p, cible);
                                        np.IsOccuped = true;
                                        p.IsOccuped = true;
                                        cible.IsOccuped = true;
                                        poissons.Add(np);
                                    } 
                                }
                            }
                            else if (p is IHermaOpport hermaopport)
                            {
                                List<Poisson> temp = new List<Poisson>();
                                while (temp.Count < poissons.Count && (p.Race != cible.Race || p.Name == cible.Name))
                                {
                                    cible = poissons[RNG.Next(poissons.Count)];
                                    if (!temp.Contains(cible))
                                    {
                                        temp.Add(cible);
                                    }
                                }
                                if (temp.Count < poissons.Count)
                                {
                                    if (p.IsMale == cible.IsMale)
                                    {
                                        hermaopport.ChangerSexe(p);
                                    }
                                    Poisson np = hermaopport.SeReproduire(p, cible);
                                    np.IsOccuped = true;
                                    p.IsOccuped = true;
                                    cible.IsOccuped = true;
                                    poissons.Add(np);
                                }
                            }

                        }

                    }
                    else
                    {
                        Algues repas = algues[RNG.Next(algues.Count)];
                        p.Manger(p,repas,algues);
                    }
                }
                else if (p is ICarnivore carn)
                {
                    if (p.Pv > 5)
                    {
  
                        if (p.IsOccuped == false)
                        {
                        Poisson cible = poissons[RNG.Next(poissons.Count)];
                            if (p is IMonosexue || p is IHermaAge)
                            {
                                List<Poisson> temp = new List<Poisson>();
                                while (temp.Count < poissons.Count && p.Race != cible.Race || p.Name == cible.Name || p.IsMale == cible.IsMale)
                                {
                                    cible = poissons[RNG.Next(poissons.Count)];
                                    if (!temp.Contains(cible))
                                    {
                                        temp.Add(cible);
                                    }
                                }

                                if (temp.Count < poissons.Count)
                                {
                                    if (p is IMonosexue mono)
                                    {
                                        Poisson np = mono.SeReproduire(p, cible);
                                        np.IsOccuped = true;
                                        p.IsOccuped = true;
                                        cible.IsOccuped = true;
                                        poissons.Add(np);
                                    }
                                    else if (p is IHermaAge hermaage)
                                    {
                                        Poisson np = hermaage.SeReproduire(p, cible);
                                        np.IsOccuped = true;
                                        p.IsOccuped = true;
                                        cible.IsOccuped = true;
                                        poissons.Add(np);
                                    } 
                                }
                            }
                            else if (p is IHermaOpport hermaopport)
                            {
                                //if (p.IsMale == cible.IsMale)
                                //{
                                //    hermaopport.ChangerSexe(p);
                                //}

                                List<Poisson> temp = new List<Poisson>();
                                while (temp.Count < poissons.Count && (p.Race != cible.Race ||  p.Name == cible.Name))
                                {
                                    cible = poissons[RNG.Next(poissons.Count)];
                                    if(!temp.Contains(cible))
                                    {
                                        temp.Add(cible);
                                    }
                                }
                                if (temp.Count < poissons.Count)
                                {
                                    if (p.IsMale == cible.IsMale)
                                    {
                                        hermaopport.ChangerSexe(p);
                                    }
                                    Poisson np = p.SeReproduire(p, cible);
                                    np.IsOccuped = true;
                                    p.IsOccuped = true;
                                    cible.IsOccuped = true;
                                    poissons.Add(np); 
                                }
                            }                   

                            }
                        }
                    else {
                            poissons.Remove(p);
                            Poisson repas = poissons[RNG.Next(poissons.Count)];
                            while (repas.Race == p.Race)
                            {
                                repas = poissons[RNG.Next(poissons.Count)];
                            }
                            p.Manger(repas, poissons);
                            poissons.Add(p);                          
                    }
                }

            }
            for (int i = algues.Count - 1; i >= 0; i--)
            {
                Algues algue = algues[i];
                if (algue.age == 20)
                {
                    algue.MourirAlgue(algue, algues);
                }
                if (algue.Pv >= 10 && algue.Reproduction == false)
                {
                    Algues newAlgue = new Algues();
                    newAlgue.Pv = algue.Pv / 2;
                    algue.Pv = newAlgue.Pv;
                    algue.Reproduction = true;
                    newAlgue.Reproduction = true;
                    algues.Add(newAlgue);
                }
            }
        }
    }

}
