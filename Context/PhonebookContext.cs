using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiModule.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiModule.Context
{
    public class PhonebookContext : DbContext
    {
        public PhonebookContext(DbContextOptions<PhonebookContext> options) : base(options) {

        }

        public DbSet<Contact> Contacts { get; set; }
    }
}