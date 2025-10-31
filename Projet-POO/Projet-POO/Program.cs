using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;



namespace Projet_POO
{
    internal class Program
    {

        static void Main(string[] args)
        {
            // Faire en sorte qu'on ne voit pas le curseur

            Console.CursorVisible = false;

            // Variable qui fait en sorte que le code ne s'arrête jamais si aucune condition de victoire ou défaite

            int infini = 0;
            
            // Variable qui contient le décalage sur l'axe X lorsque l'ennemi ou l'obstacle se déplace en horizontal
            
            int speedx = 6;

            // Variable qui contient le décalage sur l'axe Y lorsque l'ennemi ou l'obstacle se déplace en vertical

            int speedy = 1;

            // Variable qui contient le nombre d'ennemis restant

            int ennemynbr = 10;

            // Instancie un nouveau score

            Score points = new Score();

            // Création des listes

            // Liste des projectiles

            List<Projectile> projectiles = new List<Projectile>();

            // Liste des obstacles

            List<Obstacles> obstacles = new List<Obstacles>();
            
            // Liste des ennemis

            List<Ennemis> ennemis = new List<Ennemis>();

            // Création de la grille

            // Tant que i n'est pas egal a 101
            for (int i = 0; i < 101; i++)
            {
                // Positionner le curseur tout en haut de la console
                Console.CursorTop = 0;

                // Si i est divisible par 6
                if (i % 6 == 0)
                {
                    // Tant que j n'est pas égal a 27
                    for (int j = 0; j < 27; j++)
                    {
                        // Positionne le curseur de l'axe des X en fonction de i et écrit les délimitations de la grille de jeu
                        Console.CursorLeft = i;
                        Console.WriteLine("‖");
                    }
                }
            }
             
            // Instancie un joueur
            Player player = new Player(50, 25, 8);

            // Instaciation de 10 obstacles avec des propriétés différentes
            Obstacles o1 = new Obstacles(3, 1, 1);
            Obstacles o2 = new Obstacles(9, 1, 2);
            Obstacles o3 = new Obstacles(15, 1, 3);
            Obstacles o4 = new Obstacles(21, 1, 4);
            Obstacles o5 = new Obstacles(27, 1, 5);
            Obstacles o6 = new Obstacles(33, 1, 6);
            Obstacles o7 = new Obstacles(39, 1, 7);
            Obstacles o8 = new Obstacles(45, 1, 8);
            Obstacles o9 = new Obstacles(51, 1, 9);
            Obstacles o10 = new Obstacles(57, 1, 10);

            // Ajout de ces 10 obstacles dans une liste des obstacles
            obstacles.Add(o1);
            obstacles.Add(o2);
            obstacles.Add(o3);
            obstacles.Add(o4);
            obstacles.Add(o5);
            obstacles.Add(o6);
            obstacles.Add(o7);
            obstacles.Add(o8);
            obstacles.Add(o9);
            obstacles.Add(o10);

            // Instaciation de 10 ennemis avec des propriétés différentes
            Ennemis e1 = new Ennemis(3, 0, 1);
            Ennemis e2 = new Ennemis(9, 0, 2);
            Ennemis e3 = new Ennemis(15, 0, 3);
            Ennemis e4 = new Ennemis(21, 0, 4);
            Ennemis e5 = new Ennemis(27, 0, 5);
            Ennemis e6 = new Ennemis(33, 0, 6);
            Ennemis e7 = new Ennemis(39, 0, 7);
            Ennemis e8 = new Ennemis(45, 0, 8);
            Ennemis e9 = new Ennemis(51, 0, 9);
            Ennemis e10 = new Ennemis(57, 0, 10);

            // Ajout de ces 10 ennemis dans une liste des ennemis
            ennemis.Add(e1);
            ennemis.Add(e2);
            ennemis.Add(e3);
            ennemis.Add(e4);
            ennemis.Add(e5);
            ennemis.Add(e6);
            ennemis.Add(e7);
            ennemis.Add(e8);
            ennemis.Add(e9);
            ennemis.Add(e10);

            do
            {
                // Pour chaque obstacles dans la liste d'obstacles
                foreach (Obstacles o in obstacles)
                {
                    // Positionne le curseur à la position de l'obstacle et efface cet obstacle
                    Console.SetCursorPosition(o.X, o.Y);
                    Console.Write(' ');

                    // Si la position Y de l'obstacle est divisible par 2
                    if (o.Y % 2 == 0)
                    {
                        // Si la colonne dans laquelle se trouve l'obstacle est inférieure à 16 ET que l'obstacle est visible
                        if (o.Column < 16 && o.Visible == true)
                        {
                            // Déplace l'obstacle de la valeur de speedx vers la droite et met à jour le numéro de la colonne
                            o.X += speedx;
                            o.Column++;
                        }
                        else if (o.Column >= 16 && o.Visible == true) // Si la colonne dans laquelle se trouve l'obstacle est supérieure ou égale à 16 ET que l'obstacle est visible
                        {
                            // Déplace l'obstacle de la valeur de speedy vers le bas
                            o.Y += speedy;
                        }
                        else if (o.Visible == false) // Si l'obstacle n'est pas visible
                        {
                            // Déplacer les obstacles sur le côtés pour que ça ne gêne pas le reste du jeu
                            o.X = 100;
                            o.Y = 0;
                        }
                    }
                    else // Si aucune des conditions au dessus ne sont respectées
                    {
                        // Si la colonne qui contient l'obstacle est supérieure à 1 ET que l'obstacle est visible
                        if (o.Column > 1 && o.Visible == true)
                        {
                            // Déplacer l'obstacle de la valeur de speedx vers la gauche et mettre à jour la colonne
                            o.X -= speedx;
                            o.Column--;
                        }
                        else if (o.Column <= 1 && o.Visible == true) // Si la colonne de l'obstacle est inférieure ou égale à 1 ET que l'obstacle est visible
                        {
                            // Déplacer l'obstacle de la valeur de speedy vers le bas
                            o.Y += speedy;
                        }
                        else if (o.Visible == false) // Si l'obstacle est invisible
                        {
                            // Déplacer les obstacles sur le côtés pour que ça ne gêne pas le reste du jeu
                            o.X = 100;
                            o.Y = 0;
                        }
                    }
                }

                // Pour chaque ennemis dans la liste des ennemis
                foreach (Ennemis e in ennemis)
                {
                    // Positionne le curseur à l'emplacement de l'ennemi et l'efface
                    Console.SetCursorPosition(e.X, e.Y);
                    Console.Write(' ');

                    // Si la valeur de Y de l'ennemi est divisible par 2
                    if (e.Y % 2 == 0)
                    {
                        // Si la colonne de l'ennemi est inférieure à 16 ET que l'ennemi est visible
                        if (e.Column < 16 && e.Visible == true)
                        {
                            // Déplacer l'ennemi de la valeur de speedx vers la gauche et mettre à jour la colonne
                            e.X += speedx;
                            e.Column++;
                        }
                        else if (e.Column >= 16 && e.Visible == true) // Si la colonne de l'ennemi est supérieure ou égale à 16 ET que l'obstacle est visible
                        {
                            // Déplacer l'enemmi de la valeur de speedy vers le bas
                            e.Y += speedy;
                        }
                        else if (e.Visible == false) // Si l'ennemi est invisible
                        {
                            // Déplacer les ennemis sur le côtés pour que ça ne gêne pas le reste du jeu
                            e.X = 100;
                            e.Y = 0;
                        }
                    }
                    else // Si aucune des conditions au dessus ne sont respectées
                    {
                        // Si la colonne dans laquelle est positionné l'ennemi est supérieure à 1 ET que l'ennemi est visible
                        if (e.Column > 1 && e.Visible == true)
                        {
                            // Déplacer l'ennemi de la valeur de speedx vers la gauche et mettre à jour la colonne
                            e.X -= speedx;
                            e.Column--;
                        }
                        else if (e.Column <= 1 && e.Visible == true) // Si la colonne de l'ennemi est inférieure ou égale à 1 ET que l'obstacle est visible
                        {
                            // Déplacer l'enemmi de la valeur de speedy vers le bas
                            e.Y += speedy;
                        }
                        else if (e.Visible == false) // Si l'ennemi est invisible
                        {
                            // Déplacer les ennemis sur le côtés pour que ça ne gêne pas le reste du jeu
                            e.X = 100;
                            e.Y = 0;
                        }
                    }
                }

                // Dessine le projectile à la nouvelle position

                // Si la position Y de l'obstacle est inférieure ou égale à 24
                if (o10.Y <= 24)
                {
                    // Redessine l'ennemi avec les nouvelles positions données 
                    Console.SetCursorPosition(o10.X, o10.Y);
                    Console.Write('_');
                }

                if (Console.KeyAvailable) // vérifie s'il y a une touche pressée sans bloquer
                {
                    // Identifie la touche pressée
                    var keyInfo = Console.ReadKey(true);
                    if (keyInfo.Key == ConsoleKey.LeftArrow) player.MoveLeft(); // Si la touche pressée est la flèche de gauche le vaisseau se déplace vers la gauche
                    if (keyInfo.Key == ConsoleKey.RightArrow) player.MoveRight(); // Si la touche pressée est la flèche de droite le vaisseau se déplace vers la droite
                    if (keyInfo.Key == ConsoleKey.Spacebar) // Si la touche pressée est la barre espace
                    {
                        // Pour chaque obstacle dans la liste d'obstacles
                        foreach (Obstacles o in obstacles)
                        {
                            // Si l'obstacle est visible
                            if (o.Visible == true)
                            {
                                // Positionne le curseur à la nouvelle position de l'obstacle et dessine l'obstacle
                                Console.SetCursorPosition(o.X, o.Y);
                                Console.Write('_');
                            }
                        }
                        
                        // Pour chaque ennemis dans la liste d'ennemis
                        foreach (Ennemis e in ennemis) 
                        {
                            // Si l'ennemi est visible
                            if (e.Visible == true)
                            {
                                // Positionne le curseur à la nouvelle position de l'obstacle et le dessine
                                Console.SetCursorPosition(e.X, e.Y);
                                Console.Write('@');
                            }
                        }
                        // Créée un nouveau projectile
                        Projectile pro = new Projectile(player.X + 1, player.Y - 1, obstacles, ennemis, projectiles, points, ennemynbr);

                        // Affiche le score après le tir
                        points.AfficherScore();

                        // Ajoute le tir à la liste des projectiles
                        projectiles.Add(pro);
                    }
                }

                // Pour chaque obstacles dans la liste des obstacles
                foreach (Obstacles o in obstacles)
                {
                    // Si la position Y de l'obstacle est inférieure ou égale à 24 ET que l'obstacle est visible
                    if (o.Y <= 24 && o.Visible == true)
                    {
                        // Positionne le curseur à la nouvelle position de l'obstacle et le dessine
                        Console.SetCursorPosition(o.X, o.Y);
                        Console.Write('_');
                    }
                    else if (o.Y > 24 && o.Y == player.Y && o.Visible == true || points.Points == 200) // (Si la position Y est de l'obstacle est supérieure à 24 ET égale à la position Y du joueur ET que l'obstacle est visible) OU que le score du joueur à atteint 200 (Score maximal)
                    {
                        // Si le score du joueur est égale à 200
                        if (points.Points == 200)
                        {
                            // L'obstacle devient invisible
                            o.Visible = false;

                            // Affiche l'écran de victoire
                            ShowVictory(points.Points);

                            // Dans une intervalle de 1 milliseconde
                            Thread.Sleep(1);
                        }
                        else // Si la condition ci dessus n'est pas remplie
                        {
                            // L'obstacle devient invisible
                            o.Visible = false;

                            // Affiche l'interface de défaite
                            ShowVictory (points.Points);

                            // Dans une intervalle de 1 milliseconde
                            Thread.Sleep(1);
                        }
                    }

                    if (Console.KeyAvailable) // vérifie s'il y a une touche pressée sans bloquer
                    {
                        // Identifie la touche pressée
                        var keyInfo = Console.ReadKey(true);
                        if (keyInfo.Key == ConsoleKey.LeftArrow) player.MoveLeft(); // Si la touche pressée est la flèche de gauche, le vaisseau du joueur va se déplacer vers la gauche
                        if (keyInfo.Key == ConsoleKey.RightArrow) player.MoveRight(); // Si la touche pressée est la flèche de droite, le vaisseau du joueur va se déplacer vers la droite
                    }
                }

                // Pour chaque ennemis dans la liste des ennemis
                foreach (Ennemis e in ennemis)
                {
                    // Si la position Y de l'ennemi est inférieure ou égale à 24 ET que l'ennemi est visible
                    if (e.Y <= 24 && e.Visible == true)
                    {
                        // Positionne le curseur à la nouvelle position de l'ennemi et dessine l'ennemi
                        Console.SetCursorPosition(e.X, e.Y);
                        Console.Write('@');
                    }
                    else if (e.Y > 24 && e.Y == player.Y && e.Visible == true || points.Points == 200) // (Si la position Y de l'ennemi est supérieure à 24 ET égale à la position Y du joueur ET que l'ennemi est visible ) OU que le score du joueur atteint 200 points (Sore maximal)
                    {
                        // Si le score du joueur est égale à 200
                        if (points.Points == 200)
                        {
                            // L'ennemi devient invisible
                            e.Visible = false;

                            // Affiche l'écran de victoire
                            ShowVictory(points.Points);

                            // Dans une intervalle de 1 milliseconde
                            Thread.Sleep(1);
                        }
                        else // Si la condition ci dessus n'est pas remplie
                        {
                            // L'ennemi devient invisible
                            e.Visible = false;

                            // Affiche l'interface de défaite
                            ShowGameOver(points.Points);

                            // Dans une intervalle de 1 milliseconde
                            Thread.Sleep(1);
                        }
                    }

                    if (Console.KeyAvailable) // vérifie s'il y a une touche pressée sans bloquer
                    {
                        // Identifie la touche pressée
                        var keyInfo = Console.ReadKey(true);
                        if (keyInfo.Key == ConsoleKey.LeftArrow) player.MoveLeft(); // Si la touche pressée est égale à la flèche de gauche, le vaisseau du joueur va se déplacer vers la gauche en fonction de la méthode "MoveLeft"
                        if (keyInfo.Key == ConsoleKey.RightArrow) player.MoveRight();// Si la touche pressée est égale à la flèche de droite, le vaisseau du joueur va se déplacer vers la droite en fonction de la méthide "MoveRight"
                    }
                }

                // Dans une intervalle de 100 millisecondes
                Thread.Sleep(100);

            } while (infini == 0); // Tant que la variable intervalle est égale à 0 (Toujours jusqu'à une victoire ou une défaite)
            Console.ReadLine();
        }

