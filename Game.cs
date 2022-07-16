using System.Collections.Generic;
using System.Linq;
using Proyecto_de_Programacion_II_Marco_Randy;

namespace Domino
{
    public class Game<T, P>
    {
        public ITable<T, P> Table { get; }
        //Estructura en la que se almacenan las fichas
        public IPlayer<T>[] Players { get; set; }
        //Array con los jugadores
        public Values<T> Translator { get; set; }
        //Traductor de valores que puede tomar la ficha
        public IOrder<T> Order { get; set; }
        //Generador de Orden
        public IFinishGame<T> FinishGame { get; set; }
        //Caso de finalizacion de un juego y adicion de puntos
        public IFinishPlay<T> FinishPlay { get; set; }
        //Caso de finalizacion de una partida
        public IWinnerPlay<T> WinnerPlay { get; set; }
        //Define el ganador de la partida
        public ISorter<T> Sorter { get; set; }
        //Repartidor de fichas a los jugadores
        public ISorterPlayer<T> SorterPlayer { get; set; }
        //Repartidor de los jugadores en Players
        public int Index { get; set; }
        //Indice del jugador que debe jugar
        public int Passes { get; set; }
        //Cantidad de pases consecutivos

        public Game(ITable<T, P> table)
        {
            Table = table;
            Index = -1;
            Passes = 0;
        }

        public void Form(bool[] order, bool[] finishgame, bool[] finishplay, bool[] winnerplay,
        bool[] sorter, bool[] sorterplayer, int[] typeplayers, int quantity)
        //Metodo para crear las estructuras que usara el juego segun los datos enviados
        {
            int quantityplayers = typeplayers.Sum();

            if (order[0])
            {
                Order = new ClassicOrd<T>();
            }
            else if (order[1])
            {
                Order = new MaximumOrd<T>();
            }
            else if (order[2])
            {
                Order = new TurnPass<T>();
            }

            if (finishgame[0])
            {
                FinishGame = new ClassicFG<T>(quantityplayers);
            }
            else if (finishgame[1])
            {
                FinishGame = new AdderFichaFG<T>(quantityplayers);
            }
            else if (finishgame[2])
            {
                FinishGame = new AdderPassFG<T>(quantityplayers);
            }

            if (finishplay[0])
            {
                FinishPlay = new ClassicFP<T>();
            }
            else if (finishplay[1])
            {
                FinishPlay = new PassesFP<T>();
            }
            else if (finishplay[2])
            {
                FinishPlay = new FewPointsFP<T>();
            }

            if (winnerplay[0])
            {
                WinnerPlay = new ClassicWP<T>();
            }
            else if (winnerplay[1])
            {
                WinnerPlay = new FichaWP<T>();
            }
            else if (winnerplay[2])
            {
                WinnerPlay = new PassWP<T>();
            }

            if (sorter[0])
            {
                Sorter = new ClassicSort<T>();
            }
            else if (sorter[1])
            {
                Sorter = new ReSorter<T>();
            }
            else if (sorter[2])
            {
                Sorter = new CrazySorter<T>();
            }

            if (sorterplayer[0])
            {
                SorterPlayer = new ClassicSP<T>();
            }
            else if (sorterplayer[1])
            {
                SorterPlayer = new RandomSorterSP<T>();
            }

            Translator.Charge();
            Players = new IPlayer<T>[quantityplayers];
            SorterPlayer.SorterPlayer(Players, typeplayers, quantity);
        }
        public void Run(int quantity, int FxPly, int max)
        //Metodo para realizar una jugada (definiendo jugada como: Players[Index] juega o se pasa, puede con esto acabarse la partida o el 
        //juego)
        {
            if (Table.Fichas.Count == 0 && Table.Count == 0 && Players[0].Hand.Count == 0)
            {
                Table.Create(Translator, quantity);
            }
            if (Table.Count == 0)
            {
                Sorter.Sort(Players, Table.Fichas, FxPly);
                foreach (var player in Players)
                {
                    player.Load(Translator);
                }
                Index = Order.GenerateOrder(Players, Index);
                Move(true);
            }
            else
            {
                Index = Order.GenerateOrder(Players, Index);
                Move(false);
            }

            if (FinishPlay.Finish(Passes, Players))
            {
                int winner = WinnerPlay.Revition(Players);
                if (winner != -1)
                {
                    FinishGame.Adder(Players, winner);
                    Index = winner - 1;
                }
                FinishGame.Finish(max);
                Reload();
            }

        }
        void Move(bool beginning)
        //Metodo que realmente define que jugada se va a realizar, diferenciando la jugada que da inicio a la partida del resto
        {
            if (beginning)
            {
                foreach (var ficha in Players[Index].Hand)
                {
                    Players[Index].Possible.Add(ficha);
                }
                
                Table.Where((Players[Index].Play(Translator), Translator.Key[0]));
                MainWindow.HistoryPlay.Add(true);
                MainWindow.Action = MainWindow.StringFormation(Index, true, false, false);
            }
            else
            {
                Players[Index].Search(Table.ValLeft, Table.ValRight);

                if (Players[Index].Possible.Count == 0)
                {
                    Passes++;
                    MainWindow.HistoryPlay.Add(false);
                    for (int i = 0; i < Players.Length; i++)
                    {
                        if (Index != i)
                        {
                            Players[i].Load(Table.ValLeft, Table.ValRight, Translator);
                        }
                    }
                    MainWindow.Action = MainWindow.StringFormation(Index, false, false, false);
                }
                else
                {
                    Passes = 0;
                    MainWindow.HistoryPlay.Add(true);
                    Table.Where(Players[Index].PlayWT(Table.ValLeft, Table.ValRight, Translator));
                    MainWindow.Action = MainWindow.StringFormation(Index, true, false, false);
                }
            }

            MainWindow.HistoryIndex.Add(Index);
        }
        void Reload()
        //Metodo para restablecer los valores luego de finalizada una partida
        {
            Passes = 0;
            Table.Reload(Players);
            foreach (var player in Players)
            {
                player.Clean();
            }
            MainWindow.HistoryIndex.Clear();
            MainWindow.HistoryPlay.Clear();
        }
    }
}