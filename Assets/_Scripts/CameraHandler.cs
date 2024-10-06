using Cinemachine;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    private float _baseLensSize;
    private float _targetLensSize;
    
    private void Start()
    {
        _baseLensSize = virtualCamera.m_Lens.OrthographicSize;
        _targetLensSize = _baseLensSize;
    }
    
    private void Update()
    {
        HandleMovement();
        HandleZooming();
    }
    
    private void HandleMovement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        
        var moveDirection = new Vector3(x, y).normalized;
        var moveSpeed = 30f;
        transform.position += moveDirection * (moveSpeed * Time.deltaTime);
        
    }
    
    private void HandleZooming()
    {
        var zoomAmount = 2f;
        _targetLensSize += -Input.mouseScrollDelta.y * zoomAmount;
        var minLensSize = 10f;
        var maxLensSize = 30f;
        _targetLensSize = Mathf.Clamp(_targetLensSize, minLensSize, maxLensSize);
        var zoomSpeed = 5f;
        _baseLensSize = Mathf.Lerp(_baseLensSize, _targetLensSize, Time.deltaTime * zoomSpeed);
        virtualCamera.m_Lens.OrthographicSize = _baseLensSize;
    }
    
}