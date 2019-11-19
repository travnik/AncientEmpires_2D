using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Travnik.AncientEmpires
{
    public interface IObjectSelector
    {
        ISelect Select(Vector3 position);
    }
}
