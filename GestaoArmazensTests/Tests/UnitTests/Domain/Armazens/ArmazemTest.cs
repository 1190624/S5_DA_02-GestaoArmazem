using System;
using DDDSample1.Domain.Armazens;
using DDDSample1.Domain.Armazens.Factory;
using DDDSample1.Domain.Common;
using DDDSample1.Domain.Shared;
using Xunit;
using Xunit.Abstractions;

namespace Tests.TestesUnitarios.User
{

    public class ArmazemTest
    {

        [Fact]
        public void CriarArmazemSucess()
        {
            Armazem armazem1 = new ArmazemFactory().CriarArmazem("T16","Armazem Matosinhos","2311-412", 2311, "Rua de Matosinhos",
                "Senhora da Hora", "Portugal", "Matosinhos", 23.21, 23.21, 250);

            Identificador identificador = new Identificador("T16");
            Designacao designacao = new Designacao("Armazem Matosinhos");
            Endereco endereco = new Endereco("2311-412", 2311, "Rua de Matosinhos", "Senhora da Hora", "Portugal");
            Municipio municipio = new Municipio("Matosinhos");
            Coordenadas coordenadas = new Coordenadas(23.21, 23.21);
            Altitude altitude = new Altitude(250);

            Armazem armazem2 = new Armazem(identificador,designacao,endereco,municipio,coordenadas, altitude);

            Assert.Equal(armazem1.Id, armazem2.Id);
        }

        [Fact]
        public void CriarArmazemComIDNull()
        {
            var ex = Assert.Throws<BusinessRuleValidationException>(() => new ArmazemFactory().CriarArmazem("","Armazem Matosinhos","2311-412", 2311, "Rua de Matosinhos",
                "Senhora da Hora", "Portugal", "Matosinhos", 23.21, 23.21, 250));
            Assert.Equal("Formato inválido do Identificador do Armazem;\nO Identificador do Armazem deve ser composto por 3 caratéres alfanuméricos;", ex.Message);
        }

        [Fact]
        public void CriarArmazemComIDInválido()
        {
            var ex = Assert.Throws<BusinessRuleValidationException>(() => new ArmazemFactory().CriarArmazem("ABC1","Armazem Matosinhos","2311-412", 2311, "Rua de Matosinhos",
                "Senhora da Hora", "Portugal", "Matosinhos", 23.21, 23.21, 250));
            Assert.Equal("Formato inválido do Identificador do Armazem;\nO Identificador do Armazem deve ser composto por 3 caratéres alfanuméricos;", ex.Message);
        }

        [Fact]
        public void CriarArmazemComIDInválido2()
        {
            var ex = Assert.Throws<BusinessRuleValidationException>(() => new ArmazemFactory().CriarArmazem("123454","Armazem Matosinhos","2311-412", 2311, "Rua de Matosinhos",
                "Senhora da Hora", "Portugal", "Matosinhos", 23.21, 23.21, 250));
            Assert.Equal("Formato inválido do Identificador do Armazem;\nO Identificador do Armazem deve ser composto por 3 caratéres alfanuméricos;", ex.Message);
        }

        [Fact]
        public void CriarArmazemComIDInválido3()
        {
            var ex = Assert.Throws<BusinessRuleValidationException>(() => new ArmazemFactory().CriarArmazem("TTT123","Armazem Matosinhos","2311-412", 2311, "Rua de Matosinhos",
                "Senhora da Hora", "Portugal", "Matosinhos", 23.21, 23.21, 250));
            Assert.Equal("Formato inválido do Identificador do Armazem;\nO Identificador do Armazem deve ser composto por 3 caratéres alfanuméricos;", ex.Message);
        }

        [Fact]
        public void CriarArmazemComIDInválido4()
        {
            var ex = Assert.Throws<BusinessRuleValidationException>(() => new ArmazemFactory().CriarArmazem("abc","Armazem Matosinhos","2311-412", 2311, "Rua de Matosinhos",
                "Senhora da Hora", "Portugal", "Matosinhos", 23.21, 23.21, 250));
            Assert.Equal("Formato inválido do Identificador do Armazem;\nO Identificador do Armazem deve ser composto por 3 caratéres alfanuméricos;", ex.Message);
        }

