using CleanArchitecture.Application.Features.Products.Commands.CreateProduct;
using CleanArchitecture.Application.Features.Products.Commands.DeleteProduct;
using CleanArchitecture.Application.Features.Products.Commands.UpdateProduct;
using CleanArchitecture.Application.Features.Products.Queries.GetProductByBarcode;
using CleanArchitecture.Application.Features.Products.Queries.GetProductsList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CleanArchitecture.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "CreateProduct")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateProduct([FromBody] CreateProductCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut(Name = "UpdateProduct")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<int>> UpdateProduct([FromBody] UpdateProductCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete(Name = "DeleteProduct")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesDefaultResponseType]

        public async Task<ActionResult<int>> DeleteProduct(int Id)
        {
            var command = new DeleteProductCommand()
            {
                Id = Id,
            };

            await _mediator.Send(command);
            return NoContent();
        }


        [HttpGet(Name = "GetProductsByName")]
        [ProducesResponseType(typeof(IEnumerable<ProductViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> GetProducts(string productName)
        {
            var query = new GetProductsListQuery(productName);

            var products = await _mediator.Send(query);

            return Ok(products);
        }

        [HttpGet("{barcode}", Name = "GetProductsByBarcode")]
        [ProducesResponseType(typeof(IEnumerable<ProductViewModel>), (int)HttpStatusCode.OK)]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> GetProductByBarcode(string barcode)
        {
            var query = new GetProductByBarcodeQuery(barcode);

            var products = await _mediator.Send(query);

            return products != null? Ok(products): NotFound(barcode);
        }
    }
}
