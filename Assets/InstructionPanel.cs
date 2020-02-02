using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionPanel : MonoBehaviour
{
    public List<Sprite> pages;
    public static GameObject panel;
    public static GameObject right;
    public static GameObject left;
    public static GameObject text;
    public static int currentPage = 1;


    public static bool clickedLast = false;

    private void Awake()
    {
        panel = transform.Find("Panel").gameObject;
        right = transform.Find("Right").gameObject;
        left = transform.Find("Left").gameObject;
        text = transform.Find("Text").gameObject;

        right.GetComponent<Button>().onClick.AddListener(() => NextPage());
        left.GetComponent<Button>().onClick.AddListener(() => LastPage());

        left.SetActive(false);


        clickedLast = false;


        currentPage = 1;
    }

    public void NextPage()
    {
        SoundManager.ClickButtonSE();
        if (currentPage == pages.Count)
        {
            clickedLast = true;
            return;
        }
        else
        {
            panel.GetComponent<Image>().sprite = pages[currentPage++];
            text.GetComponent<Text>().text = currentPage.ToString() + "/" + pages.Count.ToString();
            left.SetActive(true);
        }
    }
    public void LastPage()
    {
        SoundManager.ClickButtonSE();
        if (currentPage == 1)
        {
            return;
        }
        else if (currentPage == 2)
        {
            currentPage--;
            panel.GetComponent<Image>().sprite = pages[currentPage - 1];
            text.GetComponent<Text>().text = currentPage.ToString() + "/" + pages.Count.ToString();
            left.SetActive(false);
        }
        else
        {
            currentPage--;
            panel.GetComponent<Image>().sprite = pages[currentPage - 1];
            text.GetComponent<Text>().text = currentPage.ToString() + "/" + pages.Count.ToString();
        }
    }
}
