using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToastManager : MonoSingleton<ToastManager>
{

    public void ShunWaste(string info)
    {
        UIManager.PutCambrian().ShunUIShiny("Toast", info);
    }
}
