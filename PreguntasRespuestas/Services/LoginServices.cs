using PreguntasRespuestas.Domain.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreguntasRespuestas.Services
{
    public class LoginServices: ILoginServices
    {
        public readonly ILoginServices _loginServices;
        public LoginServices(ILoginServices loginservices)
        {
            _loginServices = loginservices;
        }
    }
}
