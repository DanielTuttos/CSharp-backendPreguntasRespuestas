using PreguntasRespuestas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreguntasRespuestas.Domain.IServices
{
    public interface IUsuarioServices
    {
        Task SaveUser(Usuario usuario);

        Task<bool> ValidateExistence(Usuario usuario);
    }
}
