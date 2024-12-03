﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OBSERLIVES.CapShotViewModels;
using System.Windows.Forms;



namespace OBSERLIVES.VectorOperations
{

    public static class VectorOperation
    {
        private static double belowangle;
        private static double angle1;
        private static double upperangle;

        public static void VectorSet(ref double[] vectorC,MouseEventArgs mouseEventArgs)
        {
            //ここにマーク*********************************************************
            CapShotModel capShotModel = new CapShotModel();
            //ここのコントロールが怪しい
            //マウスクリックイベントのPaintArgs eを用いる
            Point mp = mouseEventArgs.Location;
            int x = mp.X;
            int y = mp.Y;
            double CX = capShotModel.IntToDouble(x);
            double CY = capShotModel.IntToDouble(y);
            
            vectorC[0] = CX;
            vectorC[1] = CY;



        }

        public static void DrawLinesPoint(PaintEventArgs e,double[] vectorA,double[] vectorB, double[] vectorC)
        {

            // Create pen.
            Pen blackpen = new Pen(Color.Black, 3);

            // Create array of points that define lines to draw.
            Point[] points =
                     {
                 new Point(int.Parse(vectorA[0].ToString()),int.Parse(vectorA[1].ToString())),
                 new Point(int.Parse(vectorC[0].ToString()),int.Parse(vectorC[1].ToString())),
                 new Point(int.Parse(vectorB[0].ToString()),int.Parse(vectorB[1].ToString()))
             };

            //Draw lines to screen.
            e.Graphics.DrawLines(blackpen, points);
        }
        public static void DrawLinesDual(PaintEventArgs e, double[] vectorA, double[] vectorB)
        {

            // Create pen.
            Pen blackpen = new Pen(Color.Black, 3);
            var point1 = new Point(int.Parse(vectorA[0].ToString()), int.Parse(vectorA[1].ToString()));
            var point2 = new Point(int.Parse(vectorB[0].ToString()), int.Parse(vectorB[1].ToString()));


            e.Graphics.DrawLine(blackpen, point1, point2);


        }
        //public static void VectorAnalysis2(PictureBox pictureBox,
        //                                  TextBox imgFileTextBox,
        //                                  Label vectorAnalysysResultLabel,
        //                                  ref double[] vector1Z,
        //                                  ref double[] vector2Z)
        //{


        //    string ImgFileName = "";

        //    ImgFileName = imgFileTextBox.Text;
        //    //X軸、y軸
        //    double vectorXx = 100;
        //    double vectorXy = 0;

        //    double vectorYx = 0;
        //    double vectorYy = 100;
        //    double vectorOx = 0;
        //    double vectorOy = 0;



        //    double[] vectorO = { vectorOx, vectorOy };
        //    double[] vectorX = { vectorXx, vectorXy };
        //    double[] vectorY = { vectorYx, vectorYy };

            


        //    if (ImgFileName != "")
        //    {

        //        pictureBox.Image = System.Drawing.Image.FromFile(
        //            $@"C:\Users\mizot\Desktop\VectorAxell-main\VectorAngleHakarukunSecond\capimg\{ImgFileName}");
        //        //ピクセル画素を取得
        //        Bitmap mybitmap = new Bitmap(
        //            $@"C:\Users\mizot\Desktop\VectorAxell-main\VectorAngleHakarukunSecond\capimg\{ImgFileName}");
        //        Graphics g = Graphics.FromImage(mybitmap);
        //        Pen blackPen = new Pen(Color.Black, 3);
        //        Pen bluePen = new Pen(Color.Blue, 3);


        //        CapShotModel capShotViewModel = new CapShotModel();

        //        //直線で接続する点の配列を作成
        //        System.Drawing.Point[] ps = {

        //         new System.Drawing.Point(capShotViewModel.DoubleToInt(vector1Z[0]), capShotViewModel.DoubleToInt(vector1Z[1])),
        //         new System.Drawing.Point(capShotViewModel.DoubleToInt(vector2Z[0]), capShotViewModel.DoubleToInt(vector2Z[1]))
        //     };

        //        VectorOperation.Subtraction(vector1Z, vector3Z, ref vectort31);
        //        VectorOperation.Subtraction(vector2Z, vector3Z, ref vectort32);

        //        //角度測定
        //        angle1 = VectorOperation.CalculateAngle(vectort32, vectort31);
        //        upperangle = VectorOperation.CalculateAngle(vectorX, vectort32);
        //        belowangle = VectorOperation.CalculateAngle(vectorX, vectort31);

        //        vectorAnalysysResultLabel.Text = (360 - angle1).ToString("F2") + "°";

        //        //ベクトルを線でつないでいく
        //        g.DrawLines(blackPen, ps);
        //        //円弧を描く
        //        g.DrawArc(bluePen,
        //           capShotViewModel.DoubleToFloat(vector3Z[0]),
        //           capShotViewModel.DoubleToFloat(vector3Z[1]),
        //           20,
        //           20,
        //           -capShotViewModel.DoubleToFloat(belowangle),
        //           capShotViewModel.DoubleToFloat(angle1));

        //        //鋭利物を三角関数の角度θで判別する

        //        bluePen.Dispose();
        //        blackPen.Dispose();

        //        g.Dispose();


        //        pictureBox.Image = mybitmap;
        //        //とりあえずここまで

        //        // 画面に弧を描く



        //    }

        //}

