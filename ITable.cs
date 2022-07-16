using System.Collections.Generic;

namespace Domino
{
    public interface ITable<T, P>
    {
        List<Ficha<T>> Fichas {get; }
        P FichasTable {get; }
        int Count {get; set; }
        (int, int) MarkLeft {get; set; }
        (int, int) MarkRight {get; set; }
        T ValLeft {get; set; }
        T ValRight {get; set; }

        void Create(Values<T> Transalator, int points);
        void Where((Ficha<T>, T) selection);
        void Reload(IPlayer<T>[] players);
    }
}