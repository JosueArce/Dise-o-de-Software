using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaJuegoConsola
{
    class Juego
    {
        int size;//el tamano del tablero
        int[,] tablero;//el tablero de juego
        List<List<int>> jugadasPosibles;//lista de jugadas posibles para el jugador
        public Juego(int size)
        {
            this.size = size;
            this.tablero = new int[this.size,this.size];
            iniciarMatriz();
        }

        //funcion que inicializa el tablero, llenandolo de 0s
        public void iniciarMatriz()
        {
            //llena la tabla con espacios vacios
            for(int i = 0; i < this.size; i++)
            {
                for (int j = 0; j < this.size; j++)
                {
                    this.tablero[i,j] = 0;
                }
            }
            //coloca las fichas en las posiciones iniciales
            int centro = this.size / 2;
            this.tablero[centro,centro] = 1;
            this.tablero[centro - 1,centro - 1] = 1;
            this.tablero[centro - 1,centro] = 2;
            this.tablero[centro,centro - 1] = 2;
        }

        //funcion que retorna una lista con todas las posibles jugadas que tiene el jugador de turno.
        public List<List<int>> MovidasPosibles(int jugador)
        {
            //lista con las movidas posibles en base a cual es el jugador a turno
            List<List<int>> movidas = new List<List<int>>();
            for (int i = 0; i < this.size; i++)
            {
                for (int j = 0; j < this.size; j++)
                {
                    if(this.tablero[i, j]==jugador)//si se encuentra una ficha del jugador
                    {//busca las movidas posibles para esa ficha
                        List<List<int>> movidasFicha = evaluarMovidas(movidas,i,j,jugador);
                        foreach(List<int> lista in movidasFicha)
                        {
                            movidas.Add(lista);//agrega las movidas de esa ficha a la lista general de movidas
                        }
                    }
                }
            }


            return movidas;
        }

        public List<List<int>> evaluarMovidas(List<List<int>> lista,int fila,int columna,int jugador)
        {//evalua segun la ficha del usuario indicada, si tiene movidas en base a esa ficha
            List<List<int>> movidas = lista;
            int arriba = this.tablero[fila - 1, columna];
            int abajo = this.tablero[fila + 1, columna];
            int izq = this.tablero[fila, columna - 1];
            int der = this.tablero[fila, columna + 1];
            if (arriba!=0 && arriba != jugador)
            {
                List<int> movidaArriba = evaluarArriba(fila, columna, jugador);
                movidas.Add(movidaArriba);
            }
            if (abajo != 0 && abajo != jugador)
            {
                List<int> movidaAbajo = evaluarAbajo(fila, columna, jugador);
                movidas.Add(movidaAbajo);
            }
            if (izq != 0 && izq != jugador)
            {
                List<int> movidaIzq = evaluarIzq(fila, columna, jugador);
            }
            if (der != 0 && der != jugador)
            {
                List<int> movidaDer = evaluarDer(fila, columna, jugador);
            }
            return movidas;
        }

        public List<int> evaluarDer(int fila, int columna, int jugador)
        {
            List<int> lista = new List<int>();
            for (int i = columna + 1; i < this.size; i++)//revisa que hay hacia la derecha de la ficha
            {
                if (this.tablero[fila, i] == jugador)
                {
                    break;
                }
                else if (this.tablero[fila, i] == 0)//si encontro un espacio vacio
                {
                    lista.Add(fila);
                    lista.Add(i);
                    return lista;
                }
            }

            return lista;
        }

        public List<int> evaluarIzq(int fila, int columna, int jugador)
        {
            List<int> lista = new List<int>();
            for (int i = columna - 1; i >= 0; i--)//revisa que hay hacia la izquierda de la ficha
            {
                if (this.tablero[fila, i] == jugador)
                {
                    break;
                }
                else if (this.tablero[fila, i] == 0)//si encontro un espacio vacio
                {
                    lista.Add(fila);
                    lista.Add(i);
                    return lista;
                }
            }

            return lista;
        }

        public List<int> evaluarAbajo(int fila, int columna, int jugador)
        {
            List<int> lista = new List<int>();
            for (int i = fila + 1; i < this.size; i++)//revisa que hay hacia abajo de la ficha
            {
                if (this.tablero[i, columna] == jugador)
                {
                    break;
                }
                else if (this.tablero[i, columna] == 0)//si encontro un espacio vacio
                {
                    lista.Add(i);
                    lista.Add(columna);
                    return lista;
                }
            }

            return lista;
        }

        public List<int> evaluarArriba(int fila,int columna,int jugador)
        {
            List<int> lista = new List<int>();
            for(int i = fila - 1; i >= 0; i--)//revisa que hay hacia arriba de la ficha
            {
                if (this.tablero[i, columna] == jugador)
                {
                    break;
                }
                else if (this.tablero[i, columna] == 0)//si encontro un espacio vacio
                {
                    lista.Add(i);
                    lista.Add(columna);
                    return lista;
                }
            }

            return lista;
        }








        //dibuja el tablero en la consola
        public void dibujar()
        {
            for (int i = 0; i < this.size; i++)
            {
                for (int j = 0; j < this.size; j++)
                {
                    Console.SetCursorPosition(j * 4, i + 1);
                    Console.Write(this.tablero[i,j]);
                }
            }
            
        }

        



    }
}
