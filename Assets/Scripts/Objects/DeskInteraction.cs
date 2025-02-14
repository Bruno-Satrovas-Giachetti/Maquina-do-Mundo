using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskInteraction : MonoBehaviour
{
    public GameObject interactIcon;

    [SerializeField] private bool PlayerInZone;
    [SerializeField] private bool canInteract = true;

    [SerializeField] private LightSwitch lightStatus;

    public GameObject Book;
    public GameObject Page;

    public PageTurn pageTurn;

    private void Start()
    {
        PlayerInZone = false;
        interactIcon.SetActive(false);
        Book.SetActive(false);
        Page.SetActive(false);
    }

    private void Update()
    {
        if (PlayerInZone && canInteract && Input.GetKeyDown(KeyCode.E))
        {
            CheckIfLightIsOn();
            if (canInteract)
            {
                Book.SetActive(true);
                Page.SetActive(true);
                canInteract = false;

                interactIcon.SetActive(false);

                UnlockMouse();
            }
        }
    }

    private void CheckIfLightIsOn()
    {
        if (lightStatus.lightIsTurnedOff)
        {
            canInteract = false;
        }

        else
        {
            canInteract = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && lightStatus.lightIsTurnedOn)
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
            pageTurn.DeactivateAllPages();
            Book.SetActive(false);

            canInteract = true;
            LockMouse();
        }
    }

    private void UnlockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void LockMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ExitBook()
    {
        LockMouse();
        pageTurn.DeactivateAllPages();
        Book.SetActive(false);
    }

}
