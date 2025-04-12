using System;
using System.Collections;
using UnityEngine;

public class Catapult : MonoBehaviour, IInteractive
{
    [SerializeField] private SpringJoint _springJoint;
    [SerializeField] private Rigidbody _upPoint;
    [SerializeField] private Rigidbody _downPoint;
    [SerializeField] private float _upSpring;
    [SerializeField] private float _downSpring;
    [SerializeField] private float _cooldown;
    [SerializeField] private GameObject _ballPrefab;
    [SerializeField] private Transform _spawnPoint;

    private bool _isReady = false;

    public void Activate()
    {
        if (_isReady == true)
        {
            ChangePosition(_upPoint, _upSpring);
            _isReady = false;
        }
    }

    public void Diactivate()
    {
        if (_isReady == false)
        {
            ChangePosition(_downPoint, _downSpring);
            StartCoroutine(Timer(ResetCatapult));
        }
    }

    private void ResetCatapult()
    {
        Instantiate(_ballPrefab, _spawnPoint.position, Quaternion.identity);
        _isReady = true;
    }

    private void ChangePosition(Rigidbody point, float spring)
    {
        _springJoint.connectedBody = point;
        _springJoint.spring = spring;
    }

    private IEnumerator Timer(Action callback = null)
    {
        WaitForSeconds time = new WaitForSeconds(_cooldown);

        yield return time;

        callback?.Invoke();
    }
}
