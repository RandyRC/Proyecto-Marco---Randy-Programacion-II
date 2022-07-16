using System.Collections.Generic;

namespace Domino
{
    public interface IPlayer<T>
    {
        List<Ficha<T>> Hand { get; }
        //Para almacenar todas sus fichas
        List<Ficha<T>> Possible { get; }
        //Luego de pasar por Search, aqui van las fichas que pueden ser jugadas en el turno del jugador
        int[] Count { get; }
        //Array de tamaño igual a la cantidad de valores diferentes usados en la partida para heuristicas de algunos jugadores

        void Search(T left, T right);
        //Metodo para llenar Possible
        Ficha<T> Play(Values<T> Translator);
        //Metodo para jugar sin saber los valores extremos de la mesa
        (Ficha<T>, T) PlayWT(T left, T right, Values<T> Translator);
        //Metodo para jugar sabiendo los valores extremos de la mesa
        void Load(Values<T> Translator);
        //Utilizado en heuristica con Count
        void Load(T left, T right, Values<T> Translator);
        //Utilizado en heuristica con Count
        void Clean();
        //Metodo para limpiar Count cuando se acaba la partida
        List<Ficha<T>> ReSort();
        //Metodo para devolver fichas en ReSorter
    }
}