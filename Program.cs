using MinimalApis;

var builder = WebApplication.CreateBuilder();

var list = new List<Article>
{
    new Article(1, "Marteau"),
    new Article(2, "Scie")
};


var app = builder.Build();


app.MapGet("/get", () => "Hello GET !");
app.MapDelete("/delete", () => "Hello DELETE !");
app.MapPost("/post", () => "Hello POST !");
app.MapPut("/put", () => "Hello PUT !");
app.MapPatch("/patch", () => "Hello PATCH !");
// app.MapMethods("/methods", new[] {"GET", "POST"}, ()=> "Hello vous !");



app.MapGet("/article/{id:int}", (int id) =>
{
    var article = list.Find(a => a.Id == id);
    if (article is not null){
    return Results.Ok(article);
    }


    return Results.NotFound();;
});

app.Run();