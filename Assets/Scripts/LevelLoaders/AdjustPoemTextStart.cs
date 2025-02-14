using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AdjustPoemTextStart : MonoBehaviour
{

    public TextMeshProUGUI poemText;

    private void Awake()
    {
        switch (StaticData.level + 1)
        {
            case 1:
                poemText.text = "A m�quina do mundo se entreabriu\r\n\r\nPara quem de a romper j� se esquivava\r\n\r\ne s� de o ter pensado se carpia.";
                break;

            case 2:
                poemText.text = "Abriu-se majestosa e circunspecta,\r\n\r\nsem emitir um som que fosse impuro\r\n\r\nnem um clar�o maior que o toler�vel.";
                break;

            case 3:
                poemText.text = "Se revelou ante a pesquisa ardente\r\n\r\nem que te consumiste... v�, contempla,\r\n\r\nabre teu peito para agasalh�-lo.";
                break;

            case 4:
                poemText.text = "Tudo se apresentou nesse relance\r\n\r\ne me chamou para seu reino augusto,\r\n\r\nafinal submetido � vista humana.";
                break;

            case 5:
                poemText.text = "Baixei os olhos, incurioso, lasso,\r\n\r\ndesdenhando colher a coisa oferta\r\n\r\nque se abria gratuita a meu engenho.";
                break;
        }
    }
}
