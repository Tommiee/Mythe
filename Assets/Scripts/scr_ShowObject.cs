using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_ShowObject : MonoBehaviour
{
    [SerializeField]
    public scr_Object obj;

    private Text nameText = null;
    private Text descriptionText = null;

    public void ShowObject(scr_Object obj)
    {
        this.obj = obj;

        if (nameText != null)
        {
            nameText.text = obj.name;
        }

        if (descriptionText != null)
        {
            descriptionText.text = obj.description;
        }

        transform.name = obj.name;
    }
}
