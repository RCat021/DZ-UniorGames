using UnityEngine;

public class DestroyCube : MonoBehaviour
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
        _cubeView.IsDestroyedCube(transform);
        Destroy(gameObject);
    }
}
