using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaJuegoConsola
{
    public partial class Ventana : Form
    {
        Juego juego = new Juego(8,1);
        Button[,] buttonArray;
        
        public Ventana()
        {
            InitializeComponent();
        }

        public void Ventana_Load(object sender, EventArgs e)
        {
            
            int horizotal = 30;
            int vertical = 30;
            int size = juego.getSize();
            buttonArray = new Button[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    buttonArray[i, j] = new Button();
                    buttonArray[i, j].Size = new Size(60, 23);
                    buttonArray[i, j].Location = new Point(horizotal, vertical);
                    if (juego.getTablero()[i, j] == "0") buttonArray[i, j].Text = " ";
                    else buttonArray[i, j].Text = juego.getTablero()[i, j];
                    buttonArray[i, j].Tag = i + "," + j;
                    buttonArray[i, j].Click += myEventHandler;
                    vertical += 30;
                    this.Controls.Add(buttonArray[i, j]);
                }
                horizotal += 80;
                vertical = 30;
            }
            horizotal += 80;
            vertical = 30;
            
            turno.Text = "Turno: jugador " + juego.getJugador();
            fichasJ1.Text = "Fichas jugador 1: " + juego.getFichasJ1();
            fichasJ2.Text = "Fichas jugador 2: " + juego.getFichasJ2();

        }


        void myEventHandler(object sender, EventArgs e)
        {
            Console.WriteLine("Se hizo click a un boton!!");
            Button button = sender as Button;
            List<List<int>> movidas = juego.MovidasPosibles();
            juego.getJugadasPosibles();//imprime las jugadas en consola
            String[] indexes = button.Tag.ToString().Split(',');
            int j = Int32.Parse(indexes[0]);
            int i = Int32.Parse(indexes[1]);
            foreach (List<int> movida in movidas)
            {
                if (i == movida[0] && j == movida[1])
                {
                    Console.WriteLine("Esa posicion es correcta!!");
                    juego.realizarJugada(i,j,false);
                    if (juego.getJuegoTerminado())
                    {
                        updateButtons();
                        mensajeTerminado();
                        break;
                    } 
                    juego.turnoSistema();
                    if (juego.getJuegoTerminado())
                    {
                        updateButtons();
                        mensajeTerminado();
                        break;
                    }
                    updateButtons();
                    break;
                }
            }



        }

        public void updateButtons()
        {
            if(juego.getJugador()=="2") Thread.Sleep(2000);
            turno.Text = "Turno: jugador " + juego.getJugador();
            fichasJ1.Text = "Fichas jugador 1: " + juego.getFichasJ1();
            fichasJ2.Text = "Fichas jugador 2: " + juego.getFichasJ2();
            for (int fila = 0; fila < juego.getSize(); fila++)
            {
                for (int columna = 0; columna < juego.getSize(); columna++)
                {
                    if (juego.getTablero()[fila, columna] == "0")
                    {
                        buttonArray[columna, fila].Text = " ";
                    }
                    else buttonArray[columna, fila].Text = juego.getTablero()[fila, columna];

                }
            }
        }

        public void mensajeTerminado()
        {
            Form mensaje = new Form();
            mensaje.Width = 600;
            mensaje.Height = 600;
            mensaje.Text = "Juego Terminado!";
            Label ganador = new Label() { Left = 50, Top = 20, Text=juego.getGanador() };
            Label fichasj1 = new Label() { Left = 60, Top = 30, Text = "Fichas jugador 1: " + juego.getFichasJ1() };
            Label fichasj2 = new Label() { Left = 70, Top = 40, Text = "Fichas jugador 2: " + juego.getFichasJ2() };
            Button ok = new Button() { Text = "OK", Left = 350, Width = 100, Top = 150 };
            ok.Click += (sender, e) => { mensaje.Close(); this.Close(); };
            mensaje.Controls.Add(ok);
            mensaje.Controls.Add(ganador);
            mensaje.Controls.Add(fichasj1);
            mensaje.Controls.Add(fichasj2);
            mensaje.ShowDialog();
        }

    }
}
