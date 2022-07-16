using System;
using System.Collections.Generic;

namespace Domino
{
    public class ClassicSP<T> : ISorterPlayer<T>
    {
        public void SorterPlayer(IPlayer<T>[] players, int[] typeplayers, int quantity)
        {
            int add = 0;

            for (int i = 0; i < typeplayers.Length; i++)
            {
                for (int j = 0; j < typeplayers[i]; j++)
                {
                    if (i == 0)
                    {
                        players[j + add] = new Player<T>(new List<Ficha<T>>(), new List<Ficha<T>>(), quantity);
                    }
                    else if (i == 1)
                    {
                        players[j + add] = new ThrowFat<T>(new List<Ficha<T>>(), new List<Ficha<T>>(), quantity);
                    }
                    else if (i == 2)
                    {
                        players[j + add] = new Reserved<T>(new List<Ficha<T>>(), new List<Ficha<T>>(), quantity);
                    }
                    else if (i == 3)
                    {
                        players[j + add] = new PassMaker<T>(new List<Ficha<T>>(), new List<Ficha<T>>(), quantity);
                    }
                }

                add += typeplayers[i];
            }
        }
    }

    public class RandomSorterSP<T> : ISorterPlayer<T>
    {
        public void SorterPlayer(IPlayer<T>[] players, int[] typeplayers, int quantity)
        {
            List<int> index = new List<int>();
            Random r = new Random();

            for (int i = 0; i < players.Length; i++)
            {
                index.Add(i);
            }

            for (int i = 0; i < typeplayers.Length; i++)
            {
                for (int j = 0; j < typeplayers[i]; j++)
                {
                    int tmp = r.Next(0, index.Count);

                    if (i == 0)
                    {
                        players[index[tmp]] = new Player<T>(new List<Ficha<T>>(), new List<Ficha<T>>(), quantity);
                    }
                    else if (i == 1)
                    {
                        players[index[tmp]] = new ThrowFat<T>(new List<Ficha<T>>(), new List<Ficha<T>>(), quantity);
                    }
                    else if (i == 2)
                    {
                        players[index[tmp]] = new Reserved<T>(new List<Ficha<T>>(), new List<Ficha<T>>(), quantity);
                    }
                    else if (i == 3)
                    {
                        players[index[tmp]] = new PassMaker<T>(new List<Ficha<T>>(), new List<Ficha<T>>(), quantity);
                    }

                    index.RemoveAt(tmp);
                }
            }
        }
    }
}