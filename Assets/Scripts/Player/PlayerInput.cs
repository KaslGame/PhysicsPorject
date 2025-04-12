using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const string Vertical = nameof(Vertical);
    private const string Horizontal = nameof(Horizontal);

    public event Action ActivateKeyDown;
    public event Action DiactivateKeyDown;

    public float X { get; private set; }
    public float Z { get; private set; }

    private void Update()
    {
        X = Input.GetAxis(Vertical);
        Z = Input.GetAxis(Horizontal);

        if (Input.GetKeyDown(KeyCode.E))
            ActivateKeyDown?.Invoke();

        if (Input.GetKeyDown(KeyCode.Q))
            DiactivateKeyDown?.Invoke();
    }
}
