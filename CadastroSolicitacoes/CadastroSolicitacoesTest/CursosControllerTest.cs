using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using CadastroSolicitacoes.Controllers;
using CadastroSolicitacoes.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;


namespace CadastroSolicitacoesTest
{
       
    public class CursosControllerTest
    {
        private readonly Mock<DbSet<Curso>> _mockSet;
        private readonly Mock<Context> _mockContext;
        private readonly Curso _curso;
        
        public CursosControllerTest()
        {
           _mockSet = new Mock<DbSet<Curso>>();
           _mockContext = new Mock<Context>();
           _curso = new Curso { Id = 1, NomeDoCurso = "Curso Teste" };

            _mockContext.Setup(m => m.Curso).Returns(_mockSet.Object);

            _mockContext.Setup(m => m.Curso.FindAsync(1))
            .ReturnsAsync(_curso);


            
        }

        [Fact]
        public void CursosController_ListaCursos()
        {
            Assert.NotNull(_mockSet.Object);
            //_curso.Id.Should().NotBe(0);
            
        }

        [Fact]
        public void Details_Cursos()
        {
            _curso.NomeDoCurso.Should().Contain("Curso Teste");
        }

        [Fact]
        public void CursosController_Create()
        {
            _curso.NomeDoCurso.Insert(1, "Curso Teste").Should().NotBe(null);
        }
    }
}
