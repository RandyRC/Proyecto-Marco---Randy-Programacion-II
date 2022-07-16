using System.Collections.Generic;

namespace Domino
{
    public interface IWinnerPlay<T>
    {
        int Revition(IPlayer<T>[] players);
    }
}