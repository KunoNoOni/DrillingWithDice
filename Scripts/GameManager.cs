using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private MusicManager mm;
    private SoundManager sm;

    public GameObject diceTray;
    public GameObject resultDieTray;
    public GameObject drillingPanel;
    public GameObject processingPanel;
    public GameObject endOfDayButton;
    public GameObject rerollButton;
    public GameObject rollResultButton;
    public Text dayTextField;
    public Text moneyTextField;
    public Text depthTextField;

    private int day = 1;
    private int money = 1000000;
    private int depth = 0;
    private int newDepth = 0;
    private int amountFromProcessing = 0;

    private bool isThereEnoughMoney = true;
    private bool isResultGood = false;
    
    private enum GamePhase
    {
        Drilling,
        Processing,
        Reset
    }

    GamePhase gamePhase;

    private void Awake()
    {
        mm = GameObject.Find("MusicManager").GetComponent<MusicManager>();
        sm = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    void Start()
    {
        if (mm.music.Length > 0)
        {
            mm.PlaySound(mm.music[1]);
        }
        gamePhase = GamePhase.Drilling;
        SetEndOfDayButtonText("End Drilling Phase");
        SetDayText(day);
        SetMoneyText(money);
        SetDepthText(depth);
        GetComponent<EndOfDayButton>().SetButtonDisableStatus(false);
        resultDieTray.GetComponent<RollResultDieButton>().SetButtonDisableStatus(false);
        drillingPanel.GetComponent<DrillingPanel>().EnableDisableDiceBoxes();
        processingPanel.GetComponent<ProcessingPanel>().DisableProcessingDiceBoxes();
        DestroyAllDiceInDiceTray();
        SpawnNewDiceInDiceTray();
    }

    private void SetEndOfDayButtonText(string text)
    {
        GetComponent<EndOfDayButton>().SetText(text);
    }

    public void ProcessRerollButton()
    {
        sm.PlaySound(sm.sounds[0]);
        GetComponent<RerollButton>().RerollDiceInDiceTray(diceTray);
        sm.PlaySound(sm.sounds[1]);
        GetComponent<RerollButton>().SetButtonDisableStatus(false);
    }

    public void ProcessResultDieButton()
    {
        sm.PlaySound(sm.sounds[0]);
        isResultGood = resultDieTray.GetComponent<RollResultDieButton>().RandomizeResultDie();
        sm.PlaySound(sm.sounds[1]);
        resultDieTray.GetComponent<RollResultDieButton>().SetButtonDisableStatus(false);
        Debug.Log("Result is " + isResultGood);
        Debug.Log("gamePhase is " + gamePhase.ToString());
        if (isResultGood && gamePhase == GamePhase.Drilling)
        {
            DestroyAllDiceInDiceTray();
            newDepth = drillingPanel.GetComponent<DrillingPanel>().GetDepth();
            money -= (newDepth * 1000);
            SetMoneyText(money);
            depth += newDepth;
            SetDepthText(depth);
            drillingPanel.GetComponent<DrillingPanel>().DestroyAllChildren();
        }
        else if (!isResultGood && gamePhase == GamePhase.Drilling)
        {
            DestroyAllDiceInDiceTray();
            SetEndOfDayButtonText("End Of Day");
            gamePhase = GamePhase.Reset;
            money -= 250000;
            SetMoneyText(money);
            drillingPanel.GetComponent<DrillingPanel>().DestroyAllChildren();
        }
        else if (isResultGood && gamePhase == GamePhase.Processing)
        {
            DestroyAllDiceInDiceTray();
            SetEndOfDayButtonText("End of Day");
            gamePhase = GamePhase.Reset;
            amountFromProcessing = processingPanel.GetComponent<ProcessingPanel>().GetTotalFromDice();
            money += (amountFromProcessing * 25000);
            SetMoneyText(money);
            processingPanel.GetComponent<ProcessingPanel>().DestroyAllChildren();
        }
        else if(!isResultGood && gamePhase == GamePhase.Processing)
        {
            DestroyAllDiceInDiceTray();
            SetEndOfDayButtonText("End Of Day");
            gamePhase = GamePhase.Reset;
            money -= 200000;
            SetMoneyText(money);
            processingPanel.GetComponent<ProcessingPanel>().DestroyAllChildren();
        }
        GetComponent<EndOfDayButton>().SetButtonDisableStatus(true);
    }

    public void ProcessEndOfDayButton()
    {
        Debug.Log("Processing Phase button...");
        sm.PlaySound(sm.sounds[0]);
        if (gamePhase == GamePhase.Drilling)
        {
            SetEndOfDayButtonText("End Processing Phase");
            GetComponent<EndOfDayButton>().SetButtonDisableStatus(false);
            gamePhase = GamePhase.Processing;
            drillingPanel.GetComponent<DrillingPanel>().DisableDiceBoxesForProcessing();
            processingPanel.GetComponent<ProcessingPanel>().EnableProcessingDiceBoxes();
        }
        else if (gamePhase == GamePhase.Reset)
        {
            if (isResultGood)
            {
                day++;
            }
            else
            {
                day += 2;
            }
            SetDayText(day);
            SetEndOfDayButtonText("Drilling Phase");
            GetComponent<EndOfDayButton>().SetButtonDisableStatus(false);
            gamePhase = GamePhase.Drilling;
            drillingPanel.GetComponent<DrillingPanel>().EnableDiceBoxesForProcessing();
            processingPanel.GetComponent<ProcessingPanel>().DisableProcessingDiceBoxes();
            CheckMoneySituation();
            CheckForWin();
            CheckForLose();
        }

        ResetRerollButton();
        ResetResultDieButton();
        SpawnNewDiceInDiceTray();
        drillingPanel.GetComponent<DrillingPanel>().EnableDisableDiceBoxes();
        sm.PlaySound(sm.sounds[1]);
    }

    private void ResetRerollButton()
    {
        Debug.Log("ResetRerollButton() running...");
        GetComponent<RerollButton>().SetButtonDisableStatus(true);
    }

    private void ResetResultDieButton()
    {
        Debug.Log("ResetResultDieButton() running...");
        //resultDieTray.GetComponent<RollResultDieButton>().SetButtonDisableStatus(false);
        resultDieTray.GetComponent<RollResultDieButton>().DestroyAllChildren();
    }

    private void DestroyAllDiceInDiceTray()
    {
        Debug.Log("DestroyAllDiceInDiceTray() running...");
        diceTray.GetComponentInChildren<DiceTray>().DestroyAllChildren();
    }

    private void SetDayText(int value)
    {
        dayTextField.text = "Day: " + value;
    }

    private void SetMoneyText(int value)
    {
        moneyTextField.text = "Money: " + value;
    }

    private void SetDepthText(int value)
    {
        depthTextField.text = "Depth: " + value + "m";
    }

    private void CheckMoneySituation()
    {
        if (gamePhase == GamePhase.Drilling && (money < 300000 && money >= 200000))
        {
            drillingPanel.GetComponent<DrillingPanel>().DisableDepthBoxes("300"); 
        }
        else if (gamePhase == GamePhase.Drilling && money >= 300000)
        {
            drillingPanel.GetComponent<DrillingPanel>().EnableDepthBoxes("300");
        }

        if (gamePhase == GamePhase.Drilling && money < 200000)
        {
            drillingPanel.GetComponent<DrillingPanel>().DisableDepthBoxes("200");
        }
        else if (gamePhase == GamePhase.Drilling && (money >= 200000 && money < 300000))
        {
            drillingPanel.GetComponent<DrillingPanel>().EnableDepthBoxes("200");
        }

        if (gamePhase == GamePhase.Drilling && money < 100000)
        {
            isThereEnoughMoney = false;
        }
    }

    private void CheckForWin()
    {
        if (depth >= 3500)
        {
            Debug.Log("You Win!");
            SceneManager.LoadScene(3);
        }
    }

    private void CheckForLose()
    {
        if ((day >= 31 && depth < 3500) || !isThereEnoughMoney)
        {
            SceneManager.LoadScene(4);
        }
    }

    private void SpawnNewDiceInDiceTray()
    {
        Debug.Log("SpawnNewDiceInDiceTray() running...");
        diceTray.GetComponent<DiceTray>().RandomizeDiceTray(false);
    }
}

