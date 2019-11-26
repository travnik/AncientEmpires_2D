using System.Collections.Generic;

namespace Travnik.AncientEmpires
{
    public interface IUnitMovablePositioner
    {
        IEnumerable<MoveStep> CreateMovablePositions(IBaseUnit unit);
    }
}