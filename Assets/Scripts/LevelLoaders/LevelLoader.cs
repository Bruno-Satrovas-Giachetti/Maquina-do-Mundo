using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public Animator poemFade;
    //public Animator transitionText;
    public float transitionTime = 1f;

    public TextMeshProUGUI poemText;

    //private void Awake()
    //{
    //    switch (StaticData.level)
    //    {
    //        case 1:
    //            poemText.text = "A máquina do mundo se entreabriu\r\n\r\nPara quem de a romper já se esquivava\r\n\r\ne só de o ter pensado se carpia.";
    //            break;

    //        case 2:
    //            poemText.text = "Abriu-se majestosa e circunspecta,\r\n\r\nsem emitir um som que fosse impuro\r\n\r\nnem um clarão maior que o tolerável.";
    //            break;

    //        case 3:
    //            poemText.text = "Se revelou ante a pesquisa ardente\r\n\r\nem que te consumiste... vê, contempla,\r\n\r\nabre teu peito para agasalhá-lo.";
    //            break;

    //        case 4:
    //            poemText.text = "Tudo se apresentou nesse relance\r\n\r\ne me chamou para seu reino augusto,\r\n\r\nafinal submetido à vista humana.";
    //            break;

    //        case 5:
    //            poemText.text = "Baixei os olhos, incurioso, lasso,\r\n\r\ndesdenhando colher a coisa oferta\r\n\r\nque se abria gratuita a meu engenho.";
    //            break;
    //    }
    //}

    public void LoadNextLevel(int polution)
    {
        StaticData.IncreaseLevel(1);
        StartCoroutine(SceneTransition(polution));
    }

    public void LoadGoodEnding()
    {
        SceneManager.LoadScene("GoodEnding");
    }


    public void LoadBadEnding()
    {
        SceneManager.LoadScene("BadEnding");
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        StaticData.ResetLevel();
        StartCoroutine(LoadMainMenuTransition());
    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene("FirstLevel");
    }

    public IEnumerator SceneTransition(int polution)
    {
        //poemText.alpha = 255f;
        switch (StaticData.level)
        {
            case 1:
                poemText.text = "A máquina do mundo se entreabriu\r\n\r\nPara quem de a romper já se esquivava\r\n\r\ne só de o ter pensado se carpia.";
                break;

            case 2:
                poemText.text = "Abriu-se majestosa e circunspecta,\r\n\r\nsem emitir um som que fosse impuro\r\n\r\nnem um clarão maior que o tolerável.";
                break;

            case 3:
                poemText.text = "Se revelou ante a pesquisa ardente\r\n\r\nem que te consumiste... vê, contempla,\r\n\r\nabre teu peito para agasalhá-lo.";
                break;

            case 4:
                poemText.text = "Tudo se apresentou nesse relance\r\n\r\ne me chamou para seu reino augusto,\r\n\r\nafinal submetido à vista humana.";
                break;

            case 5:
                poemText.text = "Baixei os olhos, incurioso, lasso,\r\n\r\ndesdenhando colher a coisa oferta\r\n\r\nque se abria gratuita a meu engenho.";
                break;
        }

        transition.SetTrigger("Start");
        poemFade.SetTrigger("StartPoem");

        //yield return new WaitForSeconds(2);


        //transition.SetTrigger("Start2");

        yield return new WaitForSeconds(transitionTime);

        if (polution < 10)
        {
            StaticData.IncreaseQuota(10);
            SceneManager.LoadScene("CleanFullBin");
            //Maquina Limpa, +10 meta, Carvão Cheio
        }

        else if (polution > 10 && polution <= 25)
        {
            StaticData.IncreaseQuota(25);
            SceneManager.LoadScene("CleanFullBin");
            //Maquina Limpa, +25 meta, Carvão Cheio
        }

        else if (polution > 25 && polution <= 50)
        {
            StaticData.IncreaseQuota(50);
            SceneManager.LoadScene("DirtyMediumBin");
            //Maquina Suja, +50 meta, Carvão Médio
        }

        else if (polution > 50 && polution <= 75)
        {
            StaticData.IncreaseQuota(75);
            SceneManager.LoadScene("DirtyMediumBin");
            //Maquina Suja, +75 meta, Carvão Médio
        }

        else if (polution > 75 && polution <= 100)
        {
            StaticData.IncreaseQuota(100);
            SceneManager.LoadScene("RustyEndingBin");
            //Maquina Podre, +100 meta, Carvão Acabando
        }

        else if (polution > 100)
        {
            StaticData.IncreaseQuota(150);
            SceneManager.LoadScene("RustyEmptyBin");
            //Maquina Podre, +150 meta, Carvão Acabou
        }
    }

    public IEnumerator LoadMainMenuTransition()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("MainMenu");
    }
}
