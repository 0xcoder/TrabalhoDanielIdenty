using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrabalhoDaniel02.Models;

namespace TrabalhoDaniel02.Context
{
    public class Contexto : IdentityDbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        { }
        public DbSet<Funcionario> Funcionarios { get; set; }
    }
}
