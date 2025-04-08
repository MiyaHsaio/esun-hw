namespace Models.Contracts.Database
{
    public class LikeList
    {
        public int SN { get; set; }
        public string UserID { get; set; }
        public int ProductNo { get; set; }
        public int Quantity { get; set; }
        public string Account { get; set; }
        public decimal TotalFee { get; set; }
        public decimal TotalAmount { get; set; }
        
        public User User { get; set; }
        public Product Product { get; set; }
    }

    public class Product
    {
        public int No { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal FeeRate { get; set; }
        
        public ICollection<LikeList> LikeLists { get; set; }
    }
    
    public class User
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Account { get; set; }
        
        public ICollection<LikeList> LikeLists { get; set; }
    }
}