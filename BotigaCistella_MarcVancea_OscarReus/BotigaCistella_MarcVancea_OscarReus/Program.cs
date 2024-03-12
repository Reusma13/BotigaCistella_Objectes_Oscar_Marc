namespace BotigaCistella_MarcVancea_OscarReus
{
    public class Program
    {
        static void Main(string[] args)
        {
            Botiga botiga = new Botiga();
            Cistella cistella = new Cistella();
            string opcio = "1";
            while (opcio != "3")
            {
                Console.Clear();
                Console.WriteLine("1. Gestionar botiga");
                Console.WriteLine("2. Fer una compra");
                Console.WriteLine("3. Sortir");
                Console.Write("Selecciona una opció: ");
                opcio = Console.ReadLine();

                switch (opcio)
                {
                    case "1":
                        // Gestionar botiga
                        Console.WriteLine("Has seleccionat gestionar la botiga.");
                        string opcioBotiga = "1";
                        while (opcioBotiga != "0")
                        {
                            Console.Clear();
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
                                    if (botiga.AfegirProducte(producte))
                                        Console.WriteLine("Producte afegit amb èxit.");
                                    else
                                        Console.WriteLine("El producte no se a afegit correctament.");
                                    Console.ReadLine();
                                    break;
                                case "2":
                                    // Afegir producte Array

                                    Console.WriteLine("Quants productes vols afegir? ");
                                    int numeroProducte = Convert.ToInt32(Console.ReadLine());
                                    Producte[] producteArray = new Producte[numeroProducte];
                                    for (int i = 0; i < numeroProducte; i++)
                                    {
                                        Console.Write("Introdueix el nom del producte: ");
                                        string nomProducteArray = Console.ReadLine();
                                        Console.Write("Introdueix el preu del producte: ");
                                        double preuProducteArray = Convert.ToDouble(Console.ReadLine());
                                        Producte producte1 = new Producte(nomProducteArray, preuProducteArray);
                                        producteArray[i] = producte1;
                                    }
                                    if (botiga.AfegirProducte(producteArray))
                                        Console.WriteLine("Producte afegit amb èxit.");
                                    else
                                        Console.WriteLine("El producte no se a afegit correctament.");
                                    Console.ReadLine();
                                    break;
                                case "3":
                                    // Eliminar producte
                                    Console.Write("Introdueix el nom del producte a eliminar: ");
                                    string nomProducteEliminar = Console.ReadLine();
                                    Console.Write("Introdueix el preu del producte: ");
                                    double preuProducteEliminar = Convert.ToDouble(Console.ReadLine());
                                    Producte producteEliminar = new Producte(nomProducteEliminar, preuProducteEliminar);
                                    if (botiga.EsborrarProducte(producteEliminar))
                                        Console.WriteLine("Producte eliminat amb èxit.");
                                    else
                                        Console.WriteLine("El producte no s'ha pogut eliminar.");
                                    Console.ReadLine();
                                    break;
                                case "4":
                                    // Ampliar botiga
                                    Console.Write("Quant vols ampliar la botiga: ");
                                    int ampliarBotiga = Convert.ToInt32(Console.ReadLine());
                                    botiga.AmpliarBotiga(ampliarBotiga);
                                    Console.WriteLine("Botiga ampliada");
                                    Console.ReadLine();
                                    break;
                                case "5":
                                    // Modifcar preu
                                    Console.Write("Escriu el nom del producte per modificar el preu: ");
                                    string nomProducteModificar = Console.ReadLine();
                                    Console.Write("Quin preu li vols posar: ");
                                    double preuProducteModificar = Convert.ToDouble(Console.ReadLine());
                                    if (botiga.ModificarPreu(nomProducteModificar, preuProducteModificar))
                                        Console.WriteLine("Preu modificiat");
                                    else
                                        Console.WriteLine("El preu no s'ha modificat");
                                    Console.ReadLine();
                                    break;
                                case "6":
                                    // Buscar producte
                                    Console.Write("Escriu el nom del producte: ");
                                    string nomProducteBuscar = Console.ReadLine();
                                    Console.Write("Escriu un preu: ");
                                    double preuProducteBuscar = Convert.ToDouble(Console.ReadLine());
                                    Producte buscar = new Producte(nomProducteBuscar, preuProducteBuscar);
                                    if (botiga.BuscarProducte(buscar))
                                    {
                                        Console.WriteLine("Producte trobat");
                                    }
                                    else
                                        Console.WriteLine("producte no trobat");
                                    Console.ReadLine();
                                    break;
                                case "7":
                                    // Modifcar producte
                                    Console.Write("Nom del producte que vols modificar: ");
                                    string nomProducteModifcar = Console.ReadLine();
                                    Console.Write("Preu del producte que vols modificar: ");
                                    double preuProducteModificar2 = Convert.ToDouble(Console.ReadLine());
                                    Producte producteModificar = new Producte(nomProducteModifcar, preuProducteModificar2);
                                    Console.Write("Nom que vols posar-li al nou producte: ");
                                    string nomProducteNou = Console.ReadLine();
                                    Console.Write("Preu que vols posar-li al nou producte: ");
                                    double preuProducteNou = Convert.ToDouble(Console.ReadLine());
                                    Console.Write("Stock: ");
                                    int stock = Convert.ToInt32(Console.ReadLine());
                                    if (botiga.ModificarProducte(producteModificar, nomProducteNou, preuProducteNou, stock))
                                    {
                                        Console.WriteLine("Producte modificat amb exit.");
                                    }
                                    else
                                        Console.WriteLine("El producte no s'ha pogut modificar");
                                    Console.ReadLine();
                                    break;
                                case "8":
                                    // Ordenar producte
                                    botiga.OrdenarProducte();
                                    Console.WriteLine("Botiga ordenada per Producte.");
                                    Console.ReadLine();
                                    break;
                                case "9":
                                    // Ordenar preus
                                    botiga.OrdenarPreus();
                                    Console.WriteLine("Botiga ordenada per preu.");
                                    Console.ReadLine();
                                    break;
                                case "10":
                                    // Veure productes
                                    Console.WriteLine("Productos disponibles:");
                                    botiga.Mostrar();
                                    Console.ReadLine();
                                    break;

                                default:
                                    Console.WriteLine("Opció no reconeguda. Si us plau, torna a intentar-ho.");
                                    break;
                            }
                        }
                        break;
                    case "2":
                                Console.WriteLine("Has seleccionat fer una compra.");
                                botiga.Mostrar();
                                Console.Write("Selecciona un producto: ");
                                string nomProducte2 = Console.ReadLine();
                                Console.Write("Introdueix la quantitat que vols comprar: ");
                                int quant = Convert.ToInt32(Console.ReadLine());
                                int trobat = botiga.Indexador(nomProducte2);
                                if (trobat != -1)
                                {
                                    bool comprat = cistella.ComprarProducte(botiga.Producte[trobat], quant);
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
        }
    }
}