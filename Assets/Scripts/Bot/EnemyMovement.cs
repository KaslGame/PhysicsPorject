using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed = 1.5f;
    [SerializeField] private float _stopDistance = 4;

    private Transform _transform;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _transform = transform;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 direction = (_target.position - _transform.position).normalized;
        float distance = (_target.position - _transform.position).magnitude;

        if (distance > _stopDistance)
            _rigidbody.velocity = new Vector3(direction.x * _speed, _rigidbody.velocity.y, direction.z * _speed);
        else
            _rigidbody.velocity = new Vector3(Vector3.zero.x, _rigidbody.velocity.y, Vector3.zero.z);
    }
}
