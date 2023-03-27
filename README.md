# SVT Robotics API

This .NET Core Web API project provides an endpoint to determine the best robot from a fleet to transport a given load based on distance and battery level. The API retrieves the robot fleet information from a provided external API, calculates the best robot, and returns the optimal load information as a JSON response.

## Prerequisites

-   .NET Core SDK 3.1 or later

## Setup and Run

### Run the following commands in your terminal prompt:

1.  Clone the repository:

    `git clone https://github.com/aagalyoon/SVTRoboticsApi.git`

3.  Navigate to the project folder:

    `cd SVTRoboticsApi`

4.  Restore the NuGet packages:

    `dotnet restore`

5.  Build the project:

    `dotnet build`

6.  Run the project:

    `dotnet run`

    The API will be available at `http://localhost:5000` or `https://localhost:5001`.


## Testing

To test the API, use a tool like [Postman](https://www.postman.com/) or [curl](https://curl.se/) to send a POST request to `http://localhost:5000/api/robots/closest/` or `https://localhost:5001/api/robots/closest/` with the JSON payload:

`{
"loadId": 231,
"x": 5,
"y": 3
}`

The response should be similar to:

`{
"robotId": 58,
"distanceToGoal": 49.9,
"batteryLevel": 30
}`

## Potential Improvements

1.  **Persistence**: Implement a persistence layer to store and retrieve Load objects from a database.

2.  **Caching**: Implement caching for the external API calls to improve performance and reduce the number of requests made to the external API.

3.  **Robot Status**: Enhance the robot model to include additional properties, such as status (e.g., available, busy, charging) to provide better decision-making when selecting the best robot for a load.

4.  **Pagination and Filtering**: Add pagination and filtering capabilities for querying the persisted load responses.

5.  **Authentication and Authorization**: Add authentication and authorization to protect access to the API and manage user permissions.

6.  **Unit and Integration Testing**: Implement unit and integration tests to ensure the stability and correctness of the application.