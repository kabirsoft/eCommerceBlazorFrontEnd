﻿using eCommerceBlazorFrontEnd.Models;
using eCommerceWebApiBackEnd.Shared;

namespace eCommerceBlazorFrontEnd.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _http;

        public List<Category> Categories { get; set; } = new List<Category>();
        public CategoryService(HttpClient http)
        {
            _http = http;
        }

        public async Task GetAllCategories()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<Category>>>("api/category");
            if (response != null && response.Data != null)
            {
                Categories = response.Data;
            }
        }
    }
}
