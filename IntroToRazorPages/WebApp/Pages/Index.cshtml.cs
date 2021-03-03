using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        [BindProperty]
        public CourseOffering Course { get; set; }
        [BindProperty]
        public string CareerPath { get; set; }
        public string Message { get; set; }
        public void OnGet()
        {
            PopulateTitleData(new DateTime(2021, 09, 04));
        }
        public void OnPost()
        {
            PopulateTitleData(Course.TermStart);
            Message = $"I see your are in the career path of {CareerPath}.";
        }

        private void PopulateTitleData(DateTime start)
        {
            Course = new CourseOffering("DMIT-2018","Intermediate Application Development",start);
        }
    }

    public record CourseOffering(string Number, string Name, DateTime TermStart);
}
