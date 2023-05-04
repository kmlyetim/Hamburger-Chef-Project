using HamburgerMenuProject.Context;
using HamburgerMenuProject.Models.Entities;
using HamburgerMenuProject.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace HamburgerMenuProject.Repository.Concrete
{
    public class OrderRepository : GenericRepository<Order>,IOrderRepository
    {
        private readonly ApplicationDbContext db;
        public OrderRepository(ApplicationDbContext db) : base(db)
        {
            this.db = db;
        }

        public List<Order> GetAllOrdersInludeProduct()
        {
            return db.Orders.Include(x => x.Menus).Include(x => x.Hamburgers).Include(x => x.Drinks).Include(x => x.Desserts).Include(x => x.Fries).Include(x => x.Sauces).ToList();
        }

        public Order GetOrdersIncludeProduct(int id)
        {
            return db.Orders.Include(x => x.Menus).Include(x => x.Hamburgers).Include(x => x.Drinks).Include(x => x.Desserts).Include(x => x.Fries).Include(x => x.Sauces).Where(x => x.ID == id).FirstOrDefault();
        }

        public void UpdateMethod(Order order)
        {
            var updateOrder = db.Orders.Find(order.ID);
            updateOrder.Hamburgers = order.Hamburgers;
            updateOrder.Menus= order.Menus;
            updateOrder.Drinks= order.Drinks;
            updateOrder.Fries= order.Fries;
            updateOrder.Sauces= order.Sauces;
            updateOrder.Desserts= order.Desserts;
            updateOrder.Price=order.Price;
            db.SaveChanges();          
        }  
    }
}
