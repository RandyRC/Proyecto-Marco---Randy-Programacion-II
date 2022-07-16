using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Domino;

namespace Proyecto_de_Programacion_II_Marco_Randy
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Las variables History me seran utiles para variaciones donde el historial de pases y jugadas sea importante
        public static List<int> HistoryIndex = new List<int>();
        public static List<bool> HistoryPlay = new List<bool>();
        //El tipo Grafica es para usarlo en la visual del proyecto, al igual que el string, no tienen utilidad en la logica del juego
        public static Grafica Ficha = new Grafica("a", "b", (0, 0));
        public static string Action = "";
        public static List<Grafica> ListaF = new List<Grafica>();
        public static List<string> listajugadas = new List<string>();
        public static List<Grid> ListaG = new List<Grid>();
        public static List<TextBlock> listextIzq = new List<TextBlock>();
        public static List<TextBlock> listextDer = new List<TextBlock>();
        //las cosas que va a pasar el usuario desde la visual
        //array de jugadores
        public static int[] jugadores= new int[4];
        //estructura de juego
        public static bool[] estructura = new bool[2];
        //tipo de ficha
        public static bool[] PiecesType = new bool[3];
        //orden de jugadores
        public static bool[] orden = new bool[3];
        //para el finishGame
        public static bool[] finalJuego = new bool[3];
        //finishPlay
        public static bool[] finalPartida = new bool[3];
        //Sorter
        public static bool[] sortear = new bool[3];
        //WinnerPlay
        public static bool[] ganadaPartida = new bool[3];
        //sorterPlayer
        public static bool[] sortearJugadores = new bool[2];
        //para el Max
        public static int Maximo;
        public static int cantidadDeJugadores;
        public static int TipoDomino;
        public static int Cantidadfichas;

        //para el nuevo metodo de a una
        public static List<string> jugadas = new List<string>();
        public static List<Grafica> mostrar = new List<Grafica>();

        //este contador es para limpiar las listas despues de una ronda o partida
        public static int contador = 0;
        //para recorrer las listas y tener control del juego para saber cuando tengo que limpiar o cerrar la pantalla  
        public static int indice = 0;

        public MainWindow()
        {
            InitializeComponent();

            ListaG = new List<Grid>
            {
                El0A0,
                El0A1,
                El0A2,
                El0A3,
                El0A4,
                El0A5,
                El0A6,
                El0A7,
                El0A8,
                El0A9,
                El0A10,
                El0A11,
                El0A12,
                El1A0,
                El1A1,
                El1A2,
                El1A3,
                El1A4,
                El1A5,
                El1A6,
                El1A7,
                El1A8,
                El1A9,
                Es1A10,
                Es1A11,
                Es1A12,
                El2A0,
                El2A1,
                El2A2,
                El2A3,
                El2A4,
                El2A5,
                El2A6,
                El2A7,
                El2A8,
                El2A9,
                El2A10,
                El2A11,
                El2A12,
                El3A0,
                El3A1,
                El3A2,
                El3A3,
                El3A4,
                El3A5,
                El3A6,
                El3A7,
                El3A8,
                El3A9,
                El3A10,
                El3A11,
                El3A12,
                El4A0,
                El4A1,
                El4A2,
                El4A3,
                El4A4,
                El4A5,
                El4A6,
                El4A7,
                El4A8,
                El4A9,
                El4A10,
                El4A11,
                El4A12,
                El5A0,
                El5A1,
                El5A2,
                El5A3,
                El5A4,
                El5A5,
                El5A6,
                El5A7,
                El5A8,
                El5A9,
                El5A10,
                El5A11,
                El5A12,
                El6A0,
                El6A1,
                El6A2,
                El6A3,
                El6A4,
                El6A5,
                El6A6,
                El6A7,
                El6A8,
                El6A9,
                El6A10,
                El6A11,
                El6A12,
                El7A0,
                El7A1,
                El7A2,
                El7A3,
                El7A4,
                El7A5,
                El7A6,
                El7A7,
                El7A8,
                El7A9,
                El7A10,
                El7A11,
                El7A12,
                El8A0,
                El8A1,
                El8A2,
                El8A3,
                El8A4,
                El8A5,
                El8A6,
                El8A7,
                El8A8,
                El8A9,
                El8A10,
                El8A11,
                El8A12,
                El9A0,
                El9A1,
                El9A2,
                El9A3,
                El9A4,
                El9A5,
                El9A6,
                El9A7,
                El9A8,
                El9A9,
                El9A10,
                El9A11,
                El9A12,
                El10A0,
                El10A1,
                El10A2,
                El10A3,
                El10A4,
                El10A5,
                El10A6,
                El10A7,
                El10A8,
                El10A9,
                El10A10,
                El10A11,
                El10A12,
                El11A0,
                El11A1,
                El11A2,
                El11A3,
                El11A4,
                El11A5,
                El11A6,
                El11A7,
                El11A8,
                El11A9,
                El11A10,
                El11A11,
                El11A12,
                El12A0,
                El12A1,
                El12A2,
                El12A3,
                El12A4,
                El12A5,
                El12A6,
                El12A7,
                El12A8,
                El12A9,
                El12A10,
                El12A11,
                El12A12,

            };

            listextIzq = new List<TextBlock>
            {
                Izq0A0,
                Izq0A1,
                Izq0A2,
                Izq0A3,
                Izq0A4,
                Izq0A5,
                Izq0A6,
                Izq0A7,
                Izq0A8,
                Izq0A9,
                Izq0A10,
                Izq0A11,
                Izq0A12,
                Izq1A0,
                Izq1A1,
                Izq1A2,
                Izq1A3,
                Izq1A4,
                Izq1A5,
                Izq1A6,
                Izq1A7,
                Izq1A8,
                Izq1A9,
                Isq1A10,
                Isq1A11,
                Isq1A12,
                Izq2A0,
                Izq2A1,
                Izq2A2,
                Izq2A3,
                Izq2A4,
                Izq2A5,
                Izq2A6,
                Izq2A7,
                Izq2A8,
                Izq2A9,
                Izq2A10,
                Izq2A11,
                Izq2A12,
                Izq3A0,
                Izq3A1,
                Izq3A2,
                Izq3A3,
                Izq3A4,
                Izq3A5,
                Izq3A6,
                Izq3A7,
                Izq3A8,
                Izq3A9,
                Izq3A10,
                Izq3A11,
                Izq3A12,
                Izq4A0,
                Izq4A1,
                Izq4A2,
                Izq4A3,
                Izq4A4,
                Izq4A5,
                Izq4A6,
                Izq4A7,
                Izq4A8,
                Izq4A9,
                Izq4A10,
                Izq4A11,
                Izq4A12,
                Izq5A0,
                Izq5A1,
                Izq5A2,
                Izq5A3,
                Izq5A4,
                Izq5A5,
                Izq5A6,
                Izq5A7,
                Izq5A8,
                Izq5A9,
                Izq5A10,
                Izq5A11,
                Izq5A12,
                Izq6A0,
                Izq6A1,
                Izq6A2,
                Izq6A3,
                Izq6A4,
                Izq6A5,
                Izq6A6,
                Izq6A7,
                Izq6A8,
                Izq6A9,
                Izq6A10,
                Izq6A11,
                Izq6A12,
                Izq7A0,
                Izq7A1,
                Izq7A2,
                Izq7A3,
                Izq7A4,
                Izq7A5,
                Izq7A6,
                Izq7A7,
                Izq7A8,
                Izq7A9,
                Izq7A10,
                Izq7A11,
                Izq7A12,
                Izq8A0,
                Izq8A1,
                Izq8A2,
                Izq8A3,
                Izq8A4,
                Izq8A5,
                Izq8A6,
                Izq8A7,
                Izq8A8,
                Izq8A9,
                Izq8A10,
                Izq8A11,
                Izq8A12,
                Izq9A0,
                Izq9A1,
                Izq9A2,
                Izq9A3,
                Izq9A4,
                Izq9A5,
                Izq9A6,
                Izq9A7,
                Izq9A8,
                Izq9A9,
                Izq9A10,
                Izq9A11,
                Izq9A12,
                Izq10A0,
                Izq10A1,
                Izq10A2,
                Izq10A3,
                Izq10A4,
                Izq10A5,
                Izq10A6,
                Izq10A7,
                Izq10A8,
                Izq10A9,
                Izq10A10,
                Izq10A11,
                Izq10A12,
                Izq11A0,
                Izq11A1,
                Izq11A2,
                Izq11A3,
                Izq11A4,
                Izq11A5,
                Izq11A6,
                Izq11A7,
                Izq11A8,
                Izq11A9,
                Izq11A10,
                Izq11A11,
                Izq11A12,
                Izq12A0,
                Izq12A1,
                Izq12A2,
                Izq12A3,
                Izq12A4,
                Izq12A5,
                Izq12A6,
                Izq12A7,
                Izq12A8,
                Izq12A9,
                Izq12A10,
                Izq12A11,
                Izq12A12,
            };

            listextDer = new List<TextBlock>
            {
                Der0A0,
                Der0A1,
                Der0A2,
                Der0A3,
                Der0A4,
                Der0A5,
                Der0A6,
                Der0A7,
                Der0A8,
                Der0A9,
                Der0A10,
                Der0A11,
                Der0A12,

                Der1A0,
                Der1A1,
                Der1A2,
                Der1A3,
                Der1A4,
                Der1A5,
                Der1A6,
                Der1A7,
                Der1A8,
                Der1A9,
                Dor1A10,
                Dor1A11,
                Dor1A12,

                Der2A0,
                Der2A1,
                Der2A2,
                Der2A3,
                Der2A4,
                Der2A5,
                Der2A6,
                Der2A7,
                Der2A8,
                Der2A9,
                Der2A10,
                Der2A11,
                Der2A12,

                Der3A0,
                Der3A1,
                Der3A2,
                Der3A3,
                Der3A4,
                Der3A5,
                Der3A6,
                Der3A7,
                Der3A8,
                Der3A9,
                Der3A10,
                Der3A11,
                Der3A12,

                Der4A0,
                Der4A1,
                Der4A2,
                Der4A3,
                Der4A4,
                Der4A5,
                Der4A6,
                Der4A7,
                Der4A8,
                Der4A9,
                Der4A10,
                Der4A11,
                Der4A12,

                Der5A0,
                Der5A1,
                Der5A2,
                Der5A3,
                Der5A4,
                Der5A5,
                Der5A6,
                Der5A7,
                Der5A8,
                Der5A9,
                Der5A10,
                Der5A11,
                Der5A12,

                Der6A0,
                Der6A1,
                Der6A2,
                Der6A3,
                Der6A4,
                Der6A5,
                Der6A6,
                Der6A7,
                Der6A8,
                Der6A9,
                Der6A10,
                Der6A11,
                Der6A12,

                Der7A0,
                Der7A1,
                Der7A2,
                Der7A3,
                Der7A4,
                Der7A5,
                Der7A6,
                Der7A7,
                Der7A8,
                Der7A9,
                Der7A10,
                Der7A11,
                Der7A12,

                Der8A0,
                Der8A1,
                Der8A2,
                Der8A3,
                Der8A4,
                Der8A5,
                Der8A6,
                Der8A7,
                Der8A8,
                Der8A9,
                Der8A10,
                Der8A11,
                Der8A12,

                Der9A0,
                Der9A1,
                Der9A2,
                Der9A3,
                Der9A4,
                Der9A5,
                Der9A6,
                Der9A7,
                Der9A8,
                Der9A9,
                Der9A10,
                Der9A11,
                Der9A12,

                Der10A0,
                Der10A1,
                Der10A2,
                Der10A3,
                Der10A4,
                Der10A5,
                Der10A6,
                Der10A7,
                Der10A8,
                Der10A9,
                Der10A10,
                Der10A11,
                Der10A12,

                Der11A0,
                Der11A1,
                Der11A2,
                Der11A3,
                Der11A4,
                Der11A5,
                Der11A6,
                Der11A7,
                Der11A8,
                Der11A9,
                Der11A10,
                Der11A11,
                Der11A12,

                Der12A0,
                Der12A1,
                Der12A2,
                Der12A3,
                Der12A4,
                Der12A5,
                Der12A6,
                Der12A7,
                Der12A8,
                Der12A9,
                Der12A10,
                Der12A11,
                Der12A12,

                };

        }
        //llena las listas de una en una para poder darselas al tablero y al historial conforme el usuario toque "move"
        public void MostrarDuna(List<Grafica> Mostrar, List<string> jugadas, int index)
        { 
            //fichas jugadas 
            Mostrar.Add(ListaF[index]);
            //string que va al historial
            jugadas.Add(listajugadas[index]);
            //historial, es un textbox puesto en el grid tablero 
            Jugadas.Text += "\n" + jugadas[indice];

        }
        //tomo todos los valores devueltos de la ejecucion del juego y las almaceno en las listas para representar en el tablero de juego-historial
        public void LLenalistas()
        {

            for (int i = 0; i < mostrar.Count; i++)
            {
                contador = mostrar.Count;

                for (int j = 0; j < listextIzq.Count; j++)
                {
                    if (mostrar[i].Coordinates.Item1.ToString() + "A" + mostrar[i].Coordinates.Item2.ToString() == listextIzq[j].Name.Substring(3))
                    {
                        listextDer[j].Text = " " + mostrar[i].Right;
                        listextIzq[j].Text = " " + mostrar[i].Left;
                        ListaG[j].Visibility = Visibility.Visible;
                    }
                }
            }
          
        }


        //La idea logica del programa es la siguiente

        //1-Recibe los valores que recopila la visual que me permiten definir las particularidades que el usuario escoge dentro de mis posibles
        //variaciones

        //2-Crea el Game, para esto 1ro le pasa al constructor del juego la esctructura en la cual va a almacenar las fichas, 2do crea el 
        //traductor de valores para el tipo de ficha escogida, 3ro entra al metodo Form de Game y con todos los elementos restantes le da valores
        //a las propiedades que implementan interfaces y añade a los jugadores en el array de IPlayer<T>.

        //3-Realiza una jugada, el metodo Run de Game (ya sea que no existan las fichas aun, o no hayan sido repartidas, o ya el juego este en
        //marcha) hace las acciones necesarias para que el jugador que debe de jugar segun el IGenerateOrder<T> juegue o se pase y luego de eso
        //se verifica si la partida acabo con IFinishPlay<T>, en caso de que si entonces se define un ganador con IWinnerPlay<T> y se le 
        //adicionan los puntos a este, luego se revisa si alguien gano el juego con IFinishGame<T> y se restablecen las posibilidades.

        public static void Mandatodo()
        {
            //matriz o una sola ficha, en el de la ficha sola se ve solo el historial
            bool[] structure = estructura;
            //enteros, letras o emojis
            bool[] fichatype = PiecesType;
            //sentido en el que juegan
            bool[] order = orden;
            //tres
            bool[] finishgame = finalJuego;
            //tres
            bool[] finishplay = finalPartida;
            //tres
            bool[] winnerplay = ganadaPartida;
            //tres
            bool[] sorter = sortear;
            //en que posicion pone los jugadores
            bool[] sorterplayer = sortearJugadores;
            //hecho
            int[] typeplayers = jugadores;
            //hasta donde el valor de las fichas llegan
            int quantity = TipoDomino;
            //fichas en mano por jugadores
            int Fxply = Cantidadfichas;
            //puntaje maximo para ganar la partida o torneo
            int max = Maximo;

            (Grafica, string) final = (Ficha, Action);

            IEnumerable<(Grafica, string)> util = Create(fichatype, structure, order, finishgame, finishplay, winnerplay, sorter, sorterplayer, typeplayers, quantity, Fxply, max);
            IEnumerator<(Grafica, string)> result = util.GetEnumerator();

            while (result.MoveNext())
            {
                final = result.Current;
                ListaF.Add(final.Item1);
                listajugadas.Add(final.Item2);

            }

        }

        public static IEnumerable<(Grafica, string)> Create(bool[] fichatype, bool[] structure, bool[] order, bool[] finishgame,
         bool[] finishplay, bool[] winnerplay, bool[] sorter, bool[] sorterplayer, int[] typeplayers, int quantity, int FxPly, int max)
        //El metodo Create recibe todos los valores y dentro le da forma al juego, como no me gusta usar switch, las posibilidades estan
        //separadas por if, lo siento si se ve muy feo
        {
            if (fichatype[0] && structure[0])
            //caso de fichas enteras y estructura matricial
            {
                Game<int, Ficha<int>[,]> Juego = new Game<int, Ficha<int>[,]>(new Matrix<int>(new List<Ficha<int>>()));
                Juego.Translator = new Values<int>(new Dictionary<int, int>(), ChargeInt());
                Juego.Form(order, finishgame, finishplay, winnerplay, sorter, sorterplayer, typeplayers, quantity);
                while (!Action.Contains("torneo"))
                {
                    Juego.Run(quantity, FxPly, max);
                    yield return (Ficha, Action);
                }
            }

            else if (fichatype[1] && structure[0])
            //caso de fichas con letras y estructura matricial
            {
                Game<char, Ficha<char>[,]> Juego = new Game<char, Ficha<char>[,]>(new Matrix<char>(new List<Ficha<char>>()));
                Juego.Translator = new Values<char>(new Dictionary<char, int>(), ChargeLetter());
                Juego.Form(order, finishgame, finishplay, winnerplay, sorter, sorterplayer, typeplayers, quantity);
                while (!Action.Contains("torneo"))
                {
                    Juego.Run(quantity, FxPly, max);
                    yield return (Ficha, Action);
                }
            }

            else if (fichatype[0] && structure[1])
            //caso de fichas enteras y estructura simple
            {
                Game<int, List<Ficha<int>>> Juego = new Game<int, List<Ficha<int>>>(new SimpleTable<int>(new List<Ficha<int>>(), new List<Ficha<int>>()));
                Juego.Translator = new Values<int>(new Dictionary<int, int>(), ChargeInt());
                Juego.Form(order, finishgame, finishplay, winnerplay, sorter, sorterplayer, typeplayers, quantity);
                while (!Action.Contains("torneo"))
                {
                    Juego.Run(quantity, FxPly, max);
                    yield return (Ficha, Action);
                }
            }

            else if (fichatype[1] && structure[1])
            //caso de fichas con letras y estructura simple
            {
                Game<char, List<Ficha<char>>> Juego = new Game<char, List<Ficha<char>>>(new SimpleTable<char>(new List<Ficha<char>>(), new List<Ficha<char>>()));
                Juego.Translator = new Values<char>(new Dictionary<char, int>(), ChargeLetter());
                Juego.Form(order, finishgame, finishplay, winnerplay, sorter, sorterplayer, typeplayers, quantity);
                while (!Action.Contains("torneo"))
                {
                    Juego.Run(quantity, FxPly, max);
                    yield return (Ficha, Action);
                }
            }

            else if (fichatype[2] && structure[0])
            //caso de fichas emojis y estructura matricial
            {
                Game<string, Ficha<string>[,]> Juego = new Game<string, Ficha<string>[,]>(new Matrix<string>(new List<Ficha<string>>()));
                Juego.Translator = new Values<string>(new Dictionary<string, int>(), ChargeEmojis());
                Juego.Form(order, finishgame, finishplay, winnerplay, sorter, sorterplayer, typeplayers, quantity);
                while (!Action.Contains("torneo"))
                {
                    Juego.Run(quantity, FxPly, max);
                    yield return (Ficha, Action);
                }
            }

            else if (fichatype[2] && structure[1])
            //caso de fichas emojis y estructura simple
            {
                Game<string, List<Ficha<string>>> Juego = new Game<string, List<Ficha<string>>>(new SimpleTable<string>(new List<Ficha<string>>(), new List<Ficha<string>>()));
                Juego.Translator = new Values<string>(new Dictionary<string, int>(), ChargeEmojis());
                Juego.Form(order, finishgame, finishplay, winnerplay, sorter, sorterplayer, typeplayers, quantity);
                while (!Action.Contains("torneo"))
                {
                    Juego.Run(quantity, FxPly, max);
                    yield return (Ficha, Action);
                }
            }

            yield return (new Grafica("", "", (6, 6)), "Juego Completado!");
        }

        public static int[] ChargeInt()
        //metodo para crear el array de int que usa el traductor
        {
            int[] tmp = new int[1000];
            for (int i = 0; i < tmp.Length; i++)
            {
                tmp[i] = i;
            }
            return tmp;
        }

        public static char[] ChargeLetter()
        //metodo para crear el array de letras que usa el traductor
        {
            char[] tmp = new char[]
            {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
            'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'};

            return tmp;
        }

        public static string[] ChargeEmojis()
        {
            string[] tmp = new string[]
            {":(", ":)", ";(", ";)", ":/", ";/", "<3", ":-)", ":-(", ":-/", ";-)",";-/",";-("};

            return tmp;
        }

        public static string StringFormation(int index, bool move, bool play, bool game)
        //metodo para modificar el string que se devuelve a la visual
        {
            if (game)
            {
               // return "Ha ganado el torneo el jugador " + (index + 1);
                return "Campeon del torneo el jugador " + (index + 1);
            }
            else if (index == -1 && play)
            {
                return "Hay un empate";
            }
            else if (play)
            {
                return "Ha ganado el jugador " + (index + 1);
            }
            else if (move)
            {
                return "Ha jugado el jugador " + (index + 1);
            }
            else
            {
                return "Ha pasado el jugador " + (index + 1);
            }
        }

        private void Salir(object sender, RoutedEventArgs e)
        {
            Close();

        }

        private void Jugar_Click(object sender, RoutedEventArgs e)
        {
            Portada.Visibility = Visibility.Hidden;
            PantallaDePersonalizacion.Visibility = Visibility.Visible;
            Tablero.Visibility = Visibility.Hidden;
        }

        //activo las modalidades
        private void Comprobar(object sender, RoutedEventArgs e)
        {
           
            //Char o int en las fichas
            if (IntType.IsChecked==true)
            {
                PiecesType[0] = true;
                PiecesType[1] = false;
            }
            if(CharType.IsChecked==true)
            {
                PiecesType[0] = false;
                PiecesType[1] = true;
            }

            //ficha nueva emojis
            if (EmojiType.IsChecked == true)
            {
                PiecesType[0] = false;
                PiecesType[1] = false;
                PiecesType[2] = true;
            }

            //orden de jugadores
            if (ClassicOrder.IsChecked==true)
            {
                orden[0] = true;
                orden[1] = false;
                orden[2] = false;
            }
            if(MaximumOrder.IsChecked==true)
            {
                orden[0] = false;
                orden[1] = true;
                orden[2] = false;
            }
            if(TurnPassOrder.IsChecked == true)
            {
                orden[0] = false;
                orden[1] = false;
                orden[2] = true;
            }

            //finish Game
            if(ClassicFG.IsChecked==true)
            {
                finalJuego[0] = true;
                finalJuego[1] = false;
                finalJuego[2] = false;
            }
            if(AdderPieceFG.IsChecked==true)
            {
                finalJuego[0] = false;
                finalJuego[1] = true;
                finalJuego[2] = false;
            }
            if(AdderPassFG.IsChecked==true)
            {
                finalJuego[0] = false;
                finalJuego[1] = false;
                finalJuego[2] = true;
            }

            //finishPlay
            if(ClassicFP.IsChecked==true)
            {
                finalPartida[0] = true;
                finalPartida[1] = false;
                finalPartida[2] = false;
            }
            if(PassFp.IsChecked==true)
            {
                finalPartida[0] = false;
                finalPartida[1] = true;
                finalPartida[2] = false;
            }
            if(FewPointsFp.IsChecked==true)
            {
                finalPartida[0] = false;
                finalPartida[1] = false;
                finalPartida[2] = true;
            }

            //sorter
            if(ClassicSorter.IsChecked==true)
            {
                sortear[0] = true;
                sortear[1] = false;
                sortear[2] = false;
            }
            if(ResortSorter.IsChecked==true)
            {
                sortear[0] = false;
                sortear[1] = true;
                sortear[2] = false;
            }
            if(CrazySorter.IsChecked==true)
            {
                sortear[0] = false;
                sortear[1] = false;
                sortear[2] = true;
            }

            //winnerPlay
            if(ClassicWP.IsChecked==true)
            {
                ganadaPartida[0] = true;
                ganadaPartida[1] = false;
                ganadaPartida[2] = false;
            }
            if(PiecesWp.IsChecked==true)
            {
                ganadaPartida[0] = false;
                ganadaPartida[1] = true;
                ganadaPartida[2] = false;
            }
            if(PassWp.IsChecked==true)
            {
                ganadaPartida[0] = false;
                ganadaPartida[1] = false;
                ganadaPartida[2] = true;
            }

            //sorterPlayer
            if(ClassicSPlayer.IsChecked==true)
            {
                sortearJugadores[0] = true;
                sortearJugadores[1] = false;
            }
            if(RandomSPlayer.IsChecked==true)
            {
                sortearJugadores[0] = false;
                sortearJugadores[1] = true;
            }

            LLenaValores(sender, e);

            if (Maximo < 1 || TipoDomino < 2 || cantidadDeJugadores < 2 || Cantidadfichas < 3 || (((TipoDomino + 1) * (TipoDomino + 2)) / (2 * Cantidadfichas)) < cantidadDeJugadores)
            {
                MessageBox.Show("AVISO: La configuración de juego no es válida");
            }
            else
            {

                //estructura del juego
                //tablero matriz
                if (MatrixType.IsChecked == true)
                {
                    estructura[0] = true;
                    estructura[1] = false;

                    if ( TipoDomino > 11 )
                    {
                        MessageBox.Show("AVISO: La configuración de juego no es válida");
                    }
                    else Comenzar_Click(sender, e);

                }
                //tablero abstracto
                //tiene limite en caso del alfabeto debido a que se dispone de 26 valores
                if (SimpleType.IsChecked == true)
                {
                    estructura[0] = false;
                    estructura[1] = true;

                    if (CharType.IsChecked == true)
                    {
                        if ( TipoDomino > 25)
                        {

                            MessageBox.Show("AVISO: La configuración de juego no es válida");
                        }
                        else Comenzar_Click(sender, e);
                    }
                    if (IntType.IsChecked == true)
                    {
                        if (TipoDomino > 49)
                        {

                            MessageBox.Show("AVISO: La configuración de juego no es válida");
                        }
                        else Comenzar_Click(sender, e);
                    }
                    //para Emojis
                    if (EmojiType.IsChecked == true)
                    {
                        if ( TipoDomino > 12)
                        {
                            MessageBox.Show("AVISO: La configuración de juego no es válida");
                        }
                        else Comenzar_Click(sender, e);
                    }
                }
            }
        }

        private void Comenzar_Click(object sender, RoutedEventArgs e)
        {
            PantallaDePersonalizacion.Visibility = Visibility.Hidden;
            Tablero.Visibility = Visibility.Visible;
            Mandatodo();
        }

        private void Move_click(object sender, RoutedEventArgs e)
        {

            MostrarDuna(mostrar, jugadas, indice);

            if(SimpleType.IsChecked==false)
            {
                LLenalistas();

            }

            if (jugadas[indice].Contains("Ha ganado")|| jugadas[indice].Contains("empate")|| jugadas[indice].Contains("Campeon"))
            {
                
                for (int i = 0; i < ListaG.Count; i++)
                {
                    ListaG[i].Visibility = Visibility.Hidden;                                     
                }
                mostrar.RemoveRange(0, contador);
                contador = 0;

            }
            indice++;

            if (indice == ListaF.Count)
            {
                MessageBox.Show("AVISO: El torneo ha finalizado y se cerrará el componente gráfico");
                Close();
            }
           
        }


        //con el TryParse le doy valores a loa argumentos
        private (bool, int) ValidarString(string Avalidar)
        {
            int numero;
            bool revisado = int.TryParse(Avalidar, out numero);
            if(revisado && numero<0)
            {
                numero = 0;

            }
            if (!revisado)
            {
                numero = int.MinValue;
            }
            return (revisado, numero);
        }

       
        private void LLenaValores(object sender, RoutedEventArgs e)
        {
            //agregar los jugadores con su frecuencia
            jugadores[0] = ValidarString(cantRandom.Text).Item2;
            jugadores[1] = ValidarString(cantThrowfat.Text).Item2;
            jugadores[2] = ValidarString(cantReserved.Text).Item2;
            jugadores[3] = ValidarString(cantPassMaker.Text).Item2;

            //cantidad total de jugadores usado para validar
            //lo hago cero xq de poner datos erroneos la variable quedaria aumentando en valores
            cantidadDeJugadores = 0;
            for (int i = 0; i < jugadores.Length; i++)
            {
               cantidadDeJugadores += jugadores[i];

            }
            //max-points
            Maximo = ValidarString(Max.Text).Item2;
            //tipo de domino 
            TipoDomino = ValidarString(tdomino.Text).Item2 - 1;
            //cantidad de fichas por jugador
            Cantidadfichas = ValidarString(cantfichas.Text).Item2;
        }
    }
}

