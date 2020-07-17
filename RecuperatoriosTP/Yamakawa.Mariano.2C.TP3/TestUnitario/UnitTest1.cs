using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using EntidadesInstanciables;
using EntidadesAbstractas;
namespace TestUnitario
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ValidarNacionalidadInvalidaExcepcion()
        {
            try
            { 
                Alumno a1 = new Alumno(2, "lucas", "villalba", "23456578", Persona.ENacionalidad.Extranjero, Universidad.EClases.Legislacion);//le ingreso un dni por debajo de la nacionalidad que tiene
                Assert.Fail("Deberia avisar que el dni es incorrecto de acuerdo a la nacionalidad");
                
            }
            catch(NacionalidadInvalidaException e)
            {
                Assert.IsTrue(true);
            }

        }

        [TestMethod]
         public void ValidarDniInvalidoExcepcion()
        {
            try
            {
                Alumno a1 = new Alumno(2, "lucas", "villalba", "asd", Persona.ENacionalidad.Extranjero, Universidad.EClases.Legislacion);//le ingreso un dni con otro formato
                Assert.Fail("Deberia avisar que el dni es incorrecto de acuerdo al formato");
            }
            catch(DniInvalidoException e)
            {
                Assert.IsTrue(true);
            }
        }
        

        [TestMethod]
        public void ValidarSiSeRepiteAlumno()
        {
            Universidad u = new Universidad();
            Alumno a1 = new Alumno(2, "jorge", "dominguez", "12345678", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Alumno a2 = new Alumno(2, "jorge", "dominguez", "87654321", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);

            try
            {
                u += a1;
                u += a2;
                Assert.Fail("Tiene que indicar error ya que tienen el mismo legajo y son del mismo tipo");
            }
            catch(AlumnoRepetidoException e)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void ColeccionInstanciada()
        {
            //Arrange
            Universidad uni = new Universidad();

            //Act && Assert
            Assert.IsNotNull(uni.Alumnos);
            Assert.IsNotNull(uni.Instructores);
            Assert.IsNotNull(uni.Jornadas);


        }


    }
}
