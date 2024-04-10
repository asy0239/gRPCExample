namespace Application.Option
{
    public interface IOptional<out T> where T : class, new()
    {
        void Update(Action<T> applyChange);
    }
}
