using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Librerias
using System.Windows.Forms;

namespace CommonProject.App
{
    public class ClsUI
    {
        public static string ImagesProductoPath = Application.StartupPath + "\\imagenes\\productos";
        public static string ImagesFamiliaPath = Application.StartupPath + "\\imagenes\\familias";

        public static bool SoloDecimal(object sender, KeyPressEventArgs e)
        {
            bool validar = false;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',')) validar = true;

            if ((e.KeyChar == '.') && ((sender as KryptonTextBox).Text.IndexOf(',') > -1)) validar = true;

            return validar;
        }

        public static string Divisa(string txtValor) => decimal.Parse((string.IsNullOrEmpty(txtValor.Trim()) ? "0" : txtValor.Trim())).ToString("F");

    }
}
