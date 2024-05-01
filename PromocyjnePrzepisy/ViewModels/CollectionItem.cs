namespace PromocyjnePrzepisy.ViewModels
{
    public class CollectionItem(string name, string source, int discountsCount) : BaseViewModel
    {
        public string Name { get; set; } = name;
        public string Source { get; set; } = source;
        public int DiscountsCount { get; set; } = discountsCount;
    }
}
