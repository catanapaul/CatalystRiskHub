using CatalystRiskHub.DataAccess.Data;
using CatalystRiskHub.DataAccess.DTOs;
using CatalystRiskHub.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace CatalystRiskHub.Endpoints
{
    public static class ProductsEndpoints
    {
        public static void MapProductsEndpoints(this WebApplication app)
        {
            app.MapGet("/products", List)
                .Produces<List<Product>>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound)
                .WithName("ListProducts")
                .WithOpenApi()
                .AllowAnonymous();
            app.MapGet("/products/{id}", Get)
                .Produces<ProductDto>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound)
                .WithName("GetProduct")
                .WithOpenApi()
                .AllowAnonymous();
            app.MapPost("/products", Create)
                .Produces(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status400BadRequest)
                .WithName("CreateProduct")
                .WithOpenApi()
                .AllowAnonymous();
            app.MapPut("/products", Update)
                .Produces(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status400BadRequest)
                .WithName("UpdateProduct")
                .WithOpenApi()
                .AllowAnonymous();
            app.MapDelete("/products/{id}", Delete)
                .Produces<bool>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status400BadRequest)
                .Produces(StatusCodes.Status404NotFound)
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
            var product = await db.Products.FindAsync(id);
            var productDto = new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };

            if (productDto is null)
            {
                return Results.NotFound();
            }

            return Results.Ok(productDto);
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
