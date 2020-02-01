using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // reference
    public static GameManager instance;
    public static GameManager GM;
    public List<GameObject> allPlayers;

    // boolean
    public static bool instructionClicked = false;
    public static bool gameFinished = false;
    public static bool isPaused;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.PlayBGM(SoundManager.mainGameBGM);
        DialogManager.ShowInstruction();
        PauseGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (!instructionClicked)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                instructionClicked = true;
                SoundManager.ClickButtonSE();
                DialogManager.DestroyInstruction();

                // Next action
                CameraManager.StartZoomOut();
                SoundManager.ReadySE();
                DialogManager.ShowReady();
            }
        }

        if (DialogManager.readyFinished)
        {
            DialogManager.readyFinished = false;
            DialogManager.DestroyReady();

            // Next action
            SoundManager.GoSE();
            DialogManager.ShowGo();
            ResumeGame();
            Timer.StartTimer();
            OrderManager.StartOrder();
        }

        if (DialogManager.goFinished)
        {
            DialogManager.goFinished = false;
            DialogManager.DestroyGo();
        }

        if (Timer.isStart && Timer.isStop && !gameFinished)
        {
            gameFinished = true;
            Timer.StopTimer();

            // Next action
            SoundManager.TimesUpSE();
            DialogManager.ShowTimesUp();
            PauseGame();
            CanvasManager.ShowEndGamePanel();

            SoundManager.BGMSpeaker.Stop();
        }

        if (CanvasManager.canDestroyEndGamePanel && Input.GetKeyDown(KeyCode.Return))
        {
            CanvasManager.DestroyEndGamePanel();
        }
    }



    private void PauseGame()
    {
        Debug.Log("PauseGame()");
        DisableAllPlayers();
        DisableEnvironment();
    }
    private void ResumeGame()
    {
        Debug.Log("ResumeGame()");
        EnableAllPlayers();
        EnableEnvironment();
    }
    private void DisableAllPlayers()
    {
        Debug.Log("DisableAllPlayers()");
        foreach (GameObject player in allPlayers)
        {
            player.GetComponent<Player>().disablePlayer = true;
        }
    }
    private void EnableAllPlayers()
    {
        Debug.Log("EnableAllPlayers()");
        foreach (GameObject player in allPlayers)
        {
            player.GetComponent<Player>().disablePlayer = false;
        }
    }
    private void DisableEnvironment()
    {
        Debug.Log("DisableEnvironment()");
    }
    private void EnableEnvironment()
    {
        Debug.Log("EnableEnvironment()");
    }

}
