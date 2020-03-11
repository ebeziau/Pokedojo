using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedojo
{
    class Joueur : Dresseur
    {
        public Joueur(string nom) : base(nom)
        {
            //
        }

        /// <summary>
        /// Choisi un pokemon actif (Joueur)
        /// </summary>
        /// <returns></returns>
        public override Pokemon ChoixPokemonActif()
        {
            Pokemon actif = null;
            if (DresseurKO() == false)
            {
                //Création de la liste des pokémons encore en vie
                List<Pokemon> PokemonsEnVieDresseur = new List<Pokemon>(PokemonsEnVie()); //liste des pokemons encore en vie

                //Affichage des pokemon en vie
                Console.WriteLine("Quel pokémon voulez-vous utiliser ? \nVos pokémons disponibles sont :\n");
                foreach (Pokemon poke in PokemonsEnVieDresseur)
                {
                    Console.WriteLine("{0} - {1}\n", PokemonsEnVieDresseur.IndexOf(poke), poke.Nom); //Affiche le numero dans la liste et le nom du pokémon
                }

                //Traitement de la demande de pokémon
                int numero = int.Parse(Console.ReadLine());
                while ((numero < 0) || (numero >= PokemonsEnVieDresseur.Count))
                {
                    Console.WriteLine("Veuillez choisir un pokémon parmi ceux disponibles. Veuillez saisir le numéro en début de ligne du pokémon désiré :\n");
                    numero = int.Parse(Console.ReadLine());
                }
                actif = PokemonsEnVieDresseur[numero];
            }
            return actif; //si le joueur est ko, il renvoie "null"
        }
    }
}
