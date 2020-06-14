using System;
using EntidadesInstanciables;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestUnitarios
{
    [TestClass]
    public class TestColeccionInstanciada
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            Universidad uni = new Universidad();

            //Act && Assert
            Assert.IsNotNull(uni.Alumnos);
            

        }
    }
}
