using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Utilitarios;
using Logica;
namespace API.Controllers
{
    [RoutePrefix("api/Solicitud")]
    public class SolicitudController : ApiController
    {
        [HttpPost]
        [Route("insertar")]
        [Authorize]
        public IHttpActionResult insertar(ESolicitud solicitud)
        {
            string error = "Error...";
            try
            {
                if (!ModelState.IsValid)
                {
                    foreach (var state in ModelState)
                    {
                        foreach (var item in state.Value.Errors)
                        {
                            error += $"{item.ErrorMessage}";
                        }
                    }
                }
                return Ok(new LSolicitud().insertarSolicitud(solicitud));
            }
            catch (Exception ex)
            {
                error += $"Se presento un problema manejando su solicitud. Error: {ex.Message}";
                var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(error, System.Text.Encoding.UTF8, "text/plain")
                };
                return ResponseMessage(httpResponseMessage);
            }
        }

        [HttpGet]
        [Route("verRegistros")]
        [Authorize]
        public IHttpActionResult verRegistros()
        {
            string error = "Error...";
            try
            {
                if (!ModelState.IsValid)
                {
                    foreach (var state in ModelState)
                    {
                        foreach (var item in state.Value.Errors)
                        {
                            error += $"{item.ErrorMessage}";
                        }
                    }
                }
                return Ok(new LSolicitud().verRegistros());
            }
            catch (Exception ex)
            {
                error += $"Se presento un problema manejando su solicitud. Error: {ex.Message}";
                var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(error, System.Text.Encoding.UTF8, "text/plain")
                };
                return ResponseMessage(httpResponseMessage);
            }
        }

        [HttpPost]
        [Route("verSolictud")]
        [Authorize]
        public IHttpActionResult verSolicitud(ESolicitud solicitud)
        {
            string error = "Error...";
            try
            {
                if (!ModelState.IsValid)
                {
                    foreach (var state in ModelState)
                    {
                        foreach (var item in state.Value.Errors)
                        {
                            error += $"{item.ErrorMessage}";
                        }
                    }
                }
                return Ok(new LSolicitud().verSolicitud(solicitud.UsuarioId));
            }
            catch (Exception ex)
            {
                error += $"Se presento un problema manejando su solicitud. Error: {ex.Message}";
                var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(error, System.Text.Encoding.UTF8, "text/plain")
                };
                return ResponseMessage(httpResponseMessage);
            }
        }

        [HttpPost]
        [Route("borrarSolictud")]
        [Authorize]
        public IHttpActionResult borrarSolictud(ESolicitud solicitud)
        {
            string error = "Error...";
            try
            {
                if (!ModelState.IsValid)
                {
                    foreach (var state in ModelState)
                    {
                        foreach (var item in state.Value.Errors)
                        {
                            error += $"{item.ErrorMessage}";
                        }
                    }
                }
                return Ok(new LSolicitud().borrarSolicitudRespuesta(solicitud.Id));
            }
            catch (Exception ex)
            {
                error += $"Se presento un problema manejando su solicitud. Error: {ex.Message}";
                var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(error, System.Text.Encoding.UTF8, "text/plain")
                };
                return ResponseMessage(httpResponseMessage);
            }
        }
    }
}
