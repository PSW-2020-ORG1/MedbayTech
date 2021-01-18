using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Net.Client;
using MedbayTech.Pharmacies.Domain.Entities.Pharmacies;
using PharmacyIntegration.grpc.Protos;

namespace MedbayTech.Pharmacies.gRPC
{
    public class GrpcClient
    {

        public GrpcClient() { }

        public async Task<string> CheckForMedication(string name, Pharmacy pharmacy)
        {
            var channel = new Channel(pharmacy.APIEndpoint, ChannelCredentials.Insecure);
            var client = new CheckForMedication.CheckForMedicationClient(channel);

            MessageResponseProto response = await client.checkAsync(new MessageProto() { Message = name });

            return response.Response;
        }

        public async Task<string> Echo(Pharmacy pharmacy)
        {

            var channel = new Channel(pharmacy.APIEndpoint, ChannelCredentials.Insecure);

            var echo = new CheckForMedication.CheckForMedicationClient(channel);

            MessageResponseProto response = await echo.echoAsync(new MessageProto() { Message = "Hello!" });

            return response.Response;
        }
    }
}
