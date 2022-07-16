using System.Collections.Generic;
using Proyecto_de_Programacion_II_Marco_Randy;


namespace Domino
{
    public class Matrix<T> : ITable<T, Ficha<T>[,]>
    {
        public List<Ficha<T>> Fichas {get; }
        public Ficha<T>[,] FichasTable {get; }
        public int Count {get; set; }
        public (int, int) MarkLeft {get; set; }
        public (int, int) MarkRight {get; set; }
        public T ValLeft {get; set; }
        public T ValRight {get; set; }

        public Matrix(List<Ficha<T>> fichas)
        {
            Fichas = fichas;
            FichasTable = new Ficha<T>[13, 13];
            MarkLeft = (6, 6);
            MarkRight = (6, 6);
            Count = 0;
        }

        public void Create(Values<T> Transalator, int points)
        {
            Fichas.Clear();

            for (int i = 0; i <= points; i++)
            {
                for (int j = i; j <= points; j++)
                {
                    Fichas.Add(new Ficha<T>(Transalator.Key[i], Transalator.Key[j], Transalator));                    
                }
            }
        }
        public void Where((Ficha<T>, T) selection)
        {
            if (FichasTable[MarkLeft.Item1, MarkLeft.Item2] == null)
            {
                FichasTable[MarkLeft.Item1, MarkLeft.Item2] = selection.Item1;
                ValLeft = selection.Item1.LeftImg;
                ValRight = selection.Item1.RightImg;
                MainWindow.Ficha = new Grafica(selection.Item1.LeftImg.ToString(), selection.Item1.RightImg.ToString(), MarkLeft);
            }

            else if (selection.Item2.Equals(ValLeft))
            {
                MovLeft();

                if(0 == (MarkLeft.Item1 % 2))
                {
                    if (selection.Item1.RightImg.Equals(ValLeft))
                    {
                        FichasTable[MarkLeft.Item1, MarkLeft.Item2] = selection.Item1;
                        ValLeft = selection.Item1.LeftImg;
                    }
                    else
                    {
                        selection.Item1.Turn();
                        FichasTable[MarkLeft.Item1, MarkLeft.Item2] = selection.Item1;
                        ValLeft = selection.Item1.LeftImg;                   
                    }
                }
                else
                {
                    if (selection.Item1.LeftImg.Equals(ValLeft))
                    {
                        FichasTable[MarkLeft.Item1, MarkLeft.Item2] = selection.Item1;
                        ValLeft = selection.Item1.RightImg;
                    }
                    else
                    {
                        selection.Item1.Turn();
                        FichasTable[MarkLeft.Item1, MarkLeft.Item2] = selection.Item1;
                        ValLeft = selection.Item1.RightImg;                   
                    }
                }   
                MainWindow.Ficha = new Grafica(selection.Item1.LeftImg.ToString(), selection.Item1.RightImg.ToString(), MarkLeft);
            }

            else
            {
                MovRight();

                if(0 == (MarkRight.Item1 % 2))
                {
                    if (selection.Item1.LeftImg.Equals(ValRight))
                    {   
                        FichasTable[MarkRight.Item1, MarkRight.Item2] = selection.Item1;
                        ValRight = selection.Item1.RightImg;
                    }
                    else
                    {
                        selection.Item1.Turn();
                        FichasTable[MarkRight.Item1, MarkRight.Item2] = selection.Item1;
                        ValRight = selection.Item1.RightImg;
                    } 
                }
                else
                {
                    if (selection.Item1.RightImg.Equals(ValRight))
                    {   
                        FichasTable[MarkRight.Item1, MarkRight.Item2] = selection.Item1;
                        ValRight = selection.Item1.LeftImg;
                    }
                    else
                    {
                        selection.Item1.Turn();
                        FichasTable[MarkRight.Item1, MarkRight.Item2] = selection.Item1;
                        ValRight = selection.Item1.LeftImg;
                    } 
                }
                MainWindow.Ficha = new Grafica(selection.Item1.LeftImg.ToString(), selection.Item1.RightImg.ToString(), MarkRight);
            }

            Count++;
        }
        void MovLeft()
        {
            if (Validation(MarkLeft.Item2 - 1) && FichasTable[MarkLeft.Item1, MarkLeft.Item2 - 1] == null)
            {
                MarkLeft = (MarkLeft.Item1, MarkLeft.Item2 - 1);
            }
            else if (Validation(MarkLeft.Item2 + 1) && FichasTable[MarkLeft.Item1, MarkLeft.Item2 + 1] == null)
            {
                MarkLeft = (MarkLeft.Item1, MarkLeft.Item2 + 1);
            }
            else
            {
                MarkLeft = (MarkLeft.Item1 + 1, MarkLeft.Item2);
            }
        }
        void MovRight()
        {
            if (Validation(MarkRight.Item2 + 1) && FichasTable[MarkRight.Item1, MarkRight.Item2 + 1] == null)
            {
                MarkRight = (MarkRight.Item1, MarkRight.Item2 + 1);
            }
            else if (Validation(MarkRight.Item2 - 1) && FichasTable[MarkRight.Item1, MarkRight.Item2 - 1] == null)
            {
                MarkRight = (MarkRight.Item1, MarkRight.Item2 - 1);
            }
            else
            {
                MarkRight = (MarkRight.Item1 - 1, MarkRight.Item2);
            }
        }
        bool Validation(int position)
        {
            if (position < 0 || position >= FichasTable.GetLength(1))
            {
                return false;
            }
            return true;
        }
        public void Reload(IPlayer<T>[] players)
        {
            foreach (var player in players)
            {
                for (int j = 0; j < player.Hand.Count; )
                {
                    Fichas.Add(player.Hand[j]);
                    player.Hand.Remove(player.Hand[j]);
                }
            }

            for (int i = 0; i < FichasTable.GetLength(0); i++)
            {
                for (int j = 0; j < FichasTable.GetLength(0); j++)
                {
                    if (FichasTable[i, j] != null)
                    {
                        Fichas.Add(FichasTable[i, j]);
                        FichasTable[i, j] = null;
                    }                    
                }               
            }

            Count = 0;
            MarkLeft = (6, 6);
            MarkRight = (6, 6);       
        }
    }

