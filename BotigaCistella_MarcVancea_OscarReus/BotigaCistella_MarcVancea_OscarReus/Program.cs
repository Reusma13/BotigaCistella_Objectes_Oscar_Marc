namespace BotigaCistella_MarcVancea_OscarReus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Botiga botiga = new Botiga();
            Cistella cistella = new Cistella();

            while (true)
            {
                Console.WriteLine("1. Gestionar botiga");
                Console.WriteLine("2. Fer una compra");
                Console.WriteLine("3. Sortir");
                Console.Write("Selecciona una opció: ");
                string opcio = Console.ReadLine();

                switch (opcio)
                {
                    case "1":
                        // Gestionar botiga
                        Console.WriteLine("Has seleccionat gestionar la botiga.");
                        // afegir el codi per gestionar la botiga
                        break;
                    case "2":
                        // Fer una compra
                        Console.WriteLine("Has seleccionat fer una compra.");
                        // afegir el codi per fer una compra
                        break;
                    case "3":
                        // Sortir
                        Console.WriteLine("Has seleccionat sortir. Adeu!");
                        return;
                    default:
                        Console.WriteLine("Opció no reconeguda. Si us plau, torna a intentar-ho.");
                        break;
                }
            }
        }
    }
}