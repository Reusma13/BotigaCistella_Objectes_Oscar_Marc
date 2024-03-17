namespace BotigaCistella_MarcVancea_OscarReus
{
    public class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Posa nom a la botiga: ");
            string nomBotiga = Console.ReadLine();
            Botiga botiga = new Botiga(nomBotiga);
            if (CargarDatos(botiga))
            {
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
                                        // Llamamos al metodo AfegirProducte que le pasamos como parametro un producto y como devuelve un bool si es true hace
                                        // el if y nos escribe que el producto a sido añadido, si devuelve false hace el else.
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
                                        // Llamamos al metodo AfegirProducte pero en vez de pasarle solo un producto le pasamos una array
                                        // ya que he hecho sobrecarga de metodo.
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
                                        // Uso metodo para buscar el producto y si lo encuentra muestra el producto.ToString() que esta sobreescrito para que
                                        // enseñe lo que necesito
                                        if (botiga.BuscarProducte(buscar))
                                        {
                                            Console.WriteLine(buscar.ToString());
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
                                        EscriureCSV(botiga);
                                        Console.ReadLine();
                                        break;
                                    default:
                                        Console.WriteLine("Opció no reconeguda. Si us plau, torna a intentar-ho.");
                                        break;
                                }
                            }
                            break;
                        case "2":
                            Cistella cistella = new Cistella(botiga);
                            string opcioCistella = "0";
                            while (opcioCistella != "6")
                            {
                                Console.Clear();
                                Console.WriteLine("1. Fer una compra");
                                Console.WriteLine("2. Comprar múltiples productes");
                                Console.WriteLine("3. Veure cistella");
                                Console.WriteLine("4. Ordenar cistella");
                                Console.WriteLine("5. Veure cost total");
                                Console.WriteLine("6. Sortir");
                                Console.Write("Selecciona una opció: ");
                                opcioCistella = Console.ReadLine();
                                switch (opcioCistella)
                                {

                                    case "1":
                                        Console.WriteLine("Has seleccionat fer una compra.");
                                        botiga.Mostrar();
                                        Console.Write("Selecciona un producto: ");
                                        string nomProducte2 = Console.ReadLine();
                                        Console.Write("Introdueix la quantitat que vols comprar: ");
                                        int quant = Convert.ToInt32(Console.ReadLine());
                                        int trobat = botiga.Indexador(nomProducte2); // Llama a indexador para encontrar el index del producto
                                        if (trobat != -1)
                                        {
                                            // Llamamos al metodo y le pasamos el index que nos a devuelto el indexador y cuanta cantidad queremos.
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
                                    case "2":
                                        Console.WriteLine("Quants productes vols comprar?");
                                        int numProductes = Convert.ToInt32(Console.ReadLine());

                                        Producte[] productes = new Producte[numProductes];
                                        int[] quantitats = new int[numProductes];

                                        for (int i = 0; i < numProductes; i++)
                                        {
                                            Console.WriteLine("Introdueix el nom del producte " + (i + 1) + ":");
                                            string nomProducte3 = Console.ReadLine();
                                            int indexProducte = botiga.Indexador(nomProducte3);

                                            if (indexProducte == -1)
                                            {
                                                Console.WriteLine("El producte no existeix a la botiga.");
                                                i--;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Introdueix la quantitat que vols comprar del producte " + nomProducte3 + ":");
                                                int quantitat = Convert.ToInt32(Console.ReadLine());

                                                productes[i] = botiga.Producte[indexProducte];
                                                quantitats[i] = quantitat;
                                            }
                                        }

                                        bool resultat = cistella.ComprarProducte(productes, quantitats);

                                        if (resultat)
                                        {
                                            Console.WriteLine("Compra realitzada amb èxit!");
                                        }
                                        else
                                        {
                                            Console.WriteLine("La compra no s'ha pogut realitzar.");
                                        }
                                        Console.ReadLine();
                                        break;
                                    case "3":
                                        Console.WriteLine("Has seleccionat veure la cistella.");
                                        cistella.Mostra();
                                        Console.ReadLine();
                                        break;
                                    case "4":
                                        Console.WriteLine("Has seleccionat ordenar la cistella.");
                                        cistella.OrdernarCistella();
                                        cistella.Mostra();
                                        Console.ReadLine();
                                        break;
                                    case "5":
                                        Console.WriteLine("Has seleccionat veure el cost total.");
                                        Console.WriteLine("Cost total: " + cistella.CostTotal());
                                        Console.ReadLine();
                                        break;
                                    case "6":
                                        Console.WriteLine("Has seleccionat sortir. Adeu!");
                                        Console.ReadLine();
                                        break;
                                    default:
                                        Console.WriteLine("Opció no reconeguda. Si us plau, torna a intentar-ho.");
                                        break;
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
            else
            {
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
                                        // Llamamos al metodo AfegirProducte que le pasamos como parametro un producto y como devuelve un bool si es true hace
                                        // el if y nos escribe que el producto a sido añadido, si devuelve false hace el else.
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
                                        // Llamamos al metodo AfegirProducte pero en vez de pasarle solo un producto le pasamos una array
                                        // ya que he hecho sobrecarga de metodo.
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
                                        // Uso metodo para buscar el producto y si lo encuentra muestra el producto.ToString() que esta sobreescrito para que
                                        // enseñe lo que necesito
                                        if (botiga.BuscarProducte(buscar))
                                        {
                                            Console.WriteLine(buscar.ToString());
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
                                        EscriureCSV(botiga);
                                        Console.ReadLine();
                                        break;
                                    default:
                                        Console.WriteLine("Opció no reconeguda. Si us plau, torna a intentar-ho.");
                                        break;
                                }
                            }
                            break;
                        case "2":
                            Cistella cistella = new Cistella(botiga);
                            string opcioCistella = "0";
                            while (opcioCistella != "5")
                            {
                                Console.Clear();
                                Console.WriteLine("1. Fer una compra");
                                Console.WriteLine("2. Comprar múltiples productes");
                                Console.WriteLine("3. Veure cistella");
                                Console.WriteLine("4. Ordenar cistella");
                                Console.WriteLine("5. Veure cost total");
                                Console.WriteLine("6. Sortir");
                                Console.Write("Selecciona una opció: ");
                                opcioCistella = Console.ReadLine();
                                switch (opcioCistella)
                                {
                                    case "1":
                                        Console.WriteLine("Has seleccionat fer una compra.");
                                        botiga.Mostrar();
                                        Console.Write("Selecciona un producto: ");
                                        string nomProducte2 = Console.ReadLine();
                                        Console.Write("Introdueix la quantitat que vols comprar: ");
                                        int quant = Convert.ToInt32(Console.ReadLine());
                                        int trobat = botiga.Indexador(nomProducte2); // Llama a indexador para encontrar el index del producto
                                        if (trobat != -1)
                                        {
                                            // Llamamos al metodo y le pasamos el index que nos a devuelto el indexador y cuanta cantidad queremos.
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
                                    case "2":
                                        Console.WriteLine("Quants productes vols comprar?");
                                        int numProductes = Convert.ToInt32(Console.ReadLine());

                                        Producte[] productes = new Producte[numProductes];
                                        int[] quantitats = new int[numProductes];

                                        for (int i = 0; i < numProductes; i++)
                                        {
                                            Console.WriteLine("Introdueix el nom del producte " + (i + 1) + ":");
                                            string nomProducte3 = Console.ReadLine();
                                            int indexProducte = botiga.Indexador(nomProducte3);

                                            if (indexProducte == -1)
                                            {
                                                Console.WriteLine("El producte no existeix a la botiga.");
                                                i--;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Introdueix la quantitat que vols comprar del producte " + nomProducte3 + ":");
                                                int quantitat = Convert.ToInt32(Console.ReadLine());

                                                productes[i] = botiga.Producte[indexProducte];
                                                quantitats[i] = quantitat;
                                            }
                                        }

                                        bool resultat = cistella.ComprarProducte(productes, quantitats);

                                        if (resultat)
                                        {
                                            Console.WriteLine("Compra realitzada amb èxit!");
                                        }
                                        else
                                        {
                                            Console.WriteLine("La compra no s'ha pogut realitzar.");
                                        }
                                        Console.ReadLine();
                                        break;
                                    case "3":
                                        Console.WriteLine("Has seleccionat veure la cistella.");
                                        cistella.Mostra();
                                        Console.ReadLine();
                                        break;
                                    case "4":
                                        Console.WriteLine("Has seleccionat ordenar la cistella.");
                                        cistella.OrdernarCistella();
                                        cistella.Mostra();
                                        Console.ReadLine();
                                        break;
                                    case "5":
                                        Console.WriteLine("Has seleccionat veure el cost total.");
                                        Console.WriteLine("Cost total: " + cistella.CostTotal());
                                        Console.ReadLine();
                                        break;
                                    case "6":
                                        Console.WriteLine("Has seleccionat sortir. Adeu!");
                                        Console.ReadLine();
                                        break;
                                    default:
                                        Console.WriteLine("Opció no reconeguda. Si us plau, torna a intentar-ho.");
                                        break;
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

        /// <summary>
        /// Le pasamos nuestra botiga para que podamos coger el nElem y tambien la array de productos y ponemos el nombre de la botiga, el nombre del producto,
        /// el precio sin y con iva y la cantidad del producto. Miramos si esta el nombre de la botiga que nos a puesto en Botiga.NomBotiga si esta en el CSV
        /// si esta copia todos los productos en una array y asi lo podemos volver a poner despues junto a los productos que a añadido el Admin de la botiga.
        /// </summary>
        /// <param name="botiga">Pasamos la botiga como parametro</param>
        static void EscriureCSV(Botiga botiga)
        {
            int cont = 0;
            if (botiga.Producte is not null)
            {
                string[] lineas = File.ReadAllLines("persistencia.csv");

                // Buscar la línea con el nombre de la tienda
                int indice = Array.FindIndex(lineas, linea => linea.Split(';')[0] == botiga.NomBotiga); // Sirve para encontrar el indice para comenzar a compiar los productos.

                // Si se encontró la tienda, agregar los productos debajo de ella
                if (indice != -1)
                {
                    string[] nuevasLineas = new string[lineas.Length + botiga.NElem]; // Creamos la array para coger los productos antiguos + los productos nuevos
                    Array.Copy(lineas, nuevasLineas, indice + 1); // Compiamos los productos antiguos a la nueva array

                    for (int i = 0; i < botiga.NElem; i++)
                    {
                        if (!ExisteProducteEnCSV(botiga.Producte[i].Nom)) // Comprueba si el nombre del producto esta en el CSDV y si no esta lo añade, si lo estav manda un mensaje conforme no acepta duplicados.
                        {
                            nuevasLineas[indice + 1 + i] = $"{botiga.Producte[i].Nom}; {botiga.Producte[i].Preu_Sense_Iva}; {botiga.Producte[i].Preu_Sense_Iva + botiga.Producte[i].Preu()}; {botiga.Producte[i].Quantitat}";
                            cont++;
                        }
                        else
                            Console.WriteLine("Producto existente. No acepto duplicados.");
                    }

                    Array.Copy(lineas, indice + 1, nuevasLineas, indice + 1 + botiga.NElem, lineas.Length - indice - 1);

                    File.WriteAllLines("persistencia.csv", nuevasLineas);
                }
                else
                {
                    Console.WriteLine("No se encontró la tienda en el archivo CSV.");
                }
            }
            else
            {
                Console.WriteLine("No hi ha productes per posar CSV.");
            }
        }
        /// <summary>
        /// Sirve para cargar todos los productos de la tienda del csv si los nombres son iguales.
        /// </summary>
        /// <param name="botiga">Le pasamos la botiga para coger su nombre</param>
        /// <returns>Devuelve true cuando a podido añadir todos lso productos, devuelve false cuando el no esta el nombre de la botiga</returns>
        static bool CargarDatos(Botiga botiga)
        {
            bool afegit = false;
            string linea;
            if (File.Exists("persistencia.csv"))
            {
                using (StreamReader sR = new StreamReader("persistencia.csv"))
                {
                    string lineaNombre = "";
                    while (!afegit && (lineaNombre = sR.ReadLine()) != null)
                    {
                        string nombreTiendaCSV = lineaNombre.Split(';')[0];
                        if (nombreTiendaCSV == botiga.NomBotiga) // Comprueba si el nombre de la tienda coincide
                        {
                            while ((linea = sR.ReadLine()) != null) // mira todas las lineas hasta que no haya nada
                            {
                                string[] partes = linea.Split(';'); // Separa por partes la linea por ;

                                string nomProducte = partes[0]; // cogemos el nombre
                                double preuProducteSenseIVa = Convert.ToDouble(partes[1]); // cogemos el precio sin iva
                                double preuProducteAmbIva = Convert.ToDouble(partes[2]); // cogemos el precio con iva
                                int stockDisponible = Convert.ToInt32(partes[3]); // cogemos el stock disponible

                                Producte producte = new Producte(nomProducte, preuProducteSenseIVa, stockDisponible); // Creamos el producto
                                botiga.AfegirProducte(producte); // Lo añadimos a la botiga
                            }
                            afegit = true;
                        }
                    }
                    if (!afegit)
                    {
                        Console.WriteLine("El nom de la botiga no coincideix.");
                    }
                }
            }
            else
            {
                Console.WriteLine("El archivo CSV no existe.");
            }
            return afegit;
        }
        /// <summary>
        /// Miramos si el arichvo existe y mira todas las lineas, comprueba la parte del nombre del producto con el nombre del producto que le hemos pasado
        /// </summary>
        /// <param name="nomProducte">Es el nombre del producto del metodo EscriureCSV</param>
        /// <returns>Devuelve true si los nombres son iguales y deuvelve false si no esta</returns>
        static bool ExisteProducteEnCSV(string nomProducte)
        {
            if (File.Exists("persistencia.csv"))
            {
                using (StreamReader sR = new StreamReader("persistencia.csv"))
                {
                    string linea;
                    while ((linea = sR.ReadLine()) != null) // Mira el arichvo hasta el final
                    {
                        string[] partes = linea.Split(';'); // Separa la linea por ; y lo guarda en una array
                        if (partes[0] == nomProducte) // Si el nombre del csv y el nombre que nos a pasado como parametro son iguales entocnes deuvelve true
                        {
                            return true;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("El archivo CSV no existe.");
            }
            return false;
        }
    }
}