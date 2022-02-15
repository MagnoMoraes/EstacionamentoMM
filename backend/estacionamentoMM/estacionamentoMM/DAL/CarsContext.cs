using estacionamentoMM.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace estacionamentoMM.DAL
{
    public class CarsContext : DbContext
    {
        public CarsContext(DbContextOptions<CarsContext> opt) : base (opt)
        {

        }

        public DbSet<Cars> Car { get; set; }

    }
}
