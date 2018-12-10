using System.Linq;
using Domain;
using Dto;

namespace Bll.Mappings
{
    public static class Mapper
    {
        public static ProductDto MapToDto(Product source) =>

            new ProductDto
            {
                Id = source.Id,
                TimeStamp = source.TimeStamp,
                Name = source.Name,
                Description = source.Description,
                Price = source.Price,
                Category = source.Category
            };
        
        public static Product MapFromDto(ProductDto source) =>

            new Product
            {
                Id = source.Id,
                TimeStamp = source.TimeStamp,
                Name = source.Name,
                Description = source.Description,
                Price = source.Price,
                Category = source.Category
            };

        public static IQueryable<ProductDto> MapToDto(IQueryable<Product> source) =>

            source.Select(src => MapToDto(src));

        public static IQueryable<Product> MapFromDto(IQueryable<ProductDto> source) =>

            source.Select(src => MapFromDto(src));

    }
}
