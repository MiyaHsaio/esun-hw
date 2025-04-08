using Models.Contracts.Requests;
using Models.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public interface IFavoriteProductService
    {
        Task<PaginationList<FavoriteProductResponse>> GetByFilter(FilterRequest request);
        Task<FavoriteProductResponse> GetById(int id);
        Task<FavoriteProductResponse> Create(CreateFavoriteProductRequest request);
        Task<FavoriteProductResponse> Update(int id, UpdateFavoriteProductRequest request);
        Task<object> Delete(int id);
    }

    public async Task<FavoriteProductResponse> GetById(int id)
        {
            var result = await (from likeList in _dbContext.LikeLists
                         join product in _dbContext.Products on likeList.ProductNo equals product.No
                         join user in _dbContext.Users on likeList.UserID equals user.UserID
                         where likeList.SN == id
                         select new FavoriteProductResponse
                         {
                             Id = likeList.SN,
                             Name = product.ProductName,
                             Account = likeList.Account,
                             TotalAmount = likeList.TotalAmount,
                             TotalFee = likeList.TotalFee,
                             Email = user.Email
                         }).FirstOrDefaultAsync();

            return result;
        }

        public async Task<FavoriteProductResponse> Create(CreateFavoriteProductRequest request)
        {
            var currentUserId = _userContextService.GetCurrentUserId();
            var product = await _dbContext.Products
                .FirstOrDefaultAsync(p => p.ProductName == request.Name);

            decimal totalAmount = product.Price * request.Quantity;
            decimal totalFee = totalAmount * product.FeeRate;

            var newLikeList = new LikeList
            {
                UserID = currentUserId,
                ProductNo = product.No,
                Quantity = request.Quantity,
                Account = request.Account,
                TotalAmount = totalAmount,
                TotalFee = totalFee
            };

            _dbContext.LikeLists.Add(newLikeList);
            await _dbContext.SaveChangesAsync();

            var user = await _dbContext.Users
                .FirstOrDefaultAsync(u => u.UserID == currentUserId);

            return new FavoriteProductResponse
            {
                Id = newLikeList.SN,
                Name = product.ProductName,
                Account = newLikeList.Account,
                TotalAmount = newLikeList.TotalAmount,
                TotalFee = newLikeList.TotalFee,
                Email = user.Email
            };
        }

        public async Task<FavoriteProductResponse> Update(int id, UpdateFavoriteProductRequest request)
        {
            var likeList = await _dbContext.LikeLists
                .FirstOrDefaultAsync(l => l.SN == id);
            var product = await _dbContext.Products
                .FirstOrDefaultAsync(p => p.ProductName == request.Name);

            likeList.ProductNo = product.No;
            likeList.Account = request.Account;
            likeList.Quantity = request.Quantity;

            likeList.TotalAmount = product.Price * request.Quantity;
            likeList.TotalFee = likeList.TotalAmount * product.FeeRate;

            await _dbContext.SaveChangesAsync();

            var user = await _dbContext.Users
                .FirstOrDefaultAsync(u => u.UserID == likeList.UserID);

            return new FavoriteProductResponse
            {
                Id = likeList.SN,
                Name = product.ProductName,
                Account = likeList.Account,
                TotalAmount = likeList.TotalAmount,
                TotalFee = likeList.TotalFee,
                Email = user.Email
            };
        }

        public async Task<object> Delete(int id)
        {
            var likeList = await _dbContext.LikeLists
                .FirstOrDefaultAsync(l => l.SN == id);

            _dbContext.LikeLists.Remove(likeList);
            await _dbContext.SaveChangesAsync();

            return new { Success = true };
        }
}