using Microsoft.AspNetCore.Mvc;

namespace Wba.Pe2.Mvc.Models
{
    public class CheckboxHelper
    {
        public bool IsSelected { get; set; }
        [HiddenInput]
        public long Id { get; set; }
        [HiddenInput]
        public string Text { get; set; }
    }
}
