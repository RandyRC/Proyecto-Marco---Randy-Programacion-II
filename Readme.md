# Dominoes!

> Proyecto de Programación II. Facultad de Matemática y Computación. Universidad de La Habana.

> Desarrolladores:

   >>Marco Antonio Ochil Trujillo 
   >>Randy Jesús Rivero Córdova 

Es una aplicación desarrollada con tecnología .NET Core 6.0, específicamente usando WPF (Windows Presentation Fundation) para la interfaz gráfica, y en el lenguaje C#.

**Aviso importante**
>La aplicación solo funciona en sistema operativo Windows.
>Se puede ejecutar en Visual Studio 2022 o desde la carpeta del proyecto/bin/debug y abrir la aplicación.

## Ejecución
> Al ejecutar la aplicación ya sea desde Visual Studio o directamente desde el archivo ejecutable, se despliega lo que llamaremos `Cuadro de inicio` no es más que la bienvenida y el título de la aplicación con dos botones `Exit` y `Start` , sus funcionalidades son cerrar el componente visual y comenzar a personalizar el juego respectivamente. Si la opción marcada es `Start` se despliega el `Menú de personalización` donde se le muestra al usuario las posibles variaciones ya existentes en el juego.

## Personalización

Contiene las opciones `Exit` y `Ok`
Permite acceder a todas las variaciones en el juego, se irán explicando en sentido al nivel de relevancia en la interfaz gráfica

Contiene además las opciones `Exit` y `Ok`
- Exit: Cierra la aplicacion visual.
- Ok: Continua a la pantalla de visualizacion del torneo.

**Personalizacion**

**Structure**: Contiene las opciones `Matrix` y `Simple`
- Matrix: Permite ver el juego de forma más realista pues simula y muestra un tablero físico de domino, así como el historial de jugadas.
Restricciones: No se permiten fichas que contengan objetos cuyo tamaño exceda el de las caras de la fichas, ni objetos sin una manera de imprimirse en pantalla. Tampoco se permiten más de 12 valores diferentes de ningún tipo de ficha.
- Simple: Permite ver el historial de jugadas.
Restricciones: No se debe exceder de la cantidad de valores admitidos en el tipo de ficha y en el caso de IntType (se explica abajo) no se debe superar el valor 50.


**PieceType**: Contiene las opciones `CharType`, `IntType`, `EmojiType`.
- CharType: Las fichas tendran en sus caras las letras del abecedario en mayúsculas.
Restricciones: Solo existen 26 valores diferentes.
- IntType: Las fichas tendrán en sus caras los números enteros empezando por el 0.
- EmojiType: Las fichas tendrán emojis en sus caras.
Restriccciones: Solo existen 13 valores.

**Type of dominoe**: Contiene un espacio donde escribir con cuántos valores diferentes se quiere jugar, el número insertado corresponde a la cantidad de valores diferentes a generar. Ejemplo: el domino doble-6 tiene 7 valores (desde el 0 hasta el 6) y el domino doble-9 tiene 10 valores (del cero hasta el 9), en el caso de las letras del abecedario la variante del doble-6 ocupará hasta la séptima letra (G).
Restricciones: Se deben escoger más de 2 valores diferentes. Si la cantidad de jugadores multiplicada por la cantidad de fichas por jugador es mayor que la cantidad de fichas creadas entonces deberá volver a asignar un valor a dicha variación hasta que los parámetros sean correctos.

**Number of pieces for player**: Contiene un espacio donde escribir cuántas fichas repartirle a cada jugador.
Restricciones: Se debe repartir al menos 3 fichas a cada jugador.

**Type and number of player**: Contiene un espacio junto a cada tipo de jugador para decidir cuántos crear de cada tipo. Los tipos son:
- Random: Juega una ficha válida cualquiera.
- ThrowFat: Juega la ficha con más puntos entre todas las válidas.
- Reserved: Juega la ficha cuyos valores se repiten más veces entre las que tiene en la mano.
- PassMaker: Juega la ficha que más veces ha hecho pasar al resto de los jugadores, si ningún jugador se ha pasado o no tiene dicha ficha juega de igual manera al Random.
Los jugadores que se desea estén presentes en el juego y la cantidad de jugadores del mismo tipo (ejemplo: valor 3 en un jugador Random indica que en el juego participarán 3 jugadores de ese tipo), para esto ingresará en los jugadores que se quiere que participen un valor numérico distinto de cero (0), si el valor es cero entonces ese jugador no participa en el juego.
Restricciones: En cada jugador debe estar un número positivo o el 0. El total de jugadores creados debe ser al menos 2.

**SorterPlayers**: Contiene las opciones `Classic` y `Random`
- Classic: Los jugadores son creados en el orden establecido en **Type and number of player** con las cantidades especificadas, Ejemplo:
Insertar: Random - 2, ThrowFat - 1, Reserved - 3, PassMaker - 1
Resultado: 1 - Random, 2 - Random, 3 - ThrowFat, 4 - Reserved, 5 - Reserved, 6 - Reserved, 7 - PassMaker
Serían los índices de los jugadores creados.
- Random: Se crean las cantidades indicadas por el usuario y su orden es completamente aleatorio.

