using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResourceUI : MonoBehaviour
{
    private Dictionary<ResourceTypeSO, Transform> _resourcesUIDictionary = new();
    private ResourceTypeListSO _resourceList;
    
    private void Awake()
    {
        int index = 0;
        var offsetX = -130f;
        _resourceList = Resources.Load<ResourceTypeListSO>(nameof(ResourceTypeListSO));
        foreach (var resource in _resourceList.list)
        {
            var resourceTemplate = gameObject.transform.Find("resourceTemplate");
            resourceTemplate.gameObject.SetActive(false);
            var resourceTransform = Instantiate(resourceTemplate, transform);
            resourceTransform.gameObject.SetActive(true);
            resourceTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(offsetX * index, 0);
            index++;
            resourceTransform.Find("image").GetComponent<Image>().sprite = resource.sprite;
            _resourcesUIDictionary.Add(resource, resourceTransform);
        }
    }
    
    private void Start()
    {
        UpdateResourceUI();
        ResourceManager.Instance.OnResourcesChanged += OnOnResourcesChanged;
    }
    
    private void OnOnResourcesChanged(object sender, EventArgs e)
    {
        UpdateResourceUI();
    }
    
    private void UpdateResourceUI()
    {
        foreach (var resource in _resourceList.list)
        {
            int amount = ResourceManager.Instance.GetAmount(resource);
            _resourcesUIDictionary[resource].Find("text").GetComponent<TextMeshProUGUI>().SetText(amount.ToString());
        }
    }
}