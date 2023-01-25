using BarcodeLib;
using System.Drawing;

namespace ZebraPruebas
{
    class BarCode
    {

        public int x = 45;
        public int w = 155;
        public int xImg = 0;
        private int contador = 0;
        public BarCode()
        {

        }

        public Image generarCodigo(string referencia)
        {
            /*Barcode39 barcodeImg = new Barcode39();
            barcodeImg.Code = barcodeValue.ToString();
            barcodeImg.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White).Save(stream, ImageFormat.Png);*/

            Image barcodeimage;
            Barcode code = new Barcode();
            barcodeimage = GenerarImagen(referencia, code);
            /*Linear barcode = new Linear();
            barcode.Type = BarcodeType.CODE128;
            barcode.BarAlignment = AlignmentHori.Center;
            barcode.ShowText = false;
            barcode.Data = referencia;
            barcode.X = (float)0;
            //barcode.Y = 60;
            barcode.drawBarcode();
            barcodeimage = barcode.drawBarcode();*/

            /*BarcodeWriter br = new BarcodeWriter();
            br.Format = BarcodeFormat.CODE_128;
            Bitmap bm = new Bitmap(br.Write(referencia), 300, 300);
            Image barcodeimage = bm;*/




            /*BarcodeSettings barsetting = new BarcodeSettings();
            barsetting.Data = referencia;
            //barsetting.Data2D = "48525582545";

            barsetting.Type = BarCodeType.Code128;
            barsetting.ShowText = false;
            barsetting.BorderWidth = 100;
            barsetting.TextAlignment = StringAlignment.Center;
            BarCodeGenerator bargenerator = new BarCodeGenerator(barsetting);
            Size size = new Size(200, 30);
            Image barcodeimage = bargenerator.GenerateImage();*/
            return barcodeimage;

        }

        public Graphics PintarStickerCol1(Graphics g, string referencia, string descripcion, string precio3, string precio1, string precio2, string precio4, string unidadMedida, string cantidad, string dimension, string color,
            string estilo)
        {
            Font drawFont = new Font("Arial", 9);
            Font font = new Font("Arial", (float)5.5, FontStyle.Bold);
            Font fnt = new Font("Arial", 9, FontStyle.Bold);
            Font fnt2 = new Font("Arial", 11, FontStyle.Bold);
            Rectangle rect1 = new Rectangle(0, 0, 166, 20); //Rectangle rect1 = new Rectangle(0, 0, 155, 20);
            Rectangle rect3 = new Rectangle(0, 30, 166, 15);
            // Create a StringFormat object with the each line of text, and the block
            // of text centered on the page.
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            if (referencia.Length <= 13)
            {
                Image img = generarCodigo(referencia);
                g.DrawImage(img, 0, 15, 160, 15);
                //  g.DrawImage(img, xImg, 15, w, 15);
                stringFormat.LineAlignment = StringAlignment.Center;

            }
            else
            {
                stringFormat.LineAlignment = StringAlignment.Near;
            }



            // Draw the text and the surrounding rectangle.
            g.DrawString(referencia, drawFont, System.Drawing.Brushes.Black, rect1, stringFormat);
            //g.DrawString(referencia, drawFont, System.Drawing.Brushes.Black, x, 0);
            //g.DrawImage(img, xImg, 15, w, 40);//(cant * 11)

            //g.DrawString(descripcion, drawFont, System.Drawing.Brushes.Black, 5, 30);
            g.DrawString(descripcion, drawFont, System.Drawing.Brushes.Black, rect3, stringFormat);
            g.DrawString(precio1, fnt, System.Drawing.Brushes.Black, 10, 45);
            g.DrawString(precio2, fnt, System.Drawing.Brushes.Black, 90, 45);
            g.DrawString(precio3, fnt2, System.Drawing.Brushes.Black, 10, 60);
            g.DrawString(precio4, fnt2, System.Drawing.Brushes.Black, 90, 60);
            g.DrawString("CxU: " + cantidad, font, System.Drawing.Brushes.Black, 12, 80);
            g.DrawString("Dim: " + dimension, font, System.Drawing.Brushes.Black, 12, 90);
            g.DrawString("Color: " + color, font, System.Drawing.Brushes.Black, 80, 80);
            g.DrawString("Unidad: " + unidadMedida, font, System.Drawing.Brushes.Black, 80, 90);

            return g;
        }

