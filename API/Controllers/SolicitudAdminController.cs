using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Logica;
using Utilitarios;
namespace API.Controllers
{
    [RoutePrefix("api/SolicitudAdmin")]
    public class SolicitudAdminController : ApiController
    {
        [HttpPost]
        [Route("verSolictud")]
        [Authorize]
        public IHttpActionResult verSolicitud(ESolicitudAdmin solicitud)
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
                return Ok(new LSolicitudAdmin().verSolicitud(solicitud.UsuarioId));
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
        [Route("rechazarSolictud")]
        [Authorize]
        public IHttpActionResult rechazarSolictud(EUsuario user)
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
                return Ok(new LSolicitudAdmin().rechazarSolicitud(user.Id));
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
                return Ok(new LSolicitudAdmin().verRegistros());
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

        [HttpPut]
        [Route("cambiarRol")]
        [Authorize]
        public IHttpActionResult cambiarRol(EUsuario user)
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
                return Ok(new LSolicitudAdmin().cambiarRol(user));
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
        [Route("solicitar")]
        [Authorize]
        public IHttpActionResult solicitarAdmin(ESolicitudAdmin solAdmin)
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
                return Ok(new LSolicitudAdmin().solicitarAdmin(solAdmin));
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
        [Route("comprobarSolictud")]
        [Authorize]
        public IHttpActionResult comprobarSolicitud(EUsuario user)
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
                return Ok(new LSolicitudAdmin().comprobarSolicitud(user.Id));
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
