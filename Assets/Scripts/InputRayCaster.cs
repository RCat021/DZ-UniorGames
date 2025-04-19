using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputRayCaster : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Ray _ray;
    [SerializeField] protected float _maxDistance = 10f;

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
            objectHit.TryGetComponent<CubeView>(out CubeView cubeView);

            if (cubeView != null)
                cubeView.OnButton();
        }
    }
}
