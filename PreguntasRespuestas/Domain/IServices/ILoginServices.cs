using PreguntasRespuestas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreguntasRespuestas.Domain.IServices
{
    public interface ILoginServices
    {
        Task<Usuario> ValidateUser(Usuario usuario);
    }
}
