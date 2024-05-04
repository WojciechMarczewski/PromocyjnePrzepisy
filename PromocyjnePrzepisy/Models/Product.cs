namespace PromocyjnePrzepisy.Models
{
    public class Product(string name, string ingredientName, Discount discount, byte[] pdfFile, Market market) : EntityBase
    {
        public string Name { get; } = name;
        public string IngredientName { get; } = ingredientName;
        public Discount Discount { get; } = discount;
        public Market Market { get; } = market;
        public byte[] PdfFile { get; } = pdfFile;


    }
}