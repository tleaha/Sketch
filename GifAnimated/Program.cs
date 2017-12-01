using AnimatedGif;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.Windows.Interop;
using System.IO;
using BumpKit;
using System;

namespace GifAnimated
{
    class Program
    {

        static void Main(string[] args)
        {
            Program p = new Program();
            p.GenerateByAnimatedGifCreator();
        }

        //--Not Auto-Play
        private void GenerateByAnimatedGifCreator()
        {
            //Create new Animated GIF Creator with Path to C:\awesomegif.gif and 33ms delay between frames (=30 fps)
            using (AnimatedGifCreator gifCreator = new AnimatedGifCreator(@"D:\Playground\BackYard\bucket\output\awesomegif6.gif", 33))
            {
                //Enumerate through a List<System.Drawing.Image> or List<System.Drawing.Bitmap> for example
                List<Image> imgList = new List<Image>();
                //for (int i = 0; i <= 100; i++)
                //{
                //    imgList.Add(Image.FromFile(@"D:\0-Desktop\gif-research\Comp 1\"+string.Format("000",i)+".png"));
                //}
                imgList.Add(Image.FromFile(@"D:\0-Desktop\gif-research\set-2\sleepy-1.png"));
                imgList.Add(Image.FromFile(@"D:\0-Desktop\gif-research\set-2\sleepy-2.png"));
                foreach (Image img in imgList)
                {
                    using (img)
                    {
                        //Add the image to gifEncoder with default Quality
                        gifCreator.AddFrame(img, GifQuality.Default);

                    } //Image disposed
                }
            } // gifCreator.Finish and gifCreator.Dispose is called here
           
        }

        private void GenerateByBumpkit()
        {
            List<Image> imgList = new List<Image>();
            //for (int i = 0; i <= 100; i++)
            //{
            //    imgList.Add(Image.FromFile(@"D:\0-Desktop\gif-research\Comp 1\" + string.Format("000", i) + ".png"));
            //}
            imgList.Add(Image.FromFile(@"D:\0-Desktop\gif-research\set-2\sleepy-1.png"));
            imgList.Add(Image.FromFile(@"D:\0-Desktop\gif-research\set-2\sleepy-2.png"));


            var gifStream = File.OpenWrite(@"D:\Playground\BackYard\bucket\output\awesomegif-bumpkit5.gif");
            using (var encoder = new GifEncoder(gifStream))
                foreach (Image i in imgList)
                    using (var frame = i)
                    {
                        encoder.AddFrame(frame, 0, 0, TimeSpan.FromSeconds(0));
                    }
            gifStream.Position = 0;
            

            //var gifImage = Image.FromFile(@"D:\Playground\BackYard\bucket\input\stick.png");
            //var gifStream = File.OpenWrite(@"D:\Playground\BackYard\bucket\output\awesomegif-bumpkit2.gif"); // NOTE: Disposing this stream will break this demo - I don't know why.
            //using (var encoder = new GifEncoder(gifStream))
            //    for (var angle = 0; angle < 360; angle += 10)
            //        using (var frame = gifImage.Rotate(angle, false))
            //        {
            //            encoder.AddFrame(frame, 0, 0, TimeSpan.FromSeconds(0));
            //        }
            //gifStream.Position = 0;

        }
    }
}
