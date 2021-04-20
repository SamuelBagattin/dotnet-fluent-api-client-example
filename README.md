# Fluent Api Client Example

Honestly, I just wanted to work on stuff using a lot of builders, generics and fluent things 😜

This is an example of an HTTP API client (The example uses SonarQube HTTP API) that has intuitive usage, using a **Fluent API** ❤ 

Here is how to use the lib :

## Usage

### Basic
`MyClientInitiator` Creates a new client, by passing a builder function, to register the *base url* and the *authentication* <br>
The client can create a request, again by playing with builder functions <br>
Then, call `Execute` on the request to get the result
```c#
            // Create the client
            var client = MyClientInitiator.NewClient(e => e
                .WithBaseUrl("http://localhost:9000")
                .WithAnonymousAuth
            );
            
            // Create the request
            var request = client.MakeRequest(e => e
                .GetProjects
                .WithQualifiers(new[] {ComponentsQualifiers.Trk})
            );

            /// Execute the request and get the result
            var res = await request.Execute();
 
```

### With .NET DI
The client can be configured to be registered in DI.

```c#
        public void ConfigureServices(IServiceCollection services)
        {
            // ....

            services.ConfigureMyClient(e => e
                .WithBaseUrl("http://localhost:9000")
                .WithAnonymousAuth
                )

            // ....
        }
```

Then, you can get `IMyClient` in your services
```c#
    public class MyService : IMyService
    {
        private readonly IMyClient _myClient;

        public MyService(IMyClient myClient)
        {
            _myClient = myClient;
        }

        public async Task MyMethod()
        {
            var request = _myClient.MakeRequest(e => e
                .GetProjects
                .WithQualifiers(new[] {ComponentsQualifiers.Trk})
            );

            var result = await request.Execute();
        }
    }
```



