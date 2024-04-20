using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

using SistemaVenta.BLL.Interfaces;
using SistemaVenta.DAL.Interfaces;
using SistemaVenta.Entity;

namespace SistemaVenta.BLL.Imprementacion
{
   public class CorreoService : ICorreoService
    {
        private readonly IGenericRepository<Configuracion> _repositorio;
        
        public CorreoService(IGenericRepository<Configuracion> repoitorio)
        {
            _repositorio = repoitorio;
        }
        public async Task<bool> EnviarCorreo(string CorreoDestino, string Asunto, string Mensaje)
        {
            try
            {
                IQueryable<Configuracion> query = await _repositorio.Consultar(c => c.Recurso.Equals("Servicio_Correo"));
                Dictionary<string, string> Config = query.ToDictionary(keySelector: c => c.Propiedad, elementSelector: c => c.Valor);
                Console.WriteLine(Config);

                var credenciales = new NetworkCredential(Config["correo"], Config["clave"]);

                //var correo = new MailMessage()
                //{
                //    From = new MailAddress(Config["correo"], Config["alias"]),
                //    Subject = Asunto,
                //    Body = Mensaje,
                //    IsBodyHtml = true
                //};

                //correo.To.Add(new MailAddress(CorreoDestino));

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(Config["correo"]);
                    mail.To.Add(CorreoDestino);
                    mail.Subject = Asunto;
                    mail.Body = Mensaje;
                    mail.IsBodyHtml = true;
                    //mail.Attachments.Add(new Attachment("C:\\file.zip"));

                    using (SmtpClient smtp = new SmtpClient(Config["host"], 587))
                    {
                        smtp.Credentials = new NetworkCredential(Config["correo"], Config["clave"]);
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }

                //var clienteServidor = new SmtpClient()
                //{
                //    Host = Config["host"],
                //    Port = int.Parse(Config["puerto"]),
                //    DeliveryMethod = SmtpDeliveryMethod.Network,
                //    UseDefaultCredentials = true,
                //    EnableSsl = true
                //    //Credentials = credenciales

                //};

               
                return true;

            }
            catch(Exception ex) {
                Console.WriteLine();
                Console.WriteLine(ex.ToString());
                Console.WriteLine();
                return false;
            }
        }
    }
}
