using MinimalApis;

var builder = WebApplication.CreateBuilder();

var app = builder.Build();


app.MapGet("/get", () => "Hello GET !");
app.MapDelete("/delete", () => "Hello DELETE !");
app.MapPost("/post", () => "Hello POST !");
app.MapPut("/put", () => "Hello PUT !");
app.MapPatch("/patch", () => "Hello PATCH !");
app.MapMethods("/methods", new[] {"GET", "POST"}, ()=> "Hello vous !");

app.MapGet("/article", () => new Article(1, "Marteau"));
app.MapGet("/articles/{id}", (int id) => new Article(id, "Marteau"));

app.Run();