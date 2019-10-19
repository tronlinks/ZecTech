using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ZedAPI.Models
{
    public class Study : DbContext
    {
        public Study(DbContextOptions<Study> options)
            : base(options)
        {
        }

        public DbSet<StudyContent> StudyDB { get; set; }
    }

}