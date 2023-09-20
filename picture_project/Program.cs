﻿using SkiaSharp;


namespace pictures
{
    class Program
    {
        static void Main(string[] args)
        {
            SKBitmap sKBitmap = SKBitmap.Decode("city.jpg");
            SKBitmap sKBitmapSize = ReSize(sKBitmap, 0.1f, false);
            SKBitmap sKBitmapFlip = Rotate(sKBitmapSize, 90, false);
            SKBitmap sKBitmapColor = SelectColorMatrix(sKBitmapFlip, "inverter", false);
            SaveImage(sKBitmapColor, "image2", ".jpg");
            
        }   
        static SKImage GenerateImage(SKBitmap sKBitmap)
        {
            SKSurface sKSurface = SKSurface.Create(new SKImageInfo(sKBitmap.Width, sKBitmap.Height)); 
            SKCanvas sKCanvas = sKSurface.Canvas; 
            sKCanvas.DrawBitmap(sKBitmap, new SKPoint());
            sKCanvas.ResetMatrix();
            sKCanvas.Flush();
            SKImage sKImage = sKSurface.Snapshot();
            return sKImage;
        }
        
        
        static void SaveImage(SKBitmap sKBitmap, string name, string fileType = ".png")
        {          
            string filename = $"{name}.png";
            SKImage sKImage = GenerateImage(sKBitmap);

            if (new Dictionary<string, object>()
            {
                {".png", SKEncodedImageFormat.Png},
                {".jpg", SKEncodedImageFormat.Jpeg},
                {".bmp", SKEncodedImageFormat.Bmp},
            }.ContainsKey(fileType))
            {
                filename = $"{name}{fileType}";
                _ = sKImage.Encode((SKEncodedImageFormat)new Dictionary<string, object>()
            {
                {".png", SKEncodedImageFormat.Png},
                {".jpg", SKEncodedImageFormat.Jpeg},
                {".bmp", SKEncodedImageFormat.Bmp},
            }[fileType], 100);

            }
            else
            {
                _ = sKImage.Encode(SKEncodedImageFormat.Png, 100);
            }

            _ = GenerateImage(sKBitmap);
            SKData sKData = sKImage.Encode(SKEncodedImageFormat.Png, 100);

            using (FileStream fileStream = File.Create(filename))
            {                            
                sKData.AsStream().Seek(0, SeekOrigin.Begin);
                sKData.AsStream().CopyTo(fileStream);

                fileStream.Flush();
                fileStream.Close();
            }
        }

        static SKBitmap ReSize(
            SKBitmap sKBitmap,
            float resizeFactor = 1.2f,
            bool changeSize = true)
        {            
            if (!changeSize)
            {
                return sKBitmap;
            }
            else
            {
                int width = (int)Math.Round(sKBitmap.Width * resizeFactor);
                int height = (int)Math.Round(sKBitmap.Height * resizeFactor);
                
                SKBitmap resizedBitmap = new SKBitmap(width, height, sKBitmap.ColorType, sKBitmap.AlphaType);
                SKCanvas canvas = new SKCanvas(resizedBitmap);
                canvas.SetMatrix(SKMatrix.CreateScale(resizeFactor, resizeFactor));
                canvas.DrawBitmap(sKBitmap, new SKPoint());
                canvas.ResetMatrix();
                canvas.Flush();
                
                return resizedBitmap;
            }
        }

        static SKBitmap Rotate(SKBitmap bitmap, double angle, bool rotate = false)
        {
            if (!rotate)
            {
                return bitmap;
            }
            double radians = Math.PI * angle / 180;
            float sine = (float)Math.Abs(Math.Sin(radians));
            float cosine = (float)Math.Abs(Math.Cos(radians));
            int originalWidth = bitmap.Width;
            int originalHeight = bitmap.Height;
            int rotatedWidth = (int)(cosine * originalWidth + sine * originalHeight);
            int rotatedHeight = (int)(cosine * originalHeight + sine * originalWidth);

            var rotatedBitmap = new SKBitmap(rotatedWidth, rotatedHeight);

            using (var surface = new SKCanvas(rotatedBitmap))
            {
                surface.Clear();
                surface.Translate(rotatedWidth / 2, rotatedHeight / 2);
                surface.RotateDegrees((float)angle);
                surface.Translate(-originalWidth / 2, -originalHeight / 2);
                surface.DrawBitmap(bitmap, new SKPoint());
            }
            return rotatedBitmap;
        }

