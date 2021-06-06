using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using OnlineBookingAggregatorApp.Infrastructure.Extensions;

namespace OnlineBookingAggregatorApp.Infrastructure.Pagination
{
    public class PagedResult<TDto> where TDto : class
    {
        public IList<TDto> Data {get; private set; }
        public int PageNumber {get; private set; }
        public int PageSize {get; private set; }
        public int TotalCount {get; private set; }
        public int TotalPages {get; private set; }

        private PagedResult(IList<TDto> data, int pageNumber, int pageSize, int totalCount, int totalPages)
        {
            Data = data;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalCount = totalCount;
            TotalPages = totalPages;
        }

        public static async Task<PagedResult<TDto>> From<TEntity>(IQueryable<TEntity> query, PagedRequest pagedRequest,
            Func<TEntity, TDto> fromDelegate) where TEntity : class
        {
            var filterFields = pagedRequest.FilterFields?.Split(',').ToArray() ?? new []{string.Empty};
            query = query.ApplyFilters(pagedRequest.Filter, filterFields);

            var itemsCount = await query.CountAsync();
            var totalPages = (int) Math.Ceiling((double) itemsCount / pagedRequest.PageSize);

            query = query.ApplySort(pagedRequest.OrderBy, pagedRequest.Ascending);
            query = query.ApplyPagination(pagedRequest.PageNumber, pagedRequest.PageSize);

            var result = await query
                .Select(x => fromDelegate.Invoke(x))
                .ToListAsync();

            return new PagedResult<TDto>(result, pagedRequest.PageNumber, pagedRequest.PageSize, itemsCount, totalPages);
        }
        
        public static PagedResult<TDto> From(IQueryable<TDto> query, PagedRequest pagedRequest) 
        {
            var filterFields = pagedRequest.FilterFields?.Split(',').ToArray() ?? new []{string.Empty};
            query = query.ApplyFilters(pagedRequest.Filter, filterFields);

            var itemsCount = query.Count();
            var totalPages = (int) Math.Ceiling((double) itemsCount / pagedRequest.PageSize);

            query = query.ApplySort(pagedRequest.OrderBy, pagedRequest.Ascending);
            query = query.ApplyPagination(pagedRequest.PageNumber, pagedRequest.PageSize);

            var result = query.ToList();

            return new PagedResult<TDto>(result, pagedRequest.PageNumber, pagedRequest.PageSize, itemsCount, totalPages);
        }
    }
}