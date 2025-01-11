using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore_EFCore_CodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspNetCore_EFCore_CodeFirst.Mapping
{
    public class LivroMap : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        { 
            builder.ToTable("Livro");

            builder.Property(p => p.ID)
                .ValueGeneratedNever();

            builder.Property(p => p.Titulo)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(p => p.Autor)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(p => p.Preco)
                .HasColumnType("decimal(18,2)");


            builder.Property(p => p.DataEntrada)
                .HasColumnType("datetime");
            
            builder.HasIndex(p => p.Titulo)
                .HasDatabaseName("IDX_livro_Titulo");

            builder.HasOne(p => p.Categoria)
                .WithMany(p => p.Livros)
                .HasForeignKey(p => p.CategoriaID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(
                new Livro(1, 1, "O Guardador de Águas", "Manoel de Barros", 10, 25.00m),
                new Livro(2, 1, "O Livro das Ignorãças", "Manoel de Barros", 16, 25.00m),
                new Livro(3, 1, "Faz escuro mais eu canto", "Thiago de Mello", 54, 25.00m),
                new Livro(4, 1, "Poesia Completa", "Orides Fontela", 22, 25.00m),
                new Livro(5, 1, "O Poder do Mito", "Joseph Campbell", 10, 25.00m),
                new Livro(6, 1, "Poesia comprometida com a minha e a tua vida", "Thiago de Mello", 10, 25.00m)


                );
        }
    }
}
