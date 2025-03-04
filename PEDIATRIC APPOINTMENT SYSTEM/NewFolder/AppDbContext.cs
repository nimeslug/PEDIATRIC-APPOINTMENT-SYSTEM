﻿using Microsoft.EntityFrameworkCore;
using System.Numerics;
using webOdev.Models;
using webOdev.Controllers;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WEBPRO.Models;


namespace webOdev.NewFolder
{
    public class AppDbContext : DbContext
{
        public AppDbContext(DbContextOptions<AppDbContext> options)
      : base(options) { }
    public DbSet<Assistant> Assistants { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Schedule> Schedules { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Emergency> Emergencies { get; set; }
    public DbSet<CalenderEvent> CalenderEvents { get; set; }
}
}
