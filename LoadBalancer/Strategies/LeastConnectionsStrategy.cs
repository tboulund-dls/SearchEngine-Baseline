namespace LoadBalancer.Strategies;

public class LeastConnectionsStrategy : ILoadBalancerStrategy
{
    public Server GetServer(List<Server> servers)
    {
        var minConnections = Int32.MaxValue;
        Server selectedServer = null;

        foreach (var server in servers)
        {
            if (server.Connections < minConnections)
            {
                minConnections = server.Connections;
                selectedServer = server;
            }
        }

        if (selectedServer == null)
        {
            throw new Exception("LeastConnectionsStrategy selected server not found");
        };
        
        return selectedServer;
    }
}