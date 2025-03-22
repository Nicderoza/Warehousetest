using AutoMapper;
using Warehouse.Common.DTOs;
using Warehouse.Data.Models;
using Warehouse.Interfaces.IRepositories;
using Warehouse.Interfaces.IServices;

namespace Warehouse.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DTOProduct>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<DTOProduct>>(products);  // Usa AutoMapper per mappare le entità in DTO
        }

        public async Task<DTOProduct> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<DTOProduct>(product);  // Mappa l'entità in DTO
        }

        public async Task AddProductAsync(DTOProduct product)
        {
            var productEntity = _mapper.Map<Products>(product);  // Mappa il DTO in entità
            await _productRepository.AddAsync(productEntity);
        }

        public async Task UpdateProductAsync(DTOProduct product)
        {
            var productEntity = _mapper.Map<Products>(product);  // Mappa il DTO in entità
            await _productRepository.UpdateAsync(productEntity);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
        }
    }
}
