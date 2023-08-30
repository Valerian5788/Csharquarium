using Csharquarium.Classes;
using Csharquarium.Classes.Races;
using System.Security.Cryptography.X509Certificates;

internal class Program
{
    public static List<Option> options;
    public static Aquarium aq;
    private static void Main(string[] args)
    {
       
        aq = new Aquarium();
        Couleurs c = new Couleurs();
        aq.OnMessage += Console.WriteLine;
        Algues algue = new Algues();
        EtresVivant vivant = new EtresVivant();
        options = new List<Option>
            {
                new Option("Afficher l'état de l'aquarium", () => aq.AfficherÉtat()),
                new Option("Passer un tour", () =>  aq.FairePasserTemps()),
                new Option("Ajouter un poisson", () =>  aq.AddFish(CréationPoisson())),
                new Option("Ajouter des algues", () =>  aq.AddAlgues()),
                new Option("Enregistrer les données", () =>  aq.EnregistrerData()),
                new Option("Exit", () => Environment.Exit(0)),
            };

        // Set the default index of the selected item to be the first
        int index = 0;

        // Write the menu out
        WriteMenu(options, options[index]);

        // Store key info in here
        ConsoleKeyInfo keyinfo;
        do
        {
            keyinfo = Console.ReadKey();

            // Handle each key input (down arrow will write the menu again with a different selected item)
            if (keyinfo.Key == ConsoleKey.DownArrow)
            {
                if (index + 1 < options.Count)
                {
                    index++;
                    WriteMenu(options, options[index]);
                }
            }
            if (keyinfo.Key == ConsoleKey.UpArrow)
            {
                if (index - 1 >= 0)
                {
                    index--;
                    WriteMenu(options, options[index]);
                }
            }
            // Handle different action for the option
            if (keyinfo.Key == ConsoleKey.Enter)
            {
                options[index].Selected.Invoke();
                index = 0;
            }
        }
        while (keyinfo.Key != ConsoleKey.X);

        Console.ReadKey();

    }


    static void WriteMenu(List<Option> options, Option selectedOption)
    {
        Console.Clear();
        Console.ForegroundColor= ConsoleColor.White;

        foreach (Option option in options)
        {
            if (option == selectedOption)
            {
                Console.Write("> ");
            }
            else
            {
                Console.Write(" ");
            }

            Console.WriteLine(option.Name);
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

}
}

public class Option
{
    public string Name { get; }
    public Action Selected { get; }

    public Option(string name, Action selected)
    {
        Name = name;
        Selected = selected;
    }
}




