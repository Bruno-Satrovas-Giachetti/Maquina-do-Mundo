using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineStatusCheck : MonoBehaviour
{
    public GameObject interactIcon;

    public GameObject statusCheckText;

    [SerializeField] private bool PlayerInZone;

    [SerializeField] private bool canInteract = true;

    private void Start()
    {
        PlayerInZone = false;
        interactIcon.SetActive(false);
    }

    private void Update()
    {
        if (PlayerInZone && Input.GetKeyDown(KeyCode.E))
        {
            if (canInteract)
            {
                statusCheckText.SetActive(true);
                canInteract = false;

                interactIcon.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactIcon.SetActive(true);
            PlayerInZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInZone = false;
            interactIcon.SetActive(false);
            statusCheckText.SetActive(false);

            canInteract = true;
        }
    }
}
