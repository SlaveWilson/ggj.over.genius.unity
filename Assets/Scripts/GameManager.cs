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
                DialogManager.DestroyInstruction();

                // Next action
                CameraManager.StartZoomOut();
                DialogManager.ShowReady();
            }
        }

        if (DialogManager.readyFinished)
        {
            DialogManager.readyFinished = false;
            DialogManager.DestroyReady();

            // Next action
            DialogManager.ShowGo();
            ResumeGame();
            Timer.StartTimer();
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
            SoundManager.TimesUp();

            // Next action
            DialogManager.ShowTimesUp();
            PauseGame();
            CanvasManager.ShowEndGamePanel();
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
