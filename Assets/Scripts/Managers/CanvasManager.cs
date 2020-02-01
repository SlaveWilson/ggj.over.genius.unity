using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    // reference
    public static CanvasManager instance;
    public GameObject _canvas;
    public static GameObject canvasReference;

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
