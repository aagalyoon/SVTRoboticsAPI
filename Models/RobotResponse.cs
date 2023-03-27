namespace RobotRoutingApi.Models;

public class RobotResponse
{
    public int RobotId { get; set; }
    public double DistanceToGoal { get; set; }
    public int BatteryLevel { get; set; }
}