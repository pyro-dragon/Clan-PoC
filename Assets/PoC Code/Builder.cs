using UnityEngine;
using System.Collections;

namespace Assets.PoC_Code
{
    class Builder : PointerTool
    {
        public Builder()
        {

        }

        virtual void Click(GameObject gameObject, Vector3 position);

        virtual void UnitClicked(Unit unit);

        virtual void TerrainClicked(Vector3 position);
    }
}
