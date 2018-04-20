using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Object", menuName = "Object")]
public class ObjectData : ScriptableObject
{
    public new string name;
    public string description;

    public int id;

    public GameObject model;
}

[CreateAssetMenu(fileName = "New recipe", menuName = "recipe")]
public class CraftableItem : ObjectData
{
    public List<int> requiredIds = new List<int>();
}
