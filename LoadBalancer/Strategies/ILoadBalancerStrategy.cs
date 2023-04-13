namespace LoadBalancer.Strategies;

public interface ILoadBalancerStrategy
{
    string GetServer(List<Server> servers);
}