        static SKBitmap SelectColorMatrix(SKBitmap sKBitmap, string matrix_name, bool changeColor = false)
        {
            if (!changeColor)
            {
                return sKBitmap;
            }
            float [] monoChrome = new float[]
            {
                0.21f, 0.72f, 0.07f, 0, 0,
                0.21f, 0.72f, 0.07f, 0, 0,
                0.21f, 0.72f, 0.07f, 0, 0,
                0,     0,     0,     1, 0
            };
            float [] pastel = new float[]
            {
                0.75f, 0.25f, 0.25f, 0, 0,
                0.25f, 0.75f, 0.25f, 0, 0,
                0.25f, 0.25f, 0.75f, 0, 0,
                0,     0,     0,     1, 0
            };
            float [] sepia = new float[]
            {
                0.393f, 0.769f, 0.189f, 0, 0,
                0.349f, 0.686f, 0.168f, 0, 0,
                0.272f, 0.534f, 0.131f, 0, 0,
                0,      0,      0,      1, 0
            };
            float [] colorMatrix1 = new float[] 
            {
                0, 1, 0, 0, 0,
                0, 0, 1, 0, 0,
                1, 0, 0, 0, 0,
                0, 0, 0, 1, 0
            };   
            float [] colorMatrix3 = new float[] 
            {
                -1, 1, 1, 0, 0,
                1, -1, 1, 0, 0,
                1, 1, -1, 0, 0,
                0, 0, 0, 1, 0
            };                       
            float [] colorMatrix4 = new float[] 
            {
                0.0f, 0.5f, 0.5f, 0, 0,
                0.5f, 0.0f, 0.5f, 0, 0,
                0.5f, 0.5f, 0.0f, 0, 0,
                0.0f, 0.0f, 0.0f, 1, 0
            };
            float [] colorMatrix6 = new float[] {
                0, 0, 1, 0, 0,
                1, 0, 0, 0, 0,
                0, 1, 0, 0, 0,
                0, 0, 0, 1, 0
            };
            float [] colorMatrixElements = new float[] {
                3, 0, 0, 0, 0,
                0, 1, 0, 0, 0,
                0, 0, 1, 0, 0,
                .2f, .2f, .2f, 0, 1
            };
            float [] rgbBgr = new float[] {
                0, 0, 1, 0, 0,
                0, 1, 0, 0, 0,
                1, 0, 0, 0, 0,
                0, 0, 0, 1, 0
            };
            float [] polaroid = new float[] {
                1.438f, -0.062f, -0.062f, 0, 0,
                -0.122f, 1.378f, -0.122f, 0, 0,
                -0.016f, -0.016f, 1.483f, 0, 0,
                0, 0, 0, 1, 0
            };
            float [] inverter = new float[] {
                -1f,  0f,  0f, 0f, 1f,
                0f, -1f,  0f, 0f, 1f,
                0f,  0f, -1f, 0f, 1f,
                0f,  0f,  0f, 1f, 0f
            };            

            Dictionary<string, float[]> colorMatrixes = new Dictionary<string, float[]>()
            {
                {"monoChrome", monoChrome},
                {"pastel", pastel},
                {"sepia", sepia},
                {"colorMatrix1", colorMatrix1},
                {"colorMatrix3", colorMatrix3}, 
                {"colorMatrix4", colorMatrix4},
                {"colorMatrix6", colorMatrix6},
                {"colorMatrixElements", colorMatrixElements},
                {"rgbBgr", rgbBgr},
                {"polaroid", polaroid},
                {"inverter", inverter}
            };
                        
            float [] selectedColorMatrix = new float []  //default to no change
            {
                1, 0, 0, 0, 0,
                0, 1, 0, 0, 0,
                0, 0, 1, 0, 0,
                0, 0, 0, 1, 0
            };

            if (colorMatrixes.ContainsKey(matrix_name))
            {
                selectedColorMatrix = colorMatrixes[matrix_name];
            }
            
            SKPaint paint = new SKPaint
            {
                ColorFilter = SKColorFilter.CreateColorMatrix(selectedColorMatrix)
            };

            SKSurface sKSurface = SKSurface.Create(new SKImageInfo(sKBitmap.Width, sKBitmap.Height)); 
            SKCanvas sKCanvas = sKSurface.Canvas; 
            sKCanvas.DrawBitmap(sKBitmap, new SKPoint(), paint);
            
            SKImage sKImage = sKSurface.Snapshot();
            SKBitmap colorBitmap = SKBitmap.FromImage(sKImage);
            
            sKCanvas.ResetMatrix();
            sKCanvas.Flush();
            
            return colorBitmap;               
        }        
    }
}    