using UnityEngine;
using UnityEngine.UI;

public class IconBox : MonoBehaviour
{
    public Image icon;
    public GameObject iconBox;
    public Animator iconBoxAnim;
    public GameObject tickIcon;

    public bool showTickIcon = false;

    public void SetIcon(Sprite s)
    {
        icon.sprite = s;
        tickIcon.SetActive(showTickIcon);
        if (s == null)
        {
            iconBoxAnim.SetBool("Enable", false);
        } else
        {
            iconBoxAnim.SetBool("Enable", true);
        }
    }

    public void Close()
    {
        iconBoxAnim.SetBool("Enable", false);
    }
}
