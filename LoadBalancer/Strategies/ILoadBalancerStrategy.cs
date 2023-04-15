using LoadBalancer;

interface ILoadBalancerStrategy
{
    Server GetServer(List<Server> servers);
}