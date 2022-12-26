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
            var workday = await _uow.WorkDayRepository.FindAsync(descriptor.WorkDayId);
            if(workday == null)
            {
                throw new NotFoundException("Workday with such Id doesn't exist");
            }
            var product = new Product()
            {
                WorkDayId = descriptor.WorkDayId,
                Name = descriptor.Name,
                Price = descriptor.Price,
            };

            _uow.ProductRepository.Add(product);
            await _uow.CompleteAsync();

            return product.Id;
        }
        public async Task EditProductsAsync(IEnumerable<EditProductDescriptor> descriptors)
        {
            foreach (var descriptor in descriptors)
            {
                var product = await _uow.ProductRepository.FindAsync(descriptor.Id);

                if(product == null)
                {
                    throw new NotFoundException("Product with such Id doesn't exist");
                }

                if(product.Amount + descriptor.Incoming - descriptor.SoldAmount < 0)
                {
                    throw new BusinessLogicException("Sold cannot be more than Amount + Incomed");
                }

                product.Price = descriptor.Price;
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
