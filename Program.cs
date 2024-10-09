using Labb2;

bool running = true;
List<Appliance> appliances = new List<Appliance>();


while (running)
{
    MenuManager.BuildMenu();
    int selection = MenuManager.Selection(6);
    
    switch (selection)
    {
        // Activate
        case 1:
            break;

        // Register new
        case 2:
            ItemManager.AddAppliance(ref appliances);
            MenuManager.AwaitConfirm();
            break;

        // List registered
        case 3:
            break;

        // Remove
        case 4:
            break;

        // Exit app
        case 5:
            Console.Write("Är du säker på att du vill avsluta?\n" +
                "(Y/N): ");
            if (MenuManager.InterpretTrueFalse(Console.ReadLine())) running = false;
            else MenuManager.AwaitConfirm();
            break;

        // Temporary save function
        case 6:
            try
            {
                if (appliances.Count > 0)
                {
                    ItemManager.SaveList(ref appliances);
                    Console.WriteLine("Listan sparad!");
                }
                else Console.WriteLine("Listan är tom! Vänligen registrera fler köksutrustning.");
            }
            catch (Exception error)
            {
                MenuManager.LogErrorHandling(error);
                Console.WriteLine("Skrivning av fil misslyckad!\n" +
                    "Fel loggfört.");
            }
            MenuManager.AwaitConfirm();
            break;

        default:
            break;
    }
}