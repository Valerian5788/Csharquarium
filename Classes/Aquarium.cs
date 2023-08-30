using Csharquarium.Classes.Races;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Net.WebRequestMethods;

namespace Csharquarium.Classes
{
    internal class Aquarium
    {
        private int tour = 0;
        private static Random RNG = new Random();

        public event Action<string> OnMessage;

        public List<Poisson> poissons = new List<Poisson>(); // Liste de poissons dans l'aquarium
        public List<Algues> algues = new List<Algues>(); // Liste d'algues dans l'aquarium
        public Couleurs couleur = new Couleurs();

        // Méthode pour ajouter un poisson à l'aquarium
        public void AddFish(Poisson nouveauPoisson)
        {
            List<string> data = new List<string>();
            poissons.Add(nouveauPoisson); // Ajoute le poisson à la liste de poissons
            nouveauPoisson.AgeSurveillance += RaiseMessageAge;
            nouveauPoisson.MessageSUrveillance += (string message) =>
            {
                OnMessage?.Invoke(message);
            };
            nouveauPoisson.PvSurveillance += Remove;
        }

        private void Remove(EtresVivant mort)
        {
            if (mort is Poisson poisson)
            {
                poissons.Remove(poisson);
                poisson.PvSurveillance -= Remove;
                poisson.AgeSurveillance -= RaiseMessageAge;
            }
            else if (mort is Algues algue)
            {
                algues.Remove(algue);
            }
        }

        private void RaiseMessageAge(EtresVivant poisson)
        {
            Poisson p = (Poisson)poisson;
            couleur.FormatCouleur("Death");
            OnMessage?.Invoke($"Le poisson {p.Name} est mort de vieillesse");
        }

        // Méthode pour ajouter des algues à l'aquarium
        public void AddAlgues()
        {
            OnMessage?.Invoke("Combien ?");
            int nombreAlgues;
            int.TryParse(Console.ReadLine(), out nombreAlgues);
            for (int j = 0; j < nombreAlgues; j++)
            {
                // Créer une nouvelle algue et l'ajouter à la liste des algues
                Algues nouvelleAlgue = new Algues();
                algues.Add(nouvelleAlgue);
                nouvelleAlgue.PvSurveillance += (EtresVivant algue) =>
                {
                    algues.Remove(nouvelleAlgue);
                    OnMessage?.Invoke($"L'algue est morte, elle a {algue.Pv} PV");
                };
                nouvelleAlgue.AgeSurveillance += (EtresVivant algue) =>
                {
                    Algues a = (Algues)algue;
                    algues.Remove(a);
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
                    couleur.FormatCouleur("Blue");
                }
                else { couleur.FormatCouleur("Red"); }
                OnMessage?.Invoke($"{poisson.Name} de sexe {poisson.GetSexe()}, de race {poisson.Race} avec {poisson.Pv} PV est présent dans l'aquarium");
            }
        }

        // Méthode pour faire passer du temps dans l'aquarium
        public void FairePasserTemps()
        {
            tour++;
            OnMessage?.Invoke($"Nombre de tours = {tour}");

            foreach (Algues algue in algues)
            {
                algue.age += 1;
                algue.Pv += 1;
                algue.Reproduction = false;
            }
            foreach (Poisson poisson in poissons)
            {
                poisson.age += 1;
                poisson.Pv -= 1;
                if (poisson is IHermaAge hermoop && poisson.age > 10)
                {
                    hermoop.ChangerSexe();
                }
                poisson.IsOccuped = false;
            }

            for (int i = 0; i < poissons.Count; i++)
            {
                Poisson p = poissons[i];
                if (p.IsOccuped == false)
                {
                    //reproduction
                    if (p.Pv > 5)
                    {

                        Poisson cible = p.RecherchePartenaire(poissons);

                        if (cible != null)
                        {

                            Poisson np = p.SeReproduire(cible);
                            poissons.Add(np);
                        }


                    }
                    //se nourrir
                    else
                    {
                        if (p is IHerbivore herb && algues.Count >= 0)
                        {
                            Algues repas = algues[RNG.Next(algues.Count)];
                            if (algues.Count <= 0)
                            {
                                OnMessage?.Invoke("Plus aucune algue dans l'aquarium, rajoutez en svp :");
                                AddAlgues();
                            }
                            p.Manger(repas);
                        }
                        else if (p is ICarnivore carn && poissons.Count > 0)
                        {
                            List<Poisson> temp = new List<Poisson>();
                            poissons.Remove(p);
                            Poisson repas = poissons[RNG.Next(poissons.Count)];
                            while (temp.Count < poissons.Count && repas.Race == p.Race)
                            {
                                if (!temp.Contains(repas))
                                {
                                    temp.Add(repas);
                                }
                                repas = poissons[RNG.Next(poissons.Count)];
                            }
                            if (temp.Count < poissons.Count)
                            {
                                p.Manger(repas);
                                poissons.Add(p);
                            }
                            else { poissons.Add(p); }
                        }
                        else
                        {
                            OnMessage?.Invoke("Il ne reste qu'un poisson");
                        }
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
                data.Add($"{nom}|{race}|{age}|{pv}|{sexe}");
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
