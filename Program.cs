using Microsoft.AspNetCore.Mvc;
using MinimalApis;

var builder = WebApplication.CreateBuilder();

builder.Services.AddSingleton<ArticleServices>();

var app = builder.Build();


app.MapGet("/get", () => "Hello GET !");
app.MapDelete("/delete", () => "Hello DELETE !");
app.MapPost("/post", () => "Hello POST !");
app.MapPut("/put", () => "Hello PUT !");
app.MapPatch("/patch", () => "Hello PATCH !");
// app.MapMethods("/methods", new[] {"GET", "POST"}, ()=> "Hello vous !");

app.MapGet("/articles", ([FromServices] ArticleServices service) =>  service.GetAll());

app.MapGet("/article/{id:int}", (int id, [FromServices] ArticleServices service) =>
{
    var article = service.GetAll().Find(a => a.Id == id);
    if (article is not null){
    return Results.Ok(article);
    }
    return Results.NotFound("Not found");
});

app.MapPost("/addArticle/", (Article article, [FromServices] ArticleServices service)=> 
{
    Article result = service.Add(article.Title);
    return Results.Ok(result);
}); 

app.MapGet("/personne/{nom}", (
    [FromRoute(Name = "nom")] string nomPersonne,
    [FromQuery] string? prenom) => Results.Ok($"{nomPersonne} {prenom}"));

// app.MapGet("/personne/identite", (Personne p)=> Results.Ok(p));

app.Use(async (context, next) =>
{
    using var reader = new StreamReader(context.Request.Body);
    var body = await reader.ReadToEndAsync();
    Console.WriteLine($"Corps brut reçu : {body}");
    context.Request.Body = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(body));
    await next();
});


app.MapPost("/personne/identite", (Personne? p) =>
{
    if (p == null)
    {
        Console.WriteLine("Erreur : Désérialisation échouée. Le corps JSON est peut-être mal formé.");
        return Results.BadRequest("Données non valides ou mal formées.");
    }
    Console.WriteLine($"Nom : {p.Nom}, Prénom : {p.Prenom}");
    return Results.Ok(p);
});


app.Run();