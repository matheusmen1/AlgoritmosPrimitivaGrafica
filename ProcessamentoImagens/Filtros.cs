using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ProcessamentoImagens.classes;
using ProcessamentoImagens.classes.EdgeTable;

namespace ProcessamentoImagens
{
    class Filtros
    {
        //==================================== CIRCUNFERÊNCIA =================================================================================
        /*
         * Logo abaixo temos 3 MÉTODOS para a contrução (plotagem na tela) de CIRCUNFERÊNCIAS. -> Equação Real, Equação Trigonométrica e Ponto Médio
         * Existe também o método auxiliar para pintar os pontos da circunferência nas 8 OCTANTES
         * **/
        public static void CircunferenciaEquacao(Bitmap imgBitmap, int x1, int y1, int x2, int y2)
        {
            int width = imgBitmap.Width;
            int height = imgBitmap.Height;

            BitmapData img = imgBitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int raio = (int)Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));

            unsafe
            {
                byte* src = (byte*)img.Scan0.ToPointer();

                int x = 0;
                int limite = (int)(raio / Math.Sqrt(2)); // até 45°, raio / raiz de 2

                while (x <= limite)
                {
                    int y = (int)Math.Sqrt(raio * raio - x * x); // Raiz(R^2−𝑥^2)

                    PontosCircunferencia(src, img.Stride, width, height, x, y, x1, y1, 0, 0, 0);

                    x++;
                }
            }

