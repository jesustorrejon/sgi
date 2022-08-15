using ComponentFactory.Krypton.Toolkit;
using SGI.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

// Librerias
using System.Windows.Forms;

namespace SGI.App
{
    public class ClsUI
    {
        /* RUTAS DE IMAGENES */
        public static string ImagesProductoPath = Application.StartupPath +  "\\imagenes\\productos\\";
        public static string ImagesFamiliaPath = Application.StartupPath +  "\\imagenes\\familias\\";
        public static string TicketsPath = Application.StartupPath + "\\tickets\\";


        public static bool SoloDecimal(object sender, KeyPressEventArgs e)
        {
            bool validar = false;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) validar = true;

            if ((e.KeyChar == '.') && ((sender as KryptonTextBox).Text.IndexOf('.') > -1)) validar = true;

            return validar;
        } // PERMITIR PUNTOS PARA DECIMALES EN CAMPOS DE TEXTBOX NUMERICOS

        public static bool SoloNumero(object sender, KeyPressEventArgs e)
        {
            bool validar = false;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) validar = true;

            return validar;
        } // PERMITIR SOLO NUMEROS A TEXTBOX

        public static string Divisa(string txtValor)
        {
            return decimal.Parse((string.IsNullOrEmpty(txtValor.Trim()) ? "0" : txtValor.Trim())).ToString("F");
        } // DAR FORMATO DE NUMERO A TEXTBOX, SIN ESPACIOS.

        public static Image resizeImage(Image image, int width, int height)
        {
            var destinationRect = new Rectangle(0, 0, width, height);
            var destinationImage = new Bitmap(width, height);

            destinationImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destinationImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destinationRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return (Image)destinationImage;
        } // REDIMENCIONAR IMAGEN PARA LA VENTANA DE VENTAS

        public static bool ComprobarFormatoEmail(string email)
        {
            String sFormato;
            sFormato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, sFormato))
            {
                if (Regex.Replace(email, sFormato, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        } // VERIFICAR CORREO ELECTRONICO
    }
}
