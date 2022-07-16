using System.Collections.Generic;

namespace Domino
{
    public interface IFinishGame<T>
    {
        int[] Points {get; }
        void Adder(IPlayer<T>[] players, int winner);
        void Finish(int max);
    }
}