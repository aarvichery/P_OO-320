using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Projet_POO
{
    internal class Obstacles
    {
        // Définition des variables de la classe Obstacles

        /// <summary>
        /// Variable contenant le numéro de la colonne dans laquelle se trouve l'obstacle
        /// </summary>
        private int _Column;

        /// <summary>
        /// Variable qui contient la position X de l'obstacle
        /// </summary>
        private int _X;

        /// <summary>
        /// Variable qui contient la position Y de l'obstacle
        /// </summary>
        private int _Y;

        /// <summary>
        /// Variable qui détermine si l'obstacle est visible
        /// </summary>
        private bool _Visible = true;

        /// <summary>
        /// Constructeur personnalisé pour la classe obstacle
        /// </summary>
        /// <param name="x"> Variable qui contient la position X de l'obstacle </param>
        /// <param name="y"> Variable qui contient la position Y de l'onstacle </param>
        /// <param name="column"> Variable contenant le numéro de colonne dans laquelle se trouve l'obstacle </param>
        public Obstacles(int x, int y, int column)
        {
            // Initialisation des variables 
            this._X = x;
            this._Y = y;
            this._Column = column;

            // Se positionne à la position de X et Y par rapport aux valeurs données lors de l'instanciation des obstacles et écrit '_' à cette position
            Console.SetCursorPosition(_X, _Y);
            Console.Write('_');
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
        /// Getter setter de la variable _Column
        /// </summary>
        public int Column
        {
            get { return _Column; }
            set { _Column = value; }
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
