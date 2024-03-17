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
        private double diners; // Els diners disponibles per a la compra

        // Propietats
        public string ObtenirBotiga
        {
            get { return botiga.NomBotiga; }
        }
        /// <summary>
        /// Mètode per obtenir el nombre total d'elements a la cistella
        /// </summary>
        /// <returns>retorna el numero del elements</returns>
        public int ObtenirNElements
        {
            get { return nElements;}
        }

        /// <summary>
        /// Mètode per obtenir els diners restants
        /// </summary>
        /// <returns>retorna els diners que tens</returns>
        public double ObtenirDiners
        {
            get { return this.diners; }
        }

        /// <summary>
        /// Mètode per obtenir la data de la compra
        /// </summary>
        /// <returns>retorna la data</returns>
        public DateTime ObtenirData
        {
            get { return this.data; }
        }

        // Constructor buit
        public Cistella(Botiga botiga)
        {
            this.botiga = botiga;
            this.data = DateTime.Now;
            this.productes = new Producte[10];
            this.quantitat = new int[10];
            this.diners = 10000;
        }

        // Constructor amb botiga, productes, quantitats i diners
        public Cistella(Botiga botiga, Producte[] productes, int[] quantitat, double diners)
        {
            // Comprova si les taules de productes i quantitats tenen la mateixa mida
            if (productes.Length == quantitat.Length)
            {
                // Calcula el total de la compra
                double total = 0;
                for (int i = 0; i < productes.Length; i++)
                {
                    total += (productes[i].Preu_Sense_Iva + productes[i].Preu()) * quantitat[i];
                }

                // Comprova si hi ha suficients diners per a la compra
                if (total <= diners)
                {
                    this.botiga = botiga;
                    this.data = DateTime.Now;
                    this.productes = productes;
                    this.quantitat = quantitat;
                    nElements = productes.Length;
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
            if (!botiga.BuscarProducte(producte))

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
            if ((producte.Preu_Sense_Iva + producte.Preu()) * quantitat > diners)
            {
                Console.WriteLine("No teniu suficients diners per comprar aquest producte. Voleu ingressar més diners?");
                return false;
            }

            // Afegeix el producte a la cistella
            this.productes[nElements] = producte;
            this.quantitat[nElements] = quantitat;
            nElements++;
            for (int i = 0; i < botiga.NElem; i++)
            { 
                if (botiga.Producte[i].Nom == producte.Nom)
                {
                    botiga.Producte[i].Quantitat -= quantitat;
                }
            }
            this.diners -= (producte.Preu_Sense_Iva + producte.Preu()) * quantitat;

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
                if (!botiga.BuscarProducte(productes[i]))
                {
                    Console.WriteLine("El producte " + productes[i].Nom + " no existeix a la botiga.");
                    return false;
                }

                // Comprova si hi ha suficients diners per comprar el producte
                if (productes[i].Preu_Sense_Iva + productes[i].Preu() * quantitats[i] > diners)
                {
                    Console.WriteLine("No teniu suficients diners per comprar el producte " + productes[i].Nom + ". Voleu ingressar més diners?");
                    string resposta = Console.ReadLine();
                    if (resposta.ToLower() == "si")
                    {
                        Console.WriteLine("Quant vols ingressar?");
                        double quantitat = Convert.ToDouble(Console.ReadLine());
                        IngressarDiners(quantitat);
                    }
                    else
                    {
                        return false;
                    }
                }

                // Afegeix el producte a la cistella
                this.productes[nElements] = productes[i];
                this.quantitat[nElements] = quantitats[i];
                nElements++;
                for (int j = 0; j < botiga.Producte.Length; j++)
                {
                    if (botiga.Producte[i].Nom == productes[j].Nom)
                    {
                        botiga.Producte[i].Quantitat -= quantitats[j];
                    }
                }
                this.diners -= (productes[i].Preu_Sense_Iva + productes[i].Preu()) * quantitats[i];

                // Modificar la data
                this.data = DateTime.Now;
            }

            // Modificar la data
            this.data = DateTime.Now;

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
                    if (productes[j].Nom.CompareTo(productes[j + 1].Nom) > 0)

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
            Console.WriteLine("Botiga: " + ObtenirBotiga);
            Console.WriteLine("Data: " + ObtenirData.ToString());

            double total = 0;
            for (int i = 0; i < nElements; i++)
            {
                double preuTotal = (productes[i].Preu_Sense_Iva + productes[i].Preu()) * quantitat[i];
                total += preuTotal;
                Console.WriteLine("Producte: " + productes[i].Nom);
                Console.WriteLine("Quantitat: " + quantitat[i]);
                Console.WriteLine("Preu Unitari: " + (productes[i].Preu_Sense_Iva + productes[i].Preu()));
                Console.WriteLine("Preu Total: " + preuTotal);
                Console.WriteLine();
            }

            Console.WriteLine("Total: " + total);
            Console.WriteLine("Diners Restants: " + ObtenirDiners);
        }

        /// <summary>
        /// Mètode per calcular el cost total
        /// </summary>
        /// <returns>retorna el total del cost total de la cistella</returns>
        public double CostTotal()
        {
            double total = 0;

            for (int i = 0; i < nElements; i++)
            {
                total += (productes[i].Preu_Sense_Iva + productes[i].Preu()) * quantitat[i];
            }
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
            tiquet += "Botiga: " + botiga.NomBotiga + "\n";

            tiquet += "Data: " + data.ToString() + "\n";

            double total = 0;
            for (int i = 0; i < nElements; i++)
            {
                double preuTotal = (productes[i].Preu_Sense_Iva + productes[i].Preu()) * quantitat[i];
                tiquet += "Producte: " + productes[i].Nom + "\n";
                tiquet += "Quantitat: " + quantitat[i] + "\n";
                tiquet += "Preu Unitari: " + productes[i].Preu_Sense_Iva + productes[i].Preu() + "\n";
                tiquet += "Preu Total: " + preuTotal + "\n\n";
            }
            for (int i = 0; i < nElements; i++)
                total += (productes[i].Preu_Sense_Iva + productes[i].Preu()) * quantitat[i];

            tiquet += "Total amb IVA inclòs: " + total + "\n";

            return tiquet;
        }

        /// <summary>
        /// Mètode que afegeix una quantitat de diners que volem ingresar en el nostre total de diners.
        /// </summary>
        /// <param name="quantitat">és la quantitat de diners que tenim</param>
        public void IngressarDiners (double quantitat)
        {
            Console.WriteLine("Quina quantitat de diners vols ingresar?");
            string input = Console.ReadLine();
            quantitat = Convert.ToDouble(input);

            if (quantitat >= 0)
            {
                this.diners += quantitat;
                Console.WriteLine("Has ingressat " + quantitat + ". Ara tens " + this.diners + " diners al teu compte.");
            }
            else
            {
                Console.WriteLine("La quantitat ha de ser un número positiu.");
            }
        }

    }
}

