using Microsoft.EntityFrameworkCore;
using PreguntasRespuestas.Domain.IRepositories;
using PreguntasRespuestas.Domain.Models;
using PreguntasRespuestas.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreguntasRespuestas.Persistence.Repositories
{
    public class LoginRepository: ILoginRepository
    {
        private readonly AplicationDbContext _context;

        public LoginRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> ValidateUser(Usuario usuario)
        {
            var user = await _context.Usuarios.Where(x => x.NombreUsuario == usuario.NombreUsuario 
            && x.Password == usuario.Password).FirstOrDefaultAsync();
            return user;
        }
    }
}
