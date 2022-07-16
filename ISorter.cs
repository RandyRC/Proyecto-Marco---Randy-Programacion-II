using System.Collections.Generic;

namespace Domino
{
    public interface ISorter<T>
    {
        void Sort(IPlayer<T>[] players, List<Ficha<T>> Fichas, int FxPly);
    }
}