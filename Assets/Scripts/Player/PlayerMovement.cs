using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    private const string Vertical = nameof(Vertical);
    private const string Horizontal = nameof(Horizontal);

    [SerializeField] private float _speed = 6f;
    [SerializeField] private float _strafeSpeed = 6f;
    [SerializeField] private float _gravityFactor = 2f;
    [SerializeField] private Transform _cameraTransform;

    private Vector3 _verticalVelocity;
    private CharacterController _characterController;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
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

        Vector3 playerSpeed = forward * Input.GetAxis(Vertical) * _speed + right * Input.GetAxis(Horizontal) * _strafeSpeed;

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
