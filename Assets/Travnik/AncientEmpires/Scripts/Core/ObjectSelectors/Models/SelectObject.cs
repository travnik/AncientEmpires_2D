namespace Travnik.AncientEmpires
{
    public class SelectObject : ISelect
    {
        public IMapCell MapCell { get; set; }
        public IBaseUnit Unit { get; set; }
    }
}
