using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadFinalGoodScreen : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(LoadGoodEndingScreen());
    }

    public IEnumerator LoadGoodEndingScreen()
    {
        yield return new WaitForSeconds(8);
        SceneManager.LoadScene("GoodEndingScreen");
    }
}
