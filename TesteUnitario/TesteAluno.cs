using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CadastroDeAluno;
using System.Threading;

namespace TesteUnitario
{
    [TestClass]
    public class TesteAluno
    {
        [TestMethod, Description("Dada uma entrada nula, gera uma excessão")]
        public void T0001_TestaExcessao()
        {
            Assert.ThrowsException<Exception>(CriaAlunoInvalido);
        }

        public void CriaAlunoInvalido() 
        {
            Aluno aluno = new Aluno()
            {
                Nome = "",
                Nascimento = "0000",
                CPF = "0000",
                Periodo = "0000",
                RA = "0000",
                Telefone = "0000",
                UF = "0000",
            };
        }
    }
}
