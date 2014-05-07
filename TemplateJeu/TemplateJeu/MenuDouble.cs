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
    class MenuDouble : Menu
    {
        int[,] dispositionBn;
        int nbrColonne;
        int nbrLigne;

        public MenuDouble(string nom, Rectangle position, string design, int _nbrColonne, int _nbrLigne)
            : base(nom,position,design)
        {
            this.nbrColonne = _nbrColonne;
            this.nbrLigne = _nbrLigne;
            dispositionBn = new int[nbrColonne, nbrLigne];
            for (int i = 0; i < nbrColonne; i++)
                for (int j = 0; j < nbrLigne; j++)
                    dispositionBn[i, j] = 0;
            fillBnBox();
            fillListCurseurs();
        }

        public override void fillBnBox()
        {
            createBn("commencer", new Rectangle(100, 100, 50, 25), "commencer",0);
            createBn("option", new Rectangle(100, 150, 50, 25), "option", 0);
            createBn("commencer", new Rectangle(100, 200, 50, 25), "commencer", 0);
            createBn("option", new Rectangle(100, 250, 50, 25), "option", 0);
            createBn("option", new Rectangle(300, 150, 50, 25), "option", 1);
            createBn("commencer", new Rectangle(300, 200, 50, 25), "commencer", 1);
            createBn("option", new Rectangle(300, 250, 50, 25), "option", 1);
            createBn("option", new Rectangle(300, 300, 50, 25), "option", 1);
            createBn("commencer", new Rectangle(300, 400, 50, 25), "commencer", 1);
            createBn("option", new Rectangle(400, 250, 50, 25), "option", 2);
            createBn("option", new Rectangle(400, 300, 50, 25), "option", 2);
            createBn("commencer", new Rectangle(400, 400, 50, 25), "commencer",2);
            createBn("option", new Rectangle(400, 450, 50, 25), "option", 2);
        }

        private void createBn(string _design, Rectangle _position, string _nom, int indexColonne)
        {
            if (putBnInMatrix(indexColonne)==1)
                bnBox.Add(new Bouton( _design, _position, _nom));
        }

        private int putBnInMatrix(int indexColonne)
        {
            int i = 0;
            while (dispositionBn[indexColonne,i]==1 && i < nbrLigne)
            {
                i++;
            }
            if (i < nbrLigne)
            {
                dispositionBn[indexColonne, i] = 1;
                return 1;
            }
            else
                return 0;
        }

        public override void fillListCurseurs()
        {
            int indice = 12;
            listCurseurs.Add(new Curseur(MoteurDeJeu.InstanceMDJ.panelTextures[0], new Rectangle(bnBox[indice].getPosition().X, bnBox[indice].getPosition().Y, 30, 30), indice, -40, 0));
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
        
        /*private int[] DetectPositionInMatrix()
        {
            int[] position = new int[2];
            int indexLigne=0, indexColonne=0;
            for (int i = 0; i<listCurseurs[0].getIndice()+1; i++)
            {
                if (dispositionBn[indexColonne, indexLigne] != 1)
                {
                    indexColonne++;
                    indexLigne = 0;
                    i--;
                }
                else
                {
                    if (indexLigne >= nbrLigne - 1)
                    {
                        indexColonne++;
                        indexLigne = 0;
                    }
                    else
                    {
                        indexLigne++;
                    }
                }
            }
            position[0] = indexColonne;
            position[1] = indexLigne;
            return position;
        }*/

         private int[] DetectPositionInMatrix()
         {
             int[] position = new int[2];
             int indexLigne = 0, indexColonne = 0;
             int compteur = 0;
             do
             {
                 if (dispositionBn[indexColonne, indexLigne] == 1)
                 {
                     compteur++;
                     if (compteur < listCurseurs[0].getIndice()+1)
                        indexLigne++;
                 }
                 if (indexLigne >= nbrLigne - 1 || dispositionBn[indexColonne, indexLigne] == 0)
                 {
                     //if (dispositionBn[indexColonne, indexLigne] != 0)
                     indexColonne++;
                     indexLigne = 0;
                 }
             } while (compteur < listCurseurs[0].getIndice()) ;
             position[0] = indexColonne;
             position[1] = indexLigne;
             return position;
         }

        private int getLastIdListOfAColumn(int colonne)
        {
            int compteur = 0;
            int indexLigne = 0, indexColonne = 0;
            while ( indexColonne < colonne )
            {
                if (dispositionBn[indexColonne, indexLigne] == 1 && indexLigne<nbrLigne)
                {
                    indexLigne++;
                    if (compteur < listCurseurs[0].getIndice() + 1)
                        compteur++;
                }
                else
                {
                    indexColonne++;
                    indexLigne = 0;
                }
            }
            while (indexLigne < nbrLigne && dispositionBn[colonne, indexLigne] == 1)
            {
                    indexLigne++;
                    compteur++;
            }
            return compteur-1;
        }

        private int getTheLastBnOfAColumn(int colonne)
        {
            int compteur = 0;
            int indexLigne = 0, indexColonne = 0;
            while (indexColonne < colonne)
            {
                if (dispositionBn[indexColonne, indexLigne] == 1 && indexLigne < nbrLigne)
                {
                    indexLigne++;
                    if (compteur < listCurseurs[0].getIndice() + 1)
                        compteur++;
                }
                else
                {
                    indexColonne++;
                    indexLigne = 0;
                }
            }
            while (indexLigne < nbrLigne && dispositionBn[colonne, indexLigne] == 1)
            {
                indexLigne++;
                compteur++;
            }
            return indexLigne-1;
        }

        private int getTheIdListOfTheFirstOfAColomn(int colonne)
        {
            int compteur = 0;
            int indexLigne = 0, indexColonne = 0;
            while (indexColonne < colonne)
            {
                if (dispositionBn[indexColonne, indexLigne] == 1 && indexLigne < nbrLigne)
                {
                    indexLigne++;
                    if (compteur < listCurseurs[0].getIndice() + 1)
                        compteur++;
                }
                else
                {
                    indexColonne++;
                    indexLigne = 0;
                }
            }
            return compteur;
        }

        public override void navigation()
        {
            // Navigation vers le haut en appuyant en haut
            if (MoteurDeJeu.InstanceMDJ.kbState.IsKeyDown(MoteurDeJeu.InstanceMDJ.panelTouches[0].ToucheHaut)
                && MoteurDeJeu.InstanceMDJ.OldKbState.IsKeyUp(MoteurDeJeu.InstanceMDJ.panelTouches[0].ToucheHaut))
            {
                int[] position = DetectPositionInMatrix();
                if (position[1] > 0) // le curseur n'est pas sur la première ligne de la colonne
                {
                    listCurseurs[0].setIndice(listCurseurs[0].getIndice() - 1);
                }
                else
                {
                    listCurseurs[0].setIndice(getLastIdListOfAColumn(position[0]));
                }
                listCurseurs[0].setPosition(bnBox[listCurseurs[0].getIndice()].getPosition().X + listCurseurs[0].getDecalageX(),
                                            bnBox[listCurseurs[0].getIndice()].getPosition().Y + listCurseurs[0].getDecalageY());
            }
        
            // Navigation vers le bas en appuyant en bas
            else if (MoteurDeJeu.InstanceMDJ.kbState.IsKeyDown(MoteurDeJeu.InstanceMDJ.panelTouches[0].ToucheBas)
                && MoteurDeJeu.InstanceMDJ.OldKbState.IsKeyUp(MoteurDeJeu.InstanceMDJ.panelTouches[0].ToucheBas))
            {
                int[] position = DetectPositionInMatrix();
                if (position[1] < getTheLastBnOfAColumn(position[0]))
                {
                    listCurseurs[0].setIndice(listCurseurs[0].getIndice() + 1);
                }
                else
                {
                    listCurseurs[0].setIndice(getTheIdListOfTheFirstOfAColomn(position[0]));
                }
                listCurseurs[0].setPosition(bnBox[listCurseurs[0].getIndice()].getPosition().X + listCurseurs[0].getDecalageX(),
                                            bnBox[listCurseurs[0].getIndice()].getPosition().Y + listCurseurs[0].getDecalageY());
            }
            /*
            if (MoteurDeJeu.InstanceMDJ.kbState.IsKeyDown(MoteurDeJeu.InstanceMDJ.panelTouches[0].ToucheGauche)
                && MoteurDeJeu.InstanceMDJ.OldKbState.IsKeyUp(MoteurDeJeu.InstanceMDJ.panelTouches[0].ToucheGauche))
            {
            }
            else if (MoteurDeJeu.InstanceMDJ.kbState.IsKeyDown(MoteurDeJeu.InstanceMDJ.panelTouches[0].ToucheDroite)
                && MoteurDeJeu.InstanceMDJ.OldKbState.IsKeyUp(MoteurDeJeu.InstanceMDJ.panelTouches[0].ToucheDroite))
            {
            }

            if ((MoteurDeJeu.InstanceMDJ.kbState.IsKeyDown(MoteurDeJeu.InstanceMDJ.panelTouches[0].ToucheOK)
                && MoteurDeJeu.InstanceMDJ.OldKbState.IsKeyUp(MoteurDeJeu.InstanceMDJ.panelTouches[0].ToucheOK)))
            {
                bnBox[listCurseurs[0].getIndice()].onClick();
            }*/
        }
    }
}
