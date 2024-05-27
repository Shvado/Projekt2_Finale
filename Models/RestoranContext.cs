using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Projekt.Models
{
    public class RestoranContext : DbContext
    {
        public System.Data.Entity.DbSet<Projekt.Models.Narudzba> Narudzbas { get; set; }
    }
}