using Discont.Grpc.Data;
using Discont.Grpc.Models;
using Discont.Grpc.Protos;
using Grpc.Core;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Discont.Grpc.Services;

public class DiscountService(DiscountContext dbContext, ILogger<DiscountService> logger) : DiscountProtoSevice.DiscountProtoSeviceBase
{
    public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
    {
        try
        {

            var coupon = await dbContext.Coupons.FirstOrDefaultAsync(x => x.ProductName == request.ProductName);
            if (coupon is null)
                coupon = new Coupon { ProductName = "No Coupon", Amount = 0, Description = "No Coupon" };

            logger.LogInformation("GetDiscount {ProductName}", coupon.ProductName);
            var couponModel = coupon.Adapt<CouponModel>();
            return couponModel;
        }
        catch (Exception e) {
            logger.LogError("LogError {ProductName}", e.Message);

            return null;
        }
    }

    public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
    {

        var coupon = request.Coupon.Adapt<Coupon>();
        if (coupon is null)
            throw new RpcException(new Status(StatusCode.InvalidArgument, "invalid request object"));
               
        dbContext.Coupons.Add(coupon);
        await dbContext.SaveChangesAsync();
        logger.LogInformation("CreateDiscount Successfuly {ProductName}", coupon.ProductName);
        var couponModel = coupon?.Adapt<CouponModel>();
        return couponModel;
    }


    public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
    {
        var coupon = request.Coupon.Adapt<Coupon>();
        if (coupon is null)
            throw new RpcException(new Status(StatusCode.InvalidArgument, "invalid request object"));

        dbContext.Coupons.Update(coupon);
        await dbContext.SaveChangesAsync();
        logger.LogInformation("UpdateDiscount Successfuly {ProductName}", coupon.ProductName);
        var couponModel = coupon?.Adapt<CouponModel>();
        return couponModel;
    }


    public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
    {
        var coupon = await dbContext.Coupons.FirstOrDefaultAsync(x => x.ProductName == request.ProductName);
        if (coupon is null)
            throw new RpcException(new Status(StatusCode.NotFound, "Not Delete object"));
        dbContext.Coupons.Remove(coupon);
        await dbContext.SaveChangesAsync();
        logger.LogInformation("DeleteDiscount Successfuly {ProductName}", coupon.ProductName);

        return new DeleteDiscountResponse { Success = true };

    }
}
