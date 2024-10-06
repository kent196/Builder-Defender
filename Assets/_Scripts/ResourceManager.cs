using System;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance { get; private set; }
    private Dictionary<ResourceTypeSO, int> _resourcesDictionary;
    private ResourceTypeListSO _resourceTypeList;
    
    public event EventHandler OnResourcesChanged;
    
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        _resourcesDictionary = new Dictionary<ResourceTypeSO, int>();
        _resourceTypeList = Resources.Load<ResourceTypeListSO>(nameof(ResourceTypeListSO));
        foreach (var item in _resourceTypeList.list)
        {
            _resourcesDictionary.Add(item, 0);
        }
        
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            AddResource(_resourceTypeList.list[0], 2);
        }
        
    }
    
    public void AddResource(ResourceTypeSO resourceTypeSO, int value)
    {
        _resourcesDictionary[resourceTypeSO] += value;
        OnResourcesChanged?.Invoke(this, EventArgs.Empty);
        Debug.Log($"[{resourceTypeSO.nameString}]: {_resourcesDictionary[resourceTypeSO]}");
    }
    
    public int GetAmount(ResourceTypeSO resource)
    {
        return _resourcesDictionary[resource];
    }
}