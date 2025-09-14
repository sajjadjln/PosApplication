namespace PoseLibrary.DataAccess
{
    public interface IDataConnection<T>
    {
        // here the implementation is only used not the interface what can we do about this
        T AddModelToFile(T entity);
    }
}