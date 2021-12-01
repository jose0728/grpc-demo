﻿using Grpc.Core;
using GrpcDemo;
using System;
using System.Threading.Tasks;

namespace grpc_server
{
    class Program
    {
        const int Port = 9007;
        static void Main(string[] args)
        {
            Server server = new Server

            {
                Services = { gRPC.BindService(new gRPCImpl()) },

                Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }

            };

            server.Start();



            Console.WriteLine("gRPC server listening on port " + Port);

            Console.WriteLine("任意键退出...");

            Console.ReadKey();



            server.ShutdownAsync().Wait();
        }
    }

    class gRPCImpl : gRPC.gRPCBase

    {
        // 实现SayHello方法

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)

        {
            return Task.FromResult(new HelloReply { Message = "Hello " + request.Name });

        }

    }
}
