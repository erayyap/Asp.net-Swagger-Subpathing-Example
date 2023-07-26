using Asp.net_Filters_Example.Filters;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSwaggerGen(c =>
{
    c.DocumentFilter<SwaggerDocumentFilter>();
});
builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    

});
app.MapGet("/", () => "Hello World!");

app.Run();
