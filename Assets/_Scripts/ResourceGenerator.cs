using UnityEngine;

public class ResourceGenerator : MonoBehaviour
{
    private float _timer;
    private float _timerMax;
    private BuildingTypeSO _buildingType;
    
    private void Awake()
    {
        _buildingType = GetComponent<BuildingTypeHolder>().buildingTypeSO;
        _timerMax = _buildingType.data.timerMax;
    }
    
    private void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            ResourceManager.Instance.AddResource(_buildingType.data.resourceTypeSO, 1);
            _timer = _timerMax;
        }
    }
}