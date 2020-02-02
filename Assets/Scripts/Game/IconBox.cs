using UnityEngine;
using UnityEngine.UI;

public class IconBox : MonoBehaviour
{
    public Image icon;
    public GameObject iconBox;
    public Animator iconBoxAnim;
    public GameObject tickIcon;

    public Animator iamgeAnim;

    public bool isProcessing = false;
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
            iamgeAnim.SetBool("isRotate", isProcessing);
            iconBoxAnim.SetBool("Enable", true);
        }
    }

    public void Close()
    {
        isProcessing = false;
        iconBoxAnim.SetBool("Enable", false);
    }
}
