using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploader : MonoBehaviour
{
    [SerializeField] private int _force = 100;
    [SerializeField] private int _radius = 10;

    public void Expload(GameObject gameObject)
    {
        Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();

        if (rigidbody != null)
            rigidbody.AddExplosionForce(_force, gameObject.transform.position, _radius);
    }
}
