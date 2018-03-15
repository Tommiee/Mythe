using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ShowObject : MonoBehaviour
{
    [SerializeField]
    private Text nameText = null;
    [SerializeField]
    private Text descriptionText = null;
    [SerializeField]
    private Text line = null;
    
    void Start()
    {
        nameText.CrossFadeAlpha(0f, 0f, false);
        line.CrossFadeAlpha(0f, 0f, false);
        descriptionText.CrossFadeAlpha(0f, 0f, false);
    }

    public void ShowCollectable(ObjectData item)
    {
        if (nameText != null){ nameText.text = item.name; }
        if (descriptionText != null){ descriptionText.text = item.description; }

        StartCoroutine(FadeOut());
        line.GetComponent<Animation>().Play();
    }

    IEnumerator FadeOut()
    {
        nameText.CrossFadeAlpha(1f, 2f, false);
        line.CrossFadeAlpha(1f, 2f, false);
        descriptionText.CrossFadeAlpha(1f, 2f, false);

        yield return new WaitForSeconds(10f);

        nameText.CrossFadeAlpha(0f, 2f, false);
        line.CrossFadeAlpha(0f, 2f, false);
        descriptionText.CrossFadeAlpha(0f, 2f, false);
    }
}
