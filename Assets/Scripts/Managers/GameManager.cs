using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // reference
    public static GameManager instance;
    public static GameManager GM;
    public List<GameObject> allPlayers;

    // boolean
    public static bool gameFinished = false;
    public static bool playAgain = false;
    public static bool exit = false;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (playAgain)
        {
            CanvasManager.startMenu.SetActive(false);
            CanvasManager.modeMenu.SetActive(false);

            CameraManager.StartZoomOut();
            SoundManager.ReadySE();
            DialogManager.ShowReady();
        }
        else if (exit)
        {
            CanvasManager.startMenu.SetActive(true);
            CanvasManager.modeMenu.SetActive(false);
        }
        else
        {
            CanvasManager.startMenu.SetActive(true);
            CanvasManager.modeMenu.SetActive(false);
        }
        if (Player.isSinglePlayer && playAgain)
        {
            allPlayers[1].SetActive(false);
        }
        else
        {
            allPlayers[1].SetActive(true);
        }
        SoundManager.PlayBGM(SoundManager.mainGameBGM);
        PauseGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (EndGamePanel.canPlayAgain)
        {
            PlayAgain();
        }
        if (ComingSoonPanel.canExit)
        {
            Exit();
        }

        if (!DialogManager.instructionClicked)
        {
            if (InstructionPanel.clickedLast)
            {
                DialogManager.instructionClicked = true;
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


    private static void PlayAgain()
    {
        Debug.Log("PlayAgain()");
        EndGamePanel.canPlayAgain = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        Timer.isStart = false;
        Timer.isStop = true;
        gameFinished = false;

        playAgain = true;
        exit = false;
    }
    private static void Exit()
    {
        Debug.Log("Exit()");
        ComingSoonPanel.canExit = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        Timer.isStart = false;
        Timer.isStop = true;
        gameFinished = false;

        exit = true;
        playAgain = false;
    }
}
