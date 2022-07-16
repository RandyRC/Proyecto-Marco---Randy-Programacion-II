using System.Collections.Generic;
using Proyecto_de_Programacion_II_Marco_Randy;

namespace Domino
{
    public class ClassicFG<T> : IFinishGame<T>
    {
        public int[] Points { get; }

        public ClassicFG(int length)
        {
            Points = new int[length];
        }
        public virtual void Adder(IPlayer<T>[] players, int winner)
        {
            int add = 0;

            for (int i = 0; i < players.Length; i++)
            {
                if (i != winner)
                {
                    foreach (var item in players[i].Hand)
                    {
                        add += item.Suma;
                    }
                }
            }

            Points[winner] += add;
        }
        public virtual void Finish(int max)
        {
            int index = -1;
            bool win = false;

            for (int i = 0; i < Points.Length; i++)
            {
                if (Points[i] >= max)
                {
                    index = i;
                    win = true;
                    break;
                }
            }

            if (win)
            {
                MainWindow.Action = MainWindow.StringFormation(index, false, false, win);
            }
        }
    }

    public class AdderFichaFG<T> : ClassicFG<T>
    {
        public AdderFichaFG(int length) : base(length) { }

        public override void Adder(IPlayer<T>[] players, int winner)
        {
            int add = 0;

            for (int i = 0; i < players.Length; i++)
            {
                if (i != winner)
                {
                    add += players[i].Hand.Count;
                }
            }

            Points[winner] += (add * 5);
            if (add == 0) Points[winner] += 5;
        }
    }

    public class AdderPassFG<T> : ClassicFG<T>
    {
        public AdderPassFG(int length) : base(length) { }

        public override void Adder(IPlayer<T>[] players, int winner)
        {
            int add = 1;

            for (int i = 0; i < MainWindow.HistoryIndex.Count; i++)
            {
                if (MainWindow.HistoryIndex[i] == winner && i != (MainWindow.HistoryIndex.Count - 1) && !MainWindow.HistoryPlay[i + 1])
                {
                    add++;
                }
            }

            Points[winner] += (add * 5);
        }
    }
}