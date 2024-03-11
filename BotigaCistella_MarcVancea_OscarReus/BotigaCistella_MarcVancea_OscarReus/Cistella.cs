using System;
namespace BotigaCistella_MarcVancea_OscarReus
{
	public class Cistella
	{
        // Atributs
        private Botiga botiga; // La botiga on es realitza la compra
        private DateTime data; // La data de la compra
        private Producte[] productes; // Els productes que es compren
        private int[] quantitat; // La quantitat de cada producte que es compra
        private int nElements; // El nombre total d'elements a la cistella
<<<<<<< HEAD
        private double diners; // Els diners disponibles per a la compra
=======
        private decimal diners; // Els diners disponibles per a la compra
>>>>>>> 92bba535f517963aba29eeee68b50b08d875007b

        // Propietats

        /// <summary>
        /// Mètode per afegir un producte a la cistella
        /// </summary>
        /// <param name="producte">array d'elements (llistat dels productes que es compren)</param>
        /// <param name="quantitat">int (indica la quantitat de productes que tindrem)</param>
<<<<<<< HEAD
        /// <returns>retorna un boolea depenguent de si hi ha espai a la cistella o no</returns>
        public bool AfegirProducte(Producte producte, int quantitat)
        {
            // Comprova si hi ha espai a la cistella i si hi ha suficients diners
            if (nElements < productes.Length && producte.Preu() * quantitat <= diners)
=======
        /// <returns>retorna un boolea depenguent de si hi ha espai a la cistella o o</returns>
        public bool AfegirProducte(Producte producte, int quantitat)
        {
            // Comprova si hi ha espai a la cistella i si hi ha suficients diners
            if (nElements < productes.Length && producte.Preu * quantitat <= diners)
>>>>>>> 92bba535f517963aba29eeee68b50b08d875007b
            {
                // Afegeix el producte a la cistella
                this.productes[nElements] = producte;
                this.quantitat[nElements] = quantitat;
                this.nElements++;
<<<<<<< HEAD
                this.diners -= producte.Preu() * quantitat;
=======
                this.diners -= producte.Preu * quantitat;
>>>>>>> 92bba535f517963aba29eeee68b50b08d875007b
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Mètode per obtenir el nombre total d'elements a la cistella
        /// </summary>
        /// <returns>retorna el numero del elements</returns>
        public int ObtenirNElements()
        {
            return this.nElements;
        }

        /// <summary>
        /// Mètode per obtenir els diners restants
        /// </summary>
        /// <returns>retorna els diners que tens</returns>
<<<<<<< HEAD
        public double ObtenirDiners()
=======
        public decimal ObtenirDiners()
>>>>>>> 92bba535f517963aba29eeee68b50b08d875007b
        {
            return this.diners;
        }

        /// <summary>
        /// Mètode per obtenir la data de la compra
        /// </summary>
        /// <returns>retorna la data</returns>
        public DateTime ObtenirData()
        {
            return this.data;
        }

        // Constructor buit
        public Cistella()
        {
            this.botiga = null;
            this.data = DateTime.Now;
            this.productes = new Producte[10];
            this.quantitat = new int[10];
            this.nElements = 0;
<<<<<<< HEAD
            this.diners = 0;
        }

        // Constructor amb botiga, productes, quantitats i diners
        public Cistella(Botiga botiga, Producte[] productes, int[] quantitat, double diners)
=======
            this.diners = 0m;
        }

        // Constructor amb botiga, productes, quantitats i diners
        public Cistella(Botiga botiga, Producte[] productes, int[] quantitat, decimal diners)
>>>>>>> 92bba535f517963aba29eeee68b50b08d875007b
        {
            // Comprova si les taules de productes i quantitats tenen la mateixa mida
            if (productes.Length == quantitat.Length)
            {
                // Calcula el total de la compra
<<<<<<< HEAD
                double total = 0;
                for (int i = 0; i < productes.Length; i++)
                {
                    total += productes[i].Preu() * quantitat[i];
=======
                decimal total = 0m;
                for (int i = 0; i < productes.Length; i++)
                {
                    total += productes[i].ObtenirPreu() * quantitat[i];
>>>>>>> 92bba535f517963aba29eeee68b50b08d875007b
                }

                // Comprova si hi ha suficients diners per a la compra
                if (total <= diners)
                {
                    this.botiga = botiga;
                    this.data = DateTime.Now;
                    this.productes = productes;
                    this.quantitat = quantitat;
                    this.nElements = productes.Length;
                    this.diners = diners - total;
                }
            }
        }

        // Mètodes


        /// <summary>
        /// Mètode per comprar un producte mirant si hi ha espai a la cistella i si tenim suficients diners per fer la compra
        /// </summary>
        /// <param name="producte">array d'elements (llistat dels productes que es compren)</param>
        /// <param name="quantitat">int (indica la quantitat de productes que tindrem)</param>
        /// <returns>retorna un boolea si ha sigut posible fer la compra del producte</returns>
        public bool ComprarProducte(Producte producte, int quantitat)
        {
            // Comprova si el producte existeix a la botiga
<<<<<<< HEAD
            if (!botiga.BuscarProducte(producte))
=======
            if (!botiga.ExisteixProducte(producte))
>>>>>>> 92bba535f517963aba29eeee68b50b08d875007b
            {
                Console.WriteLine("El producte no existeix a la botiga.");
                return false;
            }

            // Comprova si hi ha espai a la cistella
            if (nElements >= productes.Length)
            {
                Console.WriteLine("No hi ha espai a la cistella. Voleu ampliar la cistella?");
                return false;
            }

            // Comprova si hi ha suficients diners per comprar el producte
            if (producte.Preu * quantitat > diners)
            {
                Console.WriteLine("No teniu suficients diners per comprar aquest producte. Voleu ingressar més diners?");
                return false;
            }

            // Afegeix el producte a la cistella
            this.productes[nElements] = producte;
            this.quantitat[nElements] = quantitat;
            this.nElements++;
<<<<<<< HEAD
            this.diners -= producte.Preu() * quantitat;
=======
            this.diners -= producte.Preu * quantitat;
>>>>>>> 92bba535f517963aba29eeee68b50b08d875007b

            // Modifica la data
            this.data = DateTime.Now;

            return true;
        }

        /// <summary>
        /// Mètode per afegir un conjunt de productes amb els seus respectives quantitats.
        /// </summary>
        /// <param name="productes">array d'elements (llistat dels productes que es compren)</param>
        /// <param name="quantitats">int (indica la quantitat de productes que tindrem)</param>
        /// <returns>retorna un boolea per comprovar si s'ha pogut fer la compra</returns>
        public bool ComprarProducte(Producte[] productes, int[] quantitats)
        {
            // Comprova si les taules de productes i quantitats tenen la mateixa mida
            if (productes.Length != quantitats.Length)
            {
                Console.WriteLine("Les taules de productes i quantitats han de tenir la mateixa mida.");
                return false;
            }

            // Per cada producte a la llista de productes
            for (int i = 0; i < productes.Length; i++)
            {
                // Comprova si el producte existeix a la botiga
<<<<<<< HEAD
                if (!botiga.BuscarProducte(productes[i])) 
                {
                    Console.WriteLine("El producte " + productes[i].Nom + " no existeix a la botiga.");
=======
                if (!botiga.ExisteixProducte(productes[i]))
                {
                    Console.WriteLine("El producte " + productes[i].ObtenirNom() + " no existeix a la botiga.");
>>>>>>> 92bba535f517963aba29eeee68b50b08d875007b
                    return false;
                }

                // Comprova si hi ha espai a la cistella
                if (nElements >= this.productes.Length)
                {
                    Console.WriteLine("No hi ha espai a la cistella. Voleu ampliar la cistella?");
                    return false;
                }

                // Comprova si hi ha suficients diners per comprar el producte
<<<<<<< HEAD
                if (productes[i].Preu() * quantitats[i] > diners)
                {
                    Console.WriteLine("No teniu suficients diners per comprar el producte " + productes[i].Nom + ". Voleu ingressar més diners?");
=======
                if (productes[i].Preu * quantitats[i] > diners)
                {
                    Console.WriteLine("No teniu suficients diners per comprar el producte " + productes[i].ObtenirNom() + ". Voleu ingressar més diners?");
>>>>>>> 92bba535f517963aba29eeee68b50b08d875007b
                    return false;
                }

                // Afegeix el producte a la cistella
                this.productes[nElements] = productes[i];
                this.quantitat[nElements] = quantitats[i];
                this.nElements++;
                this.diners -= productes[i].Preu * quantitats[i];

                // Modificar la data
                this.data = DateTime.Now;
            }

            return true;
        }

        /// <summary>
        /// Mètode que ordena la nostra cistella per ordre alfabètic amb elmètode de bombolla
        /// </summary>
        public void OrdernarCistella()
        {
            // Implementació del mètode de la bombolla
            for (int i = 0; i < nElements - 1; i++)
            {
                for (int j = 0; j < nElements - i - 1; j++)
                {
                    // Comprova si el producte actual és major que el següent
<<<<<<< HEAD
                    if (productes[j].Nom().CompareTo(productes[j + 1].Nom()) > 0)
=======
                    if (productes[j].ObtenirNom().CompareTo(productes[j + 1].ObtenirNom()) > 0)
>>>>>>> 92bba535f517963aba29eeee68b50b08d875007b
                    {
                        // Intercanvia els productes
                        Producte tempProducte = productes[j];
                        productes[j] = productes[j + 1];
                        productes[j + 1] = tempProducte;

                        // Intercanvia les quantitats
                        int tempQuantitat = quantitat[j];
                        quantitat[j] = quantitat[j + 1];
                        quantitat[j + 1] = tempQuantitat;
                    }
                }
            }
        }

        /// <summary>
        /// Mètode que fa visible la nostra cistella i la fa bonica per l'usuari
        /// </summary>
        public void Mostra()
        {
            Console.WriteLine("TIQUET DE COMPRA");
<<<<<<< HEAD
            Console.WriteLine("Botiga: " + botiga.NomBotiga);
            Console.WriteLine("Data: " + data.ToString());

            double total = 0;
            for (int i = 0; i < nElements; i++)
            {
                double preuTotal = productes[i].Preu() * quantitat[i];
                total += preuTotal;
                Console.WriteLine("Producte: " + productes[i].Nom);
                Console.WriteLine("Quantitat: " + quantitat[i]);
                Console.WriteLine("Preu Unitari: " + productes[i].Preu());
=======
            Console.WriteLine("Botiga: " + botiga.ObtenirNom());
            Console.WriteLine("Data: " + data.ToString());

            decimal total = 0m;
            for (int i = 0; i < nElements; i++)
            {
                decimal preuTotal = productes[i].ObtenirPreu() * quantitat[i];
                total += preuTotal;
                Console.WriteLine("Producte: " + productes[i].ObtenirNom());
                Console.WriteLine("Quantitat: " + quantitat[i]);
                Console.WriteLine("Preu Unitari: " + productes[i].ObtenirPreu());
>>>>>>> 92bba535f517963aba29eeee68b50b08d875007b
                Console.WriteLine("Preu Total: " + preuTotal);
                Console.WriteLine();
            }

            Console.WriteLine("Total: " + total);
            Console.WriteLine("Diners Restants: " + diners);
        }

        /// <summary>
        /// Mètode per calcular el cost total
        /// </summary>
        /// <returns>retorna el total del cost total de la cistella</returns>
<<<<<<< HEAD
        public double CostTotal()
        {
            double total = 0m;
            for (int i = 0; i < nElements; i++)
            {
                total += productes[i].Preu() * quantitat[i];
=======
        public decimal CostTotal()
        {
            decimal total = 0m;
            for (int i = 0; i < nElements; i++)
            {
                total += productes[i].ObtenirPreu() * quantitat[i];
>>>>>>> 92bba535f517963aba29eeee68b50b08d875007b
            }

            total *= 1.21m;

            return total;
        }

        /// <summary>
        /// Mètode que passa tot a un string
        /// </summary>
        /// <returns>retorna el tiquet en format string</returns>
        public override string ToString()
        {
            string tiquet = "";

            tiquet += "TIQUET DE COMPRA\n";
<<<<<<< HEAD
            tiquet += "Botiga: " + botiga.NomBotiga() + "\n";
            tiquet += "Data: " + data.ToString() + "\n";

            double total = 0;
            for (int i = 0; i < nElements; i++)
            {
                double preuTotal = productes[i].Preu_Sense_Iva * quantitat[i];
                tiquet += "Producte: " + productes[i].Nom + "\n";
                tiquet += "Quantitat: " + quantitat[i] + "\n";
                tiquet += "Preu Unitari: " + productes[i].Preu_Sense_Iva + "\n";
                tiquet += "Preu Total: " + preuTotal + "\n\n";
            }
            for (int i = 0; i < nElements; i++)
                total += productes[i].Preu() * quantitat[i];
=======
            tiquet += "Botiga: " + botiga.ObtenirNom() + "\n";
            tiquet += "Data: " + data.ToString() + "\n";

            decimal total = 0m;
            for (int i = 0; i < nElements; i++)
            {
                decimal preuTotal = productes[i].ObtenirPreu() * quantitat[i];
                total += preuTotal;
                tiquet += "Producte: " + productes[i].ObtenirNom() + "\n";
                tiquet += "Quantitat: " + quantitat[i] + "\n";
                tiquet += "Preu Unitari: " + productes[i].ObtenirPreu() + "\n";
                tiquet += "Preu Total: " + preuTotal + "\n\n";
            }

            total *= 1.21m;

>>>>>>> 92bba535f517963aba29eeee68b50b08d875007b
            tiquet += "Total amb IVA inclòs: " + total + "\n";

            return tiquet;
        }

    }
}

