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
    [RoutePrefix("api/Formulario")]
    public class FormularioController : ApiController
    {
        [HttpGet]
        [Route("getLocalidades")]
        [Authorize]
        public IHttpActionResult listarLocalidades()
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
                return Ok(new LFormulario().listarLocalidades());
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
        [Route("getBarrios")]
        [Authorize]
        public IHttpActionResult listarBarrios(EBarrio barrio)
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
                return Ok(new LFormulario().listarBarrios(barrio.LocalidadId));
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
        [Route("getFormulario")]
        [Authorize]
        public IHttpActionResult getFormularioXidUser(EFormulario form)
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
                return Ok(new LFormulario().GetFormulario(form.UsuarioId));
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
        [Route("getNombreLocalidad")]
        [Authorize]
        public IHttpActionResult getNombreLocalidad(EFormulario form)
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
                return Ok(new LFormulario().getNombreLocalidad(form.LocalidadId));
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
        [Route("getNombreBarrio")]
        [Authorize]
        public IHttpActionResult getNombreBarrio(EFormulario form)
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
                return Ok(new LFormulario().getNombreBarrio(form.BarrioId));
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
        [Route("comprobarFormulario")]
        [Authorize]
        public IHttpActionResult comprobarFormulario(EFormulario form)
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
                return Ok(new LFormulario().comprobarFormulario(form.UsuarioId));
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
        [Route("guardar")]
        [Authorize]
        public IHttpActionResult guardarFormulario(EFormulario formulario)
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
                return Ok(new LFormulario().guardarFormulario(formulario));
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
