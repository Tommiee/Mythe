using UnityEngine;

[CreateAssetMenu(fileName = "New Object", menuName = "Object")]
public class ObjectData : ScriptableObject
{
    public new string name;
    public string description;

    public int id;
}
