using System;
using Xunit;
using CommandAPI.Models;

namespace CommandAPI.Tests
{
    public class CommandTests : IDisposable
    {
        Command testCommand;

        public CommandTests()
        {
            testCommand = new Command
            {
                HowTo = "party",
                Platform = "party floor",
                CommandLine = "dotnet party"
            };
        }
        public void Dispose()
        {
            testCommand = null;
        }

        [Fact]
        public void CanChangeHowTo()
        {
            //Arrange


            //Act
            this.testCommand.HowTo = "get a job";

            // assert
            Assert.Equal("get a job", testCommand.HowTo);
            Assert.Equal("party floor", testCommand.Platform);
            Assert.Equal("dotnet party", testCommand.CommandLine);
        }
    }
}