using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotigaCistella_MarcVancea_OscarReus
{
    internal class Botiga
    {
        // Atributs
        private string nomBotiga;
        private Producte[] productes;
        private int nElem;

        // Constructors
        public Botiga() 
        {
            productes = new Producte[10];
            nElem = 0;
        }
        public Botiga(string nom, int nombreProductes): this()
        {
            this.nomBotiga = nom;
            this.productes = new Producte[nombreProductes];
        }
        /// <summary>
        /// J es un contador de no nulos que sirve para poner en la tabla productes
        /// los productos que no sean nulos y ademas tambien sirve para poner el nElem sin contar ningun null
        /// </summary>
        /// <param name="nom">Nombre de la botiga</param>
        /// <param name="taulaProductes">taulaProductes sirve para pasar una array de productos a la array de atributos</param>
        public Botiga(string nom, Producte[] taulaProductes)
        {
            this.nomBotiga = nom;
            int j = 0;
            for (int i=0; i < taulaProductes.Length;  i++)
            {
                if (taulaProductes[i] is not null)
                {
                    productes[j] = taulaProductes[i];
                    j++;
                }
            }
            nElem = j;
        }
        // Propietats
        public string NomBotiga
        {
            get { return nomBotiga; }
            set { nomBotiga = value; }
        }
        public Producte Producte
        {
            get { return productes; }
            set { productes = value; }
        }
        public int NElem
        {
            get { return nElem; }
            set { nElem = value; }
        }
        // Metodes
        /// <summary>
        /// EspaiLliure sirve para ver si hay algun espacio libre para poner un producto
        /// </summary>
        /// <returns>Si hay espacio libre devuelve la posicion del espacio libre, si no hay ningun espacio libre devuelve -1</returns>
        public int EspaiLliure()
        {
            for (int i = 0; i < productes.Length; i++)
            {
                if (productes[i] is null)
                    return i;    
            }
            return -1;
        }
        /// <summary>
        /// Este indexador sirve para encontrar un produto por nombre dentro de la tabla productes
        /// </summary>
        /// <param name="nomProducte">Aqui se pondria el nombre del producto</param>
        /// <returns>Aqui devolveria un valor que puede ser o la posicion del producto encontrado por el nombre o -1 si no lo encuentra</returns>
        public int Indexador(string nomProducte)
        {
            for (int i = 0; i < nElem; i++)
            {
                if (productes[i] is not null && productes[i].Nom == nomProducte)
                    return i;
            }
            return -1;
        }
        /// <summary>
        /// Este metodo llama a EspaiLliure para comprovar si hay espacios vacios, si lo hay lo añade y pone el bool en true
        /// si no hay espacio nos pregunta si queremos ampliarla y llama a AmpliarBotiga
        /// </summary>
        /// <param name="producte"></param>
        /// <returns>devolve un true si lo a añadido y devuelve un false si no lo a añadido</returns>
        public bool AfegirProducte(Producte producte)
        {
            int index = EspaiLliure();
            bool afegit = false;
            if (index != -1)
            {
                productes[index] = producte;
                afegit = true;
            }
            else
            {
                Console.WriteLine("Vols ampliar la tenda?(S/N)");
                char ampliarTenda = Convert.ToChar(Console.ReadLine());
                if (ampliarTenda == 'S' || ampliarTenda == 's')
                {
                    Console.WriteLine("Quant la vols ampliar?");
                    int valor = Convert.ToInt32(Console.ReadLine());
                    productes[AmpliarBotiga(valor)];
                }
                else
                {
                    afegit = false;
                }
            }
            return afegit;
        }
    }
}
