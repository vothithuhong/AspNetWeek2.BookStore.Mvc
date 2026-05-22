namespace AspNetWeek2.BookStore.Mvc.ViewModels;

public class BookDetailViewModel
{
    public int Id { get; set; }

    public string Sku { get; set; } = "";

    public string Isbn { get; set; } = "";

    public string Title { get; set; } = "";

    public string Author { get; set; } = "";

    public string Category { get; set; } = "";

    public string Supplier { get; set; } = "";

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public int MinStock { get; set; }

    public DateTime LastUpdatedAt { get; set; }

    public string PriceText => $"{Price:N0} VND";

    public decimal InventoryValue => Price * Quantity;

    public string InventoryValueText => $"{InventoryValue:N0} VND";

    public string LastUpdatedText =>
        LastUpdatedAt.ToString("dd/MM/yyyy HH:mm");

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
                return "Cần nhập thêm";
            }

            return "Còn hàng";
        }
    }

    public string ReorderSuggestion
    {
        get
        {
            if (Quantity <= 0)
            {
                return "Cần nhập sách ngay.";
            }

            if (Quantity <= MinStock)
            {
                return "Nên nhập thêm sách.";
            }

            return "Tồn kho ổn định.";
        }
    }
}