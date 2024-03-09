using Microsoft.EntityFrameworkCore;
using Spg.Fachtheorie.Aufgabe1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Fachtheorie.Aufgabe1.Infrastructure
{
    public class InnoLabContext : DbContext
    {
        // TODO: DB-Set-Properties

        public InnoLabContext()
        { }

        // TODO: Konstruktor korrigieren
        public InnoLabContext(object fake__PleaseCorrectThis__AndType) // :base(...)
        { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // TODO: Implementation Fluent API
        }
    }
}