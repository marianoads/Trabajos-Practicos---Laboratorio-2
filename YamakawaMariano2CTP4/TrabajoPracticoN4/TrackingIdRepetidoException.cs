using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPracticoN4
{
    public class TrackingIdRepetidoException:Exception
    {
        public TrackingIdRepetidoException(string msj):base(msj)
        {

        }

        public TrackingIdRepetidoException(string msj,Exception inner):base(msj,inner)
        {

        }
    }
}
