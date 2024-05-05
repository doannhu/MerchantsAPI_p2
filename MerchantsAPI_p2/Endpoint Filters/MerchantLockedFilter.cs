namespace MerchantsAPI_p2.Endpoint_Filters
{
    public class MerchantLockedFilter: IEndpointFilter
    {
        private Guid _id;

        public MerchantLockedFilter(Guid id)
        {
            _id = id;
        }
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context,
                                              EndpointFilterDelegate next)
        {
            Guid merchantId;
            if (context.HttpContext.Request.Method == "PUT")
            {
                merchantId = context.GetArgument<Guid>(3); // This is order of arguments in PutMerchantUpdatePaymentAsync()
                                                           // 0: Db context, 1: Mapper, 2: MerchantUpdatePayment,
                                                           // 3: Guid
            }
            else if (context.HttpContext.Request.Method == "DELETE")
            {
                merchantId= context.GetArgument<Guid>(1); // This is order of arguments in DeleteMerchantAsync() 0: Db context, 1: Guid
            }
            else
            {
                throw new NotSupportedException("This filter is not supported for this method");
            }

            // var blockedId = new Guid("91d76269-0959-44ea-a1ba-5f9e3c83272d");
            var blockedId = _id;
            if (merchantId == blockedId)
            {
                return TypedResults.Problem(new()
                {
                    Status = 400,
                    Title = "Not allow to be updated or removed",
                    Detail = "Default merchant"
                });
            }
            var result = await next.Invoke(context);
            return result;
        }
    }
}
