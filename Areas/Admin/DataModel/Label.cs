using System.ComponentModel.DataAnnotations;

namespace Area_v1.Areas.Admin.DataModel
{
    public class Labels
    {
        [Key]
        public int LableId { get; set; }
        public string? LabelName { get; set; }
    }
}
