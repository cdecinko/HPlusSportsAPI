using HPlusSportsAPI.Models;
using System.Collections.Generic;

namespace HPlusSportsAPI.Contracts
{
    public interface IProductRepository
    {
        void Add(Product item);

        IEnumerable<Product> GetAll();

        Product Find(string key);

        Product Remove(string key);

        void Update(Product item);
    }
}