using Docker.DotNet;
using Docker.DotNet.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace DotNet.TDD.DeskBooking.IntegrationTests.Setup
{
    public class MsSqlTestContainer
    {
        private const string CONTAINER_NAME_PREFIX = "dotnet.tdd.deskbooking.integrationtests";
        private const string DB_NAME = "TestDeskBooking";
        private const string DB_USERNAME = "sa";
        private const string DB_PASSWORD = "TestDotNetTDD2022";
        private const string DOCKER_IMAGE = "mcr.microsoft.com/mssql/server";
        private const string DOCKER_TAG = "2019-latest";

        private readonly DockerClient _dockerClient;

        private CreateContainerResponse _dockerContainer;
        private string _freePort;

        public MsSqlTestContainer()
        {
            _dockerClient = new DockerClientConfiguration().CreateClient();
        }

        public async Task InitializeAsync()
        {
            // This call ensures that the latest SQL Server Docker image is pulled
            await _dockerClient.Images.CreateImageAsync(
                new ImagesCreateParameters
                {
                    FromImage = $"{DOCKER_IMAGE}:{DOCKER_TAG}"
                }, null, new Progress<JSONMessage>());

            GetFreePort();

            // Create a container with the previously pulled Docker image
            _dockerContainer = await _dockerClient.Containers.CreateContainerAsync(new CreateContainerParameters()
            {
                Name = CONTAINER_NAME_PREFIX + Guid.NewGuid(),
                Image = $"{DOCKER_IMAGE}:{DOCKER_TAG}",
                Env = new List<string>
                    {
                        "ACCEPT_EULA=Y",
                        $"SA_PASSWORD={DB_PASSWORD}"
                    },
                HostConfig = new HostConfig
                {
                    PortBindings = new Dictionary<string, IList<PortBinding>>
                        {
                            {
                                "1433/tcp",
                                new PortBinding[]
                                {
                                    new PortBinding
                                    {
                                        HostPort = _freePort
                                    }
                                }
                            }
                        }
                }
            });

            // Start the container with the previously created container
            await _dockerClient.Containers.StartContainerAsync(
                _dockerContainer.ID,
                new ContainerStartParameters()
            );
        }

        private void GetFreePort()
        {
            // Taken from https://stackoverflow.com/a/150974/4190785
            var tcpListener = new TcpListener(IPAddress.Loopback, 0);
            tcpListener.Start();
            var port = ((IPEndPoint)tcpListener.LocalEndpoint).Port;
            tcpListener.Stop();
            _freePort = port.ToString();
        }

        public async Task DisposeAsync()
        {
            await _dockerClient.Containers.StopContainerAsync(
                _dockerContainer.ID,
                new ContainerStopParameters(),
                CancellationToken.None);

            await _dockerClient.Containers.RemoveContainerAsync(
                _dockerContainer.ID,
                new ContainerRemoveParameters(),
                CancellationToken.None);
        }

        public string GetConnectionString()
        {
            return $"Server=localhost,{_freePort};Database={DB_NAME};User Id={DB_USERNAME};Password={DB_PASSWORD};";
        }
    }
}
