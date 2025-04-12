using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class Player : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private LayerMask _interactiveMask;
    
    private PlayerInput _playerInput;
    private float _distanceRaycast = 5f;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        _playerInput.ActivateKeyDown += OnActivateKeyDown;
        _playerInput.DiactivateKeyDown += OnDiactivateKeyDown;
    }

    private void OnDisable()
    {
        _playerInput.ActivateKeyDown -= OnActivateKeyDown;
        _playerInput.DiactivateKeyDown -= OnDiactivateKeyDown;
    }

    private void OnActivateKeyDown()
    {
        if (Physics.Raycast(_cameraTransform.position, _cameraTransform.forward, out RaycastHit hitInfo, _distanceRaycast, _interactiveMask, QueryTriggerInteraction.Ignore))
        {
            if (hitInfo.collider.TryGetComponent(out IInteractive interactiveObject))
                interactiveObject.Activate();
        }
    }

    private void OnDiactivateKeyDown()
    {
        if (Physics.Raycast(_cameraTransform.position, _cameraTransform.forward, out RaycastHit hitInfo, _distanceRaycast, _interactiveMask, QueryTriggerInteraction.Ignore))
        {
            if (hitInfo.collider.TryGetComponent(out IInteractive interactiveObject))
                interactiveObject.Diactivate();
        }
    }
}
