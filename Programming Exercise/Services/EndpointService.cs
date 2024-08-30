using System;
using System.Collections.Generic;
using System.Linq;
using Programming_Exercise.Interfaces;
using Programming_Exercise.Models;

namespace Programming_Exercise.Services
{
    public class EndpointService : IEndpointService
    {
        private List<Endpoint> endpoints = new List<Endpoint>();

        public void InsertEndpoint(Endpoint endpoint)
        {
            if (endpoints.Any(e => e.SerialNumber == endpoint.SerialNumber))
            {
              throw new Exception("Endpoint with this Serial Number already exists.");
            }
            endpoints.Add(endpoint);
        }

        public void EditEndpoint(string serialNumber, int switchState)
        {
            var endpoint = endpoints.FirstOrDefault(e => e.SerialNumber == serialNumber);
            if (endpoint == null)
            {
                throw new Exception("Endpoint not found.");
            }
            endpoint.SwitchState = switchState;
        }

        public void DeleteEndpoint(string serialNumber)
        {
            var endpoint = endpoints.FirstOrDefault(e => e.SerialNumber == serialNumber);
            if (endpoint == null)
            {
                throw new Exception("Endpoint not found.");
            }
            endpoints.Remove(endpoint);
        }

        public Endpoint FindEndpointBySerial(string serialNumber)
        {
            return endpoints.FirstOrDefault(e => e.SerialNumber == serialNumber);
        }

        public List<Endpoint> ListAllEndpoints()
        {
            return endpoints;
        }
    }
}
