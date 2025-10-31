using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_POO
{
    internal class Score
    {
        // Définition et initialisation de la variable qui contient le nombre de points du joueur
        private int _Points = 0;

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Score() 
        {
            // Positionne le curseur à la position donnée et écrit le score du joueur
            Console.SetCursorPosition(100, 10);
            Console.WriteLine("Votre Score : " + Points);
        }

        /// <summary>
        /// Méthode qui affiche le score du joueur
        /// </summary>
        public void AfficherScore()
        {
            // Positionne le curseur à la position donnée et écrit le score du joueur
            Console.SetCursorPosition(100, 10);
            Console.Write("Votre Score : " + Points);
        }

        /// <summary>
        /// Getter setter pour la variable _Points
        /// </summary>
        public int Points
        {
            get { return _Points; }
            set { _Points = value; }
        }
    }
}
