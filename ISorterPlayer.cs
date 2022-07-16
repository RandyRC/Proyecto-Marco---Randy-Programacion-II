using System.Collections.Generic;

namespace Domino
{
    public interface ISorterPlayer<T>
    {
        void SorterPlayer(IPlayer<T>[] players, int[] typeplayers, int quantity);
    }
}