        [Fact]
        public void CriarArmazemComDesignacaoNull()
        {
            var ex = Assert.Throws<BusinessRuleValidationException>(() => new ArmazemFactory().CriarArmazem("T16","","2311-412", 2311, "Rua de Matosinhos",
                "Senhora da Hora", "Portugal", "Matosinhos", 23.21, 23.21, 250));
            Assert.Equal("Formato inválido da Designacao do Armazem;\nA Designacao do Armazem é um texto obrigatório com um máximo de 50 caratéres;", ex.Message);
        }
        
        [Fact]
        public void CriarArmazemComDesignacaoCom51Caracteres()
        {
            var ex = Assert.Throws<BusinessRuleValidationException>(() => new ArmazemFactory().CriarArmazem("T16",
            "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa","2311-412", 2311, "Rua de Matosinhos",
                "Senhora da Hora", "Portugal", "Matosinhos", 23.21, 23.21, 250));
            Assert.Equal("Formato inválido da Designacao do Armazem;\nA Designacao do Armazem é um texto obrigatório com um máximo de 50 caratéres;", ex.Message);
        }

        [Fact]
        public void CriarArmazemComCodigoPostalNull()
        {
            var ex = Assert.Throws<BusinessRuleValidationException>(() => new ArmazemFactory().CriarArmazem("T16","Armazem Matosinhos","", 2311, "Rua de Matosinhos",
                "Senhora da Hora", "Portugal", "Matosinhos", 23.21, 23.21, 250));
            Assert.Equal("Formato inválido do Código Postal do Armazem;\nO Código Postal deve seguir o formato utilizado em Portugal;", ex.Message);
        }

        [Fact]
        public void CriarArmazemComCodigoPostalInvalido1()
        {
            var ex = Assert.Throws<BusinessRuleValidationException>(() => new ArmazemFactory().CriarArmazem("T16","Armazem Matosinhos","412-2311", 2311, "Rua de Matosinhos",
                "Senhora da Hora", "Portugal", "Matosinhos", 23.21, 23.21, 250));
            Assert.Equal("Formato inválido do Código Postal do Armazem;\nO Código Postal deve seguir o formato utilizado em Portugal;", ex.Message);
        }

        [Fact]
        public void CriarArmazemComCodigoPostalInvalido2()
        {
            var ex = Assert.Throws<BusinessRuleValidationException>(() => new ArmazemFactory().CriarArmazem("T16","Armazem Matosinhos","abcd-abc", 2311, "Rua de Matosinhos",
                "Senhora da Hora", "Portugal", "Matosinhos", 23.21, 23.21,250));
            Assert.Equal("Formato inválido do Código Postal do Armazem;\nO Código Postal deve seguir o formato utilizado em Portugal;", ex.Message);
        }

        [Fact]
        public void CriarArmazemComNumeroPortaNegativo()
        {
            var ex = Assert.Throws<BusinessRuleValidationException>(() => new ArmazemFactory().CriarArmazem("T16","Armazem Matosinhos","2311-412", -1, "Rua de Matosinhos",
                "Senhora da Hora", "Portugal", "Matosinhos", 23.21, 23.21, 250));
            Assert.Equal("Formato inválido do Número da Porta do Armazem;\nO Número da Porta ultrapassa o limite máximo estabelecido (9999);", ex.Message);
        }

        [Fact]
        public void CriarArmazemComNumeroPortaAcimaLimite()
        {
            var ex = Assert.Throws<BusinessRuleValidationException>(() => new ArmazemFactory().CriarArmazem("T16","Armazem Matosinhos","2311-412", 10000, "Rua de Matosinhos",
                "Senhora da Hora", "Portugal", "Matosinhos", 23.21, 23.21, 250));
            Assert.Equal("Formato inválido do Número da Porta do Armazem;\nO Número da Porta ultrapassa o limite máximo estabelecido (9999);", ex.Message);
        }

