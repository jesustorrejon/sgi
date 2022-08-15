using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGI.Models
{
    public class Rec_OC
    {
        private decimal cod_oc;
        private DateTime fecha;
        private string estado;

        public decimal Cod_oc { get => cod_oc; set => cod_oc = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string Estado { get => estado; set => estado = value; }


        public enum ListEstado
        {
            ACEPTADO = 1,
            RECHAZADO = 2,
            PENDIENTE = 3
        }
    }
}
