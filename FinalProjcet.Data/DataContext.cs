using FinalProjectNetCore.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjcet.Data
{
    public class DataContext : DbContext
    {
        //Server=(localdb)\mmsqllocaldb;Database=my_db
        public DbSet<User> Users { get; set; }
        public DbSet<WorkLog> WorkLogs { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<Admin> Admins { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\ProjectModels;Database=new_presence_db");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error configuring database: {ex.Message}");
            }
        }


    }
}
