using Microsoft.EntityFrameworkCore;
using ProjetoCEC_Agenda.Models;

namespace ProjetoCEC_Agenda.Data{

    public class AppDbContext:DbContext{
        public DbSet<Professor>Professores {get;set;}
        protected override void OnConfiguring(DbContextOptionsBuilder options)

            => options.UseMySql("server=localhost;user=root;password=root;database=bancoagenda", new MySqlServerVersion(new Version(8, 0, 27)));
    }

}