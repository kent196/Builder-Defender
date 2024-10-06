using System;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    private BuildingTypeSO _buildingType;
    private BuildingTypeListSO _buildingTypeList;
    private Camera _mainCamera;
    
    private void Awake()
    {
        _buildingTypeList = Resources.Load<BuildingTypeListSO>(nameof(BuildingTypeListSO));
        _buildingType = _buildingTypeList.list[0];
    }
    
    private void Start()
    {
        _mainCamera = Camera.main;
    }
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(_buildingType.prefab, GetMouseWorldPosition(), Quaternion.identity);
        }
        
        if (Input.GetKeyDown(KeyCode.T))
        {
            _buildingType = _buildingTypeList.list[0];
        }
        
        if (Input.GetKeyDown(KeyCode.Y))
        {
            _buildingType = _buildingTypeList.list[1];
        }
    }
    
    private Vector3 GetMouseWorldPosition()
    {
        var mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        return mousePosition;
    }
}