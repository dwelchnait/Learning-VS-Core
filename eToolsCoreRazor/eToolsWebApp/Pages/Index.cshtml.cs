using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eToolsWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public string Message { get; set; } 
        [BindProperty]
        public string CourseNumber { get; set; }
        [BindProperty]
        public DateTime StartDate { get; set; }
        [BindProperty]
        public int Rating { get; set; }

        public void OnGet()
        {
            CourseNumber = "DMIT-2018";

        }
        public void OnPost()
        {
            Message = $"You stated <b>{CourseNumber}</b> on <b>{StartDate.ToShortDateString()}</b> and rated the difficulty as <b>{Rating}</b>/5.";
        }
    }
}
