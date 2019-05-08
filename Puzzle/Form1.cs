using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //pictureBox1.Image = new Bitmap(Properties.Resources.Nickhää);
            pictureBox1.Image = ResizeImage(Properties.Resources.Nickhää,pictureBox1);
            SplitImage(Properties.Resources.Nickhää,pictureBox2,pictureBox3);
            SplitImage(Properties.Resources.Nickhää, pictureBox4, pictureBox5,pictureBox6,pictureBox7);
        }
       
        

        private Bitmap ResizeImage(Bitmap original, PictureBox p)
        {
            Bitmap resizedImage;
            int rectHeight = p.Height;
            int rectWidth = p.Width;
          
            //if the image is squared set it's height and width to the smallest of the desired dimensions (our box). In the current example rectHeight<rectWidth
            if (original.Height == original.Width)
            {
                resizedImage = new Bitmap(original, rectHeight, rectHeight);
            }
            else
            {
                //calculate aspect ratio
                float aspect = original.Width / (float)original.Height;
                int newWidth, newHeight;

                //calculate new dimensions based on aspect ratio
                newWidth = (int)(rectWidth * aspect);
                newHeight = (int)(newWidth / aspect);

                //if one of the two dimensions exceed the box dimensions
                if (newWidth > rectWidth || newHeight > rectHeight)
                {
                    //depending on which of the two exceeds the box dimensions set it as the box dimension and calculate the other one based on the aspect ratio
                    if (newWidth > newHeight)
                    {
                        newWidth = rectWidth;
                        newHeight = (int)(newWidth / aspect);
                    }
                    else
                    {
                        newHeight = rectHeight;
                        newWidth = (int)(newHeight * aspect);
                    }
                }
                resizedImage = new Bitmap(original, newWidth, newHeight);
            }
            return resizedImage;
        }
        private void SplitImage(Bitmap b, PictureBox p1, PictureBox p2)
        {
               Bitmap first_half = b.Clone(new Rectangle(new Point(0,0),new Size(b.Width/2,b.Height)),System.Drawing.Imaging.PixelFormat.DontCare);
               Bitmap second_half = b.Clone(new Rectangle(new Point(b.Width / 2, 0), new Size(b.Width / 2, b.Height)), System.Drawing.Imaging.PixelFormat.DontCare);

            p1.Image = ResizeImage(first_half,p1);
            p2.Image = ResizeImage(second_half,p2);
        }
        private void SplitImage(Bitmap b, PictureBox p1, PictureBox p2, PictureBox p3, PictureBox p4)
        {
            Bitmap upper_first = b.Clone(new Rectangle(new Point(0, 0), new Size(b.Width / 2, b.Height / 2)), System.Drawing.Imaging.PixelFormat.DontCare);
            Bitmap upper_sec = b.Clone(new Rectangle(new Point(b.Width / 2, 0), new Size(b.Width / 2, b.Height / 2)), System.Drawing.Imaging.PixelFormat.DontCare);
            Bitmap lower_first = b.Clone(new Rectangle(new Point(0, b.Height / 2), new Size(b.Width / 2, b.Height / 2)), System.Drawing.Imaging.PixelFormat.DontCare);
            Bitmap lower_sec = b.Clone(new Rectangle(new Point(b.Width / 2, b.Height / 2), new Size(b.Width / 2, b.Height / 2)), System.Drawing.Imaging.PixelFormat.DontCare);


            p1.Image = ResizeImage(upper_first, p1);
            p2.Image = ResizeImage(upper_sec, p2);
            p3.Image = ResizeImage(lower_first, p3);
            p4.Image = ResizeImage(lower_sec, p4);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pictureBox4.Image = pictureBox5.Image;
        }
    }
}



/*
 * 
 *         private void SplitImage(Bitmap b, PictureBox p1, PictureBox p2,PictureBox p3, PictureBox p4)
        {
            Bitmap upper_first = b.Clone(new Rectangle(new Point(0, 0), new Size(b.Width / 2, b.Height/2)), System.Drawing.Imaging.PixelFormat.DontCare);
            Bitmap upper_sec = b.Clone(new Rectangle(new Point(b.Width / 2, 0), new Size(b.Width / 2, b.Height/2)), System.Drawing.Imaging.PixelFormat.DontCare);
            Bitmap lower_first = b.Clone(new Rectangle(new Point(0, b.Height/2), new Size(b.Width / 2, b.Height/2)), System.Drawing.Imaging.PixelFormat.DontCare);
            Bitmap lower_sec = b.Clone(new Rectangle(new Point(b.Width / 2, b.Height/2), new Size(b.Width / 2, b.Height/2)), System.Drawing.Imaging.PixelFormat.DontCare);


            p1.Image = ResizeImage(upper_first, p1);
            p2.Image = ResizeImage(upper_sec, p2);
            p3.Image = ResizeImage(lower_first, p3);
            p4.Image = ResizeImage(lower_sec, p4);
        }
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * */
