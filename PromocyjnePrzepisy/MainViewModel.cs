namespace PromocyjnePrzepisy
{
    public class MainViewModel : BaseViewModel
    {
        public List<CollectionItem> Items { get; set; } = new List<CollectionItem>() { new CollectionItem("Text 1", "image_1.jpg", 3),
            new CollectionItem("Text 2", "image_2.jpg", 3), new CollectionItem("Text 3", "image_3.jpg", 2), new CollectionItem("Text 4", "image_1.jpg", 3) };
    }
}
