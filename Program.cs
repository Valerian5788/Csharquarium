using Csharquarium.Classes;
using Csharquarium.Classes.Races;
using System;
using System.Security.Cryptography.X509Certificates;

internal class Program
{
    private static void Main(string[] args)
    {
        // Création d'un nouvel aquarium
        Aquarium aq = new Aquarium();
        aq.OnMessage += Console.WriteLine;
        Algues algue = new Algues();
        EtresVivant vivant = new EtresVivant();
        Poisson p1 = new PoissonClown("Nemo", true);
        Poisson p2 = new PoissonClown("Nema", false);
        Poisson p3 = new Sole("Neme", false);
        Poisson p4 = new Carpe("Nemu", true);
        Poisson p5 = new Mérou("Nemi", false);
        Poisson p6 = new Thon("Nemlo", true);
        Poisson p7 = new Sole("Nemfe", true);
        aq.AddFish(p1);
        aq.AddFish(p2);
        aq.AddFish(p3);
        aq.AddFish(p4);
        aq.AddFish(p5);
        aq.AddFish(p6);
        aq.AddFish(p7);

        // Ajoute des algues à l'aquarium
        aq.AddAlgues(5);

        // Fait passer du temps dans l'aquarium
        for (int i = 0; i < 22; i++)
        {
            string input = "";
            do
            {
                Console.WriteLine("Voulez vous faire un tour ? O pour oui, N pour non");
                input = Console.ReadLine();
                aq.FairePasserTemps();

            } while (input == "O");
            if (input == "N")
            {
                break;
            }
        }
    }
}
        // Demande à l'utilisateur de choisir trois poissons et les ajoute à l'aquarium
        /* Poisson p1 = ChoixPoisson();
         Poisson p2 = ChoixPoisson();
         Poisson p3 = ChoixPoisson();
         Poisson p4 = ChoixPoisson();
         Poisson p5 = ChoixPoisson();
         Poisson p6 = ChoixPoisson();
         Poisson p7 = ChoixPoisson();
         Poisson p8 = ChoixPoisson();
         Poisson p9 = ChoixPoisson();*/

    /*private static Poisson ChoixPoisson()
    {
        Console.WriteLine("Quel nom?");
        string name = Console.ReadLine();
        Console.WriteLine("Quel genre? 1. male 2. femelle");
        string input = Console.ReadLine();
        bool isMale = input == "1";
        Console.WriteLine("Quel type de poisson?");
        Console.WriteLine("1. pour Poisson-clown 2. pour Sole 3. pour Mérou 4. pour Carpe 5. pour Bar 6. pour Thon");
        input = Console.ReadLine();
        switch (input)
        {
            case "1":
                return new PoissonClown(name, isMale);
            case "2":
                return new Sole(name, isMale);
            case "3":
                return new Mérou(name, isMale);
            case "4":
                return new Carpe(name, isMale);
            case "5":
                return new Bar(name, isMale);
            case "6":
                return new Thon(name, isMale);
        }
        return new Poisson(name, isMale);
    }*/
    /*public void Manger(Algues repas)
    {
        Aquarium aq = new Aquarium();
        foreach (Carpe carpe in aq.poissons)
        {
            if (aq.algues.Count > 0)
            {
                aq.algues.RemoveAt(0); // Enlever la première algue de la liste
                Console.WriteLine($"{carpe.Name} a mangé une algue.");
            }
        }
    }*/
    /*private static void Manger(Poisson repas)
    {
        Aquarium aq = new Aquarium();
        Random random = new Random();
        foreach (Poisson poisson in aq.poissons.ToList())
        {
            if (aq.poissons.Count > 1)
            {
                aq.poissons.Remove(poisson); // Retirer le poisson actuel de la liste
                int randomIndex = random.Next(0, aq.poissons.Count);
                Poisson poissonMange = aq.poissons[randomIndex]; // Sélectionner un poisson aléatoire
                aq.poissons.Add(poisson); // Remettre le poisson actuel dans la liste
                aq.poissons.Remove(poissonMange); // Retirer le poisson mangé de la liste
                Console.WriteLine($"{poisson.Name} a mangé {poissonMange.Name}.");
            }
        }
    }*/


