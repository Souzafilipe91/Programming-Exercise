using Xunit;
using Programming_Exercise.Models;
using Programming_Exercise.Services;
using System;

namespace Programming_Exercise.Tests
{
    public class EndpointServiceTests
    {
        private readonly EndpointService _service;

        public EndpointServiceTests()
        {
            _service = new EndpointService();
        }

        [Fact]
        public void InsertEndpoint_ShouldAddNewEndpoint()
        {
            // Arrange
            var endpoint = new Endpoint
            {
                SerialNumber = "123",
                MeterModelId = 16,
                MeterNumber = 1001,
                FirmwareVersion = "1.0.0",
                SwitchState = 1
            };

            // Act
            _service.InsertEndpoint(endpoint);
            var result = _service.FindEndpointBySerial("123");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("123", result.SerialNumber);
            Assert.Equal(16, result.MeterModelId);
        }

        [Fact]
        public void InsertEndpoint_ShouldThrowExceptionForDuplicateSerial()
        {
            // Arrange
            var endpoint1 = new Endpoint { SerialNumber = "123" };
            var endpoint2 = new Endpoint { SerialNumber = "123" };

            // Act
            _service.InsertEndpoint(endpoint1);

            // Assert
            Assert.Throws<Exception>(() => _service.InsertEndpoint(endpoint2));
        }

        [Fact]
        public void EditEndpoint_ShouldUpdateSwitchState()
        {
            // Arrange
            var endpoint = new Endpoint
            {
                SerialNumber = "123",
                MeterModelId = 16,
                MeterNumber = 1001,
                FirmwareVersion = "1.0.0",
                SwitchState = 0 // Desconectado
            };
            _service.InsertEndpoint(endpoint);

            // Act
            _service.EditEndpoint("123", 1); // Alterar para Conectado
            var result = _service.FindEndpointBySerial("123");

            // Assert
            Assert.Equal(1, result.SwitchState);
        }

        [Fact]
        public void DeleteEndpoint_ShouldRemoveEndpoint()
        {
            // Arrange
            var endpoint = new Endpoint
            {
                SerialNumber = "123",
                MeterModelId = 16,
                MeterNumber = 1001,
                FirmwareVersion = "1.0.0",
                SwitchState = 1
            };
            _service.InsertEndpoint(endpoint);

            // Act
            _service.DeleteEndpoint("123");
            var result = _service.FindEndpointBySerial("123");

            // Assert
            Assert.Null(result);
        }


    }
}
