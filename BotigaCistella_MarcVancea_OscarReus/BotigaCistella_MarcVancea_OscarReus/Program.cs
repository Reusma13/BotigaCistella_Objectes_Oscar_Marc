namespace BotigaCistella_MarcVancea_OscarReus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Botiga botiga = new Botiga();
            Cistella cistella = new Cistella();

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

                    while (opcio != "4")
                    {
                        Console.WriteLine("1. Afegir producte");
                        Console.WriteLine("2. Eliminar producte");
                        Console.WriteLine("3. Veure productes");
                        Console.WriteLine("4. Tornar al menú principal");
                        Console.Write("Selecciona una opció: ");
                        string opcioBotiga = Console.ReadLine();

                        switch (opcioBotiga)
                        {
                            case "1":
                                // Afegir producte
                                Console.Write("Introdueix el nom del producte: ");
                                string nomProducte = Console.ReadLine();
                                Console.Write("Introdueix el preu del producte: ");
                                double preuProducte = Convert.ToDouble(Console.ReadLine());
                                Producte producte = new Producte(nomProducte, preuProducte);
                                botiga.AfegirProducte(producte);
                                Console.WriteLine("Producte afegit amb èxit.");
                                break;
                            case "2":
                                // Eliminar producte
                                Console.Write("Introdueix el nom del producte a eliminar: ");
                                string nomProducteEliminar = Console.ReadLine();
                                botiga.EliminarProducte(nomProducteEliminar);
                                Console.WriteLine("Producte eliminat amb èxit.");
                                break;
                            case "3":
                                // Veure productes
                                Console.WriteLine("Productos disponibles:");
                                for (int i = 0; i < botiga.ObtenirProductes().Length; i++)
                                {
                                    Producte p = botiga.ObtenirProductes()[i];
                                    Console.WriteLine(p.ObtenirNom() + ": " + p.ObtenirPreu());
                                }
                                break;
                            case "4":
                                // Tornar al menú principal
                                break;
                            default:
                                Console.WriteLine("Opció no reconeguda. Si us plau, torna a intentar-ho.");
                                break;
                        }
                    }
                    break;
                case "2":
                    Console.WriteLine("Has seleccionat fer una compra.");
                    for (int i = 0; i < botiga.ObtenirProductes().Length; i++)
                    {
                        Producte p = botiga.ObtenirProductes()[i];
                        Console.WriteLine((i + 1) + ". " + p.ObtenirNom() + ": " + p.ObtenirPreu());
                    }
                    Console.Write("Selecciona un producto: ");
                    string nomProducte2 = Console.ReadLine();
                    Console.Write("Introdueix la quantitat que vols comprar: ");
                    int quant = Convert.ToInt32(Console.ReadLine());
                    int trobat = botiga.Indexador(nomProducte2);
                    if (trobat != -1)
                    {
                        bool comprat = cistella.ComprarProducte(botiga.Productes[trobat], quant);
                        if (comprat == true)
                        {
                            Console.WriteLine("Compra realitzada amb èxit.");
                        }
                        else
                        {
                            Console.WriteLine("No s'ha pogut realitzar la compra.");
                        }
                    }
                    break;
                case "3":
                    Console.WriteLine("Has seleccionat sortir. Adeu!");
                    break;
                default:
                    Console.WriteLine("Opció no reconeguda. Si us plau, torna a intentar-ho.");
                    break;
            }
        }
    }
}