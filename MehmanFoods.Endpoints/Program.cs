using MehmanFoods.Core.Entities;
using MehmanFoods.Core.IRepository;
using MehmanFoods.Core.IService;
using MehmanFoods.Core.MappingProfile;
using MehmanFoods.Repository;
using MehmanFoods.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.WithOrigins("http://localhost:4200")  // The URL of your Angular app
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());  // This will automatically register all profiles in your solution

ConfigureServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();//added
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAllOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();

static void ConfigureServices(IServiceCollection servicesCollection)
{
    //Services DI
    servicesCollection.AddScoped<IOrderDetailService, OrderDetailService>();
    servicesCollection.AddScoped<IOrderService, OrderService>();
    servicesCollection.AddScoped<IProductService, ProductService>();
    servicesCollection.AddScoped<ISaleProductService, SaleProductService>();
    servicesCollection.AddScoped<ISaleService, SaleService>();
    servicesCollection.AddScoped<IInvoiceService, InvoiceService>();
    servicesCollection.AddScoped<ICustomerService, CustomerService>();
    servicesCollection.AddScoped<IBatchService, BatchService>();
    servicesCollection.AddScoped<IBatchNoService, BatchNoService>();
    servicesCollection.AddScoped<IBatchIngredientService, BatchIngredientService>();
    servicesCollection.AddScoped<IIngredientService, IngredientService>();
    servicesCollection.AddScoped<IUnitService, UnitService>();

    //Repositories DI
    servicesCollection.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
    servicesCollection.AddScoped<IOrderRepository, OrderRepository>();
    servicesCollection.AddScoped<IProductRepository, ProductRepository>();
    servicesCollection.AddScoped<ISaleProductRepository, SaleProductRepository>();
    servicesCollection.AddScoped<ISaleRepository, SaleRepository>();
    servicesCollection.AddScoped<IInvoiceRepository, InvoiceRepository>();
    servicesCollection.AddScoped<ICustomerRepository, CustomerRepository>();
    servicesCollection.AddScoped<IBatchRepository, BatchRepository>();
    servicesCollection.AddScoped<IBatchNoRepository, BatchNoRepository>();
    servicesCollection.AddScoped<IBatchIngredientRepository, BatchIngredientRepository>();
    servicesCollection.AddScoped<IIngredientRespository, IngredientRepository>();
    servicesCollection.AddScoped<IUnitRepository, UnitRepository>();

    servicesCollection.AddAutoMapper(typeof(MehmanFoodsProfiles));

    servicesCollection.AddDbContext<MehmanFoodsDbContext>(options =>
        options.UseSqlServer("Server=DESKTOP-HF285NV\\SQLEXPRESS01;Database=MehmanFoods;Trusted_Connection=True;TrustServerCertificate=true;"));
}