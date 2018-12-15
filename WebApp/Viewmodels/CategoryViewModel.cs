using System.Collections.Generic;

namespace WebApp.Viewmodels
{
    public class CategoryViewModel
    {
        public string SelectedCategory { get; set; }
        public IEnumerable<string> Categories { get; set; }
    }
}