    public class SimpleTable<T> : ITable<T, List<Ficha<T>>>
    {
        public List<Ficha<T>> Fichas {get; }
        public List<Ficha<T>> FichasTable {get; }
        public int Count { get; set; }
        public (int, int) MarkLeft {get; set; }
        public (int, int) MarkRight {get; set; }
        public T ValLeft {get; set; }
        public T ValRight {get; set; }

        public SimpleTable(List<Ficha<T>> fichas, List<Ficha<T>> fichastable)
        {
            Fichas = fichas;
            FichasTable = fichastable;
            MarkLeft = (0, 0);
            MarkRight = (0, 0);
            Count = 0;
        }
        public void Create(Values<T> Transalator, int points)
        {
            Fichas.Clear();

            for (int i = 0; i <= points; i++)
            {
                for (int j = i; j <= points; j++)
                {
                    Fichas.Add(new Ficha<T>(Transalator.Key[i], Transalator.Key[j], Transalator));                    
                }
            }        
        }
        public void Where((Ficha<T>, T) selection)
        {
            if (FichasTable.Count == 0)
            {
                FichasTable.Add(selection.Item1);
                ValLeft = selection.Item1.LeftImg;
                ValRight = selection.Item1.RightImg;
            }
            
            else if (selection.Item2.Equals(ValLeft))
            {
                FichasTable.Insert(0, selection.Item1);
                ValLeft = selection.Item1.Concat(ValLeft);
            }

            else
            {
                FichasTable.Add(selection.Item1);
                ValRight = selection.Item1.Concat(ValRight);
            }

            Count = FichasTable.Count;
            MainWindow.Ficha = new Grafica(selection.Item1.LeftImg.ToString(), selection.Item1.RightImg.ToString(), MarkLeft);

        }
        public void Reload(IPlayer<T>[] players)
        {
            foreach (var player in players)
            {
                for (int j = 0; j < player.Hand.Count; )
                {
                    Fichas.Add(player.Hand[j]);
                    player.Hand.Remove(player.Hand[j]);
                }
            }

            for (int i = 0; i < FichasTable.Count; )
            {
                Fichas.Add(FichasTable[i]);
                FichasTable.Remove(FichasTable[i]);
            }

            Count = 0; 
        }
    }
}