namespace MilesCarRental.Application.Interfaces
{
    public interface IRepository<T>
    {
        T GetById(long id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAllByCity(long idCity);
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);
    }
}
