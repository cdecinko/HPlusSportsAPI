using HPlusSportsAPI.Models;
using System.Collections.Generic;

namespace HPlusSportsAPI.Contracts
{
    public interface ICustomerRepository
    {
        void Add(Customer item);

        IEnumerable<Customer> GetAll();

        Customer Find(int key);

        Customer Remove(int key);

        void Update(Customer item);
    }
}