using Orleans;
using Sphere.Interfaces;
using Sphere.Shared;

namespace Sphere.Grains;

public class ServiceDiscoveryGrain : Grain, IServiceDiscovery
{
    private ServiceDefinition? _serviceDefinition;

    public Task<ServiceDefinition?> GetServiceDefinition()
        => Task.FromResult(_serviceDefinition);

    public Task<ServiceDefinition> SetServiceDefinition(ServiceDefinition serviceDefinition)
    {
        _serviceDefinition = serviceDefinition;
        return Task.FromResult(_serviceDefinition);
    }
}
