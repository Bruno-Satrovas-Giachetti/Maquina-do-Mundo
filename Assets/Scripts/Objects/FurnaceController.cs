using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnaceController : MonoBehaviour
{
    [SerializeField] private Animator furnaceDoor = null;

    public bool IsOpen = false;
    public bool IsClosed = true;

    public CoalBinInteraction coalBinInteraction;
    public GameManager gameManager;

    public int energyWorth;

    public GameObject interactIcon;

    [SerializeField] private bool PlayerInZone;

    [SerializeField] private bool canInteract = false;

    [SerializeField] private AudioSource doorOpen;
    [SerializeField] private AudioSource doorClose;
    [SerializeField] private AudioSource coalBurning;

    private void Start()
    {
        PlayerInZone = false;
        interactIcon.SetActive(false);
    }

    private void Update()
    {

        if (coalBinInteraction.coalCounter > 0)
        {
            canInteract = true;
        }

        if (PlayerInZone && canInteract && Input.GetKeyDown(KeyCode.E))
        {
            coalBurning.Play();
            energyWorth = coalBinInteraction.coalCounter * 2;
            gameManager.AddEnergy(energyWorth);

            gameManager.CoalUsageCount(coalBinInteraction.coalCounter);

            coalBinInteraction.coalCounter -= coalBinInteraction.coalCounter;
            coalBinInteraction.EmptyInventory();

            canInteract = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInZone = true;

            if (IsClosed)
            {
                furnaceDoor.Play("FurnaceDoorOpen", 0, 0.0f);
                doorOpen.Play();
                IsOpen = true;
                IsClosed = false;
            }

            if (canInteract)
            {
                interactIcon.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && IsOpen)
        {
            PlayerInZone = false;
            interactIcon.SetActive(false);

            if (IsOpen)
            {
                furnaceDoor.Play("FurnaceDoorClose", 0, 0.0f);
                doorClose.Play();
                IsOpen = false;
                IsClosed = true;
            }

        }
    }

}
