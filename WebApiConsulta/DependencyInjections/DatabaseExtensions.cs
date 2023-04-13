using WebApiConsulta.Service.Services;
using WebApiConsulta.Service.Servicess;
using WebApiConsulta.Service.Interfaces;
using WebApiConsulta.Repository.Interfaces;
using WebApiConsulta.Repositorie.Connection;
using WebApiConsulta.Repositorie.Interfaces;
using WebApiConsulta.Repository.Repositories;
using WebApiConsulta.Repositorie.Repositories;

namespace WebApiConsulta;

public static class DatabaseExtensions
{
    public static IServiceCollection AddDatabaseExtensions(this IServiceCollection services, IConfiguration configuration, IHostEnvironment hostEnvironment, string environmentName = "Development")
    {
        services.AddScoped<ISqlServerConnection, SqlServerConnection>();
        services.AddHttpClients();

        return services;
    }

    private static IServiceCollection AddHttpClients(this IServiceCollection services)
    {
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<IPessoaService, PessoaService>();
        services.AddScoped<ITelefoneService, TelefoneService>();
        services.AddScoped<IEnderecoService, EnderecoService>();


        services.AddTransient<IEmailRepository, EmailRepository>();
        services.AddTransient<IPessoaRepository, PessoaRepository>();
        services.AddTransient<ITelefoneRepository, TelefoneRepository>();
        services.AddTransient<IEnderecoRepository, EnderecoRepository>();



        return services;
    }
}