        [Fact]
        public void CriarArmazemComNomeRuaNull()
        {
            var ex = Assert.Throws<BusinessRuleValidationException>(() => new ArmazemFactory().CriarArmazem("T16","Armazem Matosinhos","2311-412", 2311, "",
                "Senhora da Hora", "Portugal", "Matosinhos", 23.21, 23.21, 250));
            Assert.Equal("Necessário estipular o Nome da Rua do Armazem;", ex.Message);
        }

        [Fact]
        public void CriarArmazemComLocalidadeNull()
        {
            var ex = Assert.Throws<BusinessRuleValidationException>(() => new ArmazemFactory().CriarArmazem("T16","Armazem Matosinhos","2311-412", 2311, "Rua de Matosinhos",
                "", "Portugal", "Matosinhos", 23.21, 23.21, 250));
            Assert.Equal("Necessário estipular a Localidade do Armazem;", ex.Message);
        }

        [Fact]
        public void CriarArmazemComPaisNull()
        {
            var ex = Assert.Throws<BusinessRuleValidationException>(() => new ArmazemFactory().CriarArmazem("T16","Armazem Matosinhos","2311-412", 2311, "Rua de Matosinhos",
                "Senhora da Hora", "", "Matosinhos", 23.21, 23.21, 250));
            Assert.Equal("Necessário estipular o País do Armazem;", ex.Message);
        }

        [Fact]
        public void CriarArmazemComMunicipioNull()
        {
            var ex = Assert.Throws<BusinessRuleValidationException>(() => new ArmazemFactory().CriarArmazem("T16","Armazem Matosinhos","2311-412", 2311, "Rua de Matosinhos",
                "Senhora da Hora", "Portugal", "", 23.21, 23.21, 250));
            Assert.Equal("Necessário estipular o Municipio do Armazem;", ex.Message);
        }

        [Fact]
        public void CriarArmazemComLatitudeMenorQue90()
        {
            var ex = Assert.Throws<BusinessRuleValidationException>(() => new ArmazemFactory().CriarArmazem("T16","Armazem Matosinhos","2311-412", 2311, "Rua de Matosinhos",
                "Senhora da Hora", "Portugal", "Matosinhos", -91, 23.21, 250));
            Assert.Equal("Formato inválido da Latitude do Armazem;\nO valor da Latitude deve ser entre \"-90\" e \"90\";", ex.Message);
        }

        [Fact]
        public void CriarArmazemComLatitudeMaiorQue90()
        {
            var ex = Assert.Throws<BusinessRuleValidationException>(() => new ArmazemFactory().CriarArmazem("T16","Armazem Matosinhos","2311-412", 2311, "Rua de Matosinhos",
                "Senhora da Hora", "Portugal", "Matosinhos", 91, 23.21, 250));
            Assert.Equal("Formato inválido da Latitude do Armazem;\nO valor da Latitude deve ser entre \"-90\" e \"90\";", ex.Message);
        }

        [Fact]
        public void CriarArmazemComLongitudeMenorQue180()
        {
            var ex = Assert.Throws<BusinessRuleValidationException>(() => new ArmazemFactory().CriarArmazem("T16","Armazem Matosinhos","2311-412", 2311, "Rua de Matosinhos",
                "Senhora da Hora", "Portugal", "Matosinhos", 23.21, -181, 250));
            Assert.Equal("Formato inválido da Longitude do Armazem;\nO valor da Longitude deve ser entre \"-180\" e \"180\";", ex.Message);
        }

        [Fact]
        public void CriarArmazemComLongitudeMaiorQue180()
        {
            var ex = Assert.Throws<BusinessRuleValidationException>(() => new ArmazemFactory().CriarArmazem("T16","Armazem Matosinhos","2311-412", 2311, "Rua de Matosinhos",
                "Senhora da Hora", "Portugal", "Matosinhos", 23.21, 181, 250));
            Assert.Equal("Formato inválido da Longitude do Armazem;\nO valor da Longitude deve ser entre \"-180\" e \"180\";", ex.Message);
        }
    }
}