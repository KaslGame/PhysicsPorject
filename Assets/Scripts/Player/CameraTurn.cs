using UnityEngine;

public class CameraTurn : MonoBehaviour
{
    private const string MouseYAxis = "Mouse Y";
    private const string MouseXAxis = "Mouse X";

    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private float _horizontalTurnSensitivity = 10f;
    [SerializeField] private float _verticalTurnSensitivity = 10f;
    [SerializeField] private float _verticalMinAngle = -89f;
    [SerializeField] private float _verticalMaxAngle = 89f;

    private Transform _transform;
    private float _cameraAngle = 0;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        _cameraAngle -= Input.GetAxis(MouseYAxis) * _verticalTurnSensitivity;
        _cameraAngle = Mathf.Clamp(_cameraAngle, _verticalMinAngle, _verticalMaxAngle);
        _cameraTransform.localEulerAngles = Vector3.right * _cameraAngle;
        _transform.Rotate(Vector3.up * _horizontalTurnSensitivity * Input.GetAxis(MouseXAxis));
    }
}
