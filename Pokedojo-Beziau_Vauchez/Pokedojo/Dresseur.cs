using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedojo
{
    class Dresseur
    {
        //Variable de classe
        public static List<Dresseur> ListeDresseurs = new List<Dresseur>();
        private static Random aleatoire = new Random();

        //Variables d'instances
        public string Nom { get; private set; }
        public List<Pokemon> PokemonsDresseur;
        //public bool VraiJoueur { get; private set; }

        //Constructeur
        public Dresseur(string nom)
        {
            Nom = nom;

            //Choix de 3 Pokemons aléatoires parmi ceux de la liste
            PokemonsDresseur = new List<Pokemon>();
            Pokemon AAjouter;
            while (PokemonsDresseur.Count<3)
            {
                AAjouter = Pokemon.PokemonAleatoire().Clone(); //c'est bien une copie
                if(PokemonsDresseur.Contains(AAjouter)==false) //si ce pokemon n'est pas déjà dans la liste (pour éviter les doublons)
                {
                    PokemonsDresseur.Add(AAjouter);
                }
            }
            ListeDresseurs.Add(this);
        }

        //FONCTIONS

        public override string ToString()
        {
            string str = "";
            string a = Nom.ToUpper();
            string retour = "\n";

            str = str + a + retour;
            return str;
        }

        /// <summary>
        /// Retourne un Dresseur aléatoirement parmi la liste
        /// </summary>
        /// <returns></returns>
        public static Dresseur DresseurAleatoire()
        {
            return (ListeDresseurs[aleatoire.Next(0, ListeDresseurs.Count)]); //car NbrDresseurs exclu
        }

        /// <summary>
        /// Retourne nbr Dresseurs DISTINCTS de manière aléatoire
        /// </summary>
        /// <returns></returns>
        public static List<Dresseur> PlusieursDresseursAleatoires(int nbr)
        {
            //on crée une copie de la liste des dresseurs
            List<Dresseur> CopieListeDresseurs = new List<Dresseur>(ListeDresseurs);

            //on enlève le joueur de la copie pour pas qu'il ne soit choisi (il est rajouté au tournoi manuellement dans le constructeur)
            int ind = CopieListeDresseurs.Count; //pas de risque, il y a forcément un joueur & en plus il est à la fin
            foreach (Dresseur j in CopieListeDresseurs)
            {
                if (j is Joueur)
                {
                    ind = CopieListeDresseurs.IndexOf(j);
                }
            }
            CopieListeDresseurs.RemoveAt(ind);

            //On crée la liste retour
            List<Dresseur> ListeDresseursAleatoires = new List<Dresseur>();
            
            while (ListeDresseursAleatoires.Count < nbr)
            {
                int random = aleatoire.Next(0, CopieListeDresseurs.Count); //on sélectionne aléatoirement un Dresseur restant de la liste Copie
                if (ListeDresseursAleatoires.Contains(CopieListeDresseurs[random]) == false) //si ce dresseur n'est pas déjà dans la liste (pour éviter les doublons)
                {
                    ListeDresseursAleatoires.Add(CopieListeDresseurs[random]); //on l'ajoute à la liste retour
                    CopieListeDresseurs.RemoveAt(random); //on l'enlève de la liste Copie
                }
            }
            return ListeDresseursAleatoires;
    }

        /// <summary>
        /// Retourne la liste des pokemons encore en vie d'un dresseur
        /// </summary>
        /// <returns></returns>
        public List<Pokemon> PokemonsEnVie()
        {
            List<Pokemon> PokemonsEnVie = new List<Pokemon>();
            foreach (Pokemon poke in PokemonsDresseur)
            {
                if (poke.PVProvisoire != 0) //pour tous les pokemons en vie de la liste
                {
                    PokemonsEnVie.Add(poke); //on les met dans la liste des pokémons encore en vie
                }
            }
            return PokemonsEnVie;
        }

        /// <summary>
        /// Choisi un pokemon actif (Ordi)
        /// </summary>
        /// <returns></returns>
        public virtual Pokemon ChoixPokemonActif() //Renvoie le pokémon actif de l'ordinateur, choisi aléatoirement. On pourra imaginer en stratégie une autre fonction StrategieChoixPokemonActifOrdi
        {
            Pokemon actif = null;
            if (DresseurKO() == false)
            {
                List<Pokemon> PokemonsEnVieDresseur = new List<Pokemon>(PokemonsEnVie()); //liste des pokemons encore en vie
                actif = PokemonsEnVieDresseur[aleatoire.Next(0, PokemonsEnVieDresseur.Count)]; //on prend au hasard un pokemon en vie
            }
            return actif;
        }        

        /// <summary>
        /// Retourne true si le joueur n'a plus de pokemon actif, false sinon
        /// </summary>
        /// <returns></returns>
        public bool DresseurKO()
        {
            List<Pokemon> PokemonEnVie = new List<Pokemon>(PokemonsEnVie()); ;
            if(PokemonEnVie.Count==0)
            {
                return true;
            }
            return false;
        }
    }
}

