using System.Reflection.Emit;
using Area_v1.Models;

namespace Area_v1.ViewModel
{
    public class HomeVM
    {
        public IEnumerable<LookUp>? LookUp { get; set; }
        public IEnumerable<LookUpLebel>? LookUpLebel { get; set; }
    }
}
