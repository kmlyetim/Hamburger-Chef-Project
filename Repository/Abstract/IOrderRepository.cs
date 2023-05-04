using HamburgerMenuProject.Models.Entities;

namespace HamburgerMenuProject.Repository.Abstract
{
    public interface IOrderRepository : IRepository<Order>
    {
        Order GetOrdersIncludeProduct(int id);
        List<Order> GetAllOrdersInludeProduct();
        void UpdateMethod(Order order);
    }

}
