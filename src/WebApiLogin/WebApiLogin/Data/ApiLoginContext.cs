using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiLogin.Models;

    public class ApiLoginContext : DbContext
    {
        public ApiLoginContext (DbContextOptions<ApiLoginContext> options)
            : base(options)
        {
        }

        public DbSet<WebApiLogin.Models.UsuarioModel> UsuarioModel { get; set; }
    }
