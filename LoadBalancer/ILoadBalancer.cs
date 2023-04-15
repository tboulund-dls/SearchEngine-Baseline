using LoadBalancer;

interface ILoadBalancer
{
    string AddServer(string url);
    string RemoveServer(string id);
    int SetLoadBalancerStrategy(int selection);
    Server GetServer();
    List<Server> GetServers();
}