        public Graphics PintarStickerCol2(Graphics g, string referencia, string descripcion, string precio3, string precio1, string precio2, string precio4, string unidadMedida, string cantidad, string dimension, string color,
            string estilo)
        {
            //posicion en x de la col 1 mas 180 para la col 2

            Font drawFont = new Font("Arial", 9);
            Font font = new Font("Arial", (float)5.5, FontStyle.Bold);
            Font fnt = new Font("Arial", 9, FontStyle.Bold);
            Font fnt2 = new Font("Arial", 11, FontStyle.Bold);

            Rectangle rect1 = new Rectangle(170, 0, 166, 20);
            Rectangle rect3 = new Rectangle(170, 30, 166, 15);
            // Create a StringFormat object with the each line of text, and the block
            // of text centered on the page.
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;

            if (referencia.Length <= 13)
            {
                Image img = generarCodigo(referencia);
                g.DrawImage(img, 170, 15, 160, 15);//165
                stringFormat.LineAlignment = StringAlignment.Center;
            }
            else
            {
                //stringFormat.LineAlignment = StringAlignment.Far;
                stringFormat.LineAlignment = StringAlignment.Near;
            }


            // Draw the text and the surrounding rectangle.
            g.DrawString(referencia, drawFont, System.Drawing.Brushes.Black, rect1, stringFormat);

            //g.DrawString(referencia, drawFont, System.Drawing.Brushes.Black, (x + 170), 0);

            //g.DrawString(descripcion, drawFont, System.Drawing.Brushes.Black, 175, 30);
            g.DrawString(descripcion, drawFont, System.Drawing.Brushes.Black, rect3, stringFormat);
            g.DrawString(precio1, fnt, System.Drawing.Brushes.Black, 178, 45);
            g.DrawString(precio2, fnt, System.Drawing.Brushes.Black, 258, 45);
            g.DrawString(precio3, fnt2, System.Drawing.Brushes.Black, 178, 60);
            g.DrawString(precio4, fnt2, System.Drawing.Brushes.Black, 258, 60);
            g.DrawString("CxU: " + cantidad, font, System.Drawing.Brushes.Black, 180, 80);
            g.DrawString("Dim: " + dimension, font, System.Drawing.Brushes.Black, 180, 90);
            g.DrawString("Color: " + color, font, System.Drawing.Brushes.Black, 250, 80);
            g.DrawString("Unidad: " + unidadMedida, font, System.Drawing.Brushes.Black, 250, 90);
            return g;
        }

        public Image GenerarImagen(string referencia, Barcode code)
        {
            Image img;
            if (referencia.Length <= 8)
            {
                if (referencia.Length <= 4) //validar con wilson
                {
                    if (referencia.Length <= 2)
                    {
                        img = code.Encode(TYPE.CODE128, referencia, Color.Black, Color.White, 60, 30);
                        w = 50;
                        xImg = 35;
                    }
                    else
                    {
                        img = code.Encode(TYPE.CODE128, referencia, Color.Black, Color.White, 100, 30);
                    }
                }
                else
                {
                    img = code.Encode(TYPE.CODE128, referencia, Color.Black, Color.White, 150, 30);
                }

            }
            else
            {
                if (referencia.Length >= 9 && referencia.Length <= 11)
                {
                    x = 1;
                    img = code.Encode(TYPE.CODE128, referencia, Color.Black, Color.White, 180, 30);
                }
                else
                {
                    if (referencia.Length == 13 || referencia.Length == 12)
                    {
                        x = 5;
                        w = 150;
                        img = code.Encode(TYPE.CODE128, referencia, Color.Black, Color.White, 200, 30);
                    }
                    else
                    {
                        w = 155;
                        x = 1;
                        if (referencia.Length == 14) //verificar con 15
                        {
                            img = code.Encode(TYPE.CODE128, referencia, Color.Black, Color.White, 205, 30);
                        }
                        else
                        {
                            img = GenerarImagenXl(referencia, code);
                        }

                    }

                }
            }
            return img;
        }



