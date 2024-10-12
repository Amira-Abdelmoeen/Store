using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Store.Core.Services.Contract;

namespace Store.APIs.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IProductService _productService;

		public ProductsController(IProductService productService)
        {
			_productService = productService;
		}
		[HttpGet]
		public async Task<IActionResult> GetAllProductsAsync()
		{
			var result = await _productService.GetAllProductsAsync();	
			return Ok(result);
		}

		[HttpGet("brands")]
		public async Task<IActionResult> GetAllBrandsAsync()
		{
			var result = await _productService.GetAllBrandsAsync();
			return Ok(result);
		}

		[HttpGet("types")]
		public async Task<IActionResult> GetAllTypesAsync()
		{
			var result = await _productService.GetAllTypsAsync();
			return Ok(result);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetAllProductById(int? id)
		{
			if(id is null) return BadRequest("invalid id !!");
			var result = await _productService.GetProductById(id.Value);
			if (result is null) return NotFound($"The Product With Id: {id} Not Found at DB");
			return Ok(result);
		}


	}
}
