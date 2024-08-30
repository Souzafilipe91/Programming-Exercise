using System;
using Programming_Exercise.Interfaces;
using Programming_Exercise.Models;
using Programming_Exercise.Services;

namespace Programming_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            IEndpointService endpointService = new EndpointService();
            bool running = true;

            while (running)
            {
                Console.WriteLine("Selecione uma opção:");
                Console.WriteLine("1) Inserir novo endpoint");
                Console.WriteLine("2) Editar endpoint existente");
                Console.WriteLine("3) Deletar endpoint existente");
                Console.WriteLine("4) Listar todos os endpoints");
                Console.WriteLine("5) Encontrar endpoint por número serial");
                Console.WriteLine("6) Sair");

                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        InsertEndpoint(endpointService);
                        break;
                    case "2":
                        EditEndpoint(endpointService);
                        break;
                    case "3":
                        DeleteEndpoint(endpointService);
                        break;
                    case "4":
                        ListAllEndpoints(endpointService);
                        break;
                    case "5":
                        FindEndpointBySerial(endpointService);
                        break;
                    case "6":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        static void InsertEndpoint(IEndpointService service)
        {
            var endpoint = new Endpoint();
            Console.Write("Digite o número serial: ");
            endpoint.SerialNumber = Console.ReadLine();
            Console.Write("Digite o ID do modelo do medidor: ");
            endpoint.MeterModelId = int.Parse(Console.ReadLine());
            Console.Write("Digite o número do medidor: ");
            endpoint.MeterNumber = int.Parse(Console.ReadLine());
            Console.Write("Digite a versão do firmware: ");
            endpoint.FirmwareVersion = Console.ReadLine();
            Console.Write("Digite o estado do interruptor (0-Desconectado, 1-Conectado, 2-Armado): ");
            endpoint.SwitchState = int.Parse(Console.ReadLine());

            try
            {
                service.InsertEndpoint(endpoint);
                Console.WriteLine("Endpoint inserido com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }

        static void EditEndpoint(IEndpointService service)
        {
            Console.Write("Digite o número serial do endpoint a ser editado: ");
            var serialNumber = Console.ReadLine();
            Console.Write("Digite o novo estado do interruptor (0-Desconectado, 1-Conectado, 2-Armado): ");
            var switchState = int.Parse(Console.ReadLine());

            try
            {
                service.EditEndpoint(serialNumber, switchState);
                Console.WriteLine("Endpoint editado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }

        static void DeleteEndpoint(IEndpointService service)
        {
            Console.Write("Digite o número serial do endpoint a ser deletado: ");
            var serialNumber = Console.ReadLine();

            try
            {
                service.DeleteEndpoint(serialNumber);
                Console.WriteLine("Endpoint deletado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }

        static void ListAllEndpoints(IEndpointService service)
        {
            var endpoints = service.ListAllEndpoints();
            if (endpoints.Count == 0)
            {
                Console.WriteLine("Nenhum endpoint encontrado.");
            }
            else
            {
                foreach (var endpoint in endpoints)
                {
                    Console.WriteLine($"Serial: {endpoint.SerialNumber}, Modelo: {endpoint.MeterModelId}, Número: {endpoint.MeterNumber}, Firmware: {endpoint.FirmwareVersion}, Estado: {endpoint.SwitchState}");
                }
            }
        }

        static void FindEndpointBySerial(IEndpointService service)
        {
            Console.Write("Digite o número serial do endpoint: ");
            var serialNumber = Console.ReadLine();

            var endpoint = service.FindEndpointBySerial(serialNumber);
            if (endpoint != null)
            {
                Console.WriteLine($"Serial: {endpoint.SerialNumber}, Modelo: {endpoint.MeterModelId}, Número: {endpoint.MeterNumber}, Firmware: {endpoint.FirmwareVersion}, Estado: {endpoint.SwitchState}");
            }
            else
            {
                Console.WriteLine("Endpoint não encontrado.");
            }
        }
    }
}
