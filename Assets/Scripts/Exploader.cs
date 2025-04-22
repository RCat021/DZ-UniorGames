using UnityEngine;

public class Exploader : MonoBehaviour
{
    [SerializeField] private int _force = 100;
    [SerializeField] private int _radius = 10;

    public void Expload(Rigidbody rigidbody)
    {
        rigidbody.AddExplosionForce(_force, rigidbody.transform.position, _radius);
    }
}
