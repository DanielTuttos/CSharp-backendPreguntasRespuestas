﻿using Microsoft.EntityFrameworkCore;
using PreguntasRespuestas.Domain.IRepositories;
using PreguntasRespuestas.Domain.Models;
using PreguntasRespuestas.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreguntasRespuestas.Persistence.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AplicationDbContext _context;

        public UsuarioRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task SaveUser(Usuario usuario)
        {
            _context.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ValidateExistence(Usuario usuario)
        {
            var validateExistence = await _context.Usuarios.AnyAsync(x => x.NombreUsuario == usuario.NombreUsuario);
            return validateExistence;
        }

        public async Task<Usuario> ValidatePassword(int idUsuario, string passwordAnterior)
        {
            var usuario = await _context.Usuarios.Where(x => x.Id == idUsuario && x.Password == passwordAnterior).FirstOrDefaultAsync();
            return usuario;
        }

        public async Task UpdatePassword(Usuario usuario)
        {
            _context.Update(usuario);
            await _context.SaveChangesAsync();
        }
    }
}
