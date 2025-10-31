using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Projet_POO
{
    internal class Projectile
    {
        // Définition des variables de la classe Projectiles

        /// <summary>
        /// Variable qui contient la position X du projectile
        /// </summary>
        private int _X;

        /// <summary>
        /// Variable qui contient la position Y du projectile
        /// </summary>
        private int _Y;

        /// <summary>
        /// Variable qui défini si le projectile est visible ou non
        /// </summary>
        private bool _Visible = true;

        /// <summary>
        /// Constructeur personnalisé
        /// </summary>
        /// <param name="x"> Variable qui contient la position X du projectile </param>
        /// <param name="y"> Variable qui contient la position Y du projectile </param>
        /// <param name="obstacleslist"> Liste qui contient tous les obstacles </param>
        /// <param name="enemyList"> Liste qui contient tous les ennemis </param>
        /// <param name="projectileList"> Liste qui contient tous les projectiles </param>
        /// <param name="points"> Variable qui contient et qui met a jour le nombre de points du joueur </param>
        public Projectile(int x, int y, List<Obstacles> obstacleslist, List<Ennemis> enemyList, List<Projectile> projectileList, Score points, int ennemis)
        {
            // Initialisation des variables
            int speed = 1;
            this._X = x;
            this._Y = y;
            this.Visible = true;

            do
            {
                // Si la position du projectile sur l'axe Y est supérieure ou égale à 0
               if (_Y >= 0)
                {
                    // Positionne le curseur à l'emplacement du projectile pours efface l'ancienne position
                    Console.SetCursorPosition(_X, _Y);
                    Console.Write(' ');
                }
                
                // Déplace le curseur de 1 vers le haut
                _Y -= speed;

                // Dessine le projectile à la nouvelle position

                // Si la position du projectile sur l'axe Y est supérieure ou égale à 0 ET que le projectile est visible
                if (_Y >= 0 && this.Visible == true) 
                {
                    // Se positionne à la nouvelle position et affiche le projectile
                    Console.SetCursorPosition(_X, _Y);
                    Console.Write('|');
                }
                
                // Pour chaque ennemis dans la liste des ennemis
                foreach (Ennemis enemy in enemyList)
                {
                    // Si la position X et la position Y d'un ennemi correspond aux positions X et Y du projectile ET que le projectile est visible
                    if (enemy.X == this.X && enemy.Y == this.Y && this.Visible == true)
                    {
                        // L'énemmi et le projectile devienent invisible
                        enemy.Visible = false;
                        this.Visible = false;
                        ennemis--;

                        // Le score du joueur augmente de 15
                        points.Points += 15;
                    }
                }

                // Pour chaque obstacles dans la liste des obstacles
                foreach (Obstacles obs in obstacleslist)
                {
                    // Si la position X et la position Y d'un obstacle correspond aux positions X et Y du projectile ET que le projectile est visible
                    if (obs.X == this.X && obs.Y == this.Y && this.Visible == true)
                    {
                        // L'obstacle et le projectile devienent invisible
                        obs.Visible = false;
                        this.Visible = false;

                        // Le score du joueur augmente de 5
                        points.Points += 5;
                    }
                }

                // Si la position Y du projectile est inférieure à 0 ET que le projectile est visible
                if (_Y < 0 && this.Visible == true)
                {
                    // Le projectile devient invisible
                    this.Visible = false;
                }
                 // Toutes ces informations se mettent à jour toutes les 25 millisecondes
                Thread.Sleep(25);

            } while (_Y >= 0 || this.Visible == true); // Répéter tant que le projectile n'a pas ateint le haut OU que le curseur les visible
        }

        /// <summary>
        /// Getter setter de la variable _X
        /// </summary>
        public int X
        {
            get { return _X; }
            set { _X = value; }
        }

        /// <summary>
        /// Getter setter de la variable _Y
        /// </summary>
        public int Y
        {
            get { return _Y; }
            set { _Y = value; }
        }

        /// <summary>
        /// Getter setter de la variable _Visible
        /// </summary>
        public bool Visible
        {
            get { return _Visible; }
            set { _Visible = value; }
        }
    }
}