        //SIN USO 


        public Image GenerarImagenXl(string referencia, Barcode code)
        {
            Image img;
            w = 320;
            img = code.Encode(TYPE.CODE128, referencia, Color.Black, Color.White, 329, 30);

            return img;
        }

        public Graphics PintarStickerXL(Graphics g, string referencia, string descripcion, string precio1, string precio2, string precio3, string precio4, string unidadMedida, string cantidad, string dimension, string color,
            string estilo, int numero = 0)
        {
            w = 250;
            Font drawFont = new Font("Arial", 9);
            Font font = new Font("Arial", 9, FontStyle.Bold);
            Font fnt = new Font("Arial", 12, FontStyle.Bold);
            Image img = generarCodigo(referencia);

            Rectangle rect1 = new Rectangle(0, 0, 280, 20);
            Rectangle rect2 = new Rectangle(0, 60, 280, 20);
            Rectangle rect3 = new Rectangle(0, 25, 280, 30);
            Rectangle rect4 = new Rectangle(0, 80, 250, 20);
            Rectangle rect5 = new Rectangle(0, 110, 250, 20);
            Rectangle rect6 = new Rectangle(0, 140, 250, 20);
            Rectangle rect7 = new Rectangle(0, 155, 250, 20);
            Rectangle rect8 = new Rectangle(0, 170, 250, 20);

            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            StringFormat formatoRight = new StringFormat();
            formatoRight.Alignment = StringAlignment.Near;
            formatoRight.LineAlignment = StringAlignment.Near;

            StringFormat formatoLeft = new StringFormat();
            formatoLeft.Alignment = StringAlignment.Far;
            formatoLeft.LineAlignment = StringAlignment.Far;

            g.DrawString(referencia, drawFont, System.Drawing.Brushes.Black, rect1, stringFormat);

            //g.DrawString(referencia, drawFont, System.Drawing.Brushes.Black, (x + 170), 0);
            g.DrawImage(img, rect3);
            //g.DrawImage(img, 10, 25, w, 30);
            g.DrawString(descripcion, drawFont, System.Drawing.Brushes.Black, rect2, stringFormat);

            g.DrawString(precio1, fnt, System.Drawing.Brushes.Black, rect4, formatoRight);
            g.DrawString(precio2, fnt, System.Drawing.Brushes.Black, rect4, formatoLeft);
            g.DrawString(precio3, fnt, System.Drawing.Brushes.Black, rect5, formatoRight);
            g.DrawString(precio4, fnt, System.Drawing.Brushes.Black, rect5, formatoLeft);
            g.DrawString("CxU: " + cantidad, font, System.Drawing.Brushes.Black, rect6, formatoRight);
            g.DrawString("Color: " + color, font, System.Drawing.Brushes.Black, rect6, formatoLeft);
            g.DrawString("Dim: " + dimension, font, System.Drawing.Brushes.Black, rect7, formatoRight);
            g.DrawString("Unidad: " + unidadMedida, font, System.Drawing.Brushes.Black, rect7, formatoLeft);
            if (numero != 0)
            {
                g.DrawString("v:" + numero, font, System.Drawing.Brushes.Black, rect8, formatoLeft);
            }
            //g.DrawString(precio1, fnt, System.Drawing.Brushes.Black, 170, 75);
            //g.DrawString(precio2, fnt, System.Drawing.Brushes.Black, 240, 75);
            //g.DrawString(precio3, fnt, System.Drawing.Brushes.Black, 170, 60);
            //g.DrawString(unidadMedida, font, System.Drawing.Brushes.Black, 250, 75);
            //g.DrawString("CxU: " + cantidad, font, System.Drawing.Brushes.Black, 170, 90);
            //g.DrawString("Dim: " + dimension, font, System.Drawing.Brushes.Black, 170, 100);
            //g.DrawString("Color: " + color, font, System.Drawing.Brushes.Black, 230, 90);
            //g.DrawString("Estilo: " + estilo, font, System.Drawing.Brushes.Black, 230, 100);
            return g;
        }

