using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnding : MonoBehaviour
{
    public GameObject interactIcon;
    public LevelLoader levelLoader;
    public GameManager gameManager;

    [SerializeField] private bool PlayerInZone;

    private void Awake()
    {
        PlayerInZone = false;
        interactIcon.SetActive(false);
    }

    private void Update()
    {
        if (PlayerInZone && Input.GetKeyDown(KeyCode.E))
        {
            interactIcon.SetActive(false);
            if (gameManager.energy >= gameManager.quota && StaticData.level < 5)
            {
                int polution = gameManager.polutionCounter;
                levelLoader.LoadNextLevel(polution);
            }

            else if (gameManager.energy >= gameManager.quota && StaticData.level == 5)
            {
                levelLoader.LoadGoodEnding();
            }

            else if (gameManager.energy < gameManager.quota && SceneManager.GetActiveScene().name == "RustyEmptyBin")
            {
                levelLoader.LoadBadEnding();
            }

            else if (gameManager.energy < gameManager.quota)
            {
                levelLoader.LoadGameOver();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInZone = true;
            interactIcon.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInZone = false;
            interactIcon.SetActive(false);
        }
    }
}
