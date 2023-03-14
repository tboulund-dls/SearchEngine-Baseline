namespace LoadBalancer.Models;

public class ServiceModel {
    public string url { get; set; }
    public double currentLatency { get; set; } = 0;
    public int activeQueries { get; set; } = 0;
}