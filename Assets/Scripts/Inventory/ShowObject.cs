using System.Collections;
using System.Collections.Generic;
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

    [SerializeField]
    private List<ObjectData> itemData = new List<ObjectData>();

    private float waitTime = 10f;
    private float fadeTimer = 2f;

    private IEnumerator DisplayIEnumerator;

    void Start()
    {
        nameText.CrossFadeAlpha(0f, 0f, false);
        line.CrossFadeAlpha(0f, 0f, false);
        descriptionText.CrossFadeAlpha(0f, 0f, false);
    }

    public void ShowCollectable(ObjectData data)
    {
        itemData.Add(data);
        StartCoroutine(FadeOut(itemData[0]));
    }

    IEnumerator FadeOut(ObjectData item)
    {
        if (nameText != null) { nameText.text = item.name; }
        if (descriptionText != null) { descriptionText.text = item.description; }

        line.GetComponent<Animation>().Play();
        nameText.CrossFadeAlpha(1f, fadeTimer, false);
        line.CrossFadeAlpha(1f, fadeTimer, false);
        descriptionText.CrossFadeAlpha(1f, fadeTimer, false);

        yield return new WaitForSeconds(waitTime);

        nameText.CrossFadeAlpha(0f, fadeTimer, false);
        line.CrossFadeAlpha(0f, fadeTimer, false);
        descriptionText.CrossFadeAlpha(0f, fadeTimer, false);

        yield return new WaitForSeconds(fadeTimer);

        itemData.RemoveAt(0);
        print("hoebeel?");
        if(itemData.Count > 0)
        {
            StartCoroutine(FadeOut(itemData[0]));
        }
    }
}

Queue items
Ienumerator()
{
    ík ben aan het displayen...

    while (items!=leeg)
    {
        Display item
        etc. etc.
        verwijder item uit queue (Display lijst)
    }
    ik ben klaar met display
}
