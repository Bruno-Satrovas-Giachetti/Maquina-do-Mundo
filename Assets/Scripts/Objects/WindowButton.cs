using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class WindowButton : MonoBehaviour
{
    public GameObject interactIcon;

    [SerializeField] private bool PlayerInZone;

    public bool windowIsOpen = false;
    public bool windowIsClosed = true;

    [SerializeField] private Animator window = null;

    [SerializeField] private bool turbineIsOn;

    [SerializeField] Propeller propeller;

    public float generatedEnergy = 0.1f;

    public GameManager gameManager;

    [SerializeField] AudioSource windBlowing;
    [SerializeField] AudioSource buttonClicking;
    [SerializeField] AudioSource windowOpen;
    [SerializeField] AudioSource windowClose;

    private void Start()
    {
        PlayerInZone = false;
        interactIcon.SetActive(false);

        windowIsOpen = false;
        windowIsClosed = true;
    }

    private void Update()
    {
        if (PlayerInZone && Input.GetKeyDown(KeyCode.E))
        {
            if (windowIsClosed)
            {
                window.Play("WindowOpen", 0, 0.0f);
                windowIsOpen = true;
                windowIsClosed = false;

                propeller.isOn = true;

                windowOpen.Play();
                windBlowing.Play();
                StartCoroutine(EnergyConverter());
            }

            else if (windowIsOpen)
            {
                window.Play("WindowClose", 0, 0.0f);
                windowIsClosed = true;
                windowIsOpen = false;

                propeller.isOn = false;

                windowClose.Play();
                windBlowing.Stop();
                StopCoroutine(EnergyConverter());
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
        }
    }

    public IEnumerator EnergyConverter()
    {
        yield return new WaitForSeconds(2);

        if (!propeller.isOn)
        {
            yield break;
        }

        gameManager.AddEnergy(generatedEnergy);
        StartCoroutine(EnergyConverter());

    }
}
