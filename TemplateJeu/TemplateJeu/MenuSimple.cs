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
    abstract class MenuSimple : Menu
    {
        public MenuSimple(string nom, Rectangle position, string design)
            : base(nom,position,design)
        {
        }

        override public void Update()
        {
            base.Update();
            navigation();
        }
        override public void Draw()
        {
            base.Draw();
        }

        public override void navigation()
        {
            // Navigation vers le haut en appuyant à gauche ou en haut
            if ( ( MoteurDeJeu.InstanceMDJ.kbState.IsKeyDown(MoteurDeJeu.InstanceMDJ.panelTouches[0].ToucheHaut) 
                && MoteurDeJeu.InstanceMDJ.OldKbState.IsKeyUp(MoteurDeJeu.InstanceMDJ.panelTouches[0].ToucheHaut))
                ||
                (MoteurDeJeu.InstanceMDJ.kbState.IsKeyDown(MoteurDeJeu.InstanceMDJ.panelTouches[0].ToucheGauche) 
                && MoteurDeJeu.InstanceMDJ.OldKbState.IsKeyUp(MoteurDeJeu.InstanceMDJ.panelTouches[0].ToucheGauche))
               )
            {
                if (listCurseurs[0].getIndice() > 0)
                {
                    listCurseurs[0].setIndice(listCurseurs[0].getIndice() - 1);
                }
                else
                {
                    listCurseurs[0].setIndice(bnBox.Count - 1);
                }
                listCurseurs[0].setPosition(bnBox[listCurseurs[0].getIndice()].getPosition().X + listCurseurs[0].getDecalageX(),
                                            bnBox[listCurseurs[0].getIndice()].getPosition().Y + listCurseurs[0].getDecalageY());
            }

            // Navigation vers le haut en droite ou en bas
            else if ((MoteurDeJeu.InstanceMDJ.kbState.IsKeyDown(MoteurDeJeu.InstanceMDJ.panelTouches[0].ToucheBas)
                && MoteurDeJeu.InstanceMDJ.OldKbState.IsKeyUp(MoteurDeJeu.InstanceMDJ.panelTouches[0].ToucheBas))
                ||
                (MoteurDeJeu.InstanceMDJ.kbState.IsKeyDown(MoteurDeJeu.InstanceMDJ.panelTouches[0].ToucheDroite)
                && MoteurDeJeu.InstanceMDJ.OldKbState.IsKeyUp(MoteurDeJeu.InstanceMDJ.panelTouches[0].ToucheDroite))
               )
            {
                if (listCurseurs[0].getIndice() < bnBox.Count - 1)
                {
                    listCurseurs[0].setIndice(listCurseurs[0].getIndice() + 1);
                }
                else
                {
                    listCurseurs[0].setIndice(0);
                }
                listCurseurs[0].setPosition(bnBox[listCurseurs[0].getIndice()].getPosition().X + listCurseurs[0].getDecalageX(),
                                            bnBox[listCurseurs[0].getIndice()].getPosition().Y + listCurseurs[0].getDecalageY());

            }

            if ( ( MoteurDeJeu.InstanceMDJ.kbState.IsKeyDown(MoteurDeJeu.InstanceMDJ.panelTouches[0].ToucheOK) 
                && MoteurDeJeu.InstanceMDJ.OldKbState.IsKeyUp(MoteurDeJeu.InstanceMDJ.panelTouches[0].ToucheOK)))
            {
                bnBox[listCurseurs[0].getIndice()].onClick();
            }

        }

    }
}
