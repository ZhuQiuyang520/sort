using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PierceWine
{
    public static string InvadeUpSea(double a)
    {
        return Math.Round(a, CommonExcite.EnsueDigits).ToString();
    }
    public static string InvadeUpSea(double a, int digits)
    {
        return Math.Round(a, digits).ToString();
    }

    public static double Ensue(double a)
    {
        return Math.Round(a, CommonExcite.EnsueDigits);
    }

}
