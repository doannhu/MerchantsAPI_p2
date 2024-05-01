using AutoMapper;
using MerchantsAPI.DbContexts;
using MerchantsAPI.DTOs;
using MerchantsAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.Extensions.Caching.Memory;

namespace MerchantsAPI_p2.EndpointHandlers
{
    public static class MerchantHandler
    {
        /*
        public static async Task<Results<NotFound, Ok<IEnumerable<MerchantDto>>>>
            GetMerchantsAsync(MerchantDbContext merchantDbContext,
                              ClaimsPrincipal claimsPrincipal,
                              IMapper mapper,
                              [FromQuery] string? name)
        {
            Console.WriteLine($"User authenticated? {claimsPrincipal.Identity?.IsAuthenticated}");
            return TypedResults.Ok(mapper.Map<IEnumerable<MerchantDto>>(await merchantDbContext.Merchants.
                Where(m => name == null || m.Name.Contains(name)).ToListAsync()));
        }
        */


        public static async Task<Results<NotFound, Ok<MerchantDto>>> GetAMerchantAsync(MerchantDbContext merchantDbContext,
                                                                               IMapper mapper,
                                                                               Guid merchant_unique_id)
        {
            var merchantEntity = await merchantDbContext.Merchants.FirstOrDefaultAsync(mer => mer.Id == merchant_unique_id);
            if (merchantEntity == null)
            {
                TypedResults.NotFound();
            }
            return TypedResults.Ok(mapper.Map<MerchantDto>(merchantEntity));
        }

        public static async Task<Results<NotFound, Created<MerchantDto>>> PostMerchantAsync(MerchantDbContext merchantDbContext,
                                                                                        IMapper mapper,
                                                                                        MerchantForCreationDto merchantForCreationDto,
                                                                                        LinkGenerator linkGenerator,
                                                                                        HttpContext httpContext)
        {
            var merchantEntity = mapper.Map<Merchant>(merchantForCreationDto);
            merchantDbContext.Add(merchantEntity);
            await merchantDbContext.SaveChangesAsync();
            var merchantToReturn = mapper.Map<MerchantDto>(merchantEntity);

            var linkToMerchant = linkGenerator.GetUriByName(httpContext, "GetMerchant", new { merchantId = merchantToReturn.Id });
            return TypedResults.Created(linkToMerchant, merchantToReturn);
        }

        public static async Task<Results<NotFound, NoContent>> PutMerchantUpdatePaymentAsync(MerchantDbContext merchantDbContext,
                                                                         IMapper mapper,
                                                                         MerchantForUpdatePaymentDto merchantForUpdatePaymentDto,
                                                                         Guid merchant_id)
        {
            var merchantEntity = await merchantDbContext.Merchants.FirstOrDefaultAsync(mer => mer.Id == merchant_id);
            if (merchantEntity == null)
            {
                TypedResults.NotFound();
            }
            mapper.Map(merchantForUpdatePaymentDto, merchantEntity);
            await merchantDbContext.SaveChangesAsync();

            return TypedResults.NoContent();
        }

        // For Testing purposes
        public static async Task<Results<NotFound, Ok<Merchant>>> GetMerchantsAllFieldsTestingAsync(MerchantDbContext merchantDbContext,
                                                                                                    Guid merchant_unique_id)
        {
            var merchantEntity = await merchantDbContext.Merchants.FirstOrDefaultAsync(mer => mer.Id == merchant_unique_id);
            if (merchantEntity == null)
            {
                TypedResults.NotFound();
            }
            return TypedResults.Ok(merchantEntity);
        }

        // Add cache memory
        public static async Task<Results<NotFound, Ok<IEnumerable<MerchantDto>>>>
            GetMerchantsAsync(MerchantDbContext merchantDbContext,
                              ClaimsPrincipal claimsPrincipal,
                              IMapper mapper,
                              IMemoryCache memoryCache,
                              [FromQuery] string? name)
        {
            Console.WriteLine($"User authenticated? {claimsPrincipal.Identity?.IsAuthenticated}");
            
            // Check if data is already in cache
            if (memoryCache.TryGetValue("MerchantsData", out IEnumerable<MerchantDto>? cachedMerchants))
            {
                Console.WriteLine("Data retrieved from cache");
                return TypedResults.Ok(cachedMerchants);
            }

            // Data not found in cache, fetch from database
            var merchants = await merchantDbContext.Merchants
                .Where(m => name == null || m.Name.Contains(name))
                .ToListAsync();

            var merchantsDto = mapper.Map<IEnumerable<MerchantDto>>(merchants);

            // Cache the fetched data
            Console.WriteLine("Creating cache");

            memoryCache.Set<IEnumerable<MerchantDto>>("MerchantsData",merchantsDto);

            return TypedResults.Ok(merchantsDto);
            

        }

    }

}
