using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesInstanciables;
using EntidadesAbstractas;
using Excepciones;

namespace TestUnitarios
{
    /// <summary>
    /// Descripción resumida de t
    /// </summary>
    [TestClass]
    public class TestDniInvalido
    {
        [ExpectedException(typeof(DniInvalidoException))]
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            Alumno a1;

            //Act && Assert
            a1 = new Alumno(1, "Juan", "Lopez", "dni333",
            EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
            Alumno.EEstadoCuenta.Becado);

        }
    }
}
