Swagger

Install Pacakge:
	Install-Package Swashbuckle.AspNetCore

Register the Swagger generator in Startup.cs 

	

	//import swagger
	using Swashbuckle.AspNetCore.Swagger;
	
	public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TechVendorDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("TechVendorDatabaseConnection"),
                    t => t.MigrationsHistoryTable("__EFMigrationsHistory", Constants.DBSchema)));

            services.AddTransient<ITechVendorManager, TechVendorManager>();

            services.AddAutoMapper();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(options => {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                });

            // Register the Swagger generator
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
        }

// Enable middleware to serve generated Swagger as a JSON endpoint.
	app.UseSwagger();

// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
// specifying the Swagger JSON endpoint.
	app.UseSwaggerUI(c =>
	{
		c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
	});
	

	Results:
	https://localhost:5001/swagger/v1/swagger.json
	
	
	Interactive:
	https://localhost:5001/swagger/index.html
	
	