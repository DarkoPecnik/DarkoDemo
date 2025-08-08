namespace DarkoDemo.DataServices.Base.Interfaces;

public interface IUnitOfWork
{
    Task<int> SaveChanges();
}