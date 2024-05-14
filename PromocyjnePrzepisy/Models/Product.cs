namespace PromocyjnePrzepisy.Models
{
    public class Product(string name, string ingredientName, Discount discount, string pdfFilePath, Market market)
    {
        public string Name { get; } = name;
        public string IngredientName { get; } = ingredientName;
        public Discount Discount { get; } = discount;
        public Market Market { get; } = market;
        public string PdfFilePath { get; } = pdfFilePath;
    }
}