**Order**: Contiene las opciones `Classic`, `Maximum` y `TurnPass`
- Classic: El juego respeta los índices originales de los jugadores, avanzando de manera ascendente por dichos índices, después del turno del último se vuelve a iniciar el ciclo desde el primero.
- Maximum: El turno es del jugador con más puntos en la mano, si dicho jugador pasa con los valores que se encuentran en la mesa, en el siguiente turno no se incluirá entre los posibles jugadores que pueden jugar, este algoritmo se repite para cada jugador que pase, en caso de 2 jugadores que pasen consecutivamente serán retirados ambos de los posibles jugadores que pueden jugar, esto se cumple para cualquier cantidad de jugadores siempre, si todos pasan en algun momento el juego debe terminar en base a las condiciones de finalización.
- TurnPass: Funciona de manera semejante a Classic, pero cuando un jugador pasa, el sentido en que se recorren los índices de los jugadores cambia de ascendente a descendiente y viceversa.

**Sorter**: Contiene las opciones `Classic`, `Crazy` y `Resort`
- Classic: El juego reparte cualquier ficha a cada jugador hasta que cada uno tenga las fichas seleccionadas por el usuario.
- Crazy: El juego reparte 2 fichas a cada jugador y luego revisa cuántas fichas en total le quedan por repartir y las va repartiendo una a una para un jugador random, de esta manera los jugadores pueden tener mínimo 2 fichas y máximo 2 mas todas las fichas que faltaban por repartir.
- Resort: El juego reparte de igual manera que en Classic, pero ahora los jugadores tienen la opción de devolver algunas de esas fichas y el juego vuelve a repartirle fichas a cada uno hasta llegar a la cantidad de fichas que deberían tener.

**FinishPlay**: Contiene las opciones `Classic`, `FewPoints` y `Pass`
- Classic: El juego termina si hay una cantidad de pases consecutivos igual a la cantidad de jugadores o si algún jugador se queda sin fichas.
- FewPoints: El juego termina si hay una cantidad de pases consecutivos igual a la cantidad de jugadores o si algún jugador tiene menos de 10 puntos en su mano.
- Pass: El juego termina si algún jugador pasa 3 veces consecutivas o si algún jugador se queda sin fichas.

**WinnerPlay**: Contiene las opciones `Classic`, `Pieces` y `Pass`
- Classic: El ganador de la partida será un jugador sin fichas, en caso de no haber ninguno entonces ganará el jugador con menos puntos, si 2 o más jugadores coinciden en ser los que menos puntos tienen se declara un empate y no hay ganador.
- Pieces: El ganador de la partida será el jugador con menos fichas, si 2 o más jugadores coinciden en ser los que menos fichas tienen se declara un empate y no hay ganador.
- Pass: El ganador de la partida será el jugador que más veces precedió a un jugador que pasara, sin importar la cantidad de fichas o puntos en las manos, si 2 o más jugadores coinciden en ser los que más veces cumplen la condición anterior entonces se declara un empate y no hay ganador.

**Points**: Contiene un espacio donde escribir cuántos puntos debe conseguir un jugador para ganar el torneo, en caso de querer jugar una partida solamente, escogiendo la cantidad 1 esto es posible, la única situación en la que esto incurrirá en jugar más de una partida es cuando exista empate y no se pueda escoger ganador.
Restricción: Esta cantidad debe ser mayor que 0.

**FinishGame**: Contiene las opciones `Classic`, `AdderPieces` y `AdderPass`
- Classic: Al ganador de la partida se le adiciona la suma de los puntos en la mano de cada uno de los perdedores, en caso de que esa cantidad sea 0, recibe 1 punto por ganar la partida.
- AdderPieces: Al ganador de la partida se le adicionan 5 puntos por cada ficha en la mano de cada uno de los perdedores.
- AdderPass: Al ganador de la partida se le adicionan 5 puntos por cada jugador que pasó después de que él jugara en la partida, mas 5 puntos por ganar la partida.

Restricciones de **Personalizacion**: En todas las casillas que se utilizan para que el usuario escriba valores, si éstos no son válidos, se le mostrará al usuario `AVISO: La configuración de juego no es válida` en un cuadro de texto, una vez se presione aceptar podrá volver a asignar un valor a dicha variación. En las opciones marcables en cada variación solo se puede marcar una de las posibles.

## Visualizacion de Torneo
Hay 2 maneras de presentarse, definidas anteriormente en **Structure**: Matrix y Simple

Matrix Contiene 3 zonas a resaltar: `Tablero`, `Game History` y `Move`
- Tablero: Muestra una forma semejante a la que tiene el domino cuando se juega en fisico la primera ficha jugada, que aparecerá en el centro, tendrá un color distintivo al resto.
- Game History: Muestra la acción más relevante del turno, los niveles de relevancia en orden descendiente son los siguientes:
1- Un jugador ha ganado el torneo.
2- Un jugador ha ganado la partida o hay un empate.
3- Un jugador ha jugado o ha pasado.
- Move: Es un botón con el cual se avanza en el juego por turnos, cuando acabe una partida el tablero se limpia y muestra la siguiente, una vez acaben todas las partidas y se decida el ganador del torneo, se mostrará un mensaje indicando que el componente gráfico se va a cerrar y con esto finaliza la ejecución de la aplicación.
Simple sólo contiene `Game History` y `Move` dado que esta forma de representación está destinada para juegos donde los valores de las fichas no sean representables.