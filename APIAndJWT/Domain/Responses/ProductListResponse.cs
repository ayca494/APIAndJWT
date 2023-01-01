using APIAndJWT.Domain.Models;

namespace APIAndJWT.Domain.Responses
{
    public class ProductListResponse : BaseResponse
    {
        public IEnumerable<Product> productList { get; set; }
        public ProductListResponse(bool success, string message,IEnumerable<Product> productList) : base(success, message)
        {
            this.productList= productList;
        }
        //başarılı olursa 
        public ProductListResponse(IEnumerable<Product> productList):this(true,string.Empty,productList)
        {

        }

        //başarısız olursa
        public ProductListResponse(string message):this(false,message,null)
        {

        }
    }
}
