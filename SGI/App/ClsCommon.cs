using SGI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SGI.App
{
    public class ClsCommon
    {
        public static int flag = 0;
        public static string codigo = "";
        public static bool payCommited = false;
        public static string FileName_Ticket;

        public static readonly string version = "2021.07.23";
        public static readonly string app = "Sistema Almacen Yuyitos";

        public static string Server = "xe";
        public static string Database = "sgi";
        public static string User = "sgi";
        public static string Password = "sgi";
        //public static string ConnectionString = $"Server={Server};Database={Database};User id={User};Password{Password}";
        public static string ConnectionString = $"DATA SOURCE = {Server}; PASSWORD= {Password}; USER ID= {User};";

        // mensajes de CRUD
        public static readonly string NoRowsAfected = "Ningun registro eliminado";
        public static readonly string NoRowsAdded = "No se guardó el registro, intenta nuevamente";
        public static readonly string NoRowsUpdated = "No se actualizó el registro";
        public static readonly string NoRowsDeleted = "No se eliminó el registro";

        public static readonly string RowCreated = "Se agrego correctamente el registro a la tabla";
        public static readonly string RowDeleted = "Se elimino correctamente el registro de la tabla";
        public static readonly string RowUpdated = "Se actualizó correctamente el registro en la tabla";

        // mensajes predeterminados
        public static readonly string AccesDenied = "Acceso denegado para ";
        public static readonly string RutNoValido = "Rut no valido ";

        public static void Toast(string msg)
        {
            fToast f = new fToast(msg);
            f.ShowDialog();
        }

        public static string EncrypByMD5(string text)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(text);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            // step 3, return encrypted text
            return sb.ToString();
        } // ENCRIPTAR CADENA DE TEXTO

        // VALIDACIONES DE RUT

        public static bool ValidaRut(string rut)
        {
            rut = rut.Replace(".", "").ToUpper();
            Regex expresion = new Regex("^([0-9]+-[0-9K])$");
            string dv = rut.Substring(rut.Length - 1, 1);
            if (!expresion.IsMatch(rut))
            {
                return false;
            }
            char[] charCorte = { '-' };
            string[] rutTemp = rut.Split(charCorte);
            if (dv != Digito(int.Parse(rutTemp[0])))
            {
                return false;
            }
            return true;
        }

        public static string Digito(int rut)
        {
            int suma = 0;
            int multiplicador = 1;
            while (rut != 0)
            {
                multiplicador++;
                if (multiplicador == 8)
                    multiplicador = 2;
                suma += (rut % 10) * multiplicador;
                rut = rut / 10;
            }
            suma = 11 - (suma % 11);
            if (suma == 11)
            {
                return "0";
            }
            else if (suma == 10)
            {
                return "K";
            }
            else
            {
                return suma.ToString();
            }
        }

        // rutina que formatea con separadores de miles y agrega el guion
        public static string FormatearRut(string rut)
        {
            string rutFormateado = string.Empty;

            if (rut.Length == 0)
            {
                rutFormateado = "";
            }
            else
            {
                string rutTemporal;
                string dv;
                Int64 rutNumerico;

                rut = rut.Replace("-", "").Replace(".", "");

                if (rut.Length == 1)
                {
                    rutFormateado = rut;
                }
                else
                {
                    rutTemporal = rut.Substring(0, rut.Length - 1);
                    dv = rut.Substring(rut.Length - 1, 1);

                    //aqui convierto a un numero el RUT si ocurre un error lo deja en CERO
                    if (!Int64.TryParse(rutTemporal, out rutNumerico))
                    {
                        rutNumerico = 0;
                    }

                    //este comando es el que formatea con los separadores de miles
                    rutFormateado = rutNumerico.ToString("N0");

                    if (rutFormateado.Equals("0"))
                    {
                        rutFormateado = string.Empty;
                    }
                    else
                    {
                        //si no hubo problemas con el formateo agrego el DV a la salida
                        rutFormateado += "-" + dv;

                        //y hago este replace por si el servidor tuviese configuracion anglosajona y reemplazo las comas por puntos
                        rutFormateado = rutFormateado.Replace(",", ".");
                    }
                }
            }

            return rutFormateado;
        }

        public static string QuitarFormatoRut(string rut)
        {
            rut = rut.Replace("-", "").Replace(".", "");

            return rut;
        }
    }
}
