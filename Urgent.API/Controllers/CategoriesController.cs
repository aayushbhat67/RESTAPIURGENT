using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Urgent.API.Data;
using Urgent.API.Models.Domain;
using Urgent.API.Models.DTO;
using Urgent.API.Repositories.Interface;

namespace Urgent.API.Controllers
{
    //https://localhost:xxxx/api/categories -- path to reach the controller 
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;
        public CategoriesController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        //
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequestDto request)
        {
            //Map DTO to Domain Model - To post the parameters from the swagger
            var category = new Category
            {
                Name = request.Name,
                UrlHandle = request.UrlHandle
            };

            await categoryRepository.CreateAsync(category); //Abstracting the controller and the repository



            //Domain model to dto  - to hide the essential data from the client 
            var response = new CategoryDto 
            {
                Id = category.Id,
            Name = category.Name,
            UrlHandle = category.UrlHandle
        };

            return Ok(response);

        }


    }
}
