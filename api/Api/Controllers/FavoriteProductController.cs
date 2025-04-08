
namespace Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class FavoriteProductController : BaseController
    {
        public IFavoriteProductService FavoriteProductService { get; set; }

        public FavoriteProductController(IFavoriteProductService favoriteProductService)
        {
            FavoriteProductService = favoriteProductService;
        }

        /// <summary>
        /// 取得喜好金融商品列表
        /// </summary>
        [SwaggerResponse((int)HttpStatusCode.OK, "成功取得列表", typeof(ResponseWrapper<PaginationList<FavoriteProductResponse>>))]
        [HttpPost("Filter")]
        public Task<IActionResult> GetAll([FromBody] FilterRequest request)
        {
            return ContextHandle(() => FavoriteProductService.GetByFilter(request));
        }

        /// <summary>
        /// 取得單筆喜好金融商品內容
        /// </summary>
        [SwaggerResponse((int)HttpStatusCode.OK, "成功取得商品內容", typeof(ResponseWrapper<FavoriteProductResponse>))]
        [HttpGet("{id}")]
        public Task<IActionResult> Get(int id)
        {
            return ContextHandle(() => FavoriteProductService.GetById(id));
        }

        /// <summary>
        /// 新增喜好金融商品
        /// </summary>
        [SwaggerResponse((int)HttpStatusCode.OK, "成功新增商品", typeof(ResponseWrapper<FavoriteProductResponse>))]
        [HttpPost]
        public Task<IActionResult> Create([FromBody] CreateFavoriteProductRequest request)
        {
            return ContextHandle(() => FavoriteProductService.Create(request));
        }

        /// <summary>
        /// 編輯喜好金融商品內容
        /// </summary>
        [SwaggerResponse((int)HttpStatusCode.OK, "成功更新商品", typeof(ResponseWrapper<FavoriteProductResponse>))]
        [HttpPut("{id}")]
        public Task<IActionResult> Update(int id, [FromBody] UpdateFavoriteProductRequest request)
        {
            return ContextHandle(() => FavoriteProductService.Update(id, request));
        }

        /// <summary>
        /// 刪除喜好金融商品內容
        /// </summary>
        [SwaggerResponse((int)HttpStatusCode.OK, "成功刪除商品", typeof(ResponseWrapper<object>))]
        [HttpDelete("{id}")]
        public Task<IActionResult> Delete(int id)
        {
            return ContextHandle(() => FavoriteProductService.Delete(id));
        }
    }
}