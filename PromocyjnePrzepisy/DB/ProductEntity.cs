using PromocyjnePrzepisy.Models;
namespace PromocyjnePrzepisy.DB
{
    public class ProductEntity : EntityBase
    {
        public string? Name { get; set; }
        public string? IngredientName { get; set; }
        //public Discount? Discount { get; set; }
        public string? DiscountStartDate { get; set; }
        public string? DiscountEndDate { get; set; }
        public Market Market { get; set; }
        public int LeafletImageId { get; set; }
        public ProductEntity() { }
        public ProductEntity(Product product)
        {
            Name = product.Name;
            IngredientName = product.IngredientName;
            DiscountStartDate = product.Discount.StartDate.ToShortDateString();
            DiscountEndDate = product.Discount.EndDate.ToShortDateString();
            Market = product.Market;
            LeafletImageId = product.LeafletImageId;
        }
        public Product ToProduct()
        {
            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(IngredientName) || string.IsNullOrEmpty(DiscountStartDate)
                || string.IsNullOrEmpty(DiscountEndDate) /*|| string.IsNullOrEmpty(LeafletImageId)*/)
            {
                throw new InvalidOperationException("Cannot convert to Product because one or more properties are null");
            }
            DateOnly discountStartDate = DateOnly.Parse(DiscountStartDate);
            DateOnly discountEndDate = DateOnly.Parse(DiscountEndDate);
            return new Product(Name, IngredientName, new Discount(discountStartDate, discountEndDate), LeafletImageId, Market);
        }
    }
}