            imgBitmap.UnlockBits(img);
        }
        public static void CircunferenciaTrigonometria(Bitmap imgBitmap, int x1, int y1, int x2, int y2)
        {
            //utiliza as equações paramétricas da circunferência, onde o ângulo α varia de 0 a 2π
            //permitindo calcular as coordenadas x e y a partir das funções cosseno e seno
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
                    PintaPixel(src, img.Stride, width, height, x1 + x, y1 + y, 0, 0, 0);
                }
            }

            imgBitmap.UnlockBits(img);
        }
        public static void CircunferenciaPontoMedio(Bitmap imgBitmap, int x1, int y1, int x2, int y2, int R, int G, int B)
        {
            int width = imgBitmap.Width;
            int height = imgBitmap.Height;

            BitmapData img = imgBitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int raio = (int)Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));

            unsafe
            {
                byte* src = (byte*)img.Scan0.ToPointer();

                int x = 0;
                int y = raio;
                int d = 3 - 2 * raio;
                while (x <= y)
                {

                    PontosCircunferencia(src, img.Stride, width, height, x, y, x1, y1, R, G, B);

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
        unsafe private static void PontosCircunferencia(byte* src, int stride, int width, int height, int x, int y, int xc, int yc, int R, int G, int B)
        {
            PintaPixel(src, stride, width, height, xc + x, yc + y, R, G, B);
            PintaPixel(src, stride, width, height, xc + y, yc + x, R, G, B);
            PintaPixel(src, stride, width, height, xc - y, yc + x, R, G, B);
            PintaPixel(src, stride, width, height, xc - x, yc + y, R, G, B);
            PintaPixel(src, stride, width, height, xc - x, yc - y, R, G, B);
            PintaPixel(src, stride, width, height, xc - y, yc - x, R, G, B);
            PintaPixel(src, stride, width, height, xc + y, yc - x, R, G, B);
            PintaPixel(src, stride, width, height, xc + x, yc - y, R, G, B);
        }

        //==================================== ELIPSE ======================================================================================
        /*
         * Logo abaixo temos o MÉTODO para a contrução (plotagem na tela) de ELIPSES
         * **/
        public static void ElipsePontoMedio(Bitmap imgBitmap, int x1, int y1, int x2, int y2, int x3, int y3, int R, int G, int B)
        {
            int width = imgBitmap.Width;
            int height = imgBitmap.Height;

            BitmapData img = imgBitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int xc = x1;
            int yc = y1;

            // raio horizontal (semi-eixo maior ou menor)
            int a = Math.Abs(x2 - xc);

            // raio vertical
            int b = Math.Abs(y3 - yc);

            unsafe
            {
                byte* src = (byte*)img.Scan0.ToPointer();

                MidpointElipse(src, img.Stride, width, height, a, b, xc, yc, R, G, B);
            }

            imgBitmap.UnlockBits(img);
        }
        unsafe private static void PontosElipse(byte* src, int stride, int width, int height, int x, int y, int xc, int yc, int R, int G, int B)
        {
            PintaPixel(src, stride, width, height, xc + x, yc + y, R, G, B);
            PintaPixel(src, stride, width, height, xc - x, yc + y, R, G, B);
            PintaPixel(src, stride, width, height, xc - x, yc - y, R, G, B);
            PintaPixel(src, stride, width, height, xc + x, yc - y, R, G, B);
        }
        unsafe private static void MidpointElipse(byte* src, int stride, int width, int height, int a, int b, int xc, int yc, int R, int G, int B)
        {
            int x, y;
            double d1, d2;

            /* Valores iniciais */
            x = 0;
            y = b;
            d1 = b * b - a * a * b + (a * a) / 4.0;

            PontosElipse(src, stride, width, height, x, y, xc, yc, R, G, B); /* Simetria de ordem 4 */
            while (a * a * (y - 0.5) > b * b * (x + 1))
            {
                /* Região 1 */
                if (d1 < 0)
                {
                    d1 = d1 + b * b * (2 * x + 3);
                    x++;
                }
                else
                {
                    d1 = d1 + b * b * (2 * x + 3) + a * a * (-2 * y + 2);
                    x++;
                    y--;
                }
                PontosElipse(src, stride, width, height, x, y, xc, yc, R, G, B);
            }
            d2 = b * b * (x + 0.5) * (x + 0.5) + a * a * (y - 1) * (y - 1) - a * a * b * b;
            while (y > 0)
            {
                /* Região 2 */
                if (d2 < 0)
                {
                    d2 = d2 + b * b * (2 * x + 2) + a * a * (-2 * y + 3);
                    x++;
                    y--;
                }
                else
                {
                    d2 = d2 + a * a * (-2 * y + 3);
                    y--;
                }/*end if*/
                PontosElipse(src, stride, width, height, x, y, xc, yc, R, G, B);
            }
        }

        //==================================== RETAS =======================================================================================
        /*
         * Codificação de 3 MÉTODOS DIFERENTES para a construção (plotagem na tela) de RETAS.
         * **/
        public static void EquacaoReta(Bitmap imgBitmap, int x1, int y1, int x2, int y2)
        {
            int width = imgBitmap.Width;
            int height = imgBitmap.Height;
            int pixelSize = 3;

            BitmapData img = imgBitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

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

            BitmapData img = imgBitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

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
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

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

        //=================================== FILTROS ================================================================================
        /*
         * Codificação de um MÉTODO para deixar a IMAGEM INTEIRAMENTE BRANCA.
         * **/
        public static void ImagemBranca(Bitmap imgBitmap)
        {
            int width = imgBitmap.Width;
            int height = imgBitmap.Height;
            int pixelSize = 3;

            BitmapData img = imgBitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

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

        /*
         * Codificação de um MÉTODO para deixar a IMAGEM INTEIRAMENTE na ESCALA DE CINZA.
         * **/
        public static void Convert_to_grayDMA(Bitmap imageBitmapSrc, Bitmap imageBitmapDest)
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

        /*
         * Codificação de um MÉTODO para PINTAR UM PIXEL na ESCALA DE CINZA.
         * **/
        unsafe private static void PintaPixel(byte* src, int stride, int width, int height, int x, int y, int R, int G, int B)
        {
            if (x >= 0 && x < width && y >= 0 && y < height) //limitar no tamanho da imagem
            {
                byte* pixel;
                pixel = src + y * stride + x * 3;
                *(pixel++) = (byte)B;
                *(pixel++) = (byte)G;
                *(pixel++) = (byte)R;
            }
        }

        unsafe public static void PintaVertice(Bitmap bmp, int x, int y, int R, int G, int B)
        {
            int width = bmp.Width;
            int height = bmp.Height;
            int pixelSize = 3;

            BitmapData data = bmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int stride = data.Stride;

            byte* src = (byte*)data.Scan0.ToPointer();

            int raio = 3;
            int bordaR = 0, bordaG = 0, bordaB = 0;

            for (int dy = -raio; dy <= raio; dy++)
            {
                for (int dx = -raio; dx <= raio; dx++)
                {
                    int px = x + dx;
                    int py = y + dy;

                    if (px >= 0 && px < width && py >= 0 && py < height)
                    {
                        int dist2 = dx * dx + dy * dy;

                        byte* pixel = src + py * stride + px * pixelSize;

                        // borda
                        if (dist2 <= raio * raio && dist2 >= (raio - 1) * (raio - 1))
                        {
                            pixel[0] = (byte)bordaB;
                            pixel[1] = (byte)bordaG;
                            pixel[2] = (byte)bordaR;
                        }
                        // centro
                        else if (dist2 < (raio - 1) * (raio - 1))
                        {
                            pixel[0] = (byte)B;
                            pixel[1] = (byte)G;
                            pixel[2] = (byte)R;
                        }
                    }
                }
            }

            bmp.UnlockBits(data);
        }

        //=================================== ALGORITMOS DE PREENCHIMENTO ================================================================================
        /*
         * Codificação de um MÉTODO para preencher toda a área do polígono.
         * **/
        public static void PreencherPoligonoFloodFill(Bitmap imageBitmap, Poligono poligono)
        {
            int width = imageBitmap.Width;
            int height = imageBitmap.Height;
            int pixelSize = 3;

            BitmapData data = imageBitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            //add no inicio[0] e removo do inicio[0]
            List<int> coordX = new List<int>();
            List<int> coordY = new List<int>();
            Point atual = new Point();
            int totX = 0, totY = 0;

            int stride = data.Stride;

            unsafe
            {
                byte* src = (byte*)data.Scan0.ToPointer();
                byte* aux;

                //empilhando os pontos dos vértices
                List<Point> vertices = poligono.GetVerticesModificados();
                for (int i = 0; i < vertices.Count; i++)
                {
                    totX += vertices[i].X;
                    totY += vertices[i].Y;
                }

                //empilhar a média
                coordX.Add(totX / vertices.Count);
                coordY.Add(totY / vertices.Count);

                while (coordX.Count > 0)
                {
                    //desempilha
                    atual.X = coordX[coordX.Count - 1];
                    coordX.RemoveAt(coordX.Count - 1);
                    atual.Y = coordY[coordY.Count - 1];
                    coordY.RemoveAt(coordY.Count - 1);


                    aux = src + atual.Y * stride + atual.X * pixelSize;

                    if (aux[0] == 255 && aux[1] == 255 && aux[2] == 255)
                    {
                        //PintaPixel(src, stride, width, height, atual.X, atual.Y, Color.Azure.R, Color.Azure.G, Color.Azure.B);
                        // pinta direto
                        aux[0] = Color.Azure.B;
                        aux[1] = Color.Azure.G;
                        aux[2] = Color.Azure.R;

                        //DIREITA
                        coordX.Add(atual.X + 1);
                        coordY.Add(atual.Y);

                        //BAIXO
                        coordX.Add(atual.X);
                        coordY.Add(atual.Y + 1);

                        //ESQUERDA
                        coordX.Add(atual.X - 1);
                        coordY.Add(atual.Y);

                        //CIMA
                        coordX.Add(atual.X);
                        coordY.Add(atual.Y - 1);
                    }
                }
            }

            imageBitmap.UnlockBits(data);
        }

        public static void PreencherPoligonoScanlineAET(Bitmap imageBitmap, Poligono poligono)
        {
            int width = imageBitmap.Width;
            int height = imageBitmap.Height;

            BitmapData data = imageBitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int stride = data.Stride;

            unsafe
            {
                byte* src = (byte*)data.Scan0.ToPointer();

                int yMax = poligono.GetYMax();
                EdgeTable[] et = new EdgeTable[yMax + 1]; //vetor de tamanho yMax, para integrar todas as linhas possíveis
                FormarEdgeTable(et, poligono);

                int yMin = poligono.GetYMin();
                int y = yMin;
                EdgeTable aet = new EdgeTable();
                while (!IsVectorEdgeEmpty(et, et.Length) || aet.Count() > 0)
                {
                    if (y >= 0 && y < et.Length && et[y] != null)
                    {
                        NoEdgeTable atual = et[y].GetNoEdgeTableAt(0);

                        while (atual != null)
                        {
                            NoEdgeTable prox = atual.prox;

                            atual.prox = null;
                            aet.Add(atual);

                            atual = prox;
                        }

                        et[y] = null;
                    }

                    //ordenar a lista de available
                    aet.Sort();

                    //remover os elementos (nós) com yMax == y
                    aet.RemoveAllYMax(y);

                    //desenhar os pixels utilizando os pares de coordenadas da AET
                    int quant = aet.Count();
                    for (int i = 0; i < (quant / 2); i++)
                    {
                        NoEdgeTable par1 = aet.GetNoEdgeTableAt(i * 2);
                        NoEdgeTable par2 = aet.GetNoEdgeTableAt(i * 2 + 1);

                        //pintar do (xMin par1) até (xMin par2)
                        int limite = (int)Math.Ceiling(par2.xMin);
                        for (int j = (int)Math.Ceiling(par1.xMin); j < limite; j++)
                            PintaPixel(src, stride, width, height, j, y, Color.Red.R, Color.Red.G, Color.Red.B);
                    }

                    //atualizar os xMin utilizando os incrementos
                    for (int i = 0; i < aet.Count(); i++)
                        aet.GetNoEdgeTableAt(i).Incrementar();

                    y++;
                }
            }

            imageBitmap.UnlockBits(data);
        }

        public static void FormarEdgeTable(EdgeTable[] et, Poligono p)
        {
            //formar a et, primeira parte do algoritmo para rasterização de polígonos
            List<Reta> arestas = p.GetArestasTransformadas();

            foreach (Reta a in arestas)
            {
                NoEdgeTable novoNo = new NoEdgeTable();

                //pegar o yMax
                novoNo.yMax = a.GetYMax();

                //pegar o xMin
                novoNo.xMin = a.GetXMin();

                //calcular o incremento no novoNo
                novoNo.CalcularIncremento(a);

                //setar na posição de Edge Table, onde: [yMin]
                int yMin = a.GetYMin();
                if (et[yMin] == null)
                {
                    et[yMin] = new EdgeTable();
                }
                et[yMin].Add(novoNo);
            }
        }

        public static bool IsVectorEdgeEmpty(EdgeTable[] et, int tamanho)
        {
            //verificar se o vetor de Edge Table possui algum elemento para ser verificado
            bool possuiElementos = false;
            for (int i = 0; i < tamanho && !possuiElementos; i++)
                if (et[i] != null)
                    possuiElementos = true;
            return !possuiElementos;
        }
    }
}
