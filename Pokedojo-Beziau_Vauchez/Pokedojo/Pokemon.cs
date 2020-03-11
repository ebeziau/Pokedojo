using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedojo
{
    class Pokemon
    {
        //Variables de classe
        public static List<Pokemon> ListePokemon = new List<Pokemon>();
        //public static int NbrPokemon = 0;
        public static Random aleatoire = new Random();

        //Variables d'instances
        public string Nom { get; private set; }
        public int PV { get; private set; }
        public int PVProvisoire { get; set; } //PV qui seront modifiés au cours d'un combat
        public int PuissanceAttaque { get; private set; }
        public Type Type { get; private set; }
        public int VictoiresConsecutives { get; set; }
        
        //Construteur
        public Pokemon(string nom, int pv, int puissanceAttaque, Type type)
        {
            Nom = nom;
            PV = pv;
            PVProvisoire = pv;
            PuissanceAttaque = puissanceAttaque;
            Type = type;
            VictoiresConsecutives = 0;
            
            ListePokemon.Add(this);
        }

        //Constructeur 2 : pour les clones (on ne les ajoute pas à la liste)
        public Pokemon(string nom, int pv, int puissanceAttaque, Type type, bool clone)
        {
            Nom = nom;
            PV = pv;
            PVProvisoire = pv;
            PuissanceAttaque = puissanceAttaque;
            Type = type;
            VictoiresConsecutives = 0;
        }

        //FONCTIONS

        public override string ToString()
        {
            string str = "";
            string a = Nom.ToUpper();
            string b1 = "Type : ";
            string b2 = Type.ToString();
            string c1 = "PV : ";
            int c2 = PV;
            string d1 = "Attaque : ";
            int d2 = PuissanceAttaque;
            string e1 = "Faiblesse : ";
            string e2 = Type.FaiblesseAssociee().ToString();

            string retour = "\n";

            str = str + a + retour + b1 + b2 + retour + c1 + c2 + retour + d1 + d2 + retour + e1 + e2 + retour;

            return str;
        }

        public void ToStringCombat()
        {
            string a = Nom.ToUpper();
            string b2 = Type.ToString();
            int c2 = PV;
            int c3 = PVProvisoire;
            string d1 = "Att: ";
            int d2 = PuissanceAttaque;
            string e1 = "Faib: ";
            string e2 = Type.FaiblesseAssociee().ToString();

            string espace = "  ";
            string retour = "\n";

            Console.Write(a);

            //Jauge de PVProvisoires
            //Pourcentage
            double arrondi = PVProvisoire * 100 / PV;
            //Nombre d’étoiles rouges
            arrondi = Math.Floor((arrondi / 10));

            Console.Write("      ");
            for (int i = 0; i < arrondi; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("*");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            for (int i = 0; i < (10 - arrondi); i++)
            {
                Console.Write(".");
            }
            string ligne1 = espace + c3 + "/" + c2;
            string ligne2 = b2;
            string ligne3 = d1 + d2 + espace + e1 + e2 + retour;
            Console.WriteLine(ligne1);
            Console.WriteLine(ligne2);
            Console.WriteLine(ligne3);
        }

        /// <summary>
        /// Clone un pokemon
        /// </summary>
        /// <returns></returns>
        public Pokemon Clone()
        {
            Pokemon poke = new Pokemon(Nom, PV, PuissanceAttaque, Type, true);
            return poke;
        }
    

        /// <summary>
        /// Retourne un Pokemon aléatoirement
        /// </summary>
        /// <returns></returns>
        public static Pokemon PokemonAleatoire()
        {
            return (ListePokemon[aleatoire.Next(0, ListePokemon.Count)]); //car NbrPokemon exclu
        }

        /// <summary>
        /// Redonne les pv d'un pokémon (utile à la fin d'un combat) + annule les combats consécutifs
        /// </summary>
        public void InitPokemon()
        {
            PVProvisoire = PV;
            VictoiresConsecutives = 0;
        }

        public void EvolutionPokemon(bool FH) //Attention, à appeler avant l'initialisation
        {
            string nomOriginal = Nom;
            PV+=10;
            //on veut remonter également les PV provisoires de 10
            int i = 0;
            while((PVProvisoire<PV)&&(i<10)) //on s'arrête au bout de 10fois ou quand la jauge est pleine
            {
                PVProvisoire++;
                i++;
            }
            PuissanceAttaque += 10;
            Nom = "Super" + Nom;
            VictoiresConsecutives = 0; //Reinitialisation
            if (FH)
            {
                Console.WriteLine("Le pokemon {0} à évolué !! On l'appelle désormais {1} !", nomOriginal, Nom);
            }
        }

        /// <summary>
        /// Attaque ; Procédure retirant des points au pokemon defenseur
        /// </summary>
        /// <param name="pok2"></param>
        /// <returns></returns>
        public void Attaque(Pokemon pok2) //Le pokémon 1 (this) est attaquant et le pokémon 2 est défenseur
        {
            int attaque = PuissanceAttaque ;
            int degats;
            Type faiblessePok2 = pok2.Type.FaiblesseAssociee(); //on récupère la faiblesse du pokémon 2
            if (this.Type == faiblessePok2) //Si la faiblesse du pokémon 2 est le type du pokémon 1 (this)
            {
                degats = attaque * 2; //les dégats sont multipliés par 2
            }
            else
            {
                degats = attaque; 
            }
            pok2.PVProvisoire -= degats; //le pokemon 2 perd des pv
            if(pok2.PVProvisoire<0) //si on est passé dans les négatif, on se met à 0
            {
                pok2.PVProvisoire = 0; 
            }
        }
    }
}
