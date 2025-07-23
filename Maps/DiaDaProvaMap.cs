using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agendamento.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agendamento.Maps
{
    public class DiaDaProvaMap : IEntityTypeConfiguration<DiaDaProva>
    {
        public void Configure(EntityTypeBuilder<DiaDaProva> builder)
        {
            builder.HasKey(d => d.Id);

            builder.ToTable("AgendamentosDeProva");

            builder.HasOne(a => a.Alunos)
            .WithMany(p => p.DiaDaProva)
            .HasForeignKey(a => a.AlunoId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}