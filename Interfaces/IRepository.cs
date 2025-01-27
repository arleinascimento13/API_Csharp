namespace Interfaces
{
    public interface IRepository<T>
    {
        T GetById(int id);
        public List<T> Get();

        public void Post(T user);

        public void Update(int id);

        public void Delete(int id);
        public void Patch(int id);
    }
}
