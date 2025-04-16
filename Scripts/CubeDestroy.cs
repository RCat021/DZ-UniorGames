using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class CubeDestroy : MonoBehaviour
{
    private CubeView _cubeView;

    private void Start()
    {
        _cubeView = FindObjectOfType<CubeView>();
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
