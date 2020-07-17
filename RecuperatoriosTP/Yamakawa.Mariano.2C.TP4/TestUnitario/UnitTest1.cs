using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
namespace TestUnitario
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void VerificarInstaciaListaPaquetesCorreo()
        {
            Correo c = new Correo();

            Assert.IsNotNull(c);
        }

        [TestMethod]
        public void VerificarCargaDosPaquetesMimosTrackingId()
        {
            Paquete p1 = new Paquete("jujuy", "123");
            Paquete p2 = new Paquete("Salta", "123");
            Correo c = new Correo();
            try
            {
                c += p1;
                c += p2;
                Assert.Fail("deberia lanzar excepcion al agregar uno paquete de igual tracking ID");
            }
            catch(Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(TrackingIdRepetidoException));
            }

        }
    }
}
