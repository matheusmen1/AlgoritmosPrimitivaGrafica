using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ProcessamentoImagens
{
    class Filtros
    {
        //sem acesso direto a memoria
        public static void convert_to_gray(Bitmap imageBitmapSrc, Bitmap imageBitmapDest)
        {
            int width = imageBitmapSrc.Width;
            int height = imageBitmapSrc.Height;
            int r, g, b;
            Int32 gs;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //obtendo a cor do pixel
                    Color cor = imageBitmapSrc.GetPixel(x, y);

                    r = cor.R;
                    g = cor.G;
                    b = cor.B;
                    gs = (Int32)(r * 0.2990 + g * 0.5870 + b * 0.1140);

                    //nova cor
                    Color newcolor = Color.FromArgb(gs, gs, gs);

                    imageBitmapDest.SetPixel(x, y, newcolor);
                }
            }
        }

        //sem acesso direito a memoria
        public static void negativo(Bitmap imageBitmapSrc, Bitmap imageBitmapDest)
        {
            int width = imageBitmapSrc.Width;
            int height = imageBitmapSrc.Height;
            int r, g, b;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //obtendo a cor do pixel
                    Color cor = imageBitmapSrc.GetPixel(x, y);

                    r = cor.R;
                    g = cor.G;
                    b = cor.B;

                    //nova cor
                    Color newcolor = Color.FromArgb(255 - r, 255 - g, 255 - b);

                    imageBitmapDest.SetPixel(x, y, newcolor);
                }
            }
        }

        //com acesso direto a memória
        public static void convert_to_grayDMA(Bitmap imageBitmapSrc, Bitmap imageBitmapDest)
        {
            int width = imageBitmapSrc.Width;
            int height = imageBitmapSrc.Height;
            int pixelSize = 3;
            Int32 gs;

            //lock dados bitmap origem
            BitmapData bitmapDataSrc = imageBitmapSrc.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            //lock dados bitmap destino
            BitmapData bitmapDataDst = imageBitmapDest.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int padding = bitmapDataSrc.Stride - (width * pixelSize);

            unsafe
            {
                byte* src = (byte*)bitmapDataSrc.Scan0.ToPointer();
                byte* dst = (byte*)bitmapDataDst.Scan0.ToPointer();

                int r, g, b;
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        b = *(src++); //está armazenado dessa forma: b g r 
                        g = *(src++);
                        r = *(src++);
                        gs = (Int32)(r * 0.2990 + g * 0.5870 + b * 0.1140);
                        *(dst++) = (byte)gs;
                        *(dst++) = (byte)gs;
                        *(dst++) = (byte)gs;
                    }
                    src += padding;
                    dst += padding;
                }
            }
            //unlock imagem origem
            imageBitmapSrc.UnlockBits(bitmapDataSrc);
            //unlock imagem destino
            imageBitmapDest.UnlockBits(bitmapDataDst);
        }

        //com acesso direito a memoria
        public static void negativoDMA(Bitmap imageBitmapSrc, Bitmap imageBitmapDest)
        {
            int width = imageBitmapSrc.Width;
            int height = imageBitmapSrc.Height;
            int pixelSize = 3;

            //lock dados bitmap origem 
            BitmapData bitmapDataSrc = imageBitmapSrc.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            //lock dados bitmap destino
            BitmapData bitmapDataDst = imageBitmapDest.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int padding = bitmapDataSrc.Stride - (width * pixelSize);

            unsafe
            {
                byte* src1 = (byte*)bitmapDataSrc.Scan0.ToPointer();
                byte* dst = (byte*)bitmapDataDst.Scan0.ToPointer();

                int r, g, b;
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        b = *(src1++); //está armazenado dessa forma: b g r 
                        g = *(src1++);
                        r = *(src1++);

                        *(dst++) = (byte)(255 - b);
                        *(dst++) = (byte)(255 - g);
                        *(dst++) = (byte)(255 - r);
                    }
                    src1 += padding;
                    dst += padding;
                }
            }
            //unlock imagem origem 
            imageBitmapSrc.UnlockBits(bitmapDataSrc);
            //unlock imagem destino
            imageBitmapDest.UnlockBits(bitmapDataDst);
        }


        //------------------------------------------------------------------------
        //--------- FILTROS -------------------------------------------
        //------------------------------------------------------------------------

        public static void EquacaoReta(Bitmap imgBitmap, int x1, int y1, int x2, int y2)
        {
            int width = imgBitmap.Width;
            int height = imgBitmap.Height;
            int pixelSize = 3;

            BitmapData img = imgBitmap.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            
            //desenhar linha da direita -> esquerda
            if (x1 > x2)
            {
                int temp;

                temp = x1; 
                x1 = x2; 
                x2 = temp;

                temp = y1; 
                y1 = y2; 
                y2 = temp;
            }

            double dy = y2 - y1;
            double dx = x2 - x1;
            double m = dy / dx;

            unsafe
            {
                byte* origem = (byte*)img.Scan0.ToPointer();
                byte* pixel;

                // Caso onde a reta cresce mais em X
                if (Math.Abs(dx) > Math.Abs(dy))
                {
                    for (int x = x1; x <= x2; x++)
                    {
                        double y = y1 + m * (x - x1);
                        int py = (int)Math.Round(y);

                        if (x >= 0 && x < width && py >= 0 && py < height)
                        {
                            pixel = origem + py * img.Stride + x * pixelSize;

                            pixel[0] = pixel[1] = pixel[2] = 0;
                        }
                    }
                }
                // Caso onde a reta cresce mais em Y
                else
                {
                    // se y1 > y2 inverte o loop
                    //permite desenhar linha subindo ou descendo
                    if (y1 > y2)
                    {
                        for (int y = y1; y >= y2; y--)
                        {
                            double x = x1 + (y - y1) / m;
                            int px = (int)Math.Round(x);

                            if (px >= 0 && px < width && y >= 0 && y < height)
                            {
                                pixel = origem + y * img.Stride + px * pixelSize;

                                pixel[0] = pixel[1] = pixel[2] = 0;
                            }
                        }
                    }
                    else
                    {
                        for (int y = y1; y <= y2; y++)
                        {
                            double x = x1 + (y - y1) / m;
                            int px = (int)Math.Round(x);

                            if (px >= 0 && px < width && y >= 0 && y < height)
                            {
                                pixel = origem + y * img.Stride + px * pixelSize;
                                pixel[0] = pixel[1] = pixel[2] = 0;
                            }
                        }
                    }
                }
            }

            imgBitmap.UnlockBits(img);
        }

        public static void DDA(Bitmap imgBitmap, int X1, int Y1, int X2, int Y2)
        {

            
            int width = imgBitmap.Width;
            int height = imgBitmap.Height;
            int pixelSize = 3;

            BitmapData img = imgBitmap.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite,PixelFormat.Format24bppRgb);

            int Length, I;
            float X, Y, Xinc, Yinc;

            // Calcula o tamanho da linha no eixo X
            Length = Math.Abs(X2 - X1);

            // Se a variação em Y for maior, usa ela como referência
            if (Math.Abs(Y2 - Y1) > Length)
                Length = Math.Abs(Y2 - Y1);

            // Incrementos em cada passo
            Xinc = (float)(X2 - X1) / Length;
            Yinc = (float)(Y2 - Y1) / Length;

            // Começa no ponto inicial
            X = X1;
            Y = Y1;

            unsafe
            {
                byte* origem = (byte*)img.Scan0.ToPointer();
                byte* pixel;

                // while (X < X2) isso só funciona se a linha vai pra direita

                for (I = 0; I <= Length; I++)
                {
                    int px = (int)Math.Round(X);
                    int py = (int)Math.Round(Y);

                    // Verifica se está dentro da imagem
                    if (px >= 0 && px < width && py >= 0 && py < height)
                    {
                        pixel = origem + py * img.Stride + px * pixelSize;

                        pixel[0] = pixel[1] = pixel[2] = 0;
                    }

                    // Avança para o próximo ponto
                    X += Xinc;
                    Y += Yinc;
                }
            }
            imgBitmap.UnlockBits(img);
        }
        public static void bresenham(Bitmap imgBitmap, int x1, int y1, int x2, int y2)
        {
            int width = imgBitmap.Width;
            int height = imgBitmap.Height;
            int pixelSize = 3;

            // Verifica se a reta é muito inclinada
            // Se |dy| > |dx| significa que ela é mais vertical que horizontal
            bool steep = Math.Abs(y2 - y1) > Math.Abs(x2 - x1);

            // Se for muito inclinada, trocamos x por y, faz o algoritmo funcionar para todos os octantes
            if (steep)
            {
                int aux;

                aux = x1;
                x1 = y1;
                y1 = aux;

                aux = x2;
                x2 = y2;
                y2 = aux;
            }

            //desenho será sempre da esquerda para direita
            if (x1 > x2)
            {
                int aux;

                aux = x1;
                x1 = x2;
                x2 = aux;

                aux = y1;
                y1 = y2;
                y2 = aux;
            }

            // Calcula as diferenças entre os pontos
            int dx = x2 - x1;
            int dy = Math.Abs(y2 - y1);

            // Define se a reta sobe ou desce
            // se y2 >= y1 → sobe (1) 
            // se y2 < y1 → desce (-1)
            int declive = (y1 < y2) ? 1 : -1;

            // Variável de decisão do Bresenham
            int erro = dx / 2;

            int y = y1;

            BitmapData img = imgBitmap.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite,PixelFormat.Format24bppRgb);

            unsafe
            {
                byte* origem = (byte*)img.Scan0.ToPointer();

                // Percorre todos os valores de x
                for (int x = x1; x <= x2; x++)
                {
                    int px, py;

                    // Se os eixos foram trocados anteriormente inverte novamente para desenhar o pixel correto
                    if (steep)
                    {
                        px = y;
                        py = x;
                    }
                    else
                    {
                        px = x;
                        py = y;
                    }

                    // Se o pixel está dentro da imagem
                    if (px >= 0 && px < width && py >= 0 && py < height)
                    {
                        byte* pixel = origem + py * img.Stride + px * pixelSize;

                        // Define o pixel como preto
                        pixel[0] = pixel[1] = pixel[2] = 0;
                    }

                    // Atualiza o erro
                    erro -= dy;

                    if (erro < 0)
                    {
                        y += declive;
                        erro += dx;
                    }
                }
            }

            // Libera o acesso à memória da imagem
            imgBitmap.UnlockBits(img);
        }
        public static void imagemBranca(Bitmap imgBitmap)
        {
            int width = imgBitmap.Width;
            int height = imgBitmap.Height;
            int pixelSize = 3;

            BitmapData img = imgBitmap.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            unsafe
            {
                byte* origem = (byte*)img.Scan0.ToPointer();
                byte* pixel;

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        pixel = origem + y * img.Stride + x * pixelSize;

                        pixel[0] = 255;
                        pixel[1] = 255;
                        pixel[2] = 255;
                    }
                }


            }
            imgBitmap.UnlockBits(img);

        }
    }
}
