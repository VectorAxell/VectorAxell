using OBSERLIVES.CapShotViewModels;
using OBSERLIVES.VectorOperations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VectorAngleHakarukunSecond.VectorHakarukunViews
{
    public partial class VectorHakarukunView : Form
    {
        private double[] vectorA = new double[2];
        private double[] vectorB = new double[2];
        private double[] vectorC = new double[2];
        private double angle;
        private double belowangle;
        private double upperangle;
        private int count;
        private bool flg;
        private bool flg1;
        private bool flg2;
        private bool flg3;
        private MouseEventArgs mouseEventArgs;
        private PaintEventArgs paintEventArgs;
        public VectorHakarukunView()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            AngleHakaruPictureBox.Controls.Add(LocationResultLabel);
            LocationResultLabel.Top = LocationResultLabel.Top - AngleHakaruPictureBox.Top;
            LocationResultLabel.Left = LocationResultLabel.Left - AngleHakaruPictureBox.Left;
        }

        private void AppFinishButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ImgLoadButton_Click(object sender, EventArgs e)
        {
            count = 0;
            Resultabel.Text = "";
            CapShotModel capShotModel = new CapShotModel();
            capShotModel.CapShotViewLoad(AngleHakaruPictureBox, ImgInputTextBox);
        }

        private void VectorHakaruButton_Click(object sender, EventArgs e)
        {
            if (count == 3)
            {
                VectorOperation.VectorAnalysis(AngleHakaruPictureBox
                                                , ImgInputTextBox,
                                                ref Resultabel,
                                                ref vectorA,
                                                ref vectorB,
                                                ref vectorC,
                                                ref angle,
                                                ref belowangle,
                                                ref upperangle,
                                                mouseEventArgs);
                flg = true;
                ///ラベルを角の近くに持っていきたい
                ///
                LocationResultLabel.Text = Resultabel.Text;
                LocationResultLabel.Location = new Point(int.Parse(vectorC[0].ToString()), int.Parse((vectorC[1]- 20).ToString()));
                count = 0;
            }
        }


        //二段階製法

        private void AngleHakaruPictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (flg == true) 
            {
                VectorOperation.DrawLinesPoint(e, vectorA, vectorB, vectorC);
              
                //VectorOperation.DrawVectorArk(vectorC, angle, belowangle, upperangle, e, ImgInputTextBox.Text);
            }
            if(flg1 == true)
            {

                VectorOperation.SetPixelXY(e,vectorA);
            }
            if (flg2 == true)
            {

                VectorOperation.SetPixelXY(e,vectorB);
            }
            if (flg3 == true)
            {

                VectorOperation.SetPixelXY(e, vectorC);
            }
        }

        private void AngleHakaruPictureBox_MouseClick(object sender, MouseEventArgs e)
        {

            mouseEventArgs = e;
            ++count;
            if (count == 1)
            {
                VectorOperation.VectorSet(ref vectorA,mouseEventArgs);
                flg1 = true;

            }
            else if (count == 2)
            {
                VectorOperation.VectorSet(ref vectorB,mouseEventArgs);
                flg2 = true;
            }
            else if (count == 3)
            {

                VectorOperation.VectorSet(ref vectorC,mouseEventArgs);
                flg3 = true;    
                flg = true;
            }
            else if (count == 4)
            {
                flg = false;
                flg1 = false;
                flg2 = false;
                flg3 = false;
                count = 0;
            }
        }


    }
}
