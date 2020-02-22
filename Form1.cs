
//150201222 MERT VAR

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Yuv_Cozucu
{
    public partial class Form1 : Form
    {
        String path;
        int framenumber=1;
        int imagenumber=1;
        long framesayisi;
        Boolean b1 = false;
        
        
        public Form1()
        {
            InitializeComponent();
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;

        }

        public void FrameOynat(long fr)
        {

            if (imagenumber > fr)
            {
                imagenumber = 1;
                b1 = false;
               
            }
            else
            {
                pictureBox1.ImageLocation = string.Format(@"Frame\\{0}.bmp", imagenumber);
                label3.Text = imagenumber.ToString() +"/"+ fr.ToString();
                imagenumber++;
            }
            
            
        }

        public void ConvertBitmap(byte[] bmpData, int width, int height, long fra)
        {
            
            if (framenumber == fra)
            {
                MessageBox.Show("İşleminiz başarıyla gerçekleşti", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button3.Enabled = true;
                button4.Enabled = true;
            }
            
            Bitmap bmp = new Bitmap(width, height);
            int index = 0;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    bmp.SetPixel(x, y, Color.FromArgb(bmpData[index], bmpData[index], bmpData[index]));
                    index++;
                }
                  
            }
            
            bmp.Save(@"Frame\\"+framenumber+".bmp");
            framenumber++;
         
        }

 
        public void Format420(String yol, int width, int height)
        {
            FileStream fs = new FileStream(yol, FileMode.Open);
            int a = 0;
            //Frame sayisi hesaplama
            framesayisi = fs.Length/((width*height*3)/2);
            Byte[] Y = new Byte[fs.Length];

            for(int j=0; j<framesayisi; j++)
            {
                //frame sayisi kadar döncek

            // Y değerlerinin okunması
            for (int i = 0; i < width*height; i++)
            {
                    //her framedeki pixel kadar döncek
                a = fs.ReadByte();
                if (a != -1)
                {
                    Y[i] = (Byte)a;
                }
            }

            // U ve V değerlerinin okunması
            for(int k=0; k<(width*height)/2; k++)
                {
                    a = fs.ReadByte();
                }
                ConvertBitmap(Y, width, height,framesayisi);
            }
            fs.Close();
            
        }
        public void Format422(String yol, int width, int height)
        {
            FileStream fs = new FileStream(yol, FileMode.Open);
            
            int a = 0;
            framesayisi = fs.Length / ((width * height * 2));
            Byte[] Y = new Byte[fs.Length];

            for (int j = 0; j < framesayisi; j++)
            {
                //frame kadar döncek

                for (int i = 0; i < width * height; i++)
                {
                    // Y değerlerinin okunması
                    //her framedeki pixel kadar döncek
                    a = fs.ReadByte();
                    if (a != -1)
                    {
                        Y[i] = (Byte)a;
                    }
                }
                // U ve V değerlerinin okunması
                for (int k = 0; k < (width * height); k++)
                {
                    a = fs.ReadByte();
                }

                ConvertBitmap(Y, width, height,framesayisi);
            }
            fs.Close();
            
        }
        public void Format444(String yol, int width, int height)
        {
            FileStream fs = new FileStream(yol, FileMode.Open);
            int a = 0;
            framesayisi = fs.Length / ((width * height * 3));
            Byte[] Y = new Byte[fs.Length];

            for (int j = 0; j < framesayisi; j++)
            {
                //frame kadar döncek

                for (int i = 0; i < width * height; i++)
                {
                    // Y değerlerinin okunması
                    //her framedeki pixel kadar döncek
                    a = fs.ReadByte();
                    if (a != -1)
                    {
                        Y[i] = (Byte)a;
                    }

                }
                // U ve V değerlerinin okunması
                for (int k = 0; k < (width * height*2); k++)
                {
                    a = fs.ReadByte();
                }

                ConvertBitmap(Y, width, height,framesayisi);
            }
            fs.Close();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                path = ofd.FileName;
            }
            button2.Enabled = true;
        }

        //ÇEVİR BUTONU

        private void button2_Click(object sender, EventArgs e)
        {

            //4:2:0 Formatı
            if (radioButton1.Checked == true)
            {
                int width = int.Parse(textBox1.Text);
                int height = int.Parse(textBox2.Text);
                Format420(path,width,height);
                framenumber = 1;
                imagenumber = 1;
            }
            //4:2:2 Formatı
            else if (radioButton2.Checked == true)
            {
                int width = int.Parse(textBox1.Text);
                int height = int.Parse(textBox2.Text);
                Format422(path, width, height);
                framenumber = 1;
                imagenumber = 1;

            }
            //4:4:4 Formatı
            else if (radioButton3.Checked == true)
            {
                int width = int.Parse(textBox1.Text);
                int height = int.Parse(textBox2.Text);
                Format444(path, width, height);
                framenumber = 1;
                imagenumber = 1;

            }

            else
            {
                MessageBox.Show("Bir hata oluştu.","HATA",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
   
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        //BAŞLAT BUTONU
        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Start();
            b1 = true;
        }
        //DURDUR BUTONU
        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            b1 = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (b1 == true)
            {
                FrameOynat(framesayisi);    
            }
        }

        // TEMİZLE BUTONU
        private void button5_Click(object sender, EventArgs e)
        {
            FileInfo fileInfo;
            string uzanti = ".bmp";
            foreach (string dosya in Directory.GetFiles(@"Frame"))
            {
                fileInfo = new FileInfo(dosya);
                if (fileInfo.Extension == uzanti) // Dosya Uzantısı bmp ise silme işlemi
                {
                    fileInfo.Delete();
                }
            }
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
