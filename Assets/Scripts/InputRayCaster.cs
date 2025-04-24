using UnityEngine;

public class InputRayCaster : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Spawner _spawner;
    [SerializeField] protected float _maxDistance = 10f;

    private Ray _ray;
    private KeyCode _raycastKey = KeyCode.Mouse0;

    private void Update()
    {
        if (Input.GetKeyDown(_raycastKey))
            HandleRaycast();
    }

    private void HandleRaycast()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Debug.DrawRay(_ray.origin, _ray.direction * _maxDistance, Color.magenta);

        if (Physics.Raycast(_ray, out hit, Mathf.Infinity))
        {
            Transform objectHit = hit.transform;

            if (objectHit.TryGetComponent<CubeView>(out CubeView cubeView))
                HitCube(cubeView);
        }
    }

    private void HitCube(CubeView cube)
    {
        if (cube.IsTriggerSpawn())
            SpawnCubes(cube);
        else
            SpawnCubeExplosion(cube.transform.position, cube.GetCubeBlastInfo());
       
        cube.Destroy();
    }

    private void SpawnCubes(CubeView cube)
    {
        Vector3 newSize = cube.GetSizeNewCube();
        int newShanceDecrease = cube.GetNewChanceDecrease();

        _spawner.SpawnCube(cube.transform.position,newSize, newShanceDecrease, cube.GetCubeBlastInfo());
    }

    private void SpawnCubeExplosion(Vector3 position, CubeBlastInfo cubeBlastInfo)
    {
        _spawner.SpawnExploadCube(position, cubeBlastInfo);
    }
}
