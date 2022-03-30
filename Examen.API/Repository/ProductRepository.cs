using Dapper;
using Examen.API.Context;
using Examen.API.Contracts;
using Examen.API.Entities;
using System.Data;

namespace Examen.API.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DapperContext _context;
        public ProductRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            using (var connection = _context.CreateConnection())
            {
                var products = await connection.QueryAsync<Product>("SP_GetProducts");

                return products.ToList();
            }
        }

        public async Task<Product> GetProduct(int id)
        {
            var procedureName = "SP_GetProductsById";
            var parameters = new DynamicParameters();

            parameters.Add("Id", id, DbType.Int32, ParameterDirection.Input);

            using (var connection = _context.CreateConnection())
            {
                var product = await connection.QueryFirstOrDefaultAsync<Product>
                    (procedureName, parameters, commandType: CommandType.StoredProcedure);

                return product;
            }
        }

        public async Task<Product> CreateProduct(Product product)
        {
            var query = "SP_InsertProduct";

            var parameters = new DynamicParameters();
            parameters.Add("Name", product.Name, DbType.String, ParameterDirection.Input);
            parameters.Add("Price", product.Price, DbType.Double, ParameterDirection.Input);

            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(query, parameters, commandType: CommandType.StoredProcedure);
                var createdProduct = new Product
                {
                    Id = id,
                    Name = product.Name,
                    Price = product.Price
                };
                return createdProduct;
            }
        }

        public async Task UpdateProduct(int id, Product product)
        {
            var query = "SP_UpdateProduct";

            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Name", product.Name, DbType.String, ParameterDirection.Input);
            parameters.Add("Price", product.Price, DbType.Double, ParameterDirection.Input);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task DeleteProduct(int id)
        {
            var query = "SP_DeleteProduct";

            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32, ParameterDirection.Input);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
