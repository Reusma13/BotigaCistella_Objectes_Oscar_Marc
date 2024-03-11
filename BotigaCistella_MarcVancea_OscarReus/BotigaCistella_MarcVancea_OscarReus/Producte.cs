using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotigaCistella_MarcVancea_OscarReus
{
    public class Producte
    {
        // Atributs
        private string nom;
        private double preu_sense_iva;
        private int iva;
        private int quantitat;

        // Constructors
        public Producte ()
        {
            iva = 21;
            quantitat = 0;
        }
        public Producte (string nom, double preuInicial): this()
        {
            this.nom = nom;
            this.preu_sense_iva = preuInicial;
        }
        public Producte(string nom, double preuInicial, int quantitat): this(nom, preuInicial)
        {
            this.quantitat = quantitat;
        }

        // Propietats
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }
        public double Preu_Sense_Iva
        {
            get { return preu_sense_iva; }
            set { if (value > 0) // Si el precio sin iva es menos a 0 da error sino coge el precio
                    preu_sense_iva = value;
                else
                    Console.WriteLine("Error");
            }
        }
        public int Iva
        {
            get { return iva; }
            set { if (value > 0) // Si el iva es menos a 0 da error sino coge el iva
                    iva = value; 
            else
                    Console.WriteLine("Error");}
        }
        public int Quantitat
        {
            get { return quantitat; }
            set { if (value > 0) // Si el cantidad es menos a 0 da error sino coge el cantidad
                    quantitat = value;
            else
                    Console.WriteLine("Error");}
        }

        // Metodes publics
        /// <summary>
        /// Coge el precio sin iva lo multiplica por iva i lo divide entre 100 para coger el precio con iva
        /// </summary>
        /// <returns>Devuelve el precio con iva</returns>
        public double Preu()
        {
            return preu_sense_iva * iva / 100;
        }
        /// <summary>
        /// Sirve para sobreescribir el metodo ToString y ajustarlo como necesitas
        /// </summary>
        /// <returns>Devuelve en este caso el nombre, el precio con iva y la cantidad</returns>
        public override string ToString()
        {
            return $"Nom: {nom}; preu: {Preu()}; quantiat: {quantitat}";
        }
    }
}

