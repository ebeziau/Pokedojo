using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedojo
{
    class Program
    {
        public static void CentrerTexte(string s)
        {
            Console.SetCursorPosition(((Console.WindowWidth - s.Length) / 2)-4, Console.CursorTop);
            Console.Write(s);
        }

        public static void ColorerTexte(ConsoleColor color, string str)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(str);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static void Main(string[] args)
        {
            //VARIABLES
            int difficulte;

            //Liste des types (chaque type déclaré est la faiblesse de celui du dessus (en boucle)
            Type Plante = new Type("Plante");
            Type Psy = new Type("Psy");
            Type Pierre = new Type("Pierre");
            Type Electrique = new Type("Electrique");
            Type Eau = new Type("Eau");
            Type Feu = new Type("Feu");

            //Liste des 50 Pokemons
            Pokemon bulbizarre = new Pokemon("Bulbizarre", 60, 39, Plante); 
            Pokemon salameche = new Pokemon("Salamèche", 60, 42, Feu);
            Pokemon carapuce = new Pokemon("Carapuce", 60, 48, Eau);
            Pokemon chenipan = new Pokemon("Chenipan", 45, 20, Plante);
            Pokemon aspicot = new Pokemon("Aspicot", 40, 25, Psy);
            Pokemon roucool = new Pokemon("Roucool", 50, 35, Psy);
            Pokemon rattata = new Pokemon("Rattata", 30, 46, Pierre);
            Pokemon piafabec = new Pokemon("Piafabec", 40, 30, Pierre);
            Pokemon abo = new Pokemon("Abo", 35, 50, Psy);
            Pokemon pikachu = new Pokemon("Pikachu", 60, 45, Electrique); //10

            Pokemon sabelette = new Pokemon("Sabelette", 50, 45, Pierre);
            Pokemon nidoran = new Pokemon("Nidoran", 55, 40, Psy);
            Pokemon melofee = new Pokemon("Mélofée", 70, 35, Psy);
            Pokemon goupix = new Pokemon("Goupix", 38, 31, Feu);
            Pokemon rondoudou = new Pokemon("Rondoudou", 115, 45, Pierre);
            Pokemon nosferapti = new Pokemon("Nosferapti", 40, 35, Psy);
            Pokemon mystherbe = new Pokemon("Mystherbe", 45, 35, Plante);
            Pokemon paras = new Pokemon("Paras", 35, 60, Plante);
            Pokemon mimitoss = new Pokemon("Mimitoss", 60, 40, Plante);
            Pokemon taupiqueur = new Pokemon("Taupiqueur", 10, 45, Pierre); //20

            Pokemon miaouss = new Pokemon("Miaouss", 55, 45, Pierre);
            Pokemon psykokwak = new Pokemon("Psykokwak", 50, 35, Eau);
            Pokemon ferosinge = new Pokemon("Ferosinge", 50, 80, Pierre);
            Pokemon caninos = new Pokemon("Caninos", 50, 65, Feu);
            Pokemon ptitard = new Pokemon("Ptitard", 40, 30, Eau);
            Pokemon abra = new Pokemon("Abra", 25, 20, Psy);
            Pokemon machoc = new Pokemon("Machoc", 70, 80, Pierre);
            Pokemon chetiflor = new Pokemon("Chetiflor", 55, 55, Plante);
            Pokemon tentacool = new Pokemon("Tentacool", 40, 30, Eau);
            Pokemon racaillou = new Pokemon("Racaillou", 40, 70, Pierre); //30

            Pokemon ponyta = new Pokemon("Ponyta", 50, 75, Feu);
            Pokemon ramoloss = new Pokemon("Ramoloss", 90, 45, Eau);
            Pokemon magneti = new Pokemon("Magneti", 25, 35, Electrique);
            Pokemon canarticho = new Pokemon("Canarticho", 52, 43, Eau);
            Pokemon doduo = new Pokemon("Doduo", 35, 50, Pierre);
            Pokemon otaria = new Pokemon("Otaria", 65, 45, Eau);
            Pokemon tadmorv = new Pokemon("Tadmorv", 90, 60, Psy);
            Pokemon kokiyas = new Pokemon("Kokiyas", 30, 40, Eau);
            Pokemon fantominus = new Pokemon("Fantominus", 30, 30, Psy);
            Pokemon onix = new Pokemon("Onix", 35, 45, Pierre); //40

            Pokemon soporifik = new Pokemon("Soporifik", 60, 48, Psy);
            Pokemon krabby = new Pokemon("Krabby", 30, 60, Eau);
            Pokemon voltorbe = new Pokemon("Voltorbe", 40, 30, Electrique);
            Pokemon noeunoeuf = new Pokemon("Noeunoeuf", 60, 30, Plante);
            Pokemon osselait = new Pokemon("Osselait", 50, 40, Pierre);
            Pokemon kicklee = new Pokemon("Kicklee", 50, 120, Pierre);
            Pokemon excelangue = new Pokemon("Excelangue", 90, 45, Eau);
            Pokemon smogo = new Pokemon("Smogo", 40, 55, Psy);
            Pokemon saquedeneu = new Pokemon("Saquedeneu", 70, 45, Plante);
            Pokemon hypotrempe = new Pokemon("Hypotrempe", 30, 30, Eau); //50

            Pokemon poissirene = new Pokemon("Poissirene", 45, 35, Eau);
            Pokemon stari = new Pokemon("Stari", 50, 45, Eau);
            Pokemon insecateur = new Pokemon("Insecateur", 70, 110, Plante);
            Pokemon magicarpe = new Pokemon("Magicarpe", 20, 10, Eau);
            Pokemon voltali = new Pokemon("Voltali", 70, 65, Electrique);
            Pokemon pyroli = new Pokemon("Pyroli", 65, 130, Feu);
            Pokemon ronflex = new Pokemon("Ronflex", 160, 70, Plante);
            Pokemon minidraco = new Pokemon("Minidraco", 41, 64, Psy);
            Pokemon sulfura = new Pokemon("Sulfura", 90, 100, Feu);
            Pokemon mewtwo = new Pokemon("Mewtwo", 106, 110, Psy); //60


            //Liste des 31 dresseurs virtuels (ils seront alors 32 maximum avec le joueur)
            Dresseur aurore = new Dresseur("Aurore");
            Dresseur piotr = new Dresseur("Piotr");
            Dresseur perrine = new Dresseur("Perrine");
            Dresseur ben = new Dresseur("Ben");
            Dresseur gregory = new Dresseur("Gregory");
            Dresseur sally = new Dresseur("Sally");
            Dresseur calvin = new Dresseur("Calvin");
            Dresseur james = new Dresseur("James");
            Dresseur suzette = new Dresseur("Suzette");
            Dresseur rachel = new Dresseur("Rachel");
            Dresseur keneda = new Dresseur("Keneda");
            Dresseur rachid = new Dresseur("Rachid");
            Dresseur nacy = new Dresseur("Nacy");
            Dresseur elijah = new Dresseur("Alijah");
            Dresseur isabelle = new Dresseur("Isabelle");

            Dresseur dorian = new Dresseur("Dorian");
            Dresseur anny = new Dresseur("Anny");
            Dresseur jo = new Dresseur("Jo");
            Dresseur lin = new Dresseur("Lin");
            Dresseur mona = new Dresseur("Mona");
            Dresseur bob = new Dresseur("Bob");
            Dresseur loan = new Dresseur("Loan");
            Dresseur julie = new Dresseur("Julie");
            Dresseur axel = new Dresseur("Axel");
            Dresseur chris = new Dresseur("Chris");
            Dresseur max = new Dresseur("Max");
            Dresseur sylvain = new Dresseur("Sylvain");
            Dresseur jason = new Dresseur("Jason");
            Dresseur martin = new Dresseur("Martin");
            Dresseur pat = new Dresseur("Pat");
            Dresseur mathy = new Dresseur("Mathy");

            //DEBUT DE PARTIE (couleur)
            Console.WriteLine();
            CentrerTexte("Bienvenue dans ce prestigieux Jeu du Meilleur Dresseur ");
            //Console.Write("Bienvenue dans ce prestigieux Jeu du Meilleur Dresseur ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write("POKEMON");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine(" !");

            //CREATION DU PROFIL DU JOUEUR
            Console.WriteLine("\nQuel est ton nom de dresseur ?");
            string NomJoueur = Console.ReadLine();

            Joueur Joueur = new Joueur(NomJoueur);
            
            Console.WriteLine("\nVos pokémons sont :\n");
            foreach (Pokemon poke in Joueur.PokemonsDresseur)
            {
                Console.WriteLine("{0} - {1}\n", Joueur.PokemonsDresseur.IndexOf(poke), poke.Nom); //Affiche le numero dans la liste et le nom du pokémon
            }

            //CREATION TOURNOI
            Console.WriteLine("A quel tournoi voulez-vous participer ?\n1 : Régional (3 combats)\n2 : National (4 combats)\n3 : Mondial (5 combats)");
            difficulte = int.Parse(Console.ReadLine());
            while ((difficulte < 1) || (difficulte > 3))
            {
                Console.WriteLine("Choisissez un chiffre parmi 1, 2 ou 3 : ");
                difficulte = int.Parse(Console.ReadLine());
            }

            Tournoi tournoi = new Tournoi(difficulte, false, Joueur);
            tournoi.LancerLeTournoi();
        }
    }
}
