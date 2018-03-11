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
        String jugador;
        String rival;
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

        public void setJugador(String j)
        {
            if (j == "1")
            {
                this.jugador = j;
                this.rival = "2";
            }
            else
            {
                this.jugador = j;
                this.rival = "1";
            }
        }

        public String getJugador()
        {
            return this.jugador;
        }

        public String getRival()
        {
            return this.rival;
        }


        public void getJugadasPosibles()
        {
            foreach(List<int> jugada in jugadasPosibles)
            {
                Console.Write("[" + jugada[0] + "," + jugada[1] + "] ");
            }
            Console.Write("\n");
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
            /*
            this.tablero[0, 0] = "1";
            this.tablero[6, 0] = "1";
            this.tablero[1, 1] = "2";
            this.tablero[4, 1] = "1";
            this.tablero[5, 1] = "2";
            this.tablero[2, 2] = "2";
            this.tablero[3, 2] = "1";
            this.tablero[4, 2] = "2";
            this.tablero[5, 2] = "1";
            this.tablero[1, 4] = "1";
            this.tablero[2, 4] = "2";
            this.tablero[1, 5] = "1";
            this.tablero[2, 5] = "1";
            this.tablero[5, 5] = "2";
            this.tablero[6, 6] = "1";
            */
        }

        //funcion que retorna una lista con todas las posibles jugadas que tiene el jugador de turno.
        public List<List<int>> MovidasPosibles()
        {
            //lista con las movidas posibles en base a cual es el jugador a turno
            List<List<int>> movidas = new List<List<int>>();
            for (int i = 0; i < this.size; i++)
            {
                for (int j = 0; j < this.size; j++)
                {
                    if (this.tablero[i, j] == this.jugador)//si se encuentra una ficha del jugador
                    {//busca las movidas posibles para esa ficha
                        List<List<int>> movidasFicha = evaluarMovidas(i, j);
                        foreach (List<int> lista in movidasFicha)
                        {
                            if(lista.Count>0)
                            movidas.Add(lista);//agrega las movidas de esa ficha a la lista general de movidas
                        }
                    }
                }
            }
            this.jugadasPosibles = movidas;
            return movidas;
        }

        public List<List<int>> evaluarMovidas(int fila, int columna)
        {//evalua segun la ficha del usuario indicada, si tiene movidas en base a esa ficha
            List<List<int>> movidas = new List<List<int>>();
            String arriba, abajo, izq, der, diagArribaIzq, diagArribaDer, diagAbajoIzq, diagAbajoDer;
            if(Enumerable.Range(1,this.size-2).Contains(fila) && Enumerable.Range(1, this.size - 2).Contains(columna))
            {
                arriba = this.tablero[fila - 1, columna];
                abajo = this.tablero[fila + 1, columna];
                izq = this.tablero[fila, columna - 1];
                der = this.tablero[fila, columna + 1];
                diagArribaIzq = this.tablero[fila - 1, columna - 1];
                diagAbajoIzq = this.tablero[fila + 1, columna - 1];
                diagArribaDer = this.tablero[fila - 1, columna + 1];
                diagAbajoDer = this.tablero[fila + 1, columna + 1];

                if (arriba == this.rival)
                {
                    List<int> movidaArriba = evaluarArriba(fila, columna);
                    movidas.Add(movidaArriba);
                }
                if (abajo == this.rival)
                {
                    List<int> movidaAbajo = evaluarAbajo(fila, columna);
                    movidas.Add(movidaAbajo);
                }
                if (izq == this.rival)
                {
                    List<int> movidaIzq = evaluarIzq(fila, columna);
                    movidas.Add(movidaIzq);
                }
                if (der == this.rival)
                {
                    List<int> movidaDer = evaluarDer(fila, columna);
                    movidas.Add(movidaDer);
                }

                if (diagAbajoDer == this.rival)
                {
                    List<int> movidaDiagArribaDer = evaluarDiagAbajoDer(fila, columna);
                    movidas.Add(movidaDiagArribaDer);
                }
                if (diagAbajoIzq == this.rival)
                {
                    List<int> movidaDiagAbajoIzq = evaluarDiagAbajoIzq(fila, columna);
                    movidas.Add(movidaDiagAbajoIzq);
                }
                if (diagArribaDer == this.rival)
                {
                    List<int> movidaDiagArribaDer = evaluarDiagArribaDer(fila, columna);
                    movidas.Add(movidaDiagArribaDer);
                }
                if (diagArribaIzq == this.rival)
                {
                    List<int> movidaDiagArribaIzq = evaluarDiagArribaIzq(fila, columna);
                    movidas.Add(movidaDiagArribaIzq);
                }

            }

            else if (fila<=0 && Enumerable.Range(1, this.size - 1).Contains(columna))
            {//si la ficha esta chocando con la pared superior del tablero
                abajo = this.tablero[fila + 1, columna];
                izq = this.tablero[fila, columna - 1];
                der = this.tablero[fila, columna + 1];
                diagAbajoIzq = this.tablero[fila + 1, columna - 1];
                diagAbajoDer = this.tablero[fila + 1, columna + 1];

                if (abajo == this.rival)
                {
                    List<int> movidaAbajo = evaluarAbajo(fila, columna);
                    movidas.Add(movidaAbajo);
                }
                if (izq == this.rival)
                {
                    List<int> movidaIzq = evaluarIzq(fila, columna);
                    movidas.Add(movidaIzq);
                }
                if (der == this.rival)
                {
                    List<int> movidaDer = evaluarDer(fila, columna);
                    movidas.Add(movidaDer);
                }

                if (diagAbajoDer == this.rival)
                {
                    List<int> movidaDiagArribaDer = evaluarDiagAbajoDer(fila, columna);
                    movidas.Add(movidaDiagArribaDer);
                }
                if (diagAbajoIzq == this.rival)
                {
                    List<int> movidaDiagAbajoIzq = evaluarDiagAbajoIzq(fila, columna);
                    movidas.Add(movidaDiagAbajoIzq);
                }
            }
            
            else if(fila>=this.size - 1 && Enumerable.Range(1, this.size - 2).Contains(columna))
            {//si la ficha esta chocando con la pared posterior
                arriba = this.tablero[fila - 1, columna];
                izq = this.tablero[fila, columna - 1];
                der = this.tablero[fila, columna + 1];
                diagArribaIzq = this.tablero[fila - 1, columna - 1];
                diagArribaDer = this.tablero[fila - 1, columna + 1];

                if (arriba == this.rival)
                {
                    List<int> movidaArriba = evaluarArriba(fila, columna);
                    movidas.Add(movidaArriba);
                }
                if (izq == this.rival)
                {
                    List<int> movidaIzq = evaluarIzq(fila, columna);
                    movidas.Add(movidaIzq);
                }
                if (der == this.rival)
                {
                    List<int> movidaDer = evaluarDer(fila, columna);
                    movidas.Add(movidaDer);
                }
                if (diagArribaDer == this.rival)
                {
                    List<int> movidaDiagArribaDer = evaluarDiagArribaDer(fila, columna);
                    movidas.Add(movidaDiagArribaDer);
                }
                if (diagArribaIzq == this.rival)
                {
                    List<int> movidaDiagArribaIzq = evaluarDiagArribaIzq(fila, columna);
                    movidas.Add(movidaDiagArribaIzq);
                }
            }
            
            else if(columna<=0 && Enumerable.Range(1, this.size - 2).Contains(fila))
            {//si la ficha esta chocando con la pared izquierda
                arriba = this.tablero[fila - 1, columna];
                abajo = this.tablero[fila + 1, columna];
                der = this.tablero[fila, columna + 1];
                diagArribaDer = this.tablero[fila - 1, columna + 1];
                diagAbajoDer = this.tablero[fila + 1, columna + 1];

                if (arriba == this.rival)
                {
                    List<int> movidaArriba = evaluarArriba(fila, columna);
                    movidas.Add(movidaArriba);
                }
                if (abajo == this.rival)
                {
                    List<int> movidaAbajo = evaluarAbajo(fila, columna);
                    movidas.Add(movidaAbajo);
                }
                if (der == this.rival)
                {
                    List<int> movidaDer = evaluarDer(fila, columna);
                    movidas.Add(movidaDer);
                }

                if (diagAbajoDer == this.rival)
                {
                    List<int> movidaDiagArribaDer = evaluarDiagAbajoDer(fila, columna);
                    movidas.Add(movidaDiagArribaDer);
                }
                if (diagArribaDer == this.rival)
                {
                    List<int> movidaDiagArribaDer = evaluarDiagArribaDer(fila, columna);
                    movidas.Add(movidaDiagArribaDer);
                }

            }

            else if (columna >= this.size - 1 && Enumerable.Range(1, this.size - 2).Contains(fila))
            {//si la ficha esta chocando con la pared derecha
                arriba = this.tablero[fila - 1, columna];
                abajo = this.tablero[fila + 1, columna];
                izq = this.tablero[fila, columna - 1];
                diagArribaIzq = this.tablero[fila - 1, columna - 1];
                diagAbajoIzq = this.tablero[fila + 1, columna - 1];

                if (arriba == this.rival)
                {
                    List<int> movidaArriba = evaluarArriba(fila, columna);
                    movidas.Add(movidaArriba);
                }
                if (abajo == this.rival)
                {
                    List<int> movidaAbajo = evaluarAbajo(fila, columna);
                    movidas.Add(movidaAbajo);
                }
                if (izq == this.rival)
                {
                    List<int> movidaIzq = evaluarIzq(fila, columna);
                    movidas.Add(movidaIzq);
                }
                if (diagAbajoIzq == this.rival)
                {
                    List<int> movidaDiagAbajoIzq = evaluarDiagAbajoIzq(fila, columna);
                    movidas.Add(movidaDiagAbajoIzq);
                }
                if (diagArribaIzq == this.rival)
                {
                    List<int> movidaDiagArribaIzq = evaluarDiagArribaIzq(fila, columna);
                    movidas.Add(movidaDiagArribaIzq);
                }

            }

            else if(fila<=0 && columna <= 0)
            {//si la ficha se encuentra en la esquina superior izquierda del tablero
                abajo = this.tablero[fila + 1, columna];
                der = this.tablero[fila, columna + 1];
                diagAbajoDer = this.tablero[fila + 1, columna + 1];

                if (abajo == this.rival)
                {
                    List<int> movidaAbajo = evaluarAbajo(fila, columna);
                    movidas.Add(movidaAbajo);
                }
                if (der == this.rival)
                {
                    List<int> movidaDer = evaluarDer(fila, columna);
                    movidas.Add(movidaDer);
                }

                if (diagAbajoDer == this.rival)
                {
                    List<int> movidaDiagArribaDer = evaluarDiagAbajoDer(fila, columna);
                    movidas.Add(movidaDiagArribaDer);
                }
            }

            else if(fila>= this.size - 1 && columna <= 0)
            {//si la ficha se encuentra en la esquina inferior izquierda del tablero
                arriba = this.tablero[fila - 1, columna];
                der = this.tablero[fila, columna + 1];
                diagArribaDer = this.tablero[fila - 1, columna + 1];

                if (arriba == this.rival)
                {
                    List<int> movidaArriba = evaluarArriba(fila, columna);
                    movidas.Add(movidaArriba);
                }
                if (der == this.rival)
                {
                    List<int> movidaDer = evaluarDer(fila, columna);
                    movidas.Add(movidaDer);
                }
                if (diagArribaDer == this.rival)
                {
                    List<int> movidaDiagArribaDer = evaluarDiagArribaDer(fila, columna);
                    movidas.Add(movidaDiagArribaDer);
                }
            }

            else if(fila<=0 && columna >= this.size - 1)
            {//si la ficha se encuentra en la esquina superior derecha
                abajo = this.tablero[fila + 1, columna];
                izq = this.tablero[fila, columna - 1];
                diagAbajoIzq = this.tablero[fila + 1, columna - 1];

                if (abajo == this.rival)
                {
                    List<int> movidaAbajo = evaluarAbajo(fila, columna);
                    movidas.Add(movidaAbajo);
                }
                if (izq == this.rival)
                {
                    List<int> movidaIzq = evaluarIzq(fila, columna);
                    movidas.Add(movidaIzq);
                }
                if (diagAbajoIzq == this.rival)
                {
                    List<int> movidaDiagAbajoIzq = evaluarDiagAbajoIzq(fila, columna);
                    movidas.Add(movidaDiagAbajoIzq);
                }
            }

            else
            {//si la ficha se encuentra en la esquina inferior derecha
                arriba = this.tablero[fila - 1, columna];
                izq = this.tablero[fila, columna - 1];
                diagArribaIzq = this.tablero[fila - 1, columna - 1];

                if (arriba == this.rival)
                {
                    List<int> movidaArriba = evaluarArriba(fila, columna);
                    movidas.Add(movidaArriba);
                }
                if (izq == this.rival)
                {
                    List<int> movidaIzq = evaluarIzq(fila, columna);
                    movidas.Add(movidaIzq);
                }
                if (diagArribaIzq == this.rival)
                {
                    List<int> movidaDiagArribaIzq = evaluarDiagArribaIzq(fila, columna);
                    movidas.Add(movidaDiagArribaIzq);
                }
            }

            return movidas;
        }

        public List<int> evaluarDer(int fila, int columna)
        {
            List<int> lista = new List<int>();
            for (int i = columna + 1; i < this.size; i++)//revisa que hay hacia la derecha de la ficha
            {
                if (this.tablero[fila, i] == this.jugador)
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

        public List<int> evaluarIzq(int fila, int columna)
        {
            List<int> lista = new List<int>();
            for (int i = columna - 1; i >= 0; i--)//revisa que hay hacia la izquierda de la ficha
            {
                if (this.tablero[fila, i] == this.jugador)
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

        public List<int> evaluarAbajo(int fila, int columna)
        {
            List<int> lista = new List<int>();
            for (int i = fila + 1; i < this.size; i++)//revisa que hay hacia abajo de la ficha
            {
                if (this.tablero[i, columna] == this.jugador)
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

        public List<int> evaluarArriba(int fila, int columna)
        {
            List<int> lista = new List<int>();
            for (int i = fila - 1; i >= 0; i--)//revisa que hay hacia arriba de la ficha
            {
                if (this.tablero[i, columna] == this.jugador)
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

        public List<int> evaluarDiagAbajoDer(int fila, int columna)
        {
            List<int> lista = new List<int>();
            int i = fila + 1; int j = columna + 1;
            while (i < this.size && j < this.size)
            {
                if (this.tablero[i, j] == this.jugador)
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

        public List<int> evaluarDiagAbajoIzq(int fila, int columna)
        {
            List<int> lista = new List<int>();
            int i = fila + 1; int j = columna - 1;
            while (i >= 0 && j >= 0)
            {
                if (this.tablero[i, j] == this.jugador)
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

        public List<int> evaluarDiagArribaDer(int fila, int columna)
        {
            List<int> lista = new List<int>();
            int i = fila - 1; int j = columna + 1;

            while (i >= 0 && j < this.size)
            {
                if (this.tablero[i, j] == this.jugador)
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

        public List<int> evaluarDiagArribaIzq(int fila, int columna)
        {
            List<int> lista = new List<int>();
            int i = fila - 1; int j = columna - 1;
            while (i >= 0 && j >= 0)
            {
                if (this.tablero[i, j] == this.jugador)
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
        public void realizarJugada(int fila, int columna)
        {
            this.tablero[fila, columna] = this.jugador;
            for (int i = 0; i < this.size; i++)
            {
                for (int j = 0; j < this.size; j++)
                {
                    if (this.tablero[i,j] == this.rival)
                    {
                        List<List<int>> fichasComibles = evaluarFichasComibles(i, j);
                        actualizarTablero(fichasComibles);
                    }
                }
            }

            if (this.getJugador() == "1") this.setJugador("2");
            else this.setJugador("1");

        }

        public List<List<int>> evaluarFichasComibles(int fila, int columna)
        {
            List<List<int>> comibles = new List<List<int>>();
            List<List<int>> chkIzq = checkIzq(fila,columna);
            List<List<int>> chkDer = checkDerecha(fila, columna);
            List<List<int>> chkArriba = checkArriba(fila, columna);
            List<List<int>> chkAbajo = checkAbajo(fila, columna);
            List<List<int>> chkArribaIzq = checkArribaIzq(fila, columna);
            List<List<int>> chkArribaDer = checkArribaDer(fila, columna);
            List<List<int>> chkAbajoIzq = checkAbajoIzq(fila, columna);
            List<List<int>> chkAbajoDer = checkAbajoDer(fila, columna);
            if(chkDer != null && chkIzq != null)
            {//si la ficha rival actual se encuentra entre 2 fichas del jugador
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

        public List<List<int>> checkIzq(int fila, int columna)
        {
            int i = columna;
            List<List<int>> fichas = new List<List<int>>();
            while (i > 0 && this.tablero[fila,i-1]!="0")
            {
                List<int> fichaActual = new List<int>();
                fichaActual.Add(fila);
                fichaActual.Add(i);
                fichas.Add(fichaActual);
                if (this.tablero[fila, i - 1] == this.jugador) return fichas;
                i--;
            }
            return null;
            
        }

        public List<List<int>> checkDerecha(int fila, int columna)
        {
            int i = columna;
            List<List<int>> fichas = new List<List<int>>();
            while (i < this.size - 1 && this.tablero[fila, i + 1] != "0")
            {
                List<int> fichaActual = new List<int>();
                fichaActual.Add(fila);
                fichaActual.Add(i);
                fichas.Add(fichaActual);
                if (this.tablero[fila, i + 1] == this.jugador) return fichas;
                i++;
            }
            return null;

        }

        public List<List<int>> checkArriba(int fila, int columna)
        {
            int i = fila;
            List<List<int>> fichas = new List<List<int>>();
            while (i > 0 && this.tablero[i - 1, columna] != "0")
            {
                List<int> fichaActual = new List<int>();
                fichaActual.Add(i);
                fichaActual.Add(columna);
                fichas.Add(fichaActual);
                if (this.tablero[i - 1, columna] == this.jugador) return fichas;
                i--;
            }
            return null;

        }

        public List<List<int>> checkAbajo(int fila, int columna)
        {
            int i = fila;
            List<List<int>> fichas = new List<List<int>>();
            while (i < this.size - 1 && this.tablero[i + 1, columna] != "0")
            {
                List<int> fichaActual = new List<int>();
                fichaActual.Add(i);
                fichaActual.Add(columna);
                fichas.Add(fichaActual);
                if (this.tablero[i + 1, columna] == this.jugador) return fichas;
                i++;
            }
            return null;

        }

        public List<List<int>> checkArribaIzq(int fila, int columna)
        {
            int i = fila; int j = columna;
            List<List<int>> fichas = new List<List<int>>();
            while(i > 0 && j > 0 && this.tablero[i - 1, j - 1] != "0")
            {
                List<int> fichaActual = new List<int>();
                fichaActual.Add(i);
                fichaActual.Add(j);
                fichas.Add(fichaActual);
                if (this.tablero[i - 1, j - 1] == this.jugador) return fichas;
                i--;
                j--;
            }

            return null;
        }

        public List<List<int>> checkAbajoIzq(int fila, int columna)
        {
            int i = fila; int j = columna;
            List<List<int>> fichas = new List<List<int>>();
            while (i < this.size - 1 && j > 0 && this.tablero[i + 1, j - 1] != "0")
            {
                List<int> fichaActual = new List<int>();
                fichaActual.Add(i);
                fichaActual.Add(j);
                fichas.Add(fichaActual);
                if (this.tablero[i + 1, j - 1] == this.jugador) return fichas;
                i++;
                j--;
            }

            return null;
        }

        public List<List<int>> checkArribaDer(int fila, int columna)
        {
            int i = fila; int j = columna;
            List<List<int>> fichas = new List<List<int>>();
            while (i > 0 && j < this.size - 1 && this.tablero[i - 1, j + 1] != "0")
            {
                List<int> fichaActual = new List<int>();
                fichaActual.Add(i);
                fichaActual.Add(j);
                fichas.Add(fichaActual);
                if (this.tablero[i - 1, j + 1] == this.jugador) return fichas;
                i--;
                j++;
            }

            return null;
        }

        public List<List<int>> checkAbajoDer(int fila, int columna)
        {
            int i = fila; int j = columna;
            List<List<int>> fichas = new List<List<int>>();
            while (i < this.size - 1 && j < this.size - 1 && this.tablero[i + 1, j + 1] != "0")
            {
                List<int> fichaActual = new List<int>();
                fichaActual.Add(i);
                fichaActual.Add(j);
                fichas.Add(fichaActual);
                if (this.tablero[i + 1, j + 1] == this.jugador) return fichas;
                i++;
                j++;
            }

            return null;
        }

        public void actualizarTablero(List<List<int>> fichasComibles)
        {
            foreach(List<int> ficha in fichasComibles)
            {
                this.tablero[ficha[0], ficha[1]] = this.jugador;
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
            Console.Write("\n");
            Console.ReadKey();
        }





    }
}
