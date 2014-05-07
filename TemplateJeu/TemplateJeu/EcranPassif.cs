#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using TemplateJeu.MoteurJeu;
#endregion

namespace TemplateJeu
{
    /// <summary>
    /// Classe abstraite "Ecran Passif", ne peut être instanciée.
    /// Sert de moule à la création d'écran qui ne possèdent aucun bouton et curseur.
    /// L'écran passera de lui-même lors de, par exemple, l'appui sur un touche du clavier, la fin d'un timer (par défaut),
    /// la fin d'une animation...
    /// </summary>
    abstract class EcranPassif : Ecran
    {

        ///////////// Attributs
        private double timer;
        private double valeurChangementEcran;


        //////////// Constructeur
        public EcranPassif(string nom, Rectangle position, string design, double valChangement = 20)
            : base(nom,position,design)
        {
            timer = 0;
            if (valChangement < 20) { valChangement = 20; }
            valeurChangementEcran = valChangement;
        }


        /////////////  Accesseurs + Mutateurs
        public void setTimer(double valeur)
        {
            timer = valeur;
        }
        public double getTimer()
        {
            return timer;
        }
        public double getValMaxTimer()
        {
            return valeurChangementEcran;
        }


        /////////////  Méthodes XNA
        override public void Update()
        {
            base.Update();
            changeEcran();
        }
        override public void Draw()
        {
            base.Draw();
        }


        /////////////  Méthodes dédiées

        //Méthodes à redéfinir: définira l'action qui produira un changement d'écran. Par exemple, l'appuie sur une touche
        abstract public void changeEcran();

    }
}