        public Graphics PintarStickerSmall(Graphics g, string referencia, int columna)
        {
            w = 250;
            Font drawFont = new Font("Arial", 9);
            Font font = new Font("Arial", 9, FontStyle.Bold);
            Font fnt = new Font("Arial", 12, FontStyle.Bold);
            Image img = generarCodigo(referencia);

            Rectangle rect1 = new Rectangle(0, 0, 125, 20);
            Rectangle rect2 = new Rectangle(0, 20, 125, 30);

            Rectangle rect3 = new Rectangle(140, 0, 125, 20);
            Rectangle rect4 = new Rectangle(140, 20, 125, 30);

            Rectangle rect5 = new Rectangle(280, 0, 125, 20);
            Rectangle rect6 = new Rectangle(280, 20, 125, 30);

            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            /*System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            g.DrawString(referencia, drawFont, myBrush, rect1, stringFormat);*/


            if (columna >= 1)
            {
                g.DrawString(referencia, drawFont, System.Drawing.Brushes.Black, rect1, stringFormat);
                g.DrawImage(img, rect2);
            }
            if (columna >= 2)
            {
                g.DrawString(referencia, drawFont, System.Drawing.Brushes.Black, rect3, stringFormat);

                g.DrawImage(img, rect4);
            }
            if (columna >= 3)
            {
                g.DrawString(referencia, drawFont, System.Drawing.Brushes.Black, rect5, stringFormat);

                g.DrawImage(img, rect6);
            }



            return g;
        }

        public Graphics PintarStickerRotulo(Graphics g, string txtDestino, string txtDireccion, string txtCiudad, string cbxContacto)
        {
            w = 250;
            Font drawFont = new Font("Arial", 25);
            Font destinoFont = new Font("Arial", 20);
            Font font = new Font("Arial", 9, FontStyle.Bold);
            Font fnt = new Font("Arial", 12, FontStyle.Bold);

            Rectangle rectDestino = new Rectangle(0, 0, 700, 180);
            Rectangle rectDireccion = new Rectangle(0, 50, 700, 180);

            Rectangle rectCiudad = new Rectangle(0, 100, 700, 180);
            Rectangle rectTelefono = new Rectangle(0, 150, 700, 180);

            Rectangle rectRemite = new Rectangle(0, 200, 700, 180);
            Rectangle rectTelefonoIM = new Rectangle(0, 250, 700, 180);
            Rectangle rectCiudadIM = new Rectangle(400, 250, 700, 180);

            StringFormat stringFormat = new StringFormat();
            //stringFormat.Alignment = StringAlignment.Center;
            //Font font = new Font(txtDestino, FontStyle.Underline);
            stringFormat.LineAlignment = StringAlignment.Center;

            /*System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            g.DrawString(referencia, drawFont, myBrush, rect1, stringFormat);*/

            g.DrawString("Destino: " + txtDestino, destinoFont, System.Drawing.Brushes.Black, rectDestino, stringFormat);
            g.DrawString("Direccion: " + txtDireccion, drawFont, System.Drawing.Brushes.Black, rectDireccion, stringFormat);
            g.DrawString("Ciudad: " + txtCiudad, drawFont, System.Drawing.Brushes.Black, rectCiudad, stringFormat);
            g.DrawString("Telefono: " + cbxContacto, drawFont, System.Drawing.Brushes.Black, rectTelefono, stringFormat);
            g.DrawString("Remite: IN MODA FANTASY S.A.S", drawFont, System.Drawing.Brushes.Black, rectRemite, stringFormat);
            g.DrawString("Teléfono: 5124129", drawFont, System.Drawing.Brushes.Black, rectTelefonoIM, stringFormat);
            g.DrawString("Ciudad: MEDELLÍN", drawFont, System.Drawing.Brushes.Black, rectCiudadIM, stringFormat);


            return g;
        }
    }
}
