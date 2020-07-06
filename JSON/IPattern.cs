namespace JSON
{
    public interface IPattern
    {
        IMatch Match(string text);
    }
}
