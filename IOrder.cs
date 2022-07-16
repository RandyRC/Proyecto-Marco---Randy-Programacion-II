using System.Collections.Generic;

namespace Domino
{
    public interface IOrder<T>
    {
        int GenerateOrder(IPlayer<T>[] players, int prev);
    }
}