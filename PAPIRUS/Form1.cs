using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PAPIRUS
{
    public partial class Form1 : Form
    {   
        List<PictureBox> Temp = new List<PictureBox>();
        float zoom=1.1f;
        
        int zoom_index=0;
        int element_1_count = 1;



        bool status = false; // Для хранения статуса работы, true - перетаскивание, false - обычная работа
        public Form1()
        {
           
            InitializeComponent();
            
         
            panel1.MouseWheel += Scale;
            

            DoubleBuffered=true;
            
            
        }
        //Методы для увеличения и уменьшения масштаба
        public void Plus_zoom() 
        {
            foreach (Control cntrl in panel1.Controls)
            {

                cntrl.Left = Convert.ToInt32(cntrl.Left * zoom);
                cntrl.Top = Convert.ToInt32(cntrl.Top * zoom);

                cntrl.Width = Convert.ToInt32(cntrl.Width * zoom);
                cntrl.Height = Convert.ToInt32(cntrl.Height * zoom);

            }
        }
        public void Minus_zoom() 
        {
            foreach (Control cntrl in panel1.Controls)
            {

                cntrl.Left = Convert.ToInt32(cntrl.Left / zoom);
                cntrl.Top = Convert.ToInt32(cntrl.Top / zoom);

                cntrl.Width = Convert.ToInt32(cntrl.Width / zoom);
                cntrl.Height = Convert.ToInt32(cntrl.Height / zoom);

            }
        }
        private void Scale(object sender, MouseEventArgs e)
        {
            if (ModifierKeys == Keys.Shift)
            {
                
                if (e.Delta > 0 && zoom_index<7)
                {                  
                    Plus_zoom();
                }

                if (zoom_index <= -7 && e.Delta > 0)
                {
                    Plus_zoom();
                    zoom_index = -6;
                }
                else if (e.Delta < 0 && zoom_index>-7)
                {                   
                    Minus_zoom();
                }
                if (zoom_index >= 7 && e.Delta < 0)
                {
                    Minus_zoom();
                    zoom_index = 6;
                }

                if (e.Delta>0) zoom_index++;
                     else zoom_index--;
            }
        }//Масштабирование основного поля


















        private void component1_MouseDown(object sender, MouseEventArgs e)
        {
            status = true;
            Temp.Add(new PictureBox());   
            Temp.ElementAt(Temp.Count - 1).Image = component1.Image;
            Temp.ElementAt(Temp.Count - 1).Size = component1.Size;
            Temp.ElementAt(Temp.Count - 1).SizeMode = component1.SizeMode;
            panel1.Controls.Add(Temp.ElementAt(Temp.Count - 1));
        }

        private void component1_MouseMove(object sender, MouseEventArgs e)
        {
            if (status == true)
            {
                Temp.ElementAt(Temp.Count - 1).Location = new Point(MousePosition.X - this.Location.X - Temp.ElementAt(Temp.Count - 1).Width / 2, MousePosition.Y - this.Location.Y - Temp.ElementAt(Temp.Count - 1).Height);
            }
        }


        private void component1_MouseUp(object sender, MouseEventArgs e)
        {
            status = false;
        }

       

        /*   private void panel1_MouseMove(object sender, MouseEventArgs e)
           {
               if (e.Button == MouseButtons.Middle)
                   panel1.Location = new Point(MousePosition.X - this.Location.X, MousePosition.Y - this.Location.Y);
           }
        */
       

        
       
        
    }
}
