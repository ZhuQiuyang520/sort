using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasteImagery : BeerZoologist<WasteImagery>
{

    public void ShunWaste(string info)
    {
        UIImagery.PutCambrian().ShunUIShiny("Waste", info);
    }
}
