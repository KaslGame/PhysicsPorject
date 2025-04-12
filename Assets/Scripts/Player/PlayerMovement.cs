using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 6f;
    [SerializeField] private float _strafeSpeed = 6f;
    [SerializeField] private float _gravityFactor = 2f;
    [SerializeField] private Transform _cameraTransform;

    private CharacterController _characterController;
    private PlayerInput _playerInput;
    private Vector3 _verticalVelocity;
    
    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        Vector3 forward = Vector3.ProjectOnPlane(_cameraTransform.forward, Vector3.up).normalized;
        Vector3 right = Vector3.ProjectOnPlane(_cameraTransform.right, Vector3.up).normalized;

        if (_characterController == null)
            return;

        Vector3 playerSpeed = forward * _playerInput.X * _speed + right * _playerInput.Z * _strafeSpeed;

        if (_characterController.isGrounded)
        {
            _verticalVelocity = Vector3.down;
            _characterController.Move((playerSpeed + _verticalVelocity) * Time.deltaTime);
        }
        else
        {
            Vector3 horizontalVelocity = _characterController.velocity;
            horizontalVelocity.y = 0;
            _verticalVelocity += Physics.gravity * Time.deltaTime * _gravityFactor;
            _characterController.Move((horizontalVelocity + _verticalVelocity) * Time.deltaTime);
        }
    }
}
