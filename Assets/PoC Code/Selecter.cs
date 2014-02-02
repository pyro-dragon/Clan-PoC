using UnityEngine;
using System.Collections;

namespace Assets.PoC_Code
{
    class Selecter : PointerTool
    {
        Unit selectedUnit;
        GameObject indicator;


        public Selecter()
        {
            selectedUnit = null;
            //indicator = GameObject.Instantiate(Resources.Load("IndicatorPrefab")) as GameObject;
            //selectIndicator = GameObject.Instantiate(indicatePrefab, selectedUnit.transform.position, Quaternion.identity) as GameObject;
        }

        public override void Click(GameObject gameObject, Vector3 position, bool righClick);

        public override void UnitClicked(Unit unit, bool righClick)
        {
            // Remove current selection
            Deselect();

            // Set the selected object
            selectedUnit = unit;

            // Create a new indicator
            indicator = GameObject.Instantiate(Resources.Load("IndicatorPrefab")) as GameObject;

            // Set the indicator as a member of the selected unit
            indicator.transform.parent = selectedUnit.transform;
        }

        public override void TerrainClicked(Vector3 position, bool righClick)
        {
            if (righClick)
                Deselect();
            else
            { 
                
            }
        }

        void Deselect()
        {
            // Get rid of the indicator
            GameObject.Destroy(indicator);

            selectedUnit = null;
        }
    }
}
