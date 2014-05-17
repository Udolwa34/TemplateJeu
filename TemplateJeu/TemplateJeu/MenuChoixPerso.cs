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
        public MenuChoixPerso(string nom, Rectangle position, string design, int _nbrColonne, int _nbrLigne)
            : base(nom, position, design, _nbrColonne, _nbrLigne)
        {
            fillBnBox();
            fillListCurseurs();
        }

        public override void fillBnBox()
        {
            createBn("option", new Rectangle(50, 100, 50, 25), "option", 0);
            createBn("option", new Rectangle(50, 150, 50, 25), "option", 0);
            createBn("option", new Rectangle(50, 200, 50, 25), "option", 0);
            createBn("option", new Rectangle(50, 250, 50, 25), "option", 0);
            createBn("option", new Rectangle(50, 300, 50, 25), "option", 0);
            createBn("option", new Rectangle(50, 350, 50, 25), "option", 0);
            createBn("option", new Rectangle(50, 400, 50, 25), "option", 0);

            createBn("option", new Rectangle(125, 100, 50, 25), "option", 1);
            createBn("option", new Rectangle(125, 150, 50, 25), "option", 1);
            createBn("option", new Rectangle(125, 200, 50, 25), "option", 1);
            createBn("option", new Rectangle(125, 250, 50, 25), "option", 1);
            createBn("option", new Rectangle(125, 300, 50, 25), "option", 1);
            createBn("option", new Rectangle(125, 350, 50, 25), "option", 1);

            createBn("option", new Rectangle(200, 100, 50, 25), "option", 2);
            createBn("option", new Rectangle(200, 150, 50, 25), "option", 2);
            createBn("option", new Rectangle(200, 200, 50, 25), "option", 2);
            createBn("option", new Rectangle(200, 250, 50, 25), "option", 2);
            createBn("option", new Rectangle(200, 300, 50, 25), "option", 2);

            createBn("option", new Rectangle(275, 100, 50, 25), "option", 3);
            createBn("option", new Rectangle(275, 150, 50, 25), "option", 3);
            createBn("option", new Rectangle(275, 200, 50, 25), "option", 3);
            createBn("option", new Rectangle(275, 250, 50, 25), "option", 3);

            createBn("option", new Rectangle(350, 100, 50, 25), "option", 4);
            createBn("option", new Rectangle(350, 150, 50, 25), "option", 4);
            createBn("option", new Rectangle(350, 200, 50, 25), "option", 4);

            createBn("option", new Rectangle(425, 100, 50, 25), "option", 5);
            createBn("option", new Rectangle(425, 150, 50, 25), "option", 5);

            createBn("option", new Rectangle(500, 100, 50, 25), "option", 6);
            createBn("option", new Rectangle(500, 150, 50, 25), "option", 6);
            createBn("option", new Rectangle(500, 200, 50, 25), "option", 6);

            createBn("option", new Rectangle(575, 100, 50, 25), "option", 7);
            createBn("option", new Rectangle(575, 150, 50, 25), "option", 7);
            createBn("option", new Rectangle(575, 200, 50, 25), "option", 7);
            createBn("option", new Rectangle(575, 250, 50, 25), "option", 7);

            createBn("option", new Rectangle(650, 100, 50, 25), "option", 8);
            createBn("option", new Rectangle(650, 150, 50, 25), "option", 8);
            createBn("option", new Rectangle(650, 200, 50, 25), "option", 8);
            createBn("option", new Rectangle(650, 250, 50, 25), "option", 8);
            createBn("option", new Rectangle(650, 300, 50, 25), "option", 8);

            createBn("option", new Rectangle(725, 100, 50, 25), "option", 9);
            createBn("option", new Rectangle(725, 150, 50, 25), "option", 9);
            createBn("option", new Rectangle(725, 200, 50, 25), "option", 9);
            createBn("option", new Rectangle(725, 250, 50, 25), "option", 9);
            // createBn("option", new Rectangle(725, 300, 50, 25), "option", 9);
            //createBn("option", new Rectangle(725, 350, 50, 25), "option", 9);
        }

        public override void fillListCurseurs()
        {
            int indice = 8;
            listCurseurs.Add(new Curseur(MoteurDeJeu.InstanceMDJ.panelTextures[0], new Rectangle(bnBox[indice].getPosition().X, bnBox[indice].getPosition().Y, 30, 30), indice, -40, 0));
        }
    }
}
