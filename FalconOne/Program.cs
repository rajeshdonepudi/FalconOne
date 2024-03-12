using FalconOne.API;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

FalconOneConfiguration.Register(builder);

WebApplication app = builder.Build();

FalconOneConfiguration.Bootstrap(app.Services);

FalconOneConfiguration.Seed(app.Services);

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRateLimiter();

app.UseSwagger();

app.UseHealthChecks("/status");

app.UseSwaggerUI(o =>
{
    o.DefaultModelsExpandDepth(-1);
    o.DisplayRequestDuration();
    o.DocumentTitle = "FalconOne APIs";
});

app.UseCors("ReactAppOrigin");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync(CancellationToken.None);

