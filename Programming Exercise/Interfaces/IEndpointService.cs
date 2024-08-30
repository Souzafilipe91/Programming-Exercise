using System.Collections.Generic;
using Programming_Exercise.Models;

namespace Programming_Exercise.Interfaces
{
    public interface IEndpointService
    {
        void InsertEndpoint(Endpoint endpoint);
        void EditEndpoint(string serialNumber, int switchState);
        void DeleteEndpoint(string serialNumber);
        Endpoint FindEndpointBySerial(string serialNumber);
        List<Endpoint> ListAllEndpoints();
    }
}
