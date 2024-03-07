using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotigaCistella_MarcVancea_OscarReus
{
    internal class Producte
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
        public Producte(string nom, double preuInicial, int iva, int quantitat): this(nom, preuInicial)
        {
            this.iva = iva;
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
            set { if (value > 0)
                    preu_sense_iva = value;
                else
                    console.WriteLine("Error");
            }
        }
        public int Iva
        {
            get { return iva; }
            set { if (value > 0)
                    iva = value;
            else
                    console.WriteLine("Error");}
        }
        public int Quantitat
        {
            get { return quantitat; }
            set { if (value > 0)
                    quantitat = value;
            else
                    Console.WriteLine("Error");}
        }

        // Metodes publics
        public double Preu()
        {
            return preu_sense_iva * iva / 100;
        }
        public override string ToString()
        {
            return $"Nom: {nom}; preu: {Preu()}; quantiat: {quantitat}";
        }
    }
}

