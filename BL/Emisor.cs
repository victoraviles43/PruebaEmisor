using Microsoft.EntityFrameworkCore;
using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Emisor
    {
        public static ML.Result UpdateEmisor(ML.Emisor emisor)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.EmisorPruebaContext context = new DL.EmisorPruebaContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"ActualizarEmisor '{emisor.idEmisor}',  '{emisor.Rfc}', '{emisor.FechaInicioOperacion}', '{emisor.Capital}'");

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = true;
                result.Ex = ex;
            }
            return (result);
        }
        public static ML.Result DeleteEmisor(ML.Emisor emisor)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EmisorPruebaContext context = new DL.EmisorPruebaContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"DeleteEmisor '{emisor.idEmisor}'");
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se eliminó el registro";
                    }

                    result.Correct = true;
                }
            }
            catch (Exception Ex)
            {
                result.Ex = Ex;
                result.ErrorMessage = "Ocurrio un Error" + result.Ex.Message;
                throw;
            }

            return result;
        }
        public static ML.Result GetEmisores()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.EmisorPruebaContext context = new DL.EmisorPruebaContext())
                {
                    var query = context.Emisors.FromSqlRaw($"GetEmisores").ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Emisor emisor = new ML.Emisor();
                            emisor.idEmisor = obj.IdEmisor;
                            emisor.Rfc = obj.Rfc;
                            emisor.FechaInicioOperacion = obj.FechaInicioOperacion.ToString();
                            emisor.Capital = obj.Capital.Value;


                            result.Objects.Add(emisor);
                        }

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros.";
                    }
                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }

            return result;
        }
        public static ML.Result GetEmisor(string idEmisor)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.EmisorPruebaContext context = new DL.EmisorPruebaContext())

                {

                    var query = context.Emisors.FromSqlRaw($"GetEmisor '{idEmisor}'").AsEnumerable().FirstOrDefault();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        ML.Emisor emisor = new ML.Emisor();

                        emisor.idEmisor = query.IdEmisor;
                        emisor.Rfc = query.Rfc;
                        emisor.FechaInicioOperacion = query.FechaInicioOperacion.ToString();
                        emisor.Capital = query.Capital.Value;

                        result.Object = emisor;

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrió un error al obtener los registros en la tabla Usuario";
                    }
                }

            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result InsertEmisor(ML.Emisor emisor)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.EmisorPruebaContext context = new DL.EmisorPruebaContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"InsertEmisor '{emisor.idEmisor}',  '{emisor.Rfc}', '{emisor.FechaInicioOperacion}',  '{emisor.Capital}'");
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = true;
                result.Ex = ex;
            }
            return (result);
        }

        
    }
}
