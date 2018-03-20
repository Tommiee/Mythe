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

    public void ShowCollectable(ObjectData item)
    {
        if (nameText != null){ nameText.text = item.name; }
        if (descriptionText != null){ descriptionText.text = item.description; }

        line.GetComponent<Animation>().Play();
    }
}
