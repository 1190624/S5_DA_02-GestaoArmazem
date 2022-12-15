using DDDSample1.Domain.Armazens;
using DDDSample1.Controllers;
using DDDSample1.Domain.Armazens.Factory;
using DDDSample1.Domain.Armazens.DTO;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Common;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Moq;

namespace Tests.TestesUnitarios.User
{
    public class ArmazemControllerTest 
    {
        [Fact]
        public async Task Create_Sucess(){
            Armazem armazem1 = new ArmazemFactory().CriarArmazem("T16","Armazém Matosinhos","2311-412", 2311, "Rua de Matosinhos",
                "Senhora da Hora", "Portugal", "Matosinhos", 23.21, 23.21);
            ArmazemDTO armazemDTO = ArmazemMapper.toDTO(armazem1);
            JObject armazemJSon = JObject.FromObject(armazemDTO);
         
            var mockRepository = new Mock<IArmazemRepository>();
            mockRepository.Setup(repository => repository.AddAsync(It.IsAny<Armazem>())).Returns(Task.FromResult(armazem1));

            var mockUnit = new Mock<IUnitOfWork>();

            RegistarArmazemService registarArmazemService = new RegistarArmazemService(mockRepository.Object, mockUnit.Object);
            RegistarArmazemController controller = new RegistarArmazemController(registarArmazemService);

            var result = await controller.Create(armazemJSon);

            mockRepository.Verify(repository => repository.AddAsync(It.IsAny<Armazem>()), Times.AtLeastOnce());
            mockUnit.Verify(unit => unit.CommitAsync(), Times.AtLeastOnce());
            Assert.IsType<ActionResult<ArmazemDTO>>(result);
        }

        [Fact]
        public async Task GetAll_Sucess(){ 
            var mockRepository = new Mock<IArmazemRepository>();
            mockRepository.Setup(repository => repository.GetAllAsync()).Returns(Task.FromResult(new List<Armazem>()));

            var mockUnit = new Mock<IUnitOfWork>();

            ListarArmazensService listarArmazensService = new ListarArmazensService(mockUnit.Object,mockRepository.Object);
            ListarArmazensController listarArmazensController = new ListarArmazensController(listarArmazensService);

            var result = await listarArmazensController.GetAll();

            mockRepository.Verify(repository => repository.GetAllAsync(), Times.AtLeastOnce());
            Assert.IsType<ActionResult<IEnumerable<JObject>>>(result);
        }

        [Fact]
        public async Task GetById_Sucess(){
            Identificador id = new Identificador("exemplo");

            var mockRepository = new Mock<IArmazemRepository>();
            mockRepository.Setup(repository => repository.GetByIdAsync(It.IsAny<Identificador>()));

            var mockUnit = new Mock<IUnitOfWork>();

            RegistarArmazemService registarArmazemService = new RegistarArmazemService(mockRepository.Object, mockUnit.Object);
            RegistarArmazemController registarArmazemController = new RegistarArmazemController(registarArmazemService);

            var result = await registarArmazemController.GetById(id.ToString());

            mockRepository.Verify(repository => repository.GetByIdAsync(It.IsAny<Identificador>()), Times.AtLeastOnce());
            Assert.IsType<ActionResult<ArmazemDTO>>(result);
        }
    }
}