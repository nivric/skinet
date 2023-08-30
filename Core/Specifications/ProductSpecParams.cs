namespace Core.Specifications
{
    public class ProductSpecParams
    {
        public const int MaxPageSize = 50;

        public string Sort { get; set; }

        public int? BrandId { get; set; }

        public int? TypeId { get; set; }

        public int PageIndex { get; set; } = 1;

        private int _pageSize { get; set; } = 6;

        private string _search;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > 50 || value < 1 ? 50 : value;
        }

        public string Search
        {
            get => _search;
            set => _search = value.ToLower();
        }

       
    }
}
