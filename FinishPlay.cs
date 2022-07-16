using System.Collections.Generic;
using System.Linq;
using Proyecto_de_Programacion_II_Marco_Randy;

namespace Domino
{
    public class ClassicFP<T> : IFinishPlay<T>
    {
        public virtual bool Finish(int pass, IPlayer<T>[] players)
        {
            return (Passes(pass, players.Length) || NotFichas(players));
        }
        public virtual bool Passes(int pass, int count)
        {
            return (pass >= count);
        }
        public virtual bool NotFichas(IPlayer<T>[] players)
        {
            foreach (var item in players)
            {
                if (item.Hand.Count == 0)
                {
                    return true;
                }
            }

            return false;
        }
    }

    public class PassesFP<T> : ClassicFP<T>
    {
        public override bool Passes(int pass, int count)
        {
            for (int i = 0; i < count; i++)
            {
                bool[] result = new bool[] { true, true, true };
                int tmp = 2;

                for (int j = MainWindow.HistoryIndex.Count - 1; j >= 0; j--)
                {
                    if (i == MainWindow.HistoryIndex[j])
                    {
                        result[tmp] = MainWindow.HistoryPlay[j];
                        tmp--;
                    }
                    if (tmp == -1) break;
                }

                if (!result.Contains(true))
                {
                    return true;
                }
            }

            return false;
        }
    }
    public class FewPointsFP<T> : ClassicFP<T>
    {
        public override bool NotFichas(IPlayer<T>[] players)
        {
            int suma = 0;

            foreach (var player in players)
            {
                foreach (var ficha in player.Hand)
                {
                    suma += ficha.Suma;
                }

                if (suma < 10)
                {
                    return true;
                }

                suma = 0;
            }

            return false;
        }
    }
}