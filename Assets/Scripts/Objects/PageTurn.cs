using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageTurn : MonoBehaviour
{
    public GameObject[] page;

    public void LoadPage1()
    {
        page[0].SetActive(true);
        page[1].SetActive(false);
    }

    public void LoadPage2()
    {
        page[1].SetActive(true);
        page[0].SetActive(false);
        page[2].SetActive(false);
    }

    public void LoadPage3()
    {
        page[2].SetActive(true);
        page[1].SetActive(false);
        page[3].SetActive(false);
    }

    public void LoadPage4()
    {
        page[3].SetActive(true);
        page[2].SetActive(false);
        page[4].SetActive(false);
    }

    public void LoadPage5()
    {
        page[4].SetActive(true);
        page[3].SetActive(false);
    }

    public void DeactivateAllPages()
    {
        page[0].SetActive(false);
        page[1].SetActive(false);
        page[2].SetActive(false);
        page[3].SetActive(false);
        page[4].SetActive(false);
    }
}
