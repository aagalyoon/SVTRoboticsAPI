using Microsoft.AspNetCore.Mvc;
using RobotRoutingApi.Models;

namespace RobotRoutingApi.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class RobotsController : ControllerBase
{
    private const string RobotApiUrl = "https://60c8ed887dafc90017ffbd56.mockapi.io/robots";
    private const string RobotApiUrlMirror = "https://svtrobotics.free.beeceptor.com/robots";

    [HttpPost("closest")]
    public async Task<IActionResult> GetClosestRobot([FromBody] Load load)
    {
        using var httpClient = new HttpClient();
        List<Robot> robots;

        try
        {
            robots = await httpClient.GetFromJsonAsync<List<Robot>>(RobotApiUrl);
        }
        catch
        {
            robots = await httpClient.GetFromJsonAsync<List<Robot>>(RobotApiUrlMirror);
        }

        var bestRobot = robots
            .Select(robot => new { Robot = robot, Distance = Distance(load.X, load.Y, robot.X, robot.Y) })
            .Where(item => item.Distance <= 10)
            .OrderByDescending(item => item.Robot.BatteryLevel)
            .ThenBy(item => item.Distance)
            .FirstOrDefault();

        if (bestRobot == null) return NotFound("No suitable robot found.");

        var response = new RobotResponse
        {
            RobotId = bestRobot.Robot.RobotId,
            DistanceToGoal = bestRobot.Distance,
            BatteryLevel = bestRobot.Robot.BatteryLevel
        };

        return Ok(response);
    }

    private static double Distance(int x1, int y1, int x2, int y2)
    {
        var deltaX = x2 - x1;
        var deltaY = y2 - y1;
        return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
    }
}