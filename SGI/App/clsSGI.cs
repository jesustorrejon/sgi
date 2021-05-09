using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Librerias
using SGI.Views;
namespace SGI.App
{
    class clsSGI
    {
        // Metodo para manejar mensaje de formulario Toast
        public static void Toast(string msg)
        {
            fToast f = new fToast(msg);
            f.ShowDialog();
        }
    }
}
