using UnityEngine;
using System.Collections;

namespace Assets.PoC_Code
{
    abstract class PointerTool
    {
        public abstract void Click(GameObject gameObject, Vector3 position, bool rightClick);

        public abstract void UnitClicked(Unit unit, bool rightClick);

        public abstract void TerrainClicked(Vector3 position, bool rightClick);
    }
}
