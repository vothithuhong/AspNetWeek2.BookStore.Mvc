namespace AspNetWeek2.BookStore.Mvc.ViewModels;

public class BookListItemViewModel
{
    public int Id { get; set; }

    public string Sku { get; set; } = "";

    public string Isbn { get; set; } = "";

    public string Title { get; set; } = "";

    public string Author { get; set; } = "";

    public string Category { get; set; } = "";

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public int MinStock { get; set; }

    public string PriceText => $"{Price:N0} VND";

    public decimal InventoryValue => Price * Quantity;

    public string InventoryValueText => $"{InventoryValue:N0} VND";

    public string StockStatus
    {
        get
        {
            if (Quantity <= 0)
            {
                return "Hết hàng";
            }

            if (Quantity <= MinStock)
            {
                return "Sắp hết";
            }

            return "Còn hàng";
        }
    }

    public string StockStatusClass
    {
        get
        {
            if (Quantity <= 0)
            {
                return "text-danger";
            }

            if (Quantity <= MinStock)
            {
                return "text-warning";
            }

            return "text-success";
        }
    }
}