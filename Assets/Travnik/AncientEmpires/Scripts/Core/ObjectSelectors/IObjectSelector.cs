using UnityEngine;

namespace Travnik.AncientEmpires
{
    public interface IObjectSelector
    {
        ISelect Select(Vector3 position);
    }
}
