using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Object", menuName = "Object")]
public class ObjectData : ScriptableObject
{
    public GameObject model;

    public new string name;
    public string description;

    public int id;
}

[CreateAssetMenu(fileName = "New Craftable Item", menuName = "Craftable Item")]
public class CraftableItem : ObjectData
{
    public List<int> requiredIds = new List<int>();
}