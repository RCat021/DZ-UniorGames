using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class CubeDestroy : MonoBehaviour
{
    [SerializeField] private CubeView _cubeView;

    private void Start()
    {
        _cubeView = CubeView.Instance;
    }

    private void OnMouseUp()
    {
        Destroy();
    }

    private void Destroy()
    {
        _cubeView.HandleCubeDestruction(transform);
        Destroy(gameObject);
    }
}
