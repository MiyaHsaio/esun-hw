namespace Models.Contracts.Requests
{
    public class CreateFavoriteProductRequest
	{
	    public string Name { get; set; }
	    public decimal Price { get; set; }
	    public decimal FeeRate { get; set; }
	    public string Account { get; set; }
	    public int Quantity { get; set; }
	}
}

