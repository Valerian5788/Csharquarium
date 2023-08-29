using Csharquarium.Classes;
using Csharquarium.Classes.Races;
using System;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Globalization;

internal class Program
{
    public static Aquarium aq;
    private static void Main(string[] args)
    {
        aq = new Aquarium();
        Couleurs c = new Couleurs();
        aq.OnMessage += Console.WriteLine;
        Algues algue = new Algues();
        EtresVivant vivant = new EtresVivant();

        //bool showMenu = true;
        //while (showMenu)
        //{
        //    showMenu = MainMenu();

        //}
        string headerText = "  __  __                     _____           _                 " +
               Environment.NewLine + " |  \\/  |                   / ____|         | |                " +
               Environment.NewLine + " | \\  / | ___ _ __  _   _  | (___  _   _ ___| |_ ___ _ __ ___" +
               Environment.NewLine + " | |\\/| |/ _ \\ '_ \\| | | |  \\___ \\| | | / __| __/ _ \\ '_ ` _ \\" +
               Environment.NewLine + " | |  | |  __/ | | | |_| |  ____) | |_| \\__ \\ ||  __/ | | | | |" +
               Environment.NewLine + " |_|  |_|\\___|_| |_|\\__,_| |_____/ \\__, |___/\\__\\___|_| |_| |_|" +
               Environment.NewLine + "                                    __/ |    " +
               Environment.NewLine + "                                   |___/             ";


        Console.Clear();

        // Setup the menu
        ConsoleMenu mainMenu = new ConsoleMenu();

        ConsoleMenu subMenu1 = new ConsoleMenu("==>");
        subMenu1.SubTitle = "---------------- Secret Menu -----------------";
        subMenu1.addMenuItem(0, "backToMain", subMenu1.hideMenu);
        subMenu1.ParentMenu = mainMenu;

        mainMenu.Header = headerText;
        subMenu1.Header = mainMenu.Header;

        mainMenu.SubTitle = "-------------------- Menu ----------------------";
        mainMenu.addMenuItem(0, "Hello World!", HelloWorld);
        mainMenu.addMenuItem(1, "Secret Menu", subMenu1.showMenu);
        mainMenu.addMenuItem(2, "Exit", Exit);
        // Display the menu
        mainMenu.showMenu();


        static void Exit()
        {
            Environment.Exit(0);
        }

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

}
    //public static bool MainMenu()
    //{
    //    Console.Clear();
    //    Console.ForegroundColor = ConsoleColor.White;
    //    Console.WriteLine("Bienvenue dans votre simulation d'aquarium:");
    //    Console.WriteLine("1) Afficher l'état de mon aquarium");
    //    Console.WriteLine("2) Passer un tour");
    //    Console.WriteLine("3) Ajouter un poisson");
    //    Console.WriteLine("4) Ajouter une algues");
    //    Console.WriteLine("5) Enregistrer les données");
    //    Console.WriteLine("6) Exit");
    //    Console.Write("\r\nchoisissez une option: ");
    //    //string input = Console.ReadLine();
    //    //int.TryParse(input, out int i);
    //    //if (input == 1)
    //    //{

    //    //}
    //    switch (Console.ReadLine())
    //    {
    //        case "1":
    //            aq.AfficherÉtat();
    //            return true;
    //        case "2":
    //            aq.FairePasserTemps();
    //            return true;
    //        case "3":
    //            aq.AddFish(CréationPoisson());
    //            return true;
    //        case "4":
    //            Console.WriteLine("Combien ?");
    //            string input = Console.ReadLine();
    //            int.TryParse(input, out int result);
    //            aq.AddAlgues(result);
    //            return true;
    //        case "5":
    //            aq.EnregistrerData();
    //            return true;
    //        case "6":
    //            return false;
    //        default:
    //            return true;
    //    }
    //}
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

    


