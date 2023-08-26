using Identity.API.Data;
using Identity.API.Helper;
using Microsoft.EntityFrameworkCore;
try
{

    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("connStr")));

    builder.Services.AddTransient<IRefreshTokenGenerator, RefreshTokenGenerator>();

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddCors(opt => opt.AddPolicy("corsPolicy", x => x.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod()));

    var app = builder.Build();

    // Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();


    app.UseCors("corsPolicy");

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();

}
catch (Exception)
{

    throw;
}