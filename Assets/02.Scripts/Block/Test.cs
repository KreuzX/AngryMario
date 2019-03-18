using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Collider _colliderChild;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(Vector3.forward * 1000.0f);
        _colliderChild = GetComponentsInChildren<Collider>()[1];
    }

    private void OnCollisionEnter(Collision collision)
    {
        _colliderChild.enabled = false;
    }
}
