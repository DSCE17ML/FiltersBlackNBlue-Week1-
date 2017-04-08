using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Imaging.Filters;

namespace App1BlackNBlue
{
	public partial class Form1 : Form
	{

        Bitmap originalImage, grayImage, edgeImage, blackNwhiteImage, hueImage, blurImage;
        
        

        private void hueModificationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HueModifier hm = new HueModifier(180);
            hueImage = hm.Apply(originalImage);
            pictureBox5.Image = hueImage;
        }

        public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

        private void blurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Blur blur = new Blur();
            blurImage = blur.Apply(originalImage);
            pictureBox6.Image = blurImage;
        }

        private void pickImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            var returnStatus = openFile.ShowDialog();
            if(returnStatus == DialogResult.OK)
            {
                originalImage = new Bitmap(openFile.FileName);
                pictureBox1.Image = originalImage;
            }
        }

        private void grayScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GrayscaleBT709 grayObj = new GrayscaleBT709();
            grayImage = grayObj.Apply(originalImage);
            pictureBox2.Image = grayImage;
        }

        private void edgeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CannyEdgeDetector edgeObj = new CannyEdgeDetector();
            edgeImage = new Bitmap(edgeObj.Apply(grayImage));
            pictureBox3.Image = edgeImage;
        }

        private void blackAndWhiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Threshold thresholdObj = new Threshold();
            blackNwhiteImage = thresholdObj.Apply(grayImage);
            pictureBox4.Image = blackNwhiteImage;
        
        }
       
    }
}
