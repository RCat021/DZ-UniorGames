using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputRayCaster : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Ray _ray;
    [SerializeField] protected float _maxDistance = 10f;
    [SerializeField] protected float _radius = 0.1f;

    private Camera _camera;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            HandleRayCast();
    }

    private void HandleRayCast()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Debug.DrawRay(_ray.origin, _ray.direction * _maxDistance, Color.magenta);

        if (Physics.Raycast(_ray, out hit, Mathf.Infinity))
        {
            Transform objectHit = hit.transform;
            CubeView cubeView = objectHit.GetComponent<CubeView>();

            if (cubeView != null)
            {
                SpawnCubes(cubeView);
                DestroyCube(cubeView);
            }
        }
    }

    private void SpawnCubes(CubeView cubeView)
    {
        if (cubeView.IsTriggerEventSpawn(out Vector3 newCubeSize, out int newShanceDecreaseCube))
            _spawner.CubeSpawn(cubeView.transform.position, newCubeSize, newShanceDecreaseCube);
    }

    private void DestroyCube(CubeView cubeView)
    {
        cubeView.Destroy();
    }
}
