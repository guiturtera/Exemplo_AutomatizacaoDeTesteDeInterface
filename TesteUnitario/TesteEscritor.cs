using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using CadastroDeAluno;
using System.IO;

namespace TesteUnitario
{
    [TestClass]
    public class TesteEscritor
    {
        private string _directoryToCreate;
        private string _fileToCreate;

        private List<Aluno> _alunos;
        [TestInitialize]
        public void Setup() 
        {
            _directoryToCreate = "AlunosCadastrados";
            _fileToCreate = @"AlunosCadastrados\Registros.txt";
            _alunos = CarregaAlunosSimulados();
        }

        private List<Aluno> CarregaAlunosSimulados()
        {
            List<Aluno> alunos = new List<Aluno>();
            for (int i = 0; i < 3; i++)
            {
                string str = i.ToString();
                Aluno aluno = new Aluno()
                {
                    Nome = str,
                    Nascimento = str,
                    CPF = str,
                    Periodo = str,
                    RA = str,
                    Telefone = str,
                    UF = str,
                };
                alunos.Add(aluno);
            }
            return alunos;
        }

        [TestMethod, Description("Dada uma lista de alunos, deve salvar os dados dos alunos em formato TXT.")]
        public void T0001_SalvaArquivo()
        {
            Directory.CreateDirectory("AlunosCadastrados");
            Escritor.SalvaArquivo(_alunos);
            Assert.IsTrue(File.Exists(_fileToCreate));
        }

        [TestMethod, Description("Caso o diretório \"AlunosCadastrados\" não exista, deve criar um diretório.")]
        public void T0002_SalvaArquivo()
        {
            Escritor.SalvaArquivo(_alunos);
            Assert.IsTrue(Directory.Exists(_directoryToCreate));
        }

        [TestCleanup]
        public void Dispose()
        {
            Directory.Delete(_directoryToCreate, true);
        }
    }
}
