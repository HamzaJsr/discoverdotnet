var builder = WebApplication.CreateBuilder();

var app = builder.Build();


app.MapGet("/get", () => "Hello GET !");
app.MapDelete("/delete", () => "Hello DELETE !");
app.MapPost("/post", () => "Hello POST !");
app.MapPut("/put", () => "Hello PUT !");
app.MapPatch("/patch", () => "Hello PATCH !");

app.Run();