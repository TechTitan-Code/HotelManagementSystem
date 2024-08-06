using HotelManagementSystem.Dto;
using HotelManagementSystem.Dto.RequestModel;
using HotelManagementSystem.Dto.ResponseModel;
using HotelManagementSystem.Implementation.Interface;
using HotelManagementSystem.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Implementation.Services
{
    public class ProductServices : IProductServices
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<ProductServices> _logger;

        public ProductServices(ApplicationDbContext dbContext, ILogger<ProductServices> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<BaseResponse<Guid>> CreateProduct(CreateProduct request)
        {
            _logger.LogInformation("Creating product with name: {ProductName}", request.Name);
            try
            {
                if (request != null)
                {
                    var product = new Product
                    {
                        Id = request.Id,
                        Name = request.Name,
                        Price = request.Price
                    };
                    _dbContext.Products.Add(product);
                }

                if (await _dbContext.SaveChangesAsync() > 0)
                {
                    _logger.LogInformation("Product created successfully with name: {ProductName}", request.Name);
                    return new BaseResponse<Guid>
                    {
                        Success = true,
                        Message = "Product Created Successfully",
                    };
                }
                else
                {
                    _logger.LogWarning("Failed to create product with name: {ProductName}", request.Name);
                    return new BaseResponse<Guid>
                    {
                        Success = false,
                        Message = "Failed to Create Product",
                        Hasherror = true
                    };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the product with name: {ProductName}", request.Name);
                return new BaseResponse<Guid>
                {
                    Success = false,
                    Message = "Failed to Create Product",
                    Hasherror = true
                };
            }
        }

        public async Task<List<ProductDto>> GetProduct()
        {
            _logger.LogInformation("Retrieving all products as list");
            return await _dbContext.Products
                .Select(x => new ProductDto()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price
                }).ToListAsync();
        }

        public async Task<BaseResponse<Guid>> DeleteProductAsync(Guid id)
        {
            _logger.LogInformation("Deleting product with ID: {ProductId}", id);
            try
            {
                var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);

                if (product != null)
                {
                    _dbContext.Products.Remove(product);
                }

                if (await _dbContext.SaveChangesAsync() > 0)
                {
                    _logger.LogInformation("Product deleted successfully with ID: {ProductId}", id);
                    return new BaseResponse<Guid>
                    {
                        Success = true,
                        Message = "Product has been deleted Successfully"
                    };
                }
                else
                {
                    _logger.LogWarning("Failed to delete product with ID: {ProductId}", id);
                    return new BaseResponse<Guid>
                    {
                        Success = false,
                        Message = "Failed to delete this product",
                        Hasherror = true
                    };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the product with ID: {ProductId}", id);
                return new BaseResponse<Guid>
                {
                    Success = false,
                    Message = "Failed to delete this product",
                    Hasherror = true
                };
            }
        }

        public async Task<BaseResponse<ProductDto>> GetAllProductsByIdAsync(Guid id)
        {
            _logger.LogInformation("Retrieving product with ID: {ProductId}", id);
            var product = await _dbContext.Products
                .Where(x => x.Id == id)
                .Select(x => new ProductDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                }).FirstOrDefaultAsync();

            if (product != null)
            {
                _logger.LogInformation("Product retrieved successfully with ID: {ProductId}", id);
                return new BaseResponse<ProductDto>
                {
                    Success = true,
                    Message = "Product Retrieved Successfully",
                    Data = product
                };
            }
            else
            {
                _logger.LogWarning("Failed to retrieve product with ID: {ProductId}", id);
                return new BaseResponse<ProductDto>
                {
                    Success = false,
                    Message = "Failed to Retrieve Product",
                    Hasherror = true
                };
            }
        }

        public async Task<BaseResponse<ProductDto>> GetProductAsync(Guid id)
        {
            _logger.LogInformation("Retrieving product with ID: {ProductId}", id);
            var product = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);

            if (product != null)
            {
                _logger.LogInformation("Product retrieved successfully with ID: {ProductId}", id);
                return new BaseResponse<ProductDto>
                {
                    Success = true,
                    Data = new ProductDto
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Price = product.Price,
                    }
                };
            }
            _logger.LogWarning("Failed to retrieve product with ID: {ProductId}", id);
            return new BaseResponse<ProductDto>
            {
                Success = false,
                Message = "Product not found",
            };
        }

        public async Task<BaseResponse<IList<ProductDto>>> GetAllProductAsync()
        {
            _logger.LogInformation("Retrieving all products");
            var products = await _dbContext.Products
                .Select(x => new ProductDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                }).ToListAsync();

            if (products.Any())
            {
                _logger.LogInformation("Products retrieved successfully");
                return new BaseResponse<IList<ProductDto>>
                {
                    Success = true,
                    Message = "Products Retrieved Successfully",
                    Data = products
                };
            }
            else
            {
                _logger.LogWarning("No products found");
                return new BaseResponse<IList<ProductDto>>
                {
                    Success = false,
                    Message = "Failed to Retrieve Products",
                    Hasherror = true
                };
            }
        }

        public async Task<BaseResponse<ProductDto>> UpdateProduct(Guid id, UpdateProduct request)
        {
            _logger.LogInformation("Updating product with ID: {ProductId}", id);
            try
            {
                var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
                if (product == null)
                {
                    _logger.LogWarning("Product not found with ID: {ProductId}", id);
                    return new BaseResponse<ProductDto>
                    {
                        Success = false,
                        Message = "Product not found",
                        Hasherror = true
                    };
                }

                product.Name = request.Name;
                product.Price = request.Price;

                _dbContext.Products.Update(product);
                if (await _dbContext.SaveChangesAsync() > 0)
                {
                    _logger.LogInformation("Product updated successfully with ID: {ProductId}", id);
                    return new BaseResponse<ProductDto>
                    {
                        Success = true,
                        Message = $"Product with ID {id} updated successfully"
                    };
                }
                else
                {
                    _logger.LogWarning("Failed to update product with ID: {ProductId}", id);
                    return new BaseResponse<ProductDto>
                    {
                        Success = false,
                        Message = "Failed to update product",
                        Hasherror = true
                    };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the product with ID: {ProductId}", id);
                return new BaseResponse<ProductDto>
                {
                    Success = false,
                    Message = "An error occurred while updating the product",
                    Hasherror = true
                };
            }
        }
    }
}
