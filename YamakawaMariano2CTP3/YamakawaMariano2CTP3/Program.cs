using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using EntidadesInstanciables;
using Excepciones;
using Archivos;


namespace YamakawaMariano2CTP3
{
    class Program
    {
        static void Main(string[] args)
        {
            Universidad uni = new Universidad();
            Alumno a1 = new Alumno(1, "Juan", "Lopez", "12234456",
            EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
            Alumno.EEstadoCuenta.Becado);
            uni += a1;
            try
            {
                Alumno a2 = new Alumno(2, "Juana", "Martinez", "12234458",
               EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio,
               Alumno.EEstadoCuenta.Deudor);
                uni += a2;
            }
            catch (NacionalidadInvalidaException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                Alumno a3 = new Alumno(3, "José", "Gutierrez", "12234456",
               EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
               Alumno.EEstadoCuenta.Becado);
                uni += a3;
            }
            catch (AlumnoRepetidoException e)
            {
                Console.WriteLine(e.Message);
            }
            Alumno a4 = new Alumno(4, "Miguel", "Hernandez", "92264456",
            EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Legislacion,
            Alumno.EEstadoCuenta.AlDia);
            uni += a4;
            Alumno a5 = new Alumno(5, "Carlos", "Gonzalez", "12236456",
            EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
            Alumno.EEstadoCuenta.AlDia);
            uni += a5;
            Alumno a6 = new Alumno(6, "Juan", "Perez", "12234656",
            EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio,
            Alumno.EEstadoCuenta.Deudor);
            uni += a6;
            Alumno a7 = new Alumno(7, "Joaquin", "Suarez", "91122456",
            EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio,
            Alumno.EEstadoCuenta.AlDia);
            uni += a7;
            Alumno a8 = new Alumno(8, "Rodrigo", "Smith", "22236456",
            EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Legislacion,
            Alumno.EEstadoCuenta.AlDia);
            uni += a8;
            Profesor i1 = new Profesor(1, "Juan", "Lopez", "12224458",
            EntidadesAbstractas.Persona.ENacionalidad.Argentino);
            uni += i1;
            Profesor i2 = new Profesor(2, "Roberto", "Juarez", "32234456",
            EntidadesAbstractas.Persona.ENacionalidad.Argentino);
            uni += i2;
            try
            {
                uni += Universidad.EClases.Programacion;
            }
            catch (SinProfesorException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                uni += Universidad.EClases.Laboratorio;
            }
            catch (SinProfesorException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                uni += Universidad.EClases.Legislacion;
            }
            catch (SinProfesorException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                uni += Universidad.EClases.SPD;
            }
            catch (SinProfesorException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine(uni.ToString());
           

            Console.ReadKey();
            Console.Clear();
            try
            {
                Universidad.Guardar(uni);
                Console.WriteLine("Archivo de Universidad guardado.");
            }
            catch (ArchivosException e)
            {
                Console.WriteLine(e.Message);
            }
                     

            try
            {
                int jornada = 0;
                Jornada.Guardar(uni[jornada]);
                Console.WriteLine("Archivo de Jornada {0} guardado.", jornada);
                //Console.WriteLine(Jornada.Leer());
            }
            catch (ArchivosException e)
            {
                Console.WriteLine(e.Message);
            }



            //----- Probando Archivos XML ----- //
            //Xml<Alumno> xml = new Xml<Alumno>();  //Guardo archivo en Xml
            //xml.Guardar(@"C:\Users\Mariano\Downloads\Alumno.xml", a1);  //Guardo la primer jornada de la lista
            //a1 = null;
            //try
            //{
            //    xml.Leer(@"C:\Users\Mariano\Downloads\Alumno.xml", out  a1);  //Leo
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //Console.WriteLine(a1.ToString());  //Muestro por consola al archivo leido


            //------- Probando Archivos Txt -------//
            //Texto texto = new Texto();
            //texto.Guardar(@"C:\Users\Mariano\Downloads\AlumnoTexto.txt", a1.ToString());
            //string datoLeido="";
            //try
            //{
            //    texto.Leer(@"C:\Users\Mariano\Downloads\AlumnoTexto.txt", out datoLeido);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //Console.WriteLine(datoLeido);

            Console.ReadKey();
        }
    }
}
