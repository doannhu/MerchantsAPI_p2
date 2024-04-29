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

            merchantsEndpoints.MapPut("/{merchant_id:guid}/payment-method", MerchantHandler.PutMerchantUpdatePaymentAsync);

            //For Testing purpose, comment merchantsEndpoints.MapGet("", MerchantHandler.GetMerchantsAsync)
            // when activate this testing endpoint
            //merchantsEndpoints.MapGet("/{merchant_unique_id:guid}", MerchantHandler.GetMerchantsAllFieldsTestingAsync);
        }
    }
}
