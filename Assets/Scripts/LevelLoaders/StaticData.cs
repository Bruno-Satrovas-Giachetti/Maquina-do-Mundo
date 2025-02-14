using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticData : MonoBehaviour
{
    public static int quota = 100;
    public static int polution;
    public static int level = 1;

    private void Start()
    {
        quota = 100;
    }

    public static void IncreaseQuota(int value)
    {
        quota += value;
    }

    public static void IncreasePolution(int value)
    {
        polution += value;
    }

    public static void IncreaseLevel(int value)
    {
        level += value;
    }

    public static void ResetLevel()
    {
        level = 1;
    }
}
