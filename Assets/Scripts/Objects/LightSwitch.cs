using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public GameObject interactIcon;

    [SerializeField] private bool PlayerInZone;

    [SerializeField] private GameObject lightOn;
    [SerializeField] private GameObject lightOff;

    [SerializeField] private GameObject switchOn;
    [SerializeField] private GameObject switchOff;

    public bool lightIsTurnedOn;
    public bool lightIsTurnedOff;

    [SerializeField] AudioSource lightSwitchClick;

    private void Start()
    {
        PlayerInZone = false;    
        interactIcon.SetActive(false);


        lightOn.SetActive(true);
        lightOff.SetActive(false);

        switchOn.SetActive(true);
        switchOff.SetActive(false);


        lightIsTurnedOn = true;
        lightIsTurnedOff = false;
    }

    private void Update()
    {
        if (PlayerInZone && Input.GetKeyDown(KeyCode.E))
        {
            lightSwitchClick.Play();
            if (lightIsTurnedOn)
            {
                lightOn.SetActive(false);
                lightOff.SetActive(true);

                switchOn.SetActive(false);
                switchOff.SetActive(true);

                lightIsTurnedOn = false;
                lightIsTurnedOff = true;
            }

            else if (lightIsTurnedOff)
            {
                lightOff.SetActive(false);
                lightOn.SetActive(true);

                switchOff.SetActive(false);
                switchOn.SetActive(true);

                lightIsTurnedOn = true;
                lightIsTurnedOff = false;
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
}