        /// <summary>
        /// Méthode qui va afficher l'interface de la défaite lorsque le joueur perd
        /// </summary>
        /// <param name="points"> Variable qui va contenir le score du joueur </param>
        public static void ShowGameOver(int points)
        {
            // Reinitialise l'interface de la console
            Console.Clear();

            // Initialise la couleur d'écriture en rouge
            Console.ForegroundColor = ConsoleColor.Red;

            // Affiche le message lors de la défaite (Généré avec de l'IA)
            Console.WriteLine("\n\n");
            Console.WriteLine("  ╔═════════════════════════════════════════╗");
            Console.WriteLine("  ║                                         ║");
            Console.WriteLine("  ║     ██████╗  █████╗ ███╗   ███╗███████╗ ║");
            Console.WriteLine("  ║    ██╔════╝ ██╔══██╗████╗ ████║██╔════╝ ║");
            Console.WriteLine("  ║    ██║  ███╗███████║██╔████╔██║█████╗   ║");
            Console.WriteLine("  ║    ██║   ██║██╔══██║██║╚██╔╝██║██╔══╝   ║");
            Console.WriteLine("  ║    ╚██████╔╝██║  ██║██║ ╚═╝ ██║███████╗ ║");
            Console.WriteLine("  ║     ╚═════╝ ╚═╝  ╚═╝╚═╝     ╚═╝╚══════╝ ║");
            Console.WriteLine("  ║                                         ║");
            Console.WriteLine("  ║     ██████╗ ██╗   ██╗███████╗██████╗    ║");
            Console.WriteLine("  ║    ██╔═══██╗██║   ██║██╔════╝██╔══██╗   ║");
            Console.WriteLine("  ║    ██║   ██║██║   ██║█████╗  ██████╔╝   ║");
            Console.WriteLine("  ║    ██║   ██║╚██╗ ██╔╝██╔══╝  ██╔══██╗   ║");
            Console.WriteLine("  ║    ╚██████╔╝ ╚████╔╝ ███████╗██║  ██║   ║");
            Console.WriteLine("  ║     ╚═════╝   ╚═══╝  ╚══════╝╚═╝  ╚═╝   ║");
            Console.WriteLine("  ║                                         ║");
            Console.WriteLine("  ╚═════════════════════════════════════════╝");
            Console.WriteLine("\n\n");

            // Affiche le score du joueur
            string scoreText = $"SCORE FINAL : {points}";
            int padding = (44 - scoreText.Length) / 2;
            Console.WriteLine(new string(' ', padding) + scoreText);
            Console.WriteLine("\n");

            // Reinitialise la couleur d'écriture en blanc
            Console.ResetColor();
        }

