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
        String[,] tablero;//el tablero de juego
        List<List<int>> jugadasPosibles;//lista de jugadas posibles para el jugador
        public Juego(int size)
        {
            this.size = size;
            this.tablero = new String[this.size,this.size];
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
                    this.tablero[i,j] = "0";
                }
            }
            //coloca las fichas en las posiciones iniciales
            int centro = this.size / 2;
            this.tablero[centro,centro] = "1";
            this.tablero[centro - 1,centro - 1] = "1";
            this.tablero[centro - 1,centro] = "2";
            this.tablero[centro,centro - 1] = "2";
            this.tablero[2, 2]="2";
        }

        //funcion que retorna una lista con todas las posibles jugadas que tiene el jugador de turno.
        public List<List<int>> MovidasPosibles(String jugador)
        {
            //lista con las movidas posibles en base a cual es el jugador a turno
            List<List<int>> movidas = new List<List<int>>();
            for (int i = 0; i < this.size; i++)
            {
                for (int j = 0; j < this.size; j++)
                {
                    if(this.tablero[i, j]==jugador)//si se encuentra una ficha del jugador
                    {//busca las movidas posibles para esa ficha
                        List<List<int>> movidasFicha = evaluarMovidas(i,j,jugador);
                        foreach(List<int> lista in movidasFicha)
                        {
                            movidas.Add(lista);//agrega las movidas de esa ficha a la lista general de movidas
                        }
                    }
                }
            }


            return movidas;
        }

        public List<List<int>> evaluarMovidas(int fila,int columna,String jugador)
        {//evalua segun la ficha del usuario indicada, si tiene movidas en base a esa ficha
            List<List<int>> movidas = new List<List<int>>();
            String arriba = this.tablero[fila - 1, columna];
            String abajo = this.tablero[fila + 1, columna];
            String izq = this.tablero[fila, columna - 1];
            String der = this.tablero[fila, columna + 1];
            String diagArribaIzq = this.tablero[fila - 1, columna - 1];
            String diagAbajoIzq = this.tablero[fila + 1, columna - 1];
            String diagArribaDer = this.tablero[fila - 1, columna + 1];
            String diagAbajoDer = this.tablero[fila + 1, columna + 1];
            if (arriba!="0" && arriba != jugador)
            {
                List<int> movidaArriba = evaluarArriba(fila, columna, jugador);
                movidas.Add(movidaArriba);
            }
            if (abajo != "0" && abajo != jugador)
            {
                List<int> movidaAbajo = evaluarAbajo(fila, columna, jugador);
                movidas.Add(movidaAbajo);
            }
            if (izq != "0" && izq != jugador)
            {
                List<int> movidaIzq = evaluarIzq(fila, columna, jugador);
                movidas.Add(movidaIzq);
            }
            if (der != "0" && der != jugador)
            {
                List<int> movidaDer = evaluarDer(fila, columna, jugador);
                movidas.Add(movidaDer);
            }
            
            if(diagAbajoDer != "0" && diagAbajoDer != jugador)
            {
                List<int> movidaDiagArribaDer = evaluarDiagAbajoDer(fila, columna, jugador);
                movidas.Add(movidaDiagArribaDer);
            }
            if (diagAbajoIzq != "0" && diagAbajoIzq != jugador)
            {
                List<int> movidaDiagAbajoIzq = evaluarDiagAbajoIzq(fila, columna, jugador);
                movidas.Add(movidaDiagAbajoIzq);
            }
            if (diagArribaDer != "0" && diagArribaDer != jugador)
            {
                List<int> movidaDiagArribaDer = evaluarDiagArribaDer(fila, columna, jugador);
                movidas.Add(movidaDiagArribaDer);
            }
            if (diagArribaIzq != "0" && diagArribaIzq != jugador)
            {
                List<int> movidaDiagArribaIzq = evaluarDiagArribaDer(fila, columna, jugador);
                movidas.Add(movidaDiagArribaIzq);
            }

            return movidas;
        }

        public List<int> evaluarDer(int fila, int columna, String jugador)
        {
            List<int> lista = new List<int>();
            for (int i = columna + 1; i < this.size; i++)//revisa que hay hacia la derecha de la ficha
            {
                if (this.tablero[fila, i] == jugador)
                {
                    break;
                }
                else if (this.tablero[fila, i] == "0")//si encontro un espacio vacio
                {
                    lista.Add(fila);
                    lista.Add(i);
                    return lista;
                }
            }

            return lista;
        }

        public List<int> evaluarIzq(int fila, int columna, String jugador)
        {
            List<int> lista = new List<int>();
            for (int i = columna - 1; i >= 0; i--)//revisa que hay hacia la izquierda de la ficha
            {
                if (this.tablero[fila, i] == jugador)
                {
                    break;
                }
                else if (this.tablero[fila, i] == "0")//si encontro un espacio vacio
                {
                    lista.Add(fila);
                    lista.Add(i);
                    return lista;
                }
            }

            return lista;
        }

        public List<int> evaluarAbajo(int fila, int columna, String jugador)
        {
            List<int> lista = new List<int>();
            for (int i = fila + 1; i < this.size; i++)//revisa que hay hacia abajo de la ficha
            {
                if (this.tablero[i, columna] == jugador)
                {
                    break;
                }
                else if (this.tablero[i, columna] == "0")//si encontro un espacio vacio
                {
                    lista.Add(i);
                    lista.Add(columna);
                    return lista;
                }
            }

            return lista;
        }

        public List<int> evaluarArriba(int fila,int columna, String jugador)
        {
            List<int> lista = new List<int>();
            for(int i = fila - 1; i >= 0; i--)//revisa que hay hacia arriba de la ficha
            {
                if (this.tablero[i, columna] == jugador)
                {
                    break;
                }
                else if (this.tablero[i, columna] == "0")//si encontro un espacio vacio
                {
                    lista.Add(i);
                    lista.Add(columna);
                    return lista;
                }
            }

            return lista;
        }

        public List<int> evaluarDiagAbajoDer(int fila, int columna, String jugador)
        {
            List<int> lista = new List<int>();
            for (int i = fila + 1; i < this.size; i++)//revisa que hay diagonal hacia abajo derecha de la ficha
            {
                for (int j = columna + 1; j < this.size; j++)
                {
                    if (this.tablero[i, j] == jugador)
                    {
                        break;
                    }
                    else if (this.tablero[i, j] == "0")//si encontro un espacio vacio
                    {
                        lista.Add(i);
                        lista.Add(j);
                        return lista;
                    }
                }
                
            }

            return lista;
        }

        public List<int> evaluarDiagAbajoIzq(int fila, int columna, String jugador)
        {
            List<int> lista = new List<int>();
            for (int i = fila + 1; i >= 0; i++)//revisa que hay diagonal hacia abajo izquierda de la ficha
            {
                for (int j = columna - 1; j >= 0; j--)
                {
                    if (this.tablero[i, j] == jugador)
                    {
                        break;
                    }
                    else if (this.tablero[i, j] == "0")//si encontro un espacio vacio
                    {
                        lista.Add(i);
                        lista.Add(j);
                        return lista;
                    }
                }

            }

            return lista;
        }

        public List<int> evaluarDiagArribaDer(int fila, int columna, String jugador)
        {
            List<int> lista = new List<int>();
            for (int i = fila - 1; i >= 0; i++)//revisa que hay diagonal hacia abajo derecha de la ficha
            {
                for (int j = columna + 1; j < this.size; j++)
                {
                    if (this.tablero[i, j] == jugador)
                    {
                        break;
                    }
                    else if (this.tablero[i, j] == "0")//si encontro un espacio vacio
                    {
                        lista.Add(i);
                        lista.Add(j);
                        return lista;
                    }
                }

            }

            return lista;
        }

        public List<int> evaluarDiagArribaIzq(int fila, int columna, String jugador)
        {
            List<int> lista = new List<int>();
            for (int i = fila - 1; i >= 0; i++)//revisa que hay diagonal hacia abajo derecha de la ficha
            {
                for (int j = columna - 1; j >= 0; j++)
                {
                    if (this.tablero[i, j] == jugador)
                    {
                        break;
                    }
                    else if (this.tablero[i, j] == "0")//si encontro un espacio vacio
                    {
                        lista.Add(i);
                        lista.Add(j);
                        return lista;
                    }
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
