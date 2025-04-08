namespace Models.Contracts.Responses
{
    public class FavoriteProductResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Account { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalFee { get; set; }
        public string Email { get; set; }
    }
}
