using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OBSERLIVES.VectorOperations;
using OBSERLIVES.ViewModels;
using OpenCvSharp.Extensions;
using OpenCvSharp;

namespace OBSERLIVES.CapShotViewModels
{
    public class CapShotModel
    {
        private bool isContours = false;
        private Mat img;
        public int DoubleToInt(double value)
        {
            return int.Parse(value.ToString());

        }

        public float DoubleToFloat(double value1)
        {
            return float.Parse(value1.ToString());

        }

        public double IntToDouble(int value2)
        {
            return double.Parse(value2.ToString());

        }
        public void CapShotViewLoad(PictureBox pictureBox)
        {
            Task.Run(() =>
            {
                using (VideoCapture v = new VideoCapture(0))
                using (Mat img = new Mat())
                {
                    while (true)
                    {
                        v.Read(img);
                        Process(img,isContours);
                        pictureBox.Image = BitmapConverter.ToBitmap(img);
                    }
                }
            });

        }

        public void Process(Mat img,bool isContours)
        {
            if (isContours)
            {
                using (Mat gray = new Mat(img.Size(), MatType.CV_8UC1))
                {
   

                    Cv2.CvtColor(img, gray, ColorConversionCodes.BGR2GRAY);
                    Cv2.Threshold(gray, gray, 0, 255, ThresholdTypes.Otsu);
                    OpenCvSharp.Point[][] contours = Cv2.FindContoursAsArray(gray, RetrievalModes.Tree, ContourApproximationModes.ApproxSimple);
                    foreach (OpenCvSharp.Point[] points in contours)
                    {
                        for (int i = 0; i < points.Length; i++)
                        {
                            Cv2.Line(img, points[i], points[(i + 1) % points.Length], Scalar.Red, 2);
                        }
                    }



                }
            }
        }
        public void FaceCognition(TextBox textBox)
        {
            if(textBox.Text != "")
            {
                //顔の矩形を抽出
                using (Mat mat = new Mat(
                    $@"C:\Users\mizot\Desktop\VectorApp\VectorAngleHakarukunSecond\capimg\{textBox.Text}"))
                {
                    // 分類機の用意
                    using (CascadeClassifier cascade = new CascadeClassifier(
                        @"C:\Users\mizot\Desktop\VectorApp\VectorAngleHakarukunSecond\cs_source\haarcascade_frontalface_default.xml"))
                    {
                        foreach (Rect rectFace in cascade.DetectMultiScale(mat))
                        {
                            // 見つかった場所に赤枠を表示   
                            Rect rect = new Rect(rectFace.X, rectFace.Y, rectFace.Width, rectFace.Height);
                            Cv2.Rectangle(mat, rect, new OpenCvSharp.Scalar(0, 0, 255), 2);
                        }
                    }

                    // ウィンドウに画像を表示
                    Cv2.ImShow("face_show", mat);
                }

            }




        }

        

        

        public void CapShotViewLoad(PictureBox pictureBox, TextBox imgFileTextBox)
        {
            string ImgFileName = "";

            ImgFileName = imgFileTextBox.Text;
            if (ImgFileName != "")
            {

                pictureBox.Image = System.Drawing.Image.FromFile(
                    $@"C:\Users\mizot\Desktop\VectorApp\VectorAngleHakarukunSecond\capimg\{ImgFileName}");
            }

        }
    }
}
