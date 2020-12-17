using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Net.Client;
using PharmacyIntegration.grpc.Protos;

namespace PharmacyIntegration.gRPC
{
    public class GrpcClient
    {

        public GrpcClient() { }

        public async Task<string> CheckForMedication(string name)
        {
            var channel = new Channel("localhost:6565", ChannelCredentials.Insecure);
            var client = new CheckForMedication.CheckForMedicationClient(channel);

            MessageResponseProto response = await client.checkAsync(new MessageProto() { Message = name });

            return response.Response;
        }
    }
}
