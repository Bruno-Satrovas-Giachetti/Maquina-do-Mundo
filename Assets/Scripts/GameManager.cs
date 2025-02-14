using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float energy;
    public int polutionCounter;
    public float quota = 100; //trocar para ser constante entre níveis

    public float timeLeft;
    public bool timerOn = false;
    public TextMeshProUGUI timerText;

    public TextMeshProUGUI progressTracker;
    public GameObject exitTrigger, furnaceTrigger, coalBinTrigger, windowTrigger;

    public Propeller propeller;
    public WindowButton windowButton;
    public Animator windowAnimator = null;

    public FurnaceController furnaceController;
    public Animator furnaceAnimator = null;

    public bool leaveTextCheck;
    public GameObject canLeaveNowText;

    //correção imbecil
    public Camera canvasCamera;


    private void Start()
    {
        exitTrigger.SetActive(false);
        timerOn = true;

        furnaceTrigger.SetActive(true);
        coalBinTrigger.SetActive(true);
        windowTrigger.SetActive(true);

        canvasCamera.allowDynamicResolution = true;
        canvasCamera.allowDynamicResolution = false;
        quota = StaticData.quota;
        progressTracker.text = "Energia Total: 0 / " + quota;

        leaveTextCheck = false;
        canLeaveNowText.SetActive(false);
    }

    private void Update()
    {
        if (energy >= quota && !leaveTextCheck)
        {
            exitTrigger.SetActive (true);
            StartCoroutine(CanLeaveNowText());
        }

        if (timerOn)
        {
            if(timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                UpdateTimer(timeLeft);
            }
            else if(timeLeft <= 0 && energy >= quota)
            {
                timeLeft = 0;
                timerOn = false;
                timerText.text = "Meta atingida.";
                //timerText.color = Color.green;

                furnaceTrigger.SetActive(false);
                coalBinTrigger.SetActive(false);
                windowTrigger.SetActive(false);


                CloseWindow();
                CloseFurnace();
                exitTrigger.SetActive(true);
            }

            else if (timeLeft <= 0 && energy < quota)
            {
                timeLeft = 0;
                timerOn = false;
                timerText.text = "Meta não atingida.";
                //timerText.color += Color.red;

                furnaceTrigger.SetActive(false);
                coalBinTrigger.SetActive(false);
                windowTrigger.SetActive(false);

                CloseWindow();
                CloseFurnace();
                exitTrigger.SetActive(true);
            }
        }
    }

    public void AddEnergy(float numberToIncrease)
    {
        energy += numberToIncrease;
        progressTracker.text = "Energia Total: " + Mathf.Round(energy * 10f) / 10f + " / " + quota;
    }

    public void CoalUsageCount(int amountOfCoalUsed)
    {
        polutionCounter += amountOfCoalUsed;
    }

    public void UpdateTimer(float currentTime)
    {
        currentTime += 1;
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    public void CloseWindow()
    {
        if (windowButton.windowIsOpen)
        {
            windowAnimator.Play("WindowClose", 0, 0.0f);
            windowButton.windowIsOpen = false;
            windowButton.windowIsClosed = true;

            propeller.isOn = false;
        }
    }

    public void CloseFurnace()
    {
        if (furnaceController.IsOpen)
        {
            furnaceAnimator.Play("FurnaceDoorClose", 0, 0.0f);
            furnaceController.IsOpen = false;
            furnaceController.IsClosed = true;
        }
    }

    public void StartingQuota()
    {
        quota = 100;
        StaticData.quota = 100;
    }

    IEnumerator CanLeaveNowText()
    {
        canLeaveNowText.SetActive(true);

        yield return new WaitForSeconds(3);

        canLeaveNowText.SetActive(false);

        leaveTextCheck = true;
    }
}
