using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowStatic : MonoBehaviour
{
    public int level;

    private void Update()
    {
        level = StaticData.level;
    }
}
