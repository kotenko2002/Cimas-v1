using Cimas.Entities.Products;
using Cimas.Service.Products.Descriptors;
using Cimas.Storage.Uow;
using Cimas.Сommon.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cimas.Service.Products
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _uow;

        public ProductService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<int> AddProductAsync(AddProductDescriptor descriptor)
        {
            var product = new Product()
            {
                WorkDayId = descriptor.WorkDayId,
                Price = descriptor.Price,
            };

            _uow.ProductRepository.Add(product);
            await _uow.CompleteAsync();

            return product.Id;
        }
        public async Task EditProductsAsync(int workDayId, IEnumerable<EditProductDescriptor> descriptors)
        {
            //await _uow.ProductRepository.GetProductsByWorkDayIdAsync(workDayId);

            foreach (var descriptor in descriptors)
            {
                var product = await _uow.ProductRepository.FindAsync(descriptor.Id);

                if(product == null)
                {
                    throw new NotFoundException("Product with such Id doesn't exist.");
                }

                product.Price = descriptor.Price;
                product.Amount = descriptor.Amount;
                product.SoldAmount = descriptor.SoldAmount;
                product.Incoming = descriptor.Incoming;
            }

            await _uow.CompleteAsync();
        }

        public async Task DeleteProductAsync(int productId)
        {
            var product = await _uow.ProductRepository.FindAsync(productId);
            if (product == null)
            {
                throw new NotFoundException("Product with such Id doesn't exist.");
            }

            _uow.ProductRepository.Remove(product);
            await _uow.CompleteAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByWorkDayIdAsync(int workDayId)
        {
            return await _uow.ProductRepository.GetProductsByWorkDayIdAsync(workDayId);
        }
    }
}
