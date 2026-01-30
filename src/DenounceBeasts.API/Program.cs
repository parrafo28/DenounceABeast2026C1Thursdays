var builder = WebApplication.CreateBuilder(args);


//var ironIcrKey = "jkashdakjhsdjkashdkjagskdgajksdgkajsgdjagsdjkagsd";
//var ironOcr = builder.Configuration.GetSection("IronOcr");
//builder.Services.AddIronIcr(ironIcrKey);


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); 
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
