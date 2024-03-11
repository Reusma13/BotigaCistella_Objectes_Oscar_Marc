using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotigaCistella_MarcVancea_OscarReus
{
    public class Botiga
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
                if (taulaProductes[i] is not null) // Comprovacion si no es null
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
        public Producte[] Producte
        {
            
            get { return productes; }
            set { for (int i = 0; i < productes.Length; i++)
                    productes[i] = value; }
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
                if (productes[i] is null) // Comprovacion + devolver valor si no es null
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
                // Comprovacion si no es null y los nombres concuerdan 
                if (productes[i] is not null && productes[i].Nom == nomProducte) 
                    return i; // Devuelve el indice
            }
            return -1;
        }
        /// <summary>
        /// Este metodo llama a EspaiLliure para comprovar si hay espacios vacios, si lo hay lo añade y pone el bool en true
        /// si no hay espacio nos pregunta si queremos ampliarla y llama a AmpliarBotiga
        /// </summary>
        /// <param name="producte">Se le pasa un producto</param>
        /// <returns>devolve un true si lo a añadido y devuelve un false si no lo a añadido</returns>
        public bool AfegirProducte(Producte producte)
        {
            int index = EspaiLliure(); // Cogemos indice si hay espacios o -1 si no hay espacios
            bool afegit = false;
            if (index != -1)
            {
                productes[index] = producte; // Donde hay espacio pone el producto
                afegit = true;
                nElem++;
            }
            else
            {
                // Llamamos AmpliarBotiga si es necesario ampliarla y le pedimos dos cosas:
                Console.WriteLine("Vols ampliar la tenda?(S/N)");
                char ampliarTenda = Convert.ToChar(Console.ReadLine());
                // Primera si quiere ampliarla,
                if (ampliarTenda == 'S' || ampliarTenda == 's')
                {
                    //  si es que si pedimos valor para añadir a AmpliarBotiga.
                    Console.WriteLine("Quant la vols ampliar?");
                    int valor = Convert.ToInt32(Console.ReadLine());
                    AmpliarBotiga(valor); 
                }
                else
                {
                    // si nos dice que no ponemos afegir = false para advertir al usuario que no se a añadido el producto
                    afegit = false;
                }
            }
            return afegit;
        }
        /// <summary>
        /// Este metodo llama al metodo AfegirProducte (Producte producte) y va mirando producto a producto si los puede añadir
        /// y gracias a el anterior metodo puede llamar en todo momento a Ampliarbotiga si necesita ampliarla
        /// </summary>
        /// <param name="producte">Se le pasa una array con la clase producte</param>
        /// <returns>Devuelve un true si añade todos los valores, devuelve un false si no lo a podido añadir</returns>
        public bool AfegirProducte(Producte[] producte)
        {
            for (int i = 0; i < producte.Length; i++)
            {
                // Lamo a AfegirProducte con el producto de la array y asi reutilizo el metodo y no necesito volver a escribir
                // todo el metodo de arriba. Si nos devuelve un false se refiere a que no a podido añadir el producto.
                if (!AfegirProducte(producte[i])) 
                {
                    return false;
                }
            }
            return true; // Si despues de hacer el for nos a podido a añadir todos los productos nos devolvera true.
        }
        /// <summary>
        /// Este metodo se utiliza para añadirle mas tamaño a la array de productes, se le sumaria la longitud de la array productes
        /// y el numero que escoje el usuario, despues creamos una array con la nueva capacidad y pasamos todos los productos
        /// de la array productes a la array nouArray despues decimos que productes = a nouArray.
        /// </summary>
        /// <param name="num">se le pasa un numero para poder ampliar la tienda</param>
        public void AmpliarBotiga(int num)
        {
            int novaCapacitat = productes.Length + num;
            Producte[] nouArray = new Producte[novaCapacitat]; // Creamos array con nueva capacidad
            for (int i = 0; i < nElem; i++)
            {
                nouArray[i] = productes[i]; // añadimos productos de productes a la nueva array
            }
            productes = nouArray; // productes ahora es nouArray para pasarle la nueva capacidad
        }
        /// <summary>
        /// Le pasamos el nombre y el precio que le queremos poner, seguidamente comprovamos que en la array de productes este
        /// ese nombre si lo esta cambiamos el precio sin iva y si no lo esta le decimos que no lo hemos encontrado.
        /// </summary>
        /// <param name="producte">se le pasa el nombre del producto</param>
        /// <param name="preu">se le pasa el precio del producto</param>
        /// <returns>Devuelve true si a modificado el precio y si cuando acaba el bucle for no a modificado el precio 
        /// devuelve un false</returns>
        public bool ModificarPreu(string producte, double preu)
        {
            for (int i = 0; i < nElem; i++)
            {
                if (productes[i].Nom == producte) // Comprovacion de nombres si son iguales
                {
                    // Le ponemos el precio a precio sin iva y devuelve true
                    productes[i].Preu_Sense_Iva = preu; 
                    return true;
                }
            }
            Console.WriteLine($"No s'ha trobat el producte: {producte}");
            return false;
        }
        /// <summary>
        /// Sirve para encontrar un producto en la array de productes a traves del nombre
        /// </summary>
        /// <param name="producte">se le pasa un producto</param>
        /// <returns>Devuelve true si encuentra el producto en la array y sino devuelve un false</returns>
        public bool BuscarProducte(Producte producte)
        {
            for (int i = 0; i < nElem; i++)
            {
                if (productes[i].Nom == producte.Nom) // Comprovacion de nombres y si lo encuentra devuelve true
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Comprovamos si en la array de productes esta el producto que buscamos, si lo esta cambia los valores: nombre,
        /// precio y cantidad
        /// </summary>
        /// <param name="producte">Le pasamos un producto</param>
        /// <param name="nouNom">Le pasamos el nuevo nombre que queremos ponerle</param>
        /// <param name="nouPreu">Le pasamos el nuevo precio que queremos ponerle</param>
        /// <param name="novaQuantitat">Le pasamos la nueva cantidad que queremos ponerle</param>
        /// <returns>Devuelve true si en la array productes se encuentra el producto que a pasado el usuario y devuelve
        /// false si no lo encuentra</returns>
        public bool ModificarProducte(Producte producte, string nouNom, double nouPreu, int novaQuantitat)
        {
            for (int i = 0; i < nElem; i++)
            {
                if (productes[i] == producte) // Comprovacion de productos de la array y producto que pasa el usuario
                {
                    // Si son iguales modifica los paramentros y devuelve true
                    productes[i].Nom = nouNom;
                    productes[i].Preu_Sense_Iva = nouPreu;
                    productes[i].Quantitat = novaQuantitat;
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Utilizo el metodo burbuja para ordenar por nombre.
        /// </summary>
        public void OrdenarProducte()
        {
            for (int numVolta = 0; numVolta < nElem - 1 ;numVolta++)
            {
                for(int i = 0; i < nElem - numVolta - 1;i++)
                {
                    // Comparacion de nombres de productes[i] y productes[i + 1] (el siguente) si es mayor productes[i] hacen cambio
                    if (productes[i].Nom.CompareTo(productes[i + 1].Nom) > 0) 
                    {
                        Producte temp = productes[i];
                        productes[i] = productes[i + 1];
                        productes[i + 1] = temp;
                    }
                }
            }
        }
        /// <summary>
        /// Sirve para ordenar por precios de manera creciente
        /// </summary>
        public void OrdenarPreus()
        {
            for (int numVolta = 0; numVolta < nElem - 1; numVolta++)
            {
                for (int i = 0; i < nElem - numVolta - 1; i++)
                {
                    // Comprovacion de precios de productes[i] y productes[i + 1], si es mayor productes[i] hacen cambio
                    if (productes[i].Preu_Sense_Iva > productes[i + 1].Preu_Sense_Iva)
                    {
                        Producte temp = productes[i];
                        productes[i] = productes[i + 1];
                        productes[i + 1] = temp;
                    }
                }
            }
        }
        /// <summary>
        /// Utilizo el indexador para poder encontrar el indice del producte si no devuelve -1 ara la eliminacion y seguira
        /// manteniendo el orden sin dejar espacios libres.
        /// </summary>
        /// <param name="producte">el usuario nos da un producto</param>
        public void EsborrarProducte(Producte producte)
        {
            // Nos devuelve un numero que puede ser o el indice del producto en la tabla o -1 si no lo a encontrado
            int index = Indexador(producte.Nom);  // Le paso el nombre del producto
            if (index >= 0 && index < nElem)
            {
                for (int i = index; i < nElem - 1; i++) // i empieza en index porque los demas no hace falta tocarlos
                    productes[i] = productes[i + 1]; // Eliminarimos el productes[i] i lo sobreescribimos por productes[i + 1]
                nElem--; 
            }
            else
                Console.WriteLine("Producte no trobat");
        }
        /// <summary>
        /// Este metodo muestra por consola el nombre del producto junto con el precio sin y con iva.
        /// </summary>
        public void Mostrar()
        {
            for (int i = 0;i < nElem;i++)
            {
                Console.WriteLine($"Producte: {productes[i].Nom}, Preu sense iva: {productes[i].Preu_Sense_Iva} \n" +
                                  $"Preu amb iva: {productes[i].Preu()}"); // Llamamos a metodo Preu para que nos devuelve el precio con iva
            }
        }
        /// <summary>
        /// Sobreescribimos el metodo ToString para poder mostrar lo que queremos que es el nombre, producto sin iva, producto con iva
        /// y cuanto iva tiene el producto.
        /// </summary>
        /// <returns>Devuelve todos los datos separados por intros</returns>
        public override string ToString()
        {
            string datos = "";
            for (int i = 0; i < nElem; i++)
            {
                datos += $"Producte: {productes[i].Nom}, Preu sense iva: {productes[i].Preu_Sense_Iva} " +
                                  $"Preu amb iva: {productes[i].Preu()} IVA total: {productes[i].Iva}\n";
            }
            return datos;
        }
    }
}
