using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadFinalBadScreen : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(LoadBadEndingScreen());
    }

    public IEnumerator LoadBadEndingScreen()
    {
        yield return new WaitForSeconds(8);
        SceneManager.LoadScene("BadEndingScreen");
    }
}
