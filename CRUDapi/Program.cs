
using CRUDapi.Data;
using CRUDapi.Integracao;
using CRUDapi.Integracao.Interfaces;
using CRUDapi.Integracao.Refit;
using CRUDapi.Repositorios;
using CRUDapi.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace CRUDapi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            /*
             * O builder do entity framework � configurado, adicionando o contexo do banco
             * e usando a string de conex�o que ser� capturada do arquivo appsettings.json
            */
            builder.Services.AddEntityFrameworkSqlServer().
                AddDbContext<SistemaDeTarefasDBContext>(
                    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
                );
            //Para inje��o de depend�ncias
            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            builder.Services.AddScoped<ITarefaRepositorio, TarefaRepositorio>();
            builder.Services.AddScoped<IViacepIntegracao, ViacepIntegracao>();

            //Configura��o do cliente HTTPS do Refit
            builder.Services.AddRefitClient<IViacepIntegracaoRefit>().ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri("https://viacep.com.br");
            });

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
        }
    }
}
