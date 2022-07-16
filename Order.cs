using System.Collections.Generic;
using Proyecto_de_Programacion_II_Marco_Randy;

namespace Domino
{
    public class ClassicOrd<T> : IOrder<T>
    {
        public int GenerateOrder(IPlayer<T>[] players, int prev)
        {
            return (prev + 1) % players.Length;
        }
    }

    public class MaximumOrd<T> : IOrder<T>
    {
        public int GenerateOrder(IPlayer<T>[] players, int prev)
        {
            bool[] passplayer = new bool[players.Length];
            for (int i = MainWindow.HistoryPlay.Count - 1; i >= 0; i--)
            {
                if (MainWindow.HistoryPlay[i])
                {
                    break;
                }

                int pass = MainWindow.HistoryIndex[i];
                passplayer[pass] = true;
            }

            int index = 0;
            int sum = 0;
            for (int i = 0; i < players.Length; i++)
            {
                if (passplayer[i])
                {
                    continue;
                }
                int tmp = 0;
                foreach (var item in players[i].Hand)
                {
                    tmp += item.Suma;
                }

                if (tmp > sum)
                {
                    sum = tmp;
                    index = i;
                }
            }

            return index;
        }
    }

    public class TurnPass<T> : IOrder<T>
    {
        public int GenerateOrder(IPlayer<T>[] players, int prev)
        {
            int pass = 0;

            for (int i = 0; i < MainWindow.HistoryPlay.Count; i++)
            {
                if (!MainWindow.HistoryPlay[i])
                {
                    pass++;
                }
            }

            if ((pass % 2) == 1)
            {
                return (prev - 1 + players.Length) % players.Length;
            }

            return (prev + 1) % players.Length;
        }
    }
}