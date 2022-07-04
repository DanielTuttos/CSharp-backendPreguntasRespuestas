using PreguntasRespuestas.Domain.IRepositories;
using PreguntasRespuestas.Domain.IServices;
using PreguntasRespuestas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreguntasRespuestas.Services
{
    public class LoginServices: ILoginServices
    {
        public readonly ILoginRepository _loginRepository;
        public LoginServices(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public async Task<Usuario> ValidateUser(Usuario usuario)
        {
            return await _loginRepository.ValidateUser(usuario);
        }
    }
}
