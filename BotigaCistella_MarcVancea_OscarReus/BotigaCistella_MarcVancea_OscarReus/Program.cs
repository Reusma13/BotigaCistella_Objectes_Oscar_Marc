namespace BotigaCistella_MarcVancea_OscarReus
{
    public class Program
    {
        static void Main(string[] args)
        {
<<<<<<< Updated upstream
            Console.WriteLine("Hello, World!");
=======
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
                    string opcioBotiga = 1;
                    while (opcioBotiga != "0")
                    {
                        Console.WriteLine("1. Afegir producte");
                        Console.WriteLine("2. Afegir producte[]");
                        Console.WriteLine("3. Eliminar producte");
                        Console.WriteLine("4. Ampliar botiga");
                        Console.WriteLine("5. Modificar preu");
                        Console.WriteLine("6. Buscar producte");
                        Console.WriteLine("7. Modificar producte");
                        Console.WriteLine("8. Ordenar producte");
                        Console.WriteLine("9. Ordenar preus");
                        Console.WriteLine("10. Veure productes");
                        Console.WriteLine("0. Tornar al menú principal");
                        Console.Write("Selecciona una opció: ");
                        opcioBotiga = Console.ReadLine();

                        switch (opcioBotiga)
                        {
                            case "0":
                                // Tornar al menú principal
                                break;
                            case "1":
                                // Afegir producte
                                Console.Write("Introdueix el nom del producte: ");
                                string nomProducte = Console.ReadLine();
                                Console.Write("Introdueix el preu del producte: ");
                                double preuProducte = Convert.ToDouble(Console.ReadLine());
                                Producte producte = new Producte(nomProducte, preuProducte);
                                botiga.AfegirProducte(producte);
                                if (botiga.AfegirProducte(producte))
                                    Console.WriteLine("Producte afegit amb èxit.");
                                else
                                    Console.WriteLine("El producte no se a afegit correctament.");
                                break;
                            case "2":
                                // Afegir producte Array
                                Producte[] producteArray;
                                for (int i = 0; i < botiga.Producte.Length; i++)
                                {
                                    Console.Write("Introdueix el nom del producte: ");
                                    string nomProducte = Console.ReadLine();
                                    Console.Write("Introdueix el preu del producte: ");
                                    double preuProducte = Convert.ToDouble(Console.ReadLine());
                                    producteArray = new Producte(nomProducte, preuProducte);
                                }
                                if (botiga.AfegirProducte(producteArray))
                                    Console.WriteLine("Producte afegit amb èxit.");
                                else
                                    Console.WriteLine("El producte no se a afegit correctament.");
                            case "3":
                                // Eliminar producte
                                Console.Write("Introdueix el nom del producte a eliminar: ");
                                string nomProducteEliminar = Console.ReadLine();
                                Console.Write("Introdueix el preu del producte: ");
                                double preuProducteEliminar = Convert.ToDouble(Console.ReadLine());
                                Producte producteEliminar = new Producte(nomProducteEliminar, preuProducteEliminar);
                                botiga.EsborrarProducte(producteEliminar);
                                Console.WriteLine("Producte eliminat amb èxit.");
                                break;
                            case "4":
                                // Ampliar botiga
                                Console.WriteLine("Quant vols ampliar la botiga: ");
                                int ampliarBotiga = Convert.ToInt32(Console.ReadLine());
                                botiga.AmpliarBotiga(ampliarBotiga);
                                break;
                            case "5":
                                // Modifcar preu
                                Console.WriteLine("Escriu el nom del producte per modificar el preu: ");
                                string nomProducteModificar = Console.ReadLine();
                                Console.WriteLine("Quin preu li vols posar: ");
                                double preuProducteModificar = Convert.ToDouble(Console.ReadLine());
                                Console.WriteLine(botiga.ModificarPreu(nomProducteModificar, preuProducteModificar));
                                break;
                            case "6":
                                // Buscar producte
                                Console.WriteLine("Escriu el nom del producte: ");
                                string nomProducteBuscar = Console.ReadLine();
                                Console.WriteLine("Escriu un preu: ");
                                double preuProducteBuscar = Convert.ToDouble(Console.ReadLine());
                                Producte buscar = new Producte(nomProducteBuscar, preuProducteBuscar);
                                Console.WriteLine(botiga.BuscarProducte(buscar));
                                break;
                            case "7":
                                // Modifcar producte
                                Console.WriteLine("Nom del producte que vols modificar: ");
                                string nomProducteModifcar = Console.ReadLine();
                                Console.Write("Preu del producte que vols modificar: ");
                                double preuProducteModificar = Convert.ToDouble(Console.ReadLine());
                                Producte producteModificar = new Producte(nomProducteModifcar, preuProducteModificar);
                                Console.WriteLine("Nom que vols posar-li al nou producte: ");
                                string nomProducteNou = Console.ReadLine();
                                Console.WriteLine("Preu que vols posar-li al nou producte: ");
                                double preuProducteNou = Convert.ToDouble(Console.ReadLine());
                                Console.WriteLine("Stock: ");
                                int stock = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine(botiga.ModificarProducte(producteModificar, nomProducteNou, preuProducteNou, stock));
                                break;
                            case "8":
                                // Ordenar producte
                                botiga.OrdenarProducte();
                                break;
                            case "9":
                                // Ordenar preus
                                botiga.OrdenarPreus();
                                break;
                            case "10":
                                // Veure productes
                                Console.WriteLine("Productos disponibles:");
                                botiga.Mostrar();
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
>>>>>>> Stashed changes
        }
    }
}