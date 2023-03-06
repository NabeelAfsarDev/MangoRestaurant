using Mango.Services.ProductAPI.Models.Dto;
using Mango.Services.ProductAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        protected ResponseDto _response;
        private IProductRepository _repo;

        public ProductController(IProductRepository repo)
        {
            _repo = repo;
            this._response = new ResponseDto();
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                var productDtos = await _repo.GetProducts();
                _response.Result = productDtos;
            }
            catch (Exception ex)
            {
                _response.IsSucess = false;
                _response.ErrorMessages = new List<string>()
                {
                    ex.ToString()
                };
                throw;
            }
            return _response;

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                var productDto = await _repo.GetProductById(id);
                _response.Result = productDto;
            }
            catch (Exception ex)
            {
                _response.IsSucess = false;
                _response.ErrorMessages = new List<string>()
                {
                    ex.ToString()
                };
                throw;
            }
            return _response;
        }

        [HttpPost]
        public async Task<object> Post([FromBody] ProductDto productDto)
        {
            try
            {
                var model = await _repo.CreateUpdateProduct(productDto);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSucess = false;
                _response.ErrorMessages = new List<string>()
                {
                    ex.ToString()
                };
                throw;
            }
            return _response;
        }

        [HttpPut]
        public async Task<object> Put([FromBody] ProductDto productDto)
        {
            try
            {
                var model = await _repo.CreateUpdateProduct(productDto);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSucess = false;
                _response.ErrorMessages = new List<string>()
                {
                    ex.ToString()
                };
                throw;
            }
            return _response;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<object> DeleteProduct(int id)
        {
            try
            {
                bool isSuccess = await _repo.DeleteProduct(id);
                _response.Result = isSuccess;
            }
            catch (Exception ex)
            {
                _response.IsSucess = false;
                _response.ErrorMessages = new List<string>()
                {
                    ex.ToString()
                };
                throw;
            }
            return _response;
        }
    }
}
