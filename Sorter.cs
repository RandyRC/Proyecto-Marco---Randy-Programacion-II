using System;
using System.Collections.Generic;

namespace Domino
{
    public class ClassicSort<T> : ISorter<T>
    {
        public void Sort(IPlayer<T>[] players, List<Ficha<T>> Fichas, int FxPly)
        {
            Random r = new Random();

            for (int i = 0; i < players.Length; i++)
            {
                for (int j = 0; j < FxPly; j++)
                {
                    int tmp = r.Next(0, Fichas.Count);
                    players[i].Hand.Add(Fichas[tmp]);
                    Fichas.RemoveAt(tmp);
                }
            }
        }
    }

    public class ReSorter<T> : ISorter<T>
    {
        public void Sort(IPlayer<T>[] players, List<Ficha<T>> Fichas, int FxPly)
        {
            Random r = new Random();

            for (int i = 0; i < players.Length; i++)
            {
                for (int j = 0; j < FxPly; j++)
                {
                    int tmp = r.Next(0, Fichas.Count);
                    players[i].Hand.Add(Fichas[tmp]);
                    Fichas.RemoveAt(tmp);
                }
            }

            for (int i = 0; i < players.Length; i++)
            {
                Fichas.AddRange(players[i].ReSort());

                for (int j = 0; j < FxPly - players[i].Hand.Count; j++)
                {
                    int tmp = r.Next(0, Fichas.Count);
                    players[i].Hand.Add(Fichas[tmp]);
                    Fichas.RemoveAt(tmp);
                }
            }
        }
    }

    public class CrazySorter<T> : ISorter<T>
    {
        public void Sort(IPlayer<T>[] players, List<Ficha<T>> Fichas, int FxPly)
        {
            int distribute = players.Length * (FxPly -2);
            Random r = new Random();

            for (int i = 0; i < players.Length * 2; i++)
            {
                int tmp = r.Next(0, Fichas.Count);
                players[i / 2].Hand.Add(Fichas[tmp]);
                Fichas.RemoveAt(tmp);
            }

            for (int i = 0; i < distribute; i++)
            {
                int tmp = r.Next(0, Fichas.Count);
                int tmpplayer = r.Next(0, players.Length);
                players[tmpplayer].Hand.Add(Fichas[tmp]);
                Fichas.RemoveAt(tmp);
            }
        }
    }
}