using MerchantsAPI_p2.Endpoint_Filters;
using MerchantsAPI_p2.EndpointHandlers;

namespace MerchantsAPI_p2.Extensions
{
    public static class EndPointRouteBuilderExtensions
    {
        public static void RegisterMerchantsEndpoints(this IEndpointRouteBuilder endpointRouteBuilder) 
        {
            var merchantsEndpoints = endpointRouteBuilder.MapGroup("/merchants/v1");


            merchantsEndpoints.MapGet("", MerchantHandler.GetMerchantsAsync);

            merchantsEndpoints.MapGet("/{merchant_unique_id:guid}", MerchantHandler.GetAMerchantAsync).WithName("GetMerchant");

            merchantsEndpoints.MapPost("", MerchantHandler.PostMerchantAsync);

            merchantsEndpoints.MapPut("/{merchant_id:guid}/payment-method", MerchantHandler.PutMerchantUpdatePaymentAsync).
                                    AddEndpointFilter(new MerchantLockedFilter(new Guid("91d76269-0959-44ea-a1ba-5f9e3c83272d"))).
                                    AddEndpointFilter(new MerchantLockedFilter(new Guid("f6767a42-955e-403c-bd38-520f5f7af6ec")));

            merchantsEndpoints.MapDelete("/{merchant_id:guid}", MerchantHandler.DeleteMerchantAsync).
                                    AddEndpointFilter(new MerchantLockedFilter(new Guid("91d76269-0959-44ea-a1ba-5f9e3c83272d"))).
                                    AddEndpointFilter(new MerchantLockedFilter(new Guid("f6767a42-955e-403c-bd38-520f5f7af6ec")));

            merchantsEndpoints.MapDelete("", () => {
                throw new NotImplementedException();    
            });

            // For Testing purpose, comment merchantsEndpoints.MapGet("", MerchantHandler.GetMerchantsAsync)
            // when activate this testing endpoint
            // merchantsEndpoints.MapGet("/{merchant_unique_id:guid}", MerchantHandler.GetMerchantsAllFieldsTestingAsync);
        }
    }
}
