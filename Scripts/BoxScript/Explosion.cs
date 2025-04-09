using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _radius = 4f;
    [SerializeField] private float _force = 2f;

    private void Start()
    {
        Explode();
        Destroy(gameObject);
    }

    private void Explode()
    {
        Collider[] overlappedColliders = Physics.OverlapSphere(transform.position, _radius);

        for (int i = 0; i < overlappedColliders.Length; ++i)
        {
            Rigidbody rigidbody = overlappedColliders[i].attachedRigidbody;

            if (rigidbody)
            {
                rigidbody.AddExplosionForce(_force, transform.position, _radius);
            }
        }
    }
}
