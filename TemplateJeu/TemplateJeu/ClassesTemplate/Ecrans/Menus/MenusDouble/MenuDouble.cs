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
    abstract class MenuDouble : Menu
    {
        int[,] matrice;
        int[] matrixData;
        int nbrColonne;
        int nbrLigne;

        public MenuDouble(string nom, Rectangle position, string design, int _nbrColonne, int _nbrLigne)
            : base(nom,position,design)
        {
            this.nbrColonne = _nbrColonne;
            this.nbrLigne = _nbrLigne;
            matrice = new int[_nbrColonne, _nbrLigne];
            for (int i = 0; i < nbrColonne; i++)
                for (int j = 0; j < nbrLigne; j++)
                    matrice[i, j] = 0;
            matrixData = new int[_nbrColonne];
            for (int i = 0; i < nbrColonne; i++)
                matrixData[i] = 0;
            
        }

        protected void createBn(string _design, Rectangle _position, string _nom, int indexColonne)
        {
            if (putBnInMatrix(indexColonne)==1)
                bnBox.Add(new Bouton( _design, _position, _nom));
        }

        private int putBnInMatrix(int indexColonne)
        {
            int i = 0;
            while (matrice[indexColonne,i]==1 && i < nbrLigne)
            {
                i++;
            }
            if (i < nbrLigne)
            {
                matrice[indexColonne, i] = 1;
                matrixData[indexColonne]++;
                return 1;
            }
            else
                return 0;
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
      
        private int[] DetectPositionInMatrix()
         {
             int[] position = new int[2];
             int indexLigne = 0, indexColonne = 0;
             int indice = listCurseurs[0].getIndice();
             int compteur = 0;
             do
             {
                 if (compteur+matrixData[indexColonne] <= indice)
                 {
                     compteur += matrixData[indexColonne];
                     indexColonne++;
                 }
                 else
                 {
                     indexLigne = indice - compteur;
                     compteur = indice;
                 }
             } while (compteur < listCurseurs[0].getIndice()) ;
             position[0] = indexColonne;
             position[1] = indexLigne;
             return position;
         }

        private int getLastIdListOfAColumn(int colonne)
        {
            int compteur = 0;
            compteur += matrixData[0] - 1;
            for (int i = 1; i <= colonne; i++)
            {
                compteur += matrixData[i];
            }
            return compteur;
        }
               
        private int getFirstIdListOfAColumn(int colonne)
        {
            int compteur = 0;
            if (colonne > 0)
                compteur += matrixData[0] - 1;
            else
                return 0;
            for (int i = 1; i < colonne; i++)
            {
                compteur += matrixData[i];
            }
            return compteur+1;
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
                if (position[1] < matrixData[position[0]]-1)
                {
                    listCurseurs[0].setIndice(listCurseurs[0].getIndice() + 1);
                }
                else
                {
                    listCurseurs[0].setIndice(getFirstIdListOfAColumn(position[0]));
                }
                listCurseurs[0].setPosition(bnBox[listCurseurs[0].getIndice()].getPosition().X + listCurseurs[0].getDecalageX(),
                                            bnBox[listCurseurs[0].getIndice()].getPosition().Y + listCurseurs[0].getDecalageY());
            }

            if (MoteurDeJeu.InstanceMDJ.kbState.IsKeyDown(MoteurDeJeu.InstanceMDJ.panelTouches[0].ToucheGauche)
                && MoteurDeJeu.InstanceMDJ.OldKbState.IsKeyUp(MoteurDeJeu.InstanceMDJ.panelTouches[0].ToucheGauche))
            {
                int[] position = DetectPositionInMatrix();
                if (position[0] > 0)// le curseur n'est pas sur la première colonne
                {
                    if ( matrixData[position[0]-1]>position[1])
                        listCurseurs[0].setIndice(listCurseurs[0].getIndice()-position[1]-(matrixData[position[0]-1]-position[1]));
                    else
                        listCurseurs[0].setIndice(getLastIdListOfAColumn(position[0]-1));
                }
                else
                {
                    if (matrixData[nbrColonne - 1] > position[1])
                        listCurseurs[0].setIndice(bnBox.Count - (matrixData[nbrColonne - 1] - position[1]));
                    else
                        listCurseurs[0].setIndice(getLastIdListOfAColumn(nbrColonne-1));
                }
                listCurseurs[0].setPosition(bnBox[listCurseurs[0].getIndice()].getPosition().X + listCurseurs[0].getDecalageX(),
                                            bnBox[listCurseurs[0].getIndice()].getPosition().Y + listCurseurs[0].getDecalageY());
            }
            else if (MoteurDeJeu.InstanceMDJ.kbState.IsKeyDown(MoteurDeJeu.InstanceMDJ.panelTouches[0].ToucheDroite)
                && MoteurDeJeu.InstanceMDJ.OldKbState.IsKeyUp(MoteurDeJeu.InstanceMDJ.panelTouches[0].ToucheDroite))
            {
                int[] position = DetectPositionInMatrix();
                if (position[0] < nbrColonne-1)// le curseur n'est pas sur la dernière colonne
                {
                    if (matrixData[position[0] + 1] > position[1])
                        listCurseurs[0].setIndice(listCurseurs[0].getIndice() + (matrixData[position[0]] - position[1]) + position[1]);
                    else
                        listCurseurs[0].setIndice(getLastIdListOfAColumn(position[0] + 1));
                }
                else
                {
                    listCurseurs[0].setIndice(position[1]);
                }
                listCurseurs[0].setPosition(bnBox[listCurseurs[0].getIndice()].getPosition().X + listCurseurs[0].getDecalageX(),
                                            bnBox[listCurseurs[0].getIndice()].getPosition().Y + listCurseurs[0].getDecalageY());
            }
            if ((MoteurDeJeu.InstanceMDJ.kbState.IsKeyDown(MoteurDeJeu.InstanceMDJ.panelTouches[0].ToucheOK)
                && MoteurDeJeu.InstanceMDJ.OldKbState.IsKeyUp(MoteurDeJeu.InstanceMDJ.panelTouches[0].ToucheOK)))
            {
                bnBox[listCurseurs[0].getIndice()].onClick();
            }
        }
    }
}
