using System.Collections.Generic;
using Proyecto_de_Programacion_II_Marco_Randy;

namespace Domino
{
    public class ClassicWP<T> : IWinnerPlay<T>
    {
        public int Revition(IPlayer<T>[] players)
        {
            int index = -1;
            int win = int.MaxValue;

            for (int i = 0; i < players.Length; i++)
            {
                int tmp = 0;
                if (players[i].Hand.Count == 0)
                {
                    index = i;
                    break;
                }

                foreach (var item in players[i].Hand)
                {
                    tmp += item.Suma;
                }

                if (tmp < win)
                {
                    win = tmp;
                    index = i;
                }
                else if (tmp == win)
                {
                    index = -1;
                }
            }

            MainWindow.Action = MainWindow.StringFormation(index, false, true, false);

            return index;
        }
    }

    public class FichaWP<T> : IWinnerPlay<T>
    {
        public int Revition(IPlayer<T>[] players)
        {
            int index = -1;
            int win = int.MaxValue;

            for (int i = 0; i < players.Length; i++)
            {
                int tmp = players[i].Hand.Count;

                if (tmp == 0)
                {
                    index = i;
                    break;
                }

                if (tmp < win)
                {
                    win = tmp;
                    index = i;
                }
                else if (tmp == win)
                {
                    index = -1;
                }
            }

            MainWindow.Action = MainWindow.StringFormation(index, false, true, false);

            return index;
        }
    }

    public class PassWP<T> : IWinnerPlay<T>
    {
        public int Revition(IPlayer<T>[] players)
        {
            int index = -1;
            int win = 0;

            for (int i = 0; i < players.Length; i++)
            {
                int tmp = 0;

                for (int j = 0; j < MainWindow.HistoryIndex.Count; j++)
                {
                    if (MainWindow.HistoryIndex[j] == i && j != (MainWindow.HistoryIndex.Count - 1) && !MainWindow.HistoryPlay[j + 1])
                    {
                        tmp++;
                    }
                }

                if (tmp > win)
                {
                    win = tmp;
                    index = i;
                }
                else if (tmp == win)
                {
                    index = -1;
                }
            }

            MainWindow.Action = MainWindow.StringFormation(index, false, true, false);

            return index;
        }
    }
}