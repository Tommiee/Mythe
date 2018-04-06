using UnityEngine;

public class SwitchController : MonoBehaviour
{
    public void SwitchControl(GameObject to, GameObject from, bool when)
    {
        if (when)
        {
            to.GetComponentInChildren<Camera>().enabled = true;
            to.gameObject.SetActive(true);

            from.GetComponentInChildren<Camera>().enabled = false;
            from.gameObject.SetActive(false);
        }
    }
}
