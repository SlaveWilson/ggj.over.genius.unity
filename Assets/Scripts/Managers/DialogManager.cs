using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    // reference
    public static DialogManager instance;
    public GameObject _canvas;
    public static GameObject canvasReference;

    // Inspector elements
    public GameObject _instructionPanel;
    public static GameObject instructionPanelReference;
    public GameObject _readyPanel;
    public static GameObject readyPanelReference;
    public GameObject _goPanel;
    public static GameObject goPanelReference;
    public GameObject _timesUpPanel;
    public static GameObject timesUpPanelReference;

    // Instantiated
    private static GameObject instructionPanel;
    private static GameObject readyPanel;
    private static GameObject goPanel;
    private static GameObject timesUpPanel;


    // boolean
    public static bool readyFinished = false;
    public static bool goFinished = false;

    private void Awake()
    {
        instance = this;
        canvasReference = _canvas;
        instructionPanelReference = _instructionPanel;
        readyPanelReference = _readyPanel;
        goPanelReference = _goPanel;
        timesUpPanelReference = _timesUpPanel;
    }

    public static void ShowInstruction()
    {
        Debug.Log("ShowInstruction()");
        instructionPanel = Instantiate(instructionPanelReference, canvasReference.transform);
    }
    public static void DestroyInstruction()
    {
        Debug.Log("DestroyInstruction()");
        Destroy(instructionPanel);
    }

    public static void ShowReady()
    {
        Debug.Log("ShowReady()");
        instance.StartCoroutine(ReadyIE());
    }
    static IEnumerator ReadyIE()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("ReadyIE()");
        readyPanel = Instantiate(readyPanelReference, canvasReference.transform);
        yield return new WaitForSeconds(1.5f);
        readyFinished = true;
    }
    public static void DestroyReady()
    {
        Debug.Log("DestroyReady()");
        Destroy(readyPanel);
    }

    public static void ShowGo()
    {
        Debug.Log("ShowGo()");
        instance.StartCoroutine(GoIE());
    }
    static IEnumerator GoIE()
    {
        Debug.Log("GoIE()");
        goPanel = Instantiate(goPanelReference, canvasReference.transform);
        yield return new WaitForSeconds(1f);
        goFinished = true;
    }
    public static void DestroyGo()
    {
        Debug.Log("DestroyGo()");
        Destroy(goPanel);
    }

    public static void ShowTimesUp()
    {
        Debug.Log("ShowTimesUp()");
        timesUpPanel = Instantiate(timesUpPanelReference, canvasReference.transform);
    }
}
