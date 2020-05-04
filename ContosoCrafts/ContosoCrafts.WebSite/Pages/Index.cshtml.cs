using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public JsonFileProductService ProductService;
        public IEnumerable<Product> Products { get; private set; }

        //declaring to .Net that a service is required, JsonFileProductService
        //ILogger is a .Net service that allows for logging
        public IndexModel(ILogger<IndexModel> logger, 
            JsonFileProductService productService)
        {
            _logger = logger;
            //get an instance of your custom service
            ProductService = productService;
        }

        //event handler when the page is retrieved
        public void OnGet()
        {
            //
            //get the products
            Products = ProductService.GetProducts();
        }
    }
}
