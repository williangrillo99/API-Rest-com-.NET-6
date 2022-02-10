using ProjetoCEC_Agenda.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>();
var app = builder.Build();
app.MapControllers();
app.Run();
