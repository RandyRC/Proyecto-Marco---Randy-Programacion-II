using System.Collections.Generic;

namespace Domino
{
    public interface IFinishPlay<T>
    {
        bool Finish(int pass, IPlayer<T>[] players);
        bool Passes(int pass, int count);
        bool NotFichas(IPlayer<T>[] players);
    }
}