namespace FlexHelper
{
    public interface IWordReplacer
    {
        string ReplacedText { get; }
        string Replace(string text);
        bool Success();
    }
}