using Microsoft.AspNetCore.Http;
using System;
using System.Text.Json;

namespace API.Infrastructure.Headers
{
      public  static class HttpExtensions
    {

        public static void AddPaginationHeader(this HttpResponse response,int currentPage,int itemsPerPage,int totalItems)  {
            var totalPages = (int) Math.Ceiling(totalItems/(double) itemsPerPage);
            var paginationHeader = new PaginationHeader(currentPage,itemsPerPage,totalItems,totalPages);

            var options = new JsonSerializerOptions{
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            
            response.Headers.Add("Pagination",JsonSerializer.Serialize(paginationHeader,options));
            response.Headers.Add("Access-Control-Expose-Headers","Pagination");

        }
    }

    internal class PaginationHeader
    {
        private int _currentPage;
        private int _itemsPerPage;
        private int _totalItems;
        private int _totalPages;

        public PaginationHeader(int currentPage, int itemsPerPage, int totalItems, int totalPages)
        {
            _currentPage = currentPage;
            _itemsPerPage = itemsPerPage;
            _totalItems = totalItems;
            _totalPages = totalPages;
        }
    }
}