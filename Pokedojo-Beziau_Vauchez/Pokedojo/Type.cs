using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedojo
{
    class Type
    {
        //Variables de classe
        public static List<Type> ListeTypes = new List<Type>();
        public static int NbrTypes = 0;

        //Variables d'instance
        public string Nom { get; set; }

        //Constructeur
        public Type(string nom)
        {
            Nom = nom;
            NbrTypes++;
            ListeTypes.Add(this);
        }

        //FONCTIONS

        public override string ToString()
        {
            string str = "";
            string a = Nom;
            str += a;

            return str;
        }

        /// <summary>
        /// Retourne le type faiblesse du type en question
        /// </summary>
        /// <returns>Type</returns>
        public Type FaiblesseAssociee()
        {
            int indice = ListeTypes.IndexOf(this); //l'indice du type dans la liste
            if(indice==NbrTypes-1) //si c'est le dernier de la liste... (l'indice du dernier est bien NbrTypes-1 car s'il y a 4 types, on a le indices 0, 1, 2 et 3)
            {
                return ListeTypes[0];//...sa faiblesse est le premier (liste bouclée)
            }
            return ListeTypes[indice+1]; //sinon, sa faiblesse est le suivant dans la liste
        }
    }
}
