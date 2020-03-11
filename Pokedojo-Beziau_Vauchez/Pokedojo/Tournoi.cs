using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedojo
{
    class Tournoi
    {
        //Variables de classe 
        public static Random aleatoire = new Random();

        //Variables d'instance
        public int NbrJoueurs { get; private set; }
        public int NbrTours { get; private set; } //un peu redondant mais peu pratique à calculer donc se fait dans le constructeur
        public Dresseur Vainqueur { get; private set; }
        public bool IA { get; private set; }
        public List<Dresseur> DresseursParticipants;

        //Constructeur
        public Tournoi (int difficulte, bool ia, Dresseur joueur) //Choix du nombre de joueur et donc du nombre de tour (de la longueur du tournoi) en fonction de la difficulté choisie par le joueur.
        {
            if (difficulte == 1)
            {
                NbrJoueurs = 8; // 3 tours
                NbrTours = 3;
            }
            if (difficulte == 2)
            {
                NbrJoueurs = 16; // 4 tours
                NbrTours = 4;
            }
            if (difficulte == 3)
            {
                NbrJoueurs = 32; // 5 tours
                NbrTours = 5;
            }
            IA = ia; //Avec intelligence(true) ou en aleatoire(false)

            //On ajoute les participants
            DresseursParticipants = Dresseur.PlusieursDresseursAleatoires(NbrJoueurs-1);
            DresseursParticipants.Add(joueur);

            //On mélange la liste de joueur pour avoir un tirage aléatoire
            int n = DresseursParticipants.Count;
            while (n > 1) //inspiré d'un code existant (web)
            {
                n--;
                int k = aleatoire.Next(n + 1);
                Dresseur dres = DresseursParticipants[k];
                DresseursParticipants[k] = DresseursParticipants[n];
                DresseursParticipants[n] = dres;
            }

            //NbrTours = Convert.ToInt32(Math.Log(NbrJoueurs) / Math.Log(2)); //Conversion forcée en entier car on sait qu'avec les nombres de joueurs choisi c'est possible. 
        }

        //FONCTIONS
        
        public Pokemon SwitchPokemon(Pokemon poke, Dresseur dress)
        {
            Console.WriteLine("Voulez-vous changer de pokémon ?\n0- OUI\n1-NON");
            int a = int.Parse(Console.ReadLine());
            while((a!=0)&&(a!=1))
            {
                Console.WriteLine("Veuillez choisir un chiffre entre 0 (OUI, je vaux changer de Pokémon) et 1 (NON, je ne veux pas).");
            }
            if (a == 0) //il veut changer
            {
                //Du moment où il veut changer, son pokemon perd ses victoires consecutives
                poke.VictoiresConsecutives = 0;
                return dress.ChoixPokemonActif();
            }
            return poke;
        }

        public static void PresentationParticipants(Dresseur d1, Dresseur d2)
        {
            Console.WriteLine(d1);
            foreach (Pokemon poke in d1.PokemonsDresseur)
            {
                Console.WriteLine(poke);
            }
            Console.WriteLine("\nVS\n");
            Console.WriteLine(d2);
            foreach (Pokemon poke in d2.PokemonsDresseur)
            {
                Console.WriteLine(poke);
            }
        }

        /// <summary>
        /// Lance le combat
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        /// <returns></returns>
        public Dresseur LancerCombat(Dresseur d1, Dresseur d2) //d2 est potentiellement un joueur
        {
            bool FH = false;
            if ((d1 is Joueur) || (d2 is Joueur))
            {
                FH = true;
            }
            if (FH)
            {
                PresentationParticipants(d1, d2);
            }

            //On définit le gagnant par défaut
            Dresseur vainqueurCombat = d1;

            //Autres variables
            bool premiereBoucle = true; //pour indiquer qu'il ne faut pas demander de changement de pokemon
            bool changementRecent = false;

            //On choisi les pokémons une première fois
            Pokemon pok1 = d1.ChoixPokemonActif();
            Pokemon pok2 = d2.ChoixPokemonActif();

            while ((d1.DresseurKO() == false) && (d2.DresseurKO() == false)) //tant que les deux ont au moins un pokemon en vie
            { 
                //Attaque 1               
                if (pok1.PVProvisoire == 0) //Si le pokemon en court est mort
                {
                    pok1 = d1.ChoixPokemonActif(); //et le pokémon mort est remplacé
                    changementRecent = true;
                }
                else
                {
                    if ((d1 is Joueur)&&(premiereBoucle==false)&&(changementRecent==false))
                    {
                        pok1 = SwitchPokemon(pok1, d1); //si le pokemon n'est pas mort, il peu changer (sauf si c'est le tout début du combat, où qu'il vient de le changer)
                    }               
                }
                changementRecent = false;
                pok1.Attaque(pok2); //d1 est forcément non-KO, car on vient de rentrer dans le while                
                //AFFICHAGE
                if (FH)
                {                    
                    Program.ColorerTexte(ConsoleColor.White, "\nNOUVEAU ROUND ");
                    Console.WriteLine(pok1.Nom + " attaque " + pok2.Nom + " !\n");
                    pok1.ToStringCombat();
                    pok2.ToStringCombat();
                }
                if (pok2.PVProvisoire == 0) //si le pokemon attaqué est mort...
                {
                    pok1.VictoiresConsecutives++;//...on attribue la victoire à l'autre
                    if (pok1.VictoiresConsecutives == 2)
                    {
                        pok1.EvolutionPokemon(FH);
                    }
                }
                else //si il est pas ko
                {
                    pok1.VictoiresConsecutives = 0; //on annule les victoires consécutives de ce pokémon
                }
                //Attaque 2                
                if (pok2.PVProvisoire == 0) //si le pokemon attaqué est mort...
                {
                    pok2 = d2.ChoixPokemonActif(); //... on le change (peut renvoyer null si d2 n'a plus de pokemon actifs)
                    changementRecent = true;
                }
                if (pok2 != null) //Si cette condition ne s'applique pas, cela signifie que d2 est KO, donc on va sortir du while;
                {
                    if ((d2 is Joueur)&&(changementRecent==false))
                    {
                        pok2 = SwitchPokemon(pok2, d2);
                    }
                    changementRecent = false;
                    pok2.Attaque(pok1);                    
                    //AFFICHAGE
                    if (FH)
                    {
                        Program.ColorerTexte(ConsoleColor.White, "\nCONTRE-ATTAQUE");
                        Console.WriteLine(pok2.Nom + " attaque " + pok1.Nom + " !\n");
                        pok1.ToStringCombat();
                        pok2.ToStringCombat();
                    }
                    if (pok1.PVProvisoire == 0) //si le pokemon attaqué est mort...
                    {
                        pok2.VictoiresConsecutives++;//...on attribue la victoire à l'autre
                        if (pok2.VictoiresConsecutives == 2)
                        {
                            pok2.EvolutionPokemon(FH);
                        }
                    }
                    else //si il est pas ko
                    {
                        pok2.VictoiresConsecutives = 0; //on annule les victoires consécutives de ce pokémon
                    }
                }
                if(premiereBoucle==true)
                {
                    premiereBoucle = false;
                }                
            }
            //Déclaration du gagnant et élimination de l'autre (NbrJoueurs--)            
            if (d1.DresseurKO() == true)
            {
                vainqueurCombat = d2;
            }
            NbrJoueurs--;
            return vainqueurCombat;
        }
        

        /// <summary>
        /// Lance le tournoi
        /// </summary>
        public void LancerLeTournoi()
        {
            List<Dresseur> DresseursEnLice = new List<Dresseur>(DresseursParticipants); ;//la liste de ce qui sont encore en lice
            List<Dresseur> Gagnants = new List<Dresseur>(); //la liste des gagnants du tour (donc c'est la "liste de ce qui sont encore en lice" du tour d'après)
            Dresseur gagnantCombat;

            //Affichage de tous les dresseurs en lice
            Console.WriteLine("\nBIENVENUE DANS CE TOURNOI !\n");
            Console.WriteLine("Les joueurs participants sont :\n");

            foreach (Dresseur d in DresseursEnLice)
            {
                Console.WriteLine(d);
            }

            for (int i=0; i<NbrTours; i++) //Nouveau tour
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nNOUVEAU TOUR : Tour n°{0}", i + 1);
                Console.ForegroundColor = ConsoleColor.Gray;
                for (int j=0; j<DresseursEnLice.Count; j+=2) //Nouveau combat
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\nCombat {0}", j/2+1);
                    Console.ForegroundColor = ConsoleColor.Gray;

                    
                    gagnantCombat = LancerCombat(DresseursEnLice[j], DresseursEnLice[j+1]);
                    Console.WriteLine("C'est {0} qui a gagné ce combat !", gagnantCombat.Nom);
                    Gagnants.Add(gagnantCombat);
              
                }
                //A la fin de tous les combats d'un tour
                foreach (Dresseur dresseur in DresseursEnLice) //on remet tous les points de vie à tous les pokémons
                {
                    foreach(Pokemon poke in dresseur.PokemonsDresseur)
                    {
                        poke.InitPokemon();
                    }                    
                }
                // et on ne garde que les gagnants
                DresseursEnLice.Clear();
                foreach(Dresseur d in Gagnants)
                {
                    DresseursEnLice.Add(d); //ils gardent le même ordre !
                }
                Gagnants.Clear(); //on réinitialise les gagnants pour le tour d'après
            }
            foreach(Dresseur d in DresseursEnLice)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nBravo, c'est {0} qui a gagné le tournoi !\n", d.Nom);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
    }
}
