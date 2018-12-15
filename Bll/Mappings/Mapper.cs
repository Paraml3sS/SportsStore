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

        public static CartLineDto MapToDto(CartLine source) =>

            new CartLineDto
            {
                Id = source.Id,
                TimeStamp = source.TimeStamp,
                Product = MapToDto(source.Product),
                Quantity = source.Quantity
            };

        public static CartLine MapFromDto(CartLineDto source) =>

            new CartLine
            {
                Id = source.Id,
                TimeStamp = source.TimeStamp,
                Product = MapFromDto(source.Product),
                Quantity = source.Quantity
            };


        public static IQueryable<ProductDto> MapToDto(IQueryable<Product> source) =>

            source.Select(src => MapToDto(src));

        public static IQueryable<Product> MapFromDto(IQueryable<ProductDto> source) =>

            source.Select(src => MapFromDto(src));

        public static IQueryable<CartLineDto> MapToDto(IQueryable<CartLine> source) =>

            source.Select(src => MapToDto(src));

        public static IQueryable<CartLine> MapFromDto(IQueryable<CartLineDto> source) =>

            source.Select(src => MapFromDto(src));
    }
}
