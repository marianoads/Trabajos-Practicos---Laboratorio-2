using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesInstanciables;
using EntidadesAbstractas;
using Excepciones;

namespace TestUnitarios
{
    [TestClass]
    public class TestNacionalidadInvalida
    {
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            Alumno a1;

            //Act && Assert
            a1 = new Alumno(1, "Juan", "Lopez", "0",
            EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
            Alumno.EEstadoCuenta.Becado);
        }






    }
}
