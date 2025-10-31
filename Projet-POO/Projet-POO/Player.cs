using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Projet_POO
{
    internal class Player
    {
        // Définition des variables de la classe Player

        /// <summary>
        /// Variable qui contient la position X du joueur
        /// </summary>
        private int _X;

        /// <summary>
        /// Variable qui contient la position Y du joueur
        /// </summary>
        private int _Y;

        /// <summary>
        /// Variable qui contient le numéro de la colonne dans laquelle le joueur se trouve
        /// </summary>
        private int _Column;

        /// <summary>
        /// Constructeur personnalisé
        /// </summary>
        /// <param name="x"> Variable qui contient la position X du joueur </param>
        /// <param name="y"> Variable qui contient la position Y du joueur </param>
        public Player(int x, int y, int column)
        {
            // Initialisation des variables
            this._X = x;
            this._Y = y;
            this._Column = column;

            // Se positionne à la position de X et Y par rapport aux valeurs données lors de l'instanciation du joueur et écrit '/|\' à cette position
            Console.SetCursorPosition(x, y);
            Console.Write("/|\\");
        }

        /// <summary>
        /// Méthode qui va déplacer le vaisseau du joueur vers la gauche
        /// </summary>
        public void MoveLeft()
        {
            // Définition et initialisation de la variable qui défini de combien le vaisseau se déplacera
            int speed = 6;

            // Si le numéro de la colonne est supérieur à 0
            if (this._Column > 0)
            {
                // Positionne la curseur à la position du vaisseau afin de l'effacer
                Console.SetCursorPosition(this._X, this._Y);
                Console.Write("   ");

                // Déplace le vaisseau de la valeur de speed vers la gauche et met a jour le numéro de la colonne
                this._X -= speed;
                this._Column--;

                // Se positionne à cette nouvelle position afin de faire réapparaître le vaisseau
                Console.SetCursorPosition(this._X, this._Y);
                Console.Write("/|\\");
            }
        }

        /// <summary>
        /// Méthode qui va déplacer le vaisseau du joueur vers la droite
        /// </summary>
        public void MoveRight()
        {
            // Définition et initialisation de la variable qui défini de combien le vaisseau se déplacera
            int speed = 6;

            // Si le numéro de la colonne est en dessous de 15
            if (this._Column < 15)
            {
                // Positionne la curseur à la position du vaisseau afin de l'effacer
                Console.SetCursorPosition(this._X, this._Y);
                Console.Write("   ");

                // Déplace le vaisseau de la valeur de speed vers la droite et met a jour le numéro de la colonne
                this._X += speed;
                this._Column++;

                // Se positionne à cette nouvelle position afin de faire réapparaître le vaisseau
                Console.SetCursorPosition(this._X, this._Y);
                Console.Write("/|\\");
            }
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
    }
}

