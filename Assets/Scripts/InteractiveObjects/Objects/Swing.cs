using UnityEngine;

public class Swing : MonoBehaviour, IInteractive
{
    [SerializeField] private Rigidbody _swing;
    [SerializeField] private float _swingForce = 100f;

    public void Activate()
    {
        _swing.AddTorque(Vector3.back * _swingForce);
    }

    public void Diactivate() {  }
}
