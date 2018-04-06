using UnityEngine;

public class Collectable : MonoBehaviour
{
    public ObjectData obj;

    public Vector3 originPos;

    void Start()
    {
        originPos = gameObject.transform.position;
    }
}
