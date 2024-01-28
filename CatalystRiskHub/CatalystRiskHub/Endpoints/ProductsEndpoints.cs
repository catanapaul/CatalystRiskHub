using CatalystRiskHub.DataAccess.Data;
using CatalystRiskHub.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace CatalystRiskHub.Endpoints
{
    public static class ProductsEndpoints
    {
        public static void MapProductsEndpoints(this WebApplication app)
        {
            app.MapGet("/products", List)
                .WithName("ListProducts")
                .WithOpenApi()
                .AllowAnonymous();
            app.MapGet("/products/{id}", Get)
                .WithName("GetProduct")
                .WithOpenApi()
                .AllowAnonymous();
            app.MapPost("/products", Create)
                .WithName("CreateProduct")
                .WithOpenApi()
                .AllowAnonymous();
            app.MapPut("/products", Update)
                .WithName("UpdateProduct")
                .WithOpenApi()
                .AllowAnonymous();
            app.MapDelete("/products/{id}", Delete)
                .WithName("DeleteProduct")
                .WithOpenApi()
                .AllowAnonymous();
        }

        public static async Task<IResult> List(CatalystRiskHubDbContext db)
        {
            var result = await db.Products.ToListAsync();
            return Results.Ok(result);
        }

        public static async Task<IResult> Get(CatalystRiskHubDbContext db, int id)
        {
            return await db.Products.FindAsync(id) is Product product 
                ? Results.Ok(product) 
                : Results.NotFound();
        }

        public static async Task<IResult> Create(CatalystRiskHubDbContext db, Product product)
        {
            await db.Products.AddAsync(product);
            await db.SaveChangesAsync();
            return Results.Created($"/products/{product.Id}", product);
        }

        public static async Task<IResult> Update(CatalystRiskHubDbContext db, Product updatedProduct)
        {
            var product = await db.Products.FindAsync(updatedProduct.Id);

            if (product is null)
                return Results.NotFound();

            db.Entry(updatedProduct).State = EntityState.Modified;
            await db.SaveChangesAsync();

            return Results.NoContent();
        }

        public static async Task<IResult> Delete(CatalystRiskHubDbContext db, int id)
        {
            var product = await db.Products.FindAsync(id);
            if (product is null)
            {
                return Results.NotFound();
            }

            db.Products.Remove(product);
            await db.SaveChangesAsync();
            return Results.Ok();
        }
    }
}
