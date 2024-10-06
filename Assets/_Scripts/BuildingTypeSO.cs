using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Building Type SO")]
public class BuildingTypeSO : ScriptableObject
{
    public string nameString;
    public Transform prefab;
    public BuildingTypeData data;
}