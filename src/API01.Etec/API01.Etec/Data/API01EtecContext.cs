using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API01.Etec.Model;

namespace API01.Etec.Data
{
    public class API01EtecContext : DbContext
    {
        public API01EtecContext (DbContextOptions<API01EtecContext> options)
            : base(options)
        {
        }

        public DbSet<API01.Etec.Model.ContatoModel> ContatoModel { get; set; }
    }
}
