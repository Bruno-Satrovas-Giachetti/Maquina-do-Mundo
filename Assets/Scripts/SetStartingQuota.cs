using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartingQuota : MonoBehaviour
{
    public GameManager gameManager;

    private void Start()
    {
        gameManager.StartingQuota();
    }
}
