/*
 * OpenAPI Petstore
 *
 * This is a sample server Petstore server. For this sample, you can use the api key `special-key` to test the authorization filters.
 *
 * The version of the OpenAPI document: 1.0.0
 * 
 * Generated by: https://openapi-generator.tech
 */

using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Org.OpenAPITools.Authentication;
using Org.OpenAPITools.Filters;
using Org.OpenAPITools.OpenApi;

namespace Org.OpenAPITools
{
    /// <summary>
    /// Startup
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="env"></param>
        public Startup(IHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        /// <summary>
        /// The application configuration.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IAuthorizationHandler, ApiKeyRequirementHandler>();
            services.AddAuthorization(authConfig =>
            {
                authConfig.AddPolicy("api_key", policyBuilder =>
                {
                    policyBuilder
                        .AddRequirements(new ApiKeyRequirement(new[] { "my-secret-key" },"api_key"));
                });
            });

            // Add framework services.
            services
                // Don't need the full MVC stack for an API, see https://andrewlock.net/comparing-startup-between-the-asp-net-core-3-templates/
                .AddControllers()
                .AddNewtonsoftJson(opts =>
                {
                    opts.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    opts.SerializerSettings.Converters.Add(new StringEnumConverter
                    {
                        NamingStrategy = new CamelCaseNamingStrategy()
                    });
                });

            services
                .AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("1.0.0", new OpenApiInfo
                    {
                        Title = "OpenAPI Petstore",
                        Description = "OpenAPI Petstore (ASP.NET Core 3.0)",
                        TermsOfService = new Uri("https://github.com/openapitools/openapi-generator"),
                        Contact = new OpenApiContact
                        {
                            Name = "OpenAPI-Generator Contributors",
                            Url = new Uri("https://github.com/openapitools/openapi-generator"),
                            Email = ""
                        },
                        License = new OpenApiLicense
                        {
                            Name = "NoLicense",
                            Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
                        },
                        Version = "1.0.0",
                    });
                    c.CustomSchemaIds(type => type.FriendlyId(true));
                    c.DescribeAllEnumsAsStrings();
                    c.IncludeXmlComments($"{AppContext.BaseDirectory}{Path.DirectorySeparatorChar}{Assembly.GetEntryAssembly().GetName().Name}.xml");
                    // Sets the basePath property in the Swagger document generated
                    c.DocumentFilter<BasePathFilter>("/v2");

                    // Include DataAnnotation attributes on Controller Action parameters as Swagger validation rules (e.g required, pattern, ..)
                    // Use [ValidateModelState] on Actions to actually validate it in C# as well!
                    c.OperationFilter<GeneratePathParamsValidationFilter>();
                });
                services
                    .AddSwaggerGenNewtonsoftSupport();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app
                // TODO: Renable if you need MVC views as well as just the API
                //.UseMvc()
                .UseDefaultFiles()
                .UseStaticFiles()
                .UseSwagger(c =>
                {
                    c.RouteTemplate = "swagger/{documentName}/openapi.json";
                })
                .UseSwaggerUI(c =>
                {
                    //ORIGIN-TODO: Either use the SwaggerGen generated Swagger contract (generated from C# classes)
                    c.SwaggerEndpoint("/swagger/1.0.0/openapi.json", "OpenAPI Petstore");

                    //ORIGIN-TODO: Or alternatively use the original Swagger contract that's included in the static files
                    // c.SwaggerEndpoint("/openapi-original.json", "OpenAPI Petstore Original");
                });
            app.UseRouting();
            app.UseEndpoints(endpoints =>
	            {
	    	        endpoints.MapControllers();
	            });
        }
    }
}