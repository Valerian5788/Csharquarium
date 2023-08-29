using Csharquarium.Classes.Races;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Csharquarium.Classes
{
    internal class Aquarium 
    {
        private int tour = 0;
        private static Random RNG = new Random();

        public event Action<string> OnMessage;

        public List<Poisson> poissons = new List<Poisson>(); // Liste de poissons dans l'aquarium
        public List<Algues> algues = new List<Algues>(); // Liste d'algues dans l'aquarium

        // Méthode pour ajouter un poisson à l'aquarium
        public void AddFish(Poisson nouveauPoisson)
        {
            List<string> data = new List<string>();
            poissons.Add(nouveauPoisson); // Ajoute le poisson à la liste de poissons
            nouveauPoisson.AgeSurveillance += (int age) =>
            {
                OnMessage?.Invoke($"Le poisson{nouveauPoisson.Name} est mort de vieillesse");
            };
            nouveauPoisson.MessageSUrveillance += (string message) =>
            {
                    OnMessage?.Invoke(message); 
            };
        }


        // Méthode pour ajouter des algues à l'aquarium
        public void AddAlgues(int nombreAlgues)
        {
            for (int j = 0; j < nombreAlgues; j++)
            {
                // Créer une nouvelle algue et l'ajouter à la liste des algues
                Algues nouvelleAlgue = new Algues();
                algues.Add(nouvelleAlgue);
                nouvelleAlgue.PvSurveillance += (int pv) =>
                {
                    algues.Remove(nouvelleAlgue);
                    OnMessage?.Invoke($"L'algue est morte, elle a {pv} PV");
                };
                nouvelleAlgue.AgeSurveillance += (int pv) =>
                {
                    algues.Remove(nouvelleAlgue);
                    OnMessage?.Invoke($"Une algue à atteint l'age de 20 tours, elle meurt paisiblement");
                };
            }
        }
        public void AfficherÉtat()
        {
            OnMessage?.Invoke($"Nombre d'algues dans l'aquarium : {algues.Count}");
            foreach (Algues algue in algues)
            {
                OnMessage?.Invoke($"Algue avec {algue.Pv}");
            }

            foreach (Poisson poisson in poissons)
            {
                if (poisson.IsMale == true)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }else { Console.ForegroundColor = ConsoleColor.Red; }
                OnMessage?.Invoke($"{poisson.Name} de sexe {poisson.GetSexe()}, de race {poisson.Race} avec {poisson.Pv} PV est présent dans l'aquarium");
            }

            Console.ReadKey();
        }

        // Méthode pour faire passer du temps dans l'aquarium
        public void FairePasserTemps()
        {
            tour++;
            OnMessage?.Invoke($"Nombre de tours = {tour}");

            foreach (Algues algue in algues)
            {
                algue.Pv += 1;
                algue.Reproduction = false;
                algue.age += 1;
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
                                while (temp.Count < poissons.Count && (p.Race != cible.Race || p.Name == cible.Name || p.IsMale == cible.IsMale || cible.IsOccuped == true))
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
                                        poissons.Add(np);
                                    }
                                    else if (p is IHermaAge hermaage)
                                    {
                                        Poisson np = p.SeReproduire(p, cible);

                                        poissons.Add(np);
                                    } 
                                }
                            }
                            else if (p is IHermaOpport hermaopport)
                            {
                                List<Poisson> temp = new List<Poisson>();
                                while (temp.Count < poissons.Count && (p.Race != cible.Race || p.Name == cible.Name || cible.IsOccuped == true))
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
                                    Poisson np = p.SeReproduire(p, cible);
                                    poissons.Add(np);
                                }
                            }

                        }

                    }
                    else
                    {
                        Algues repas = algues[RNG.Next(algues.Count)];
                        if (algues.Count <= 0)
                        {
                            OnMessage?.Invoke("Plus aucune algue dans l'aquarium, rajoutez en svp :");
                            string input = Console.ReadLine();
                            int.TryParse(input, out int o);
                            AddAlgues(o);
                        }
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
                                while (temp.Count < poissons.Count && p.Race != cible.Race || p.Name == cible.Name || p.IsMale == cible.IsMale || cible.IsOccuped == true)
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
                                        Poisson np = p.SeReproduire(p, cible);
                                        poissons.Add(np);
                                    }
                                    else if (p is IHermaAge hermaage)
                                    {
                                        Poisson np = p.SeReproduire(p, cible);
                                        poissons.Add(np);
                                    } 
                                }
                            }
                            else if (p is IHermaOpport hermaopport)
                            {
                                List<Poisson> temp = new List<Poisson>();
                                while (temp.Count < poissons.Count && (p.Race != cible.Race ||  p.Name == cible.Name || cible.IsOccuped == true))
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
            Console.ReadKey();
        }
        public void EnregistrerData()
        {
            List<string> data = new List<string>();
            foreach (Poisson poisson in poissons)
            {
                string race = poisson.Race;
                string nom = poisson.Name;
                string sexe = poisson.GetSexe();
                string pv = poisson.Pv.ToString();
                string age = poisson.age.ToString(); 
                data.Add( $"{nom}|{race}|{age}|{pv}|{sexe}" );
                // Set a variable to the Documents path.
            }

            // Write the string array to a new file named "WriteLines.txt".
            using (StreamWriter outputFile = new StreamWriter(Path.Combine("C:\\Users\\v.vandercamme\\Documents\\c#\\OO\\Csharquarium", "Poissons.txt")))
            {
                foreach (string line in data)
                    outputFile.WriteLine(line);
            }
            data = new List<string>();
            string nmbre = algues.Count.ToString();
            data.Add(nmbre);
            foreach (Algues algue in algues)
            {
                string pv = algue.Pv.ToString();
                string age = algue.age.ToString();
                
                data.Add($"{pv} | {age}");
            }
            // Write the string array to a new file named "WriteLines.txt".
            using (StreamWriter outputFile = new StreamWriter(Path.Combine("C:\\Users\\v.vandercamme\\Documents\\c#\\OO\\Csharquarium", "Algues.txt")))
            {
                foreach (string line in data)
                    outputFile.WriteLine(line);
            }

        }
    }


}
