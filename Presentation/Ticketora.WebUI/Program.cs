using Ticketora.Application.Features.CQRSDesignPattern.Categories.Handlers;
using Ticketora.Application.Features.CQRSDesignPattern.Events.Handlers;
using Ticketora.Application.Features.MediatorDesignPattern.NewFolder.Queries;
using Ticketora.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<CreateCategoryCommandHandler>();
builder.Services.AddScoped<RemoveCategoryCommandHandler>();
builder.Services.AddScoped<UpdateCategoryCommandHandler>();
builder.Services.AddScoped<GetCategoryQueryHandler>();
builder.Services.AddScoped<GetByIdCategoryQueryHandler>();

builder.Services.AddScoped<CreateEventCommandHandler>();
builder.Services.AddScoped<UpdateEventCommandHandler>();
builder.Services.AddScoped<RemoveEventCommandHandler>();
builder.Services.AddScoped<GetEventQueryHandler>();
builder.Services.AddScoped<GetByIdEventQueryHandler>();

builder.Services.AddDbContext<TicketoraContext>();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(GetTicketQuery).Assembly);
});

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
