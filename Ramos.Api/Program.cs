var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.CustomSchemaIds(n => n.FullName);
});

builder.Services.AddTransient<Handler>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("/v1/transactions", 
    (Request request, Handler handler) => handler.Handle(request))
    .WithName("Transactions: Create")
    .WithSummary("Cria uma nova transação")
    .Produces<Response>();


app.Run();


//request
public class Request
{
    public string Title { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public int Type { get; set; } 
    public decimal Amount { get; set; }
    public long CategoryId { get; set; }
    public string UserId { get; set; } = string.Empty;
}

//response
public class Response
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }

}


//handler
public class Handler
{
    public Response Handle(Request request)
    {
        return new Response
        {
            Id = 1,
            Title = request.Title,
            CreatedAt = request.CreatedAt
        };
    }

}