        /// <summary>
        /// Méthode qui va afficher l'interface de victoire lorsque le joueur gagne
        /// </summary>
        /// <param name="points"> Variable qui va contenir le score du joueur </param>
        public static void ShowVictory(int points)
        {
            // Reinitialise l'interface de la console
            Console.Clear();

            // Initialise la couleur d'écriture en vert
            Console.ForegroundColor = ConsoleColor.Green;

            // Affiche le message de victoire (Généré avec de l'IA)
            Console.WriteLine("\n\n");
            Console.WriteLine("  ╔════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("  ║                                                                ║");
            Console.WriteLine("  ║    ██╗   ██╗██╗ ██████╗████████╗ ██████╗ ██╗██████╗ ███████╗   ║");
            Console.WriteLine("  ║    ██║   ██║██║██╔════╝╚══██╔══╝██╔═══██╗██║██╔══██╗██╔════╝   ║");
            Console.WriteLine("  ║    ██║   ██║██║██║        ██║   ██║   ██║██║██████╔╝█████╗     ║");
            Console.WriteLine("  ║    ╚██╗ ██╔╝██║██║        ██║   ██║   ██║██║██╔══██╗██╔══╝     ║");
            Console.WriteLine("  ║     ╚████╔╝ ██║╚██████╗   ██║   ╚██████╔╝██║██║  ██║███████╗   ║");
            Console.WriteLine("  ║      ╚═══╝  ╚═╝ ╚═════╝   ╚═╝    ╚═════╝ ╚═╝╚═╝  ╚═╝╚══════╝   ║");
            Console.WriteLine("  ║                                                                ║");
            Console.WriteLine("  ║              FÉLICITATIONS !                                   ║");
            Console.WriteLine("  ║                                                                ║");
            Console.WriteLine("  ╚════════════════════════════════════════════════════════════════╝");
            Console.WriteLine("\n");

            // Affiche le score du joueur
            string scoreText = $"SCORE FINAL : {points}";
            int padding = (44 - scoreText.Length) / 2;
            Console.WriteLine(new string(' ', padding) + scoreText);
            Console.WriteLine("\n");

            // Reinitialise la couleur d'écriture en blanc
            Console.ResetColor();
        }
    }
}



