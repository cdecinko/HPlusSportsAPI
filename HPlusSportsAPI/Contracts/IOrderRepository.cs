using HPlusSportsAPI.Models;
using System.Collections.Generic;

namespace HPlusSportsAPI.Contracts
{
    public interface IOrderRepository
    {
        void Add(Order item);

        IEnumerable<Order> GetAll();

        Order Find(int key);

        Order Remove(int key);

        void Update(Order item);
    }
}