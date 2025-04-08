namespace Models.Contracts.Requests
{
    public class FilterRequest
    {
        [FieldDesc("目前在第幾頁")]
        public int PageIndex { get; set; }
        [FieldDesc("頁面顯示數量")]
        public int PageSize { get; set; }
        [FieldDesc("搜尋項目(多數)")]
        public List<FilterItem> FilterItems { get; set; }
        [FieldDesc("排序名稱")]
        public string SortName { get; set; }
        [FieldDesc("排序方式")]
        public bool SortByAsc { get; set; }
    }

    public class FilterItem
    {
        [FieldDesc("搜尋欄位名稱")]
        public string Name { get; set; }
        [FieldDesc("搜尋內容")]
        public string Value { get; set; }
    }
}