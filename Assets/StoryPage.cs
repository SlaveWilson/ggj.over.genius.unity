using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryPage : MonoBehaviour
{
    public GameObject panel;
    public GameObject next;

    private void Awake()
    {
        panel = transform.Find("Panel").gameObject;
        panel.GetComponent<Image>().color = new Color(1, 1, 1, 1);

        this.gameObject.SetActive(false);
    }

    void Start()
    {
        StartCoroutine(ChangeColour());

    }
    IEnumerator ChangeColour()
    {
        float opaque = 1;
        for (int i = 0; i < 2f / Time.fixedDeltaTime; i++)
        {
            yield return new WaitForFixedUpdate();
            opaque = opaque - Time.fixedDeltaTime / 2f;
            panel.GetComponent<Image>().color = new Color(1, 1, 1, opaque);
        }

        yield return new WaitForSeconds(2);
        opaque = 0;
        for (int i = 0; i < 2f / Time.fixedDeltaTime; i++)
        {
            yield return new WaitForFixedUpdate();
            opaque = opaque + Time.fixedDeltaTime / 2f;
            panel.GetComponent<Image>().color = new Color(1, 1, 1, opaque);
        }
        gameObject.SetActive(false);
        next.SetActive(true);
    }
}
