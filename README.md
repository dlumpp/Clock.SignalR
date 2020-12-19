# Clock.SignalR
A simple ticking ASP.NET Core SignalR hub to test clients.


## Getting Started
Run the Server project to get a SignalR hub that broadcasts the current time to all clients every second. 
The easiest way is to run with debug in Visual Studio, but you can also run a container either locally or in the cloud.

Build your own image

`docker build -f Dockerfile .. -t <username>/clock.signalr.server:latest`

... or pull mine from Docker Hub

`docker pull dlumpp/clock.signalr.server:latest`

Run a container mapped to local port 8080

`docker run -itd -p 8080:80 <username>/clock.signalr.server:latest`

Connect your SignalR Core client to `http://localhost:8080/clock`

Test your own client or try out the console app in this repo.
