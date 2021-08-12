using System;
using Xunit;
using CommandAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Moq;
using AutoMapper;
using CommandAPI.Models;
using CommandAPI.Data;
using CommandAPI.Profiles;
using CommandAPI.Dtos;

namespace CommandAPI.Tests
{
    public class CommandsControllerTests : IDisposable
    {
        public Mock<ICommandAPIRepo> mockRepo;
        public CommandsProfile realProfile;
        public MapperConfiguration configuration;
        public IMapper mapper;

        public CommandsControllerTests()
        {
            mockRepo = new Mock<ICommandAPIRepo>();
            realProfile = new CommandsProfile();
            configuration = new MapperConfiguration(cfg => cfg.AddProfile(realProfile));
            mapper = new Mapper(configuration);
        }

        public void Dispose()
        {
            mockRepo = null;
            mapper = null;
            configuration = null;
            realProfile = null;
        }
        [Fact]
        public void GetCommandsItems_ReturnZeroItems_WhenDBIsEmpty()
        {
            //arrange
            mockRepo.Setup(repo =>
            repo.GetAllCommands()).Returns(GetCommands(0));




            var controller = new CommandsController(mockRepo.Object, mapper);

            //act
            var result = controller.GetAllCommands();

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);

        }
        private List<Command> GetCommands(int num)
        {
            var commands = new List<Command>();
            if (num > 0)
            {
                commands.Add(new Command
                {
                    Id = 0,
                    HowTo = "How to generate a migration",
                    CommandLine = "dotnet ef migrations add <Name of Migration>",
                    Platform = ".Net Core EF"
                });

            }
            return commands;

        }
        [Fact]
        public void GetAllCommands_ReturnsOneItem_WhenDbHasOneResource()
        {
            //Given
            mockRepo.Setup(repo => repo.GetAllCommands()).Returns(GetCommands(1));
            var controller = new CommandsController(mockRepo.Object, mapper);
            //When
            var result = controller.GetAllCommands();
            //Then
            var okResult = result.Result as OkObjectResult;
            var commands = okResult.Value as List<CommandReadDto>;
            Assert.Single(commands);
        }
        [Fact]
        public void GetAllCommands_Returns200Ok_WhenDBHasOneResource()
        {
            //Given
            mockRepo.Setup(repo => repo.GetAllCommands()).Returns(GetCommands(1));
            //When
            var controller = new CommandsController(mockRepo.Object, mapper);
            //Then
            var result = controller.GetAllCommands();

            Assert.IsType<OkObjectResult>(result.Result);
        }
        [Fact]
        public void GetAllCommands_ReturnsCorrectType_WhenDBHasOneResource()
        {
            //Given
            mockRepo.Setup(repo => repo.GetAllCommands()).Returns(GetCommands(1));

            var controller = new CommandsController(mockRepo.Object, mapper);
            //When

            var result = controller.GetAllCommands();
            //Then
            Assert.IsType<ActionResult<IEnumerable<CommandReadDto>>>(result);
        }
        [Fact]
        public void GetCommandByID_Returns404NotFound_WhenNonExistentIDProvided()
        {
            //Given
            mockRepo.Setup(repo => repo.GetCommandById(0)).Returns(() => null);
            var controller = new CommandsController(mockRepo.Object, mapper);
            //When
            var result = controller.GetCommandById(1);
            //Then
            Assert.IsType<NotFoundResult>(result.Result);
        }
        [Fact]
        public void GetCommandByID_Returns200Ok_WhenValidIDProvided()
        {
            //Given
            mockRepo.Setup(repo => repo.GetCommandById(1)).Returns(new Command { Id = 1, HowTo = "mock", Platform = "Mock", CommandLine = "Mock" });
            var controller = new CommandsController(mockRepo.Object, mapper);
            //When
            var result = controller.GetCommandById(1);
            //Then
            Assert.IsType<OkObjectResult>(result.Result);
        }
        [Fact]
        public void GetCommandByID_ReturnsValidType_WhenValidIDProvided()
        {
            //Given
            mockRepo.Setup(repo => repo.GetCommandById(1)).Returns(new Command { Id = 1, HowTo = "mock", Platform = "mock", CommandLine = "mock" });

            var controller = new CommandsController(mockRepo.Object, mapper);

            //When
            var result = controller.GetCommandById(1);
            //Then

            Assert.IsType<ActionResult<CommandReadDto>>(result);
        }
    }

}