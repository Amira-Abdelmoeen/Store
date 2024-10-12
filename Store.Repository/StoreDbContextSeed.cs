using Store.Core.Entities;
using Store.Repository.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Store.Repository
{
	public class StoreDbContextSeed
	{
		public async static Task SeedAsync(StoreDbContext _context)
		{
            if (_context.Brands.Count() == 0)
            {
				//Brand
				//read data from json file

				var brandsData = File.ReadAllText(@"..\Store.Repository\Data\DataSeed\brands.json");

				//convert from json string to list<T>
				var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

				//Seed data To Databse
				if (brands is not null && brands.Count() > 0)
				{
					await _context.Brands.AddRangeAsync(brands);
					await _context.SaveChangesAsync();
				}

			}

			if (_context.Types.Count() == 0)
			{
				//Types
				//read data from json file

				var typesData = File.ReadAllText(@"..\Store.Repository\Data\DataSeed\types.json");

				//convert from json string to list<T>
				var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

				//Seed data To Databse
				if (types is not null && types.Count() > 0)
				{
					await _context.Types.AddRangeAsync(types);
					await _context.SaveChangesAsync();
				}

			}

			if (_context.Products.Count() == 0)
			{
				//Products
				//read data from json file

				var productsData = File.ReadAllText(@"..\Store.Repository\Data\DataSeed\products.json");

				//convert from json string to list<T>
				var products = JsonSerializer.Deserialize<List<Product>>(productsData);

				//Seed data To Databse
				if (products is not null && products.Count() > 0)
				{
					await _context.Products.AddRangeAsync(products);
					await _context.SaveChangesAsync();
				}

			}


		}

	}
}
