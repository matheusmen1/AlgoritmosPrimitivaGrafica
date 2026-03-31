using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ProcessamentoImagens
{
    class Filtros
    {
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




        //------------------------------------------------------------------------
        //--------- FILTROS -------------------------------------------
        //------------------------------------------------------------------------
        unsafe private static void PintaPixel(byte* src, int stride, int width, int height, int x, int y, int valor)
        {
            if(x >= 0 && x < width && y >= 0 && y < height) //limitar no tamanho da imagem
            {
                byte* pixel;
                pixel = src + y * stride + x * 3;
                *(pixel++) = (byte)valor;
                *(pixel++) = (byte)valor;
                *(pixel++) = (byte)valor;
            }
           
        }
        unsafe private static void  PontosCircunferencia(byte* src, int stride, int width, int height, int x, int y, int xc, int yc, int valor)
        {
            PintaPixel(src, stride, width, height, xc + x, yc + y, valor);
            PintaPixel(src, stride, width, height, xc + y, yc + x, valor);
            PintaPixel(src, stride, width, height, xc - y, yc + x, valor);
            PintaPixel(src, stride, width, height, xc - x, yc + y, valor);
            PintaPixel(src, stride, width, height, xc - x, yc - y, valor);
            PintaPixel(src, stride, width, height, xc - y, yc - x, valor);
            PintaPixel(src, stride, width, height, xc + y, yc - x, valor);
            PintaPixel(src, stride, width, height, xc + x, yc - y, valor);

        }

        public static void circunferenciaPontoMedio(Bitmap imgBitmap, int x1, int y1, int x2, int y2)
        {
            int width = imgBitmap.Width;
            int height = imgBitmap.Height;
            int pixelSize = 3;

            BitmapData img = imgBitmap.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int raio = (int)Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
           
            unsafe
            {

                byte* src = (byte*)img.Scan0.ToPointer();

                int x = 0;
                int y = raio;
                int d = 3 - 2 * raio;
                while(x <= y)
                {
                    
                    PontosCircunferencia(src, img.Stride, width, height, x, y, x1, y1, 0);

                    if (d < 0)
                    {
                        d = d + 2 * x + 3;
                        
                    }
                    else
                    {
                        d = d + 2 * (x - y) + 5;
                        y--;
                    }
                    x++;
                }
            }
            imgBitmap.UnlockBits(img);
        }

        public static void circunferenciaEquacao(Bitmap imgBitmap, int x1, int y1, int x2, int y2)
        {
            int width = imgBitmap.Width;
            int height = imgBitmap.Height;

            BitmapData img = imgBitmap.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite,PixelFormat.Format24bppRgb);

            int raio = (int)Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));

            unsafe
            {
                byte* src = (byte*)img.Scan0.ToPointer();

                int x = 0;
                int limite = (int)(raio / Math.Sqrt(2)); // até 45°, raio / raiz de 2

                while (x <= limite)
                {
                    int y = (int)Math.Sqrt(raio * raio - x * x); // Raiz(R^2−𝑥^2)

                    PontosCircunferencia(src, img.Stride, width, height, x, y, x1, y1, 0);

                    x++;
                }
            }

            imgBitmap.UnlockBits(img);
        }

        //utiliza as equações paramétricas da circunferência, onde o ângulo α varia de 0 a 2π
        //permitindo calcular as coordenadas x e y a partir das funções cosseno e seno
        public static void circunferenciaTrigonometria(Bitmap imgBitmap, int x1, int y1, int x2, int y2)
        {
            int width = imgBitmap.Width;
            int height = imgBitmap.Height;

            BitmapData img = imgBitmap.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            // raio da circunferência: distância entre o centro (x1,y1) e um ponto da borda (x2,y2)
            // R = Raiz( (x2 - x1)^2 + (y2 - y1)^2 )
            int raio = (int)Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));

            unsafe
            {
                byte* src = (byte*)img.Scan0.ToPointer();

                // Define o quanto o ângulo α aumenta a cada iteração
                // Quanto menor, mais pontos -> círculo mais suave
                double passo = 1.0 / raio;

                // Percorre o ângulo α de 0 até 2*PI (360° em radianos)
                for (double t = 0; t < 2 * Math.PI; t += passo)
                {

                    // y = R * sen(α) e x = R * cos(α)
                    //transformam o ângulo α em coordenadas, cos e sen vão de - 1 a 1
                    int x = (int)(raio * Math.Cos(t));
                    int y = (int)(raio * Math.Sin(t)); 

                    // Soma em x1 e y1 para deslocar a circunferência para o centro correto
                    PintaPixel(src, img.Stride, width, height, x1 + x, y1 + y, 0);
                }
            }

            imgBitmap.UnlockBits(img);
        }




        //================================= ELIPSE =================================


        unsafe private static void PontosElipse(byte* src, int stride, int width, int height, int x, int y, int xc, int yc, int valor)
        {
            PintaPixel(src, stride, width, height, xc + x, yc + y, valor);
            PintaPixel(src, stride, width, height, xc - x, yc + y, valor);
            PintaPixel(src, stride, width, height, xc - x, yc - y, valor);
            PintaPixel(src, stride, width, height, xc + x, yc - y, valor);
        }
        unsafe private static void MidpointElipse(byte* src, int stride, int width, int height, int a, int b, int xc, int yc, int color)
        {
            int x, y;
            double d1, d2;
            /* Valores iniciais */
            x = 0;
            y = b;
            d1 = b*b - a*a*b + (a*a) / 4.0;
            PontosElipse(src, stride, width, height, x, y, xc, yc, color); /* Simetria de ordem 4 */
            while (a * a * (y - 0.5) > b * b * (x + 1))
            {
                /* Regi~ao 1 */
                if (d1 < 0) { 
                    d1 = d1 + b * b * (2 * x + 3);
                    x++;
                }else
                {
                    d1 = d1 + b * b * (2 * x + 3) + a * a * (-2 * y + 2);
                    x++;
                    y--;
                }
                PontosElipse(src, stride, width, height, x, y, xc, yc, color);
            }
            d2 = b* b *(x + 0.5) * (x + 0.5) + a * a * (y - 1) * (y - 1) - a * a * b * b;
            while(y > 0)
            {
                /* Regi~ao 2 */
                if (d2< 0)
                {
                    d2 = d2 + b* b *(2 * x + 2) + a * a * (-2 * y + 3);
                    x++;
                    y--;
                }
                else
                {
                    d2 = d2 + a* a *(-2 * y + 3);
                    y--;
                }/*end if*/
                PontosElipse(src, stride, width, height, x, y, xc, yc, color);
            }
        }

        public static void elipsePontoMedio(Bitmap imgBitmap, int x1, int y1, int x2, int y2)
        {
            int width = imgBitmap.Width;
            int height = imgBitmap.Height;

            BitmapData img = imgBitmap.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            //calcula os semi-eixos a e b (raios)
            int a = Math.Abs(x2-x1);
            int b = Math.Abs(y2 - y1);

            // Calcular o centro da elipse (xc, yc)
            int xc = x1; // Aqui você pode definir o centro de acordo com sua necessidade
            int yc = y1;

            unsafe
            {
                byte* src = (byte*)img.Scan0.ToPointer();

                MidpointElipse(src, img.Stride, width, height, a, b, xc, yc, 0);
            }

            imgBitmap.UnlockBits(img);
        }

        //===================================================================================================================






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
        public static void Bresenham(Bitmap imgBitmap, int x1, int y1, int x2, int y2, int R, int G, int B)
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

                        // Define o pixel com a cor recebida por parâmetro
                        pixel[0] = (byte)B;
                        pixel[1] = (byte)G;
                        pixel[2] = (byte)R;
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
