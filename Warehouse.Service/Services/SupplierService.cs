using AutoMapper;
using Warehouse.Common.DTOs;
using Warehouse.Data.Models;
using Warehouse.Interfaces.IRepositories;
using Warehouse.Interfaces.IServices;

namespace Warehouse.Service.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public SupplierService(ISupplierRepository supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DTOSupplier>> GetAllSuppliersAsync()
        {
            var suppliers = await _supplierRepository.GetAllSuppliersAsync();
            return _mapper.Map<IEnumerable<DTOSupplier>>(suppliers);
        }

        public async Task<DTOSupplier> GetSupplierByIdAsync(int id)
        {
            var supplier = await _supplierRepository.GetSupplierByIdAsync(id);
            return _mapper.Map<DTOSupplier>(supplier);
        }

        public async Task AddSupplierAsync(DTOSupplier supplierDTO)
        {
            var supplier = _mapper.Map<Suppliers>(supplierDTO);
            await _supplierRepository.AddSupplierAsync(supplier);
        }

        public async Task UpdateSupplierAsync(DTOSupplier supplierDTO)
        {
            var supplier = _mapper.Map<Suppliers>(supplierDTO);
            await _supplierRepository.UpdateSupplierAsync(supplier);
        }

        public async Task DeleteSupplierAsync(int id)
        {
            await _supplierRepository.DeleteSupplierAsync(id);
        }
    }
}
