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
    [RoutePrefix("api/Usuario")]
    public class UsuarioController : ApiController
    {
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public IHttpActionResult login(EUsuario user)
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
                Respuesta resp = new LUsuario().login(user);

                if (resp.User != null)
                {
                    var token = TokenGenerator.GenerateTokenJwt(user.Correo);
                    return Ok(new LUsuario().login(user, token));
                }
                else
                {
                    return Ok(new LUsuario().login(user));
                }
                
               
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
        [Route("registro")]
        [AllowAnonymous]
        public IHttpActionResult registro(EUsuario user)
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
                return Ok(new LUsuario().registro(user));
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
        [Route("actualizar")]
        [Authorize]
        public IHttpActionResult actualizarDatos(EUsuario user)
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
                return Ok(new LUsuario().actualizarDatos(user));
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
        [Route("actualizarPassword")]
        [Authorize]
        public IHttpActionResult actualizarPassword(EUsuario user)
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
                return Ok(new LUsuario().actualizarPassword(user));
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
        [Route("buscarRegistro")]
        [Authorize]
        public IHttpActionResult buscarRegistro(EUsuario user)
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
                return Ok(new LUsuario().buscarRegistro(user.Id));
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
        [Route("recuperar")]
        [AllowAnonymous]
        public IHttpActionResult recuperarPassword(EUsuario user)
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
                return Ok(new LUsuario().recuperarPassword(user));
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
