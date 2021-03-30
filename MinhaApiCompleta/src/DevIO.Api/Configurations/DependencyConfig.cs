using Microsoft.Extensions.DependencyInjection;
using DevIO.Business.Interfaces;
using DevIO.Business.Models.Services;
using DevIO.Business.Notifications;
using DevIO.Data.Context;
using DevIO.Data.Repository;

namespace DevIO.Api.Configurations
{
    public static class DependencyConfig
    {
        public static IServiceCollection ResolveDependecies(this IServiceCollection services)
        {
            services.AddScoped<MeuDbContext>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IFornecedorService, FornecedorService>();
            services.AddScoped<IProdutoService, ProdutoService>();

            return services;
        }
    }
}
