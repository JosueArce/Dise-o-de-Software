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
            this.tablero = new String[this.size, this.size];
            iniciarMatriz();
        }

        public String[,] getTablero()
        {
            return this.tablero;
        }

        public int getSize()
        {
            return this.size;
        }

        //funcion que inicializa el tablero, llenandolo de 0s
        public void iniciarMatriz()
        {
            //llena la tabla con espacios vacios
            for (int i = 0; i < this.size; i++)
            {
                for (int j = 0; j < this.size; j++)
                {
                    this.tablero[i, j] = "0";
                }
            }
            //coloca las fichas en las posiciones iniciales
            int centro = this.size / 2;
            this.tablero[centro, centro] = "1";
            this.tablero[centro - 1, centro - 1] = "1";
            this.tablero[centro - 1, centro] = "2";
            this.tablero[centro, centro - 1] = "2";
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
                    if (this.tablero[i, j] == jugador)//si se encuentra una ficha del jugador
                    {//busca las movidas posibles para esa ficha
                        List<List<int>> movidasFicha = evaluarMovidas(i, j, jugador);
                        foreach (List<int> lista in movidasFicha)
                        {
                            movidas.Add(lista);//agrega las movidas de esa ficha a la lista general de movidas
                        }
                    }
                }
            }


            return movidas;
        }

        public List<List<int>> evaluarMovidas(int fila, int columna, String jugador)
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
            if (arriba != "0" && arriba != jugador)
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

            if (diagAbajoDer != "0" && diagAbajoDer != jugador)
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
                List<int> movidaDiagArribaIzq = evaluarDiagArribaIzq(fila, columna, jugador);
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

        public List<int> evaluarArriba(int fila, int columna, String jugador)
        {
            List<int> lista = new List<int>();
            for (int i = fila - 1; i >= 0; i--)//revisa que hay hacia arriba de la ficha
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
            int i = fila + 1; int j = columna + 1;
            while (i < this.size && j < this.size)
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
                i++;
                j++;
            }

            return lista;
        }

        public List<int> evaluarDiagAbajoIzq(int fila, int columna, String jugador)
        {
            List<int> lista = new List<int>();
            int i = fila + 1; int j = columna - 1;
            while (i >= 0 && j >= 0)
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
                i++;
                j--;
            }

            return lista;
        }

        public List<int> evaluarDiagArribaDer(int fila, int columna, String jugador)
        {
            List<int> lista = new List<int>();
            int i = fila - 1; int j = columna + 1;

            while (i >= 0 && j < this.size)
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
                i--;
                j++;
            }

            return lista;
        }

        public List<int> evaluarDiagArribaIzq(int fila, int columna, String jugador)
        {
            List<int> lista = new List<int>();
            int i = fila - 1; int j = columna - 1;
            while (i >= 0 && j >= 0)
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
                i--;
                j--;
            }

            return lista;
        }

        //realiza la jugada
        public void realizarJugada(String jugador)
        {
            String rival;
            if (jugador == "1") rival = "2";
            else rival = "1";
            for (int i = 0; i < this.size; i++)
            {
                for (int j = 0; j < this.size; j++)
                {
                    if (this.tablero[i,j] == rival)
                    {
                        List<List<int>> fichasComibles = evaluarFichasComibles(i, j, jugador);
                        actualizarTablero(fichasComibles, jugador);
                    }
                }
            }

        }

        public List<List<int>> evaluarFichasComibles(int fila, int columna, String jugador)
        {
            List<List<int>> comibles = new List<List<int>>();

            List<List<int>> chkIzq = checkIzq(fila,columna, jugador);
            List<List<int>> chkDer = checkDerecha(fila, columna, jugador);
            List<List<int>> chkArriba = checkArriba(fila, columna, jugador);
            List<List<int>> chkAbajo = checkAbajo(fila, columna, jugador);
            List<List<int>> chkArribaIzq = checkArribaIzq(fila, columna, jugador);
            List<List<int>> chkArribaDer = checkArribaDer(fila, columna, jugador);
            List<List<int>> chkAbajoIzq = checkAbajoIzq(fila, columna, jugador);
            List<List<int>> chkAbajoDer = checkAbajoDer(fila, columna, jugador);
            if(chkDer != null && chkIzq != null)
            {
                foreach (List<int> lista in chkIzq) comibles.Add(lista);
                foreach (List<int> lista in chkDer) comibles.Add(lista);
            }
            if(chkArriba != null && chkAbajo != null)
            {
                foreach (List<int> lista in chkArriba) comibles.Add(lista);
                foreach (List<int> lista in chkAbajo) comibles.Add(lista);
            }
            if(chkArribaIzq != null && chkAbajoDer != null)
            {
                foreach (List<int> lista in chkArribaIzq) comibles.Add(lista);
                foreach (List<int> lista in chkAbajoDer) comibles.Add(lista);
            }
            if(chkArribaDer != null && chkAbajoIzq != null)
            {
                foreach (List<int> lista in chkArribaDer) comibles.Add(lista);
                foreach (List<int> lista in chkAbajoIzq) comibles.Add(lista);
            }
            return comibles;

        }

        public List<List<int>> checkIzq(int fila, int columna, String jugador)
        {
            int i = columna;
            List<List<int>> fichas = new List<List<int>>();
            while (i > 0 && this.tablero[fila,i-1]!="0")
            {
                List<int> fichaActual = new List<int>();
                fichaActual.Add(fila);
                fichaActual.Add(i);
                fichas.Add(fichaActual);
                if (this.tablero[fila, i - 1] == jugador) return fichas;
                i--;
            }
            return null;
            
        }

        public List<List<int>> checkDerecha(int fila, int columna, String jugador)
        {
            int i = columna;
            List<List<int>> fichas = new List<List<int>>();
            while (i < this.size - 1 && this.tablero[fila, i + 1] != "0")
            {
                List<int> fichaActual = new List<int>();
                fichaActual.Add(fila);
                fichaActual.Add(i);
                fichas.Add(fichaActual);
                if (this.tablero[i + 1, columna] == jugador) return fichas;
                i++;
            }
            return null;

        }

        public List<List<int>> checkArriba(int fila, int columna, String jugador)
        {
            int i = fila;
            List<List<int>> fichas = new List<List<int>>();
            while (i > 0 && this.tablero[i - 1, columna] != "0")
            {
                List<int> fichaActual = new List<int>();
                fichaActual.Add(i);
                fichaActual.Add(columna);
                fichas.Add(fichaActual);
                if (this.tablero[i - 1, columna] == jugador) return fichas;
                i--;
            }
            return null;

        }

        public List<List<int>> checkAbajo(int fila, int columna, String jugador)
        {
            int i = fila;
            List<List<int>> fichas = new List<List<int>>();
            while (i < this.size - 1 && this.tablero[i + 1, columna] != "0")
            {
                List<int> fichaActual = new List<int>();
                fichaActual.Add(i);
                fichaActual.Add(columna);
                fichas.Add(fichaActual);
                if (this.tablero[i + 1, columna] == jugador) return fichas;
                i++;
            }
            return null;

        }

        public List<List<int>> checkArribaIzq(int fila, int columna, String jugador)
        {
            int i = fila; int j = columna;
            List<List<int>> fichas = new List<List<int>>();
            while(i > 0 && j > 0 && this.tablero[i - 1, j - 1] != "0")
            {
                List<int> fichaActual = new List<int>();
                fichaActual.Add(i);
                fichaActual.Add(j);
                fichas.Add(fichaActual);
                if (this.tablero[i - 1, j - 1] == jugador) return fichas;
                i--;
                j--;
            }

            return null;
        }

        public List<List<int>> checkAbajoIzq(int fila, int columna, String jugador)
        {
            int i = fila; int j = columna;
            List<List<int>> fichas = new List<List<int>>();
            while (i < this.size - 1 && j > 0 && this.tablero[i + 1, j - 1] != "0")
            {
                List<int> fichaActual = new List<int>();
                fichaActual.Add(i);
                fichaActual.Add(j);
                fichas.Add(fichaActual);
                if (this.tablero[i + 1, j - 1] == jugador) return fichas;
                i++;
                j--;
            }

            return null;
        }

        public List<List<int>> checkArribaDer(int fila, int columna, String jugador)
        {
            int i = fila; int j = columna;
            List<List<int>> fichas = new List<List<int>>();
            while (i > 0 && j < this.size - 1 && this.tablero[i - 1, j + 1] != "0")
            {
                List<int> fichaActual = new List<int>();
                fichaActual.Add(i);
                fichaActual.Add(j);
                fichas.Add(fichaActual);
                if (this.tablero[i - 1, j + 1] == jugador) return fichas;
                i--;
                j++;
            }

            return null;
        }

        public List<List<int>> checkAbajoDer(int fila, int columna, String jugador)
        {
            int i = fila; int j = columna;
            List<List<int>> fichas = new List<List<int>>();
            while (i > this.size - 1 && j < this.size - 1 && this.tablero[i + 1, j + 1] != "0")
            {
                List<int> fichaActual = new List<int>();
                fichaActual.Add(i);
                fichaActual.Add(j);
                fichas.Add(fichaActual);
                if (this.tablero[i + 1, j + 1] == jugador) return fichas;
                i++;
                j++;
            }

            return null;
        }

        public void actualizarTablero(List<List<int>> fichasComibles, String nuevaFicha)
        {
            foreach(List<int> ficha in fichasComibles)
            {
                this.tablero[ficha[0], ficha[1]] = nuevaFicha;
            }
        }

        //dibuja el tablero en la consola
        public void dibujar()
        {
            for (int i = 0; i < this.size; i++)
            {
                for (int j = 0; j < this.size; j++)
                {
                    Console.SetCursorPosition(j * 4, i + 1);
                    Console.Write(this.tablero[i, j]);
                }
            }

        }





    }
}
