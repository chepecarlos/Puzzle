using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzle
{
    public partial class Form1 : Form
    {
        int Sx = 0;
        int Sy = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void TRUE(object sender, KeyEventArgs e)
        {

        }

        private void B3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            // Assign the event handler to the form.
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            // Assign the event handler to the text box.
            //this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //MessageBox.Show(e.KeyValue);

            if (e.KeyCode.ToString() == "Left" )
            {
                OpLeft();
                //this.KeyPreview = false;
                //MessageBox.Show("KeyPreview is True, and this is from the FORM.");
            
            }
            else if (e.KeyCode.ToString() == "Right")
            {
                OpRight();
                //this.KeyPreview = false;
                //MessageBox.Show("KeyPreview is True, and this is from the FORM.");

            }
            else if (e.KeyCode.ToString() == "Up")
            {
                //this.KeyPreview = false;
                //MessageBox.Show("KeyPreview is True, and this is from the FORM.");
                OpUp();

            }
            else if (e.KeyCode.ToString() == "Down")
            {
                OpDown();
                //this.KeyPreview = false;
                //MessageBox.Show("KeyPreview is True, and this is from the FORM.");

            }
            else if (e.KeyCode.ToString() == "R")
            {

                //MessageBox.Show("KeyPreview is True, and this is from the FORM.");

                SuperRandon();
              
            }
            else if (e.KeyCode.ToString() == "E")
            {
                if (Examen())
                {
                    MessageBox.Show("Felicidades :D");
                }
            }

        }
  
        private void GB_Enter(object sender, EventArgs e)
        {

        }

        public bool Examen()
        {
            int[] lote = {1,8,7,
                         2,0,6,
                         3,4,5};
            int i = 0;
            bool Nota = true;
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    if (TuNombre(x, y) != lote[i])
                    {
                        MessageBox.Show("Aun le falta ordenar X:"+x.ToString()+" Y:"+y.ToString()+" valor "+lote[i].ToString());
                        Nota = false;
                        return Nota;
                    }
                    i++;
                }
            }
            return Nota;
        }

        public void OpUp()
        {
            if (Sx != 0)
            {
                int tmp = TuNombre(Sx-1, Sy);
                TeLlamaras(Sx, Sy, tmp);
                TeLlamaras(Sx - 1, Sy, 0);
            }

        }

        public void OpDown()
        {
            if (Sx != 2)
            {
                int tmp = TuNombre(Sx + 1, Sy);
                TeLlamaras(Sx, Sy, tmp);
                TeLlamaras(Sx + 1, Sy, 0);
            }

        }

        public void OpRight()
        {

            if (Sy != 2)
            {
                int tmp = TuNombre(Sx, Sy + 1);
                TeLlamaras(Sx, Sy, tmp);
                TeLlamaras(Sx, Sy + 1, 0);

            }
            
        }

        public void OpLeft()
        {
            if (Sy != 0)
            {
                int tmp = TuNombre(Sx, Sy - 1);
                TeLlamaras(Sx, Sy, tmp);
                TeLlamaras(Sx, Sy - 1, 0);

            }

        }

        public void SuperRandon() {
            Random r = new Random();
            int pollo = 0;
            //int x = 0, y = 0;
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++) {
                    TeLlamaras(x, y, 10);
                }
            }
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    do{
                        pollo = r.Next(0,9);
                        for (int xxx = 0; xxx < 3; xxx++)
                        {
                            for (int yyy = 0; yyy < 3; yyy++)
                            {
                                if (TuNombre(xxx, yyy) == pollo)
                                {
                                    pollo = 11;
                                }
                            }
                        }
                    }while(pollo > 8);
                    TeLlamaras(x,y,pollo);
                   
                }
            }
            
        }

        public void Niegate(int x, int y, bool v)
        {
            if (x == 0 && y == 0)
            {
                B00.Visible = v;
            }
            else if (x == 0 && y == 1)
            {
                B01.Visible = v;
            }
            else if (x == 0 && y == 2)
            {
                B02.Visible = v;
            }
            else if (x == 1 && y == 0)
            {
                B10.Visible = v;
            }
            else if (x == 1 && y == 1)
            {
                B11.Visible = v;
            }
            else if (x == 1 && y == 2)
            {
                B12.Visible = v;
            }
            else if (x == 2 && y == 0)
            {
                B20.Visible = v;
            }
            else if (x == 2 && y == 1)
            {
                B21.Visible = v;
            }
            else if (x == 2 && y == 2)
            {
                B22.Visible = v;
            }

        }

        public int TuNombre(int x, int y)
        {
            if (x == 0 && y == 0)
            {
                return Convert.ToInt16(B00.Text.ToString());
            }
            else if (x == 0 && y == 1)
            {
                return Convert.ToInt16(B01.Text.ToString());
            }
            else if (x == 0 && y == 2)
            {
                return Convert.ToInt16(B02.Text.ToString());
            }
            else if (x == 1 && y == 0)
            {
                return Convert.ToInt16(B10.Text.ToString());
            }
            else if (x == 1 && y == 1)
            {
                return Convert.ToInt16(B11.Text.ToString());
            }
            else if (x == 1 && y == 2)
            {
                return Convert.ToInt16(B12.Text.ToString());
            }
            else if (x == 2 && y == 0)
            {
                return Convert.ToInt16(B20.Text.ToString());
            }
            else if (x == 2 && y == 1)
            {
                return Convert.ToInt16(B21.Text.ToString());
            }
            //if (x == 2 && y == 2)
                return Convert.ToInt16(B22.Text.ToString());
            

        }

        public void TeLlamaras(int x, int y, int v) {

            if (x == 0 && y == 0) {
                B00.Text = v.ToString();
            }
            else if (x == 0 && y == 1)
            {
                B01.Text = v.ToString();
            }
            else if (x == 0 && y == 2)
            {
                B02.Text = v.ToString();
            }
            else if (x == 1 && y == 0)
            {
                B10.Text = v.ToString();
            }
            else if (x == 1 && y == 1)
            {
                B11.Text = v.ToString();
            }
            else if (x == 1 && y == 2)
            {
                B12.Text = v.ToString();
            }
            else if (x == 2 && y == 0)
            {
                B20.Text = v.ToString();
            }
            else if (x == 2 && y == 1)
            {
                B21.Text = v.ToString();
            }
            else if (x == 2 && y == 2)
            {
                B22.Text = v.ToString();
            }

            if (v == 0)
            {
                Niegate(x, y, false);
                Sx = x;
                Sy = y;
            }
            else
                Niegate(x, y, true);
        }

        private void B23_Click(object sender, EventArgs e)
        {

        }

        private void B00_Click(object sender, EventArgs e)
        {

        }
    }
}
