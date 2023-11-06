global using unidrummond_pexWebApi_DBFirst.Context;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SpMedicalGroupContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthentication();    

app.UseAuthorization(); 

app.MapControllers()    ;

app.Run();