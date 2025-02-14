using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoalBinInteraction : MonoBehaviour
{
    public GameObject interactIcon;

    [SerializeField] private bool PlayerInZone;

    [SerializeField] private bool canInteract = true;

    public GameObject[] CoalInventory;
    public int coalCounter;

    private void Start()
    {
        PlayerInZone = false;
        interactIcon.SetActive(false);

        coalCounter = 0;
    }

    private void Update()
    {
        if (coalCounter < 5)
        {
            canInteract = true;
        }

        if (PlayerInZone && Input.GetKeyDown(KeyCode.E) && canInteract)
        {
            if (coalCounter < 4)
            {
                coalCounter++;
                CoalInventory[coalCounter-1].SetActive(true);
            }

            else if (coalCounter == 4)
            {
                coalCounter++;
                CoalInventory[coalCounter - 1].SetActive(true);
                interactIcon.SetActive(false);
                canInteract = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInZone = true;

            if (canInteract)
            {
                interactIcon.SetActive(true);
            }
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

    public void EmptyInventory()
    {
        CoalInventory[0].SetActive(false);
        CoalInventory[1].SetActive(false);
        CoalInventory[2].SetActive(false);
        CoalInventory[3].SetActive(false);
        CoalInventory[4].SetActive(false);
    }
}
