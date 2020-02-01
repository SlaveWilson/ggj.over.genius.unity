using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    // reference
    public static CanvasManager instance;
    public GameObject _canvas;
    public static GameObject canvasReference;


    public static GameObject startMenu;
    public static GameObject modeMenu;

    // Inspector elements
    public GameObject _endGamePanel;
    public static GameObject endGamePanelReference;

    // Instantiated
    private static GameObject endGamePanel;

    // boolean
    public static bool canDestroyEndGamePanel = false;

    private void Awake()
    {
        instance = this;
        canvasReference = _canvas;
        endGamePanelReference = _endGamePanel;


        startMenu = canvasReference.transform.Find("StartMenu").gameObject;
        modeMenu = canvasReference.transform.Find("ModeMenu").gameObject;


        modeMenu.transform.Find("Single").GetComponent<Button>().onClick.AddListener(() => DialogManager.ShowInstruction());
        modeMenu.transform.Find("Duo").GetComponent<Button>().onClick.AddListener(() => DialogManager.ShowInstruction());
    }

    public static void ShowEndGamePanel()
    {
        Debug.Log("ShowEndGamePanel()");
        instance.StartCoroutine(EndGamePanelIE());
    }
    static IEnumerator EndGamePanelIE()
    {
        Debug.Log("EndGamePanelIE()");
        yield return new WaitForSeconds(2f);
        endGamePanel = Instantiate(endGamePanelReference, canvasReference.transform);
        yield return new WaitForSeconds(2f);
        canDestroyEndGamePanel = true;
    }
    public static void DestroyEndGamePanel()
    {
        Debug.Log("DestroyEndGamePanel()");
        Destroy(endGamePanel);
    }
}
