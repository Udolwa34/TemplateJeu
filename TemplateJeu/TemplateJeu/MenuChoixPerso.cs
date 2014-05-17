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
    class MenuChoixPerso : MenuDouble
    {
        public MenuChoixPerso(string nom, Rectangle position, string design)
            : base(nom, position, design,2,4) // les deux int sont : nombre de colonnes , nombre de lignes
        {
            fillBnBox();
            fillListCurseurs();
        }

        public override void fillBnBox()
        {
            createBn("perso", new Rectangle(250, 75, 75, 75), "perso", 0);
            createBn("perso", new Rectangle(250, 175, 75, 75), "perso", 0);
            createBn("perso", new Rectangle(250, 275, 75, 75), "perso", 0);
            createBn("perso", new Rectangle(250, 375, 75, 75), "perso", 0);

            createBn("perso", new Rectangle(500, 75, 75, 75), "perso", 1);
            createBn("perso", new Rectangle(500, 175,75, 75), "perso", 1);
            createBn("perso", new Rectangle(500, 275,75, 75), "perso", 1);
            createBn("perso", new Rectangle(500, 375, 75, 75), "perso", 1);
        }

        public override void fillListCurseurs()
        {
            int indice = 0;
            listCurseurs.Add(new Curseur(MoteurDeJeu.InstanceMDJ.panelTextures[0], new Rectangle(bnBox[indice].getPosition().X, bnBox[indice].getPosition().Y, 30, 30), indice, -40, 0));
        }
    }
}
