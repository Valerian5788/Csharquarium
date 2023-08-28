using Csharquarium.Classes;
using Csharquarium.Classes.Races;
using System;
using System.Security.Cryptography.X509Certificates;
using System.IO;

internal class Program
{
    public static Aquarium aq;
    private static void Main(string[] args)
    {
        aq = new Aquarium();
        aq.OnMessage += Console.WriteLine;
        Algues algue = new Algues();
        EtresVivant vivant = new EtresVivant();

        bool showMenu = true;
        while (showMenu)
        {
            showMenu = MainMenu();
        }
        // Création d'un nouvel aquarium
        //Poisson p1 = new PoissonClown("Nemo", true);
        //Poisson p2 = new PoissonClown("Nema", false);
        //Poisson p3 = new Sole("Neme", false);
        //Poisson p4 = new Carpe("Nemu", true);
        //Poisson p5 = new Mérou("Nemi", false);
        //Poisson p6 = new Thon("Nemlo", true);
        //Poisson p7 = new Sole("Nemfe", true);
        //aq.AddFish(p1);
        //aq.AddFish(p2);
        //aq.AddFish(p3);
        //aq.AddFish(p4);
        //aq.AddFish(p5);
        //aq.AddFish(p6);
        //aq.AddFish(p7);


        // Ajoute des algues à l'aquarium
        //aq.AddAlgues(5);

        // Fait passer du temps dans l'aquarium
        //for (int i = 0; i < 22; i++)
        //{
        //    string input = "";
        //    Console.WriteLine($"Voulez vous faire un tour ? O pour oui, N pour non, {i}");
        //    input = Console.ReadLine();
        //    if (input == "O" || input == "o" || input == "0")
        //    {
        //        aq.FairePasserTemps();
        //    }
        //    else if (input == "N" || input =="n")
        //    {
        //        break;
        //    }
        //}
    }
    public static bool MainMenu()
    {
        Console.Clear();
        Console.WriteLine("Bienvenue dans votre simulation d'aquarium:");
        Console.WriteLine("1) Afficher l'état de mon aquarium");
        Console.WriteLine("2) Passer un tour");
        Console.WriteLine("3) Ajouter un poisson");
        Console.WriteLine("4) Ajouter une algues");
        Console.WriteLine("5) Exit");
        Console.Write("\r\nchoisissez une option: ");
        //string input = Console.ReadLine();
        //int.TryParse(input, out int i);
        //if (input == 1)
        //{

        //}
        switch (Console.ReadLine())
        {
            case "1":
                aq.AfficherÉtat();
                return true;
            case "2":
                aq.FairePasserTemps();
                return true;
            case "3":
                aq.AddFish(CréationPoisson());
                return true;
            case "4":
                Console.WriteLine("Combien ?");
                string input = Console.ReadLine();
                int.TryParse(input, out int result);
                aq.AddAlgues(result);
                return true;
            case "5":
                return false;
            default:
                return true;
        }
    }
    public static Poisson CréationPoisson()
    {
        string input;
        Console.WriteLine("Quel type de poisson?");
        Console.WriteLine("1. pour Poisson-clown 2. pour Sole 3. pour Mérou 4. pour Carpe 5. pour Bar 6. pour Thon");
        input = Console.ReadLine();
        Noms nom = new Noms();
        string name = nom.GetNom();
        bool sexe = nom.GetSexe();
        object[] parameters = new object[2];
        parameters[0] = name;
        parameters[1] = sexe;
        switch (input)
        {
            case "1":
                return new PoissonClown(name, sexe);
            case "2":
                return new Sole(name, sexe);
            case "3":
                return new Mérou(name, sexe);
            case "4":
                return new Carpe(name, sexe);
            case "5":
                return new Bar(name, sexe);
            case "6":
                return new Thon(name, sexe);
        }
        return new Poisson(name, sexe);
        //if (input == "1")
        //{
        //    return new PoissonClown(name, sexe);
        //}
        //else if (input == "2")
        //{
        //    return new Sole(name, sexe);
        //}
        //else if (input == "3")
        //{
        //    return new Mérou(name, sexe);
        //}
        //else if (input == "4")
        //{
        //    return new Carpe(name, sexe);
        //}
        //else if (input == "5")
        //{
        //    return new Bar(name, sexe);
        //}
        //else if (input == "6")
        //{
        //    return new Thon(name, sexe);
        //}
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

    