        public static void VectorAnalysis(PictureBox pictureBox,
                                          TextBox imgFileTextBox,
                                          ref Label vectorAnalysysResultLabel,
                                          ref double[] vector1Z,
                                          ref double[] vector2Z,
                                          ref double[] vector3Z,
                                          ref double angle1,
                                          ref double belowangle,
                                          ref double upperangle,
                                          MouseEventArgs mouseEventArgs)
        {


            string ImgFileName = "";

            ImgFileName = imgFileTextBox.Text;
            //X軸、y軸
            double vectorXx = 100;
            double vectorXy = 0;

            double vectorYx = 0;
            double vectorYy = 100;
            double vectorOx = 0;
            double vectorOy = 0;



            double[] vectorO = { vectorOx, vectorOy };
            double[] vectorX = { vectorXx, vectorXy };
            double[] vectorY = { vectorYx, vectorYy };


            double[] vectort32 = { vector2Z[0] - vector3Z[0], vector2Z[1] - vector3Z[1] };
            double[] vectort31 = { vector1Z[0] - vector3Z[0], vector1Z[1] - vector3Z[1] };


            if (ImgFileName != "")
            {

                pictureBox.Image = System.Drawing.Image.FromFile(
                    $@"C:\Users\mizot\Desktop\VectorAxell-main\VectorAngleHakarukunSecond\capimg\{ImgFileName}");
                //ピクセル画素を取得
                Bitmap mybitmap = new Bitmap(
                    $@"C:\Users\mizot\Desktop\VectorAxell-main\VectorAngleHakarukunSecond\capimg\{ImgFileName}");
                Graphics g = Graphics.FromImage(mybitmap);
                Pen blackPen = new Pen(Color.Black, 3);
                Pen bluePen = new Pen(Color.Blue, 3);


                CapShotModel capShotViewModel = new CapShotModel();

                //直線で接続する点の配列を作成
                System.Drawing.Point[] ps = {

                 new System.Drawing.Point(capShotViewModel.DoubleToInt(vector1Z[0]), capShotViewModel.DoubleToInt(vector1Z[1])),
                 new System.Drawing.Point(capShotViewModel.DoubleToInt(vector2Z[0]), capShotViewModel.DoubleToInt(vector2Z[1]))
             };

                VectorOperation.Subtraction(vector1Z, vector3Z, ref vectort31);
                VectorOperation.Subtraction(vector2Z, vector3Z, ref vectort32);

                //角度測定
                angle1 = VectorOperation.CalculateAngle(vectort32, vectort31);
                upperangle = VectorOperation.CalculateAngle(vectorX, vectort32);
                belowangle = VectorOperation.CalculateAngle(vectorX, vectort31);

                vectorAnalysysResultLabel.Text = angle1.ToString("F2") + "°";



                //鋭利物を三角関数の角度θで判別する

                bluePen.Dispose();
                blackPen.Dispose();

                g.Dispose();


                pictureBox.Image = mybitmap;
                //とりあえずここまで

                // 画面に弧を描く



            }

        }

        public static void DrawVectorArk(double[] vector3Z,
                                          double angle1,
                                          double belowangle,
                                          double upperangle,
                                          PaintEventArgs paintEventArgs,
                                          string filename)
        {
            if(filename != "")
            {
            
                Pen blackPen = new Pen(Color.Black, 3);
      
                paintEventArgs.Graphics.DrawArc(blackPen,
                                //ここのベクトルの値も確認する
                                float.Parse(vector3Z[0].ToString()),
                                float.Parse(vector3Z[1].ToString()),
                                256,
                                256,
                                //ここが怪しい
                                float.Parse(angle1.ToString()),
                                float.Parse(upperangle.ToString()));



            }


        }

        // ベクトルの内積を計算するメソッド
        public static double CalculateDotProduct(double[] vectorA, double[] vectorB)
        {
            double dotProduct = 0;
            for (int i = 0; i < vectorA.Length; i++)
            {
                dotProduct += vectorA[i] * vectorB[i];
            }
            return dotProduct;
        }

        // ベクトルの大きさを計算するメソッド
        public static double CalculateNorm(double[] vector)
        {
            double sumOfSquares = 0;
            foreach (double component in vector)
            {
                sumOfSquares += component * component;
            }
            return Math.Sqrt(sumOfSquares);
        }

        public static void Subtraction(double[] vectorA, double[] vectorB, ref double[] vectorC)
        {
            int i;
            for (i = 0; i < vectorA.Length; i++)
            {
                vectorC[i] = vectorA[i] - vectorB[i];

            }
        }

        public static double CalculateAngle(double[] vectorA, double[] vectorB)
        {
            double dotProduct = CalculateDotProduct(vectorA, vectorB);
            double normA = CalculateNorm(vectorA);
            double normB = CalculateNorm(vectorB);
            double cosTheta = dotProduct / (normA * normB);
            return Math.Acos(cosTheta) * (180.0 / Math.PI); // ラジアンを度に変換
        }

        public static void SetPixelXY(PaintEventArgs paintEventArgs, double[] vectorZ)
        {
            // Create string to draw.
            String drawString = "X" + vectorZ[0].ToString();
            String drawString2 = "Y" + vectorZ[1].ToString();
            // Create font and brush.
            Font drawFont = new Font("Arial", 10);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            // Create point for upper-left corner of drawing.
            float x = float.Parse(vectorZ[0].ToString());
            float y = float.Parse(vectorZ[1].ToString());

            // Set format of string.
            StringFormat drawFormat = new StringFormat();
            drawFormat.FormatFlags = StringFormatFlags.DirectionVertical;

            // Draw string to screen.
            paintEventArgs.Graphics.DrawString(drawString, drawFont, drawBrush, x, y, drawFormat);
            // Draw string to screen.
            paintEventArgs.Graphics.DrawString(drawString2, drawFont, drawBrush, x + 15, y, drawFormat);
        }



    }
}
