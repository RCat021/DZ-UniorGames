using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private CubeView _cubeView;
    [SerializeField] private Exploader _exploader;

    [SerializeField] private int _minSpawnCube = 2;
    [SerializeField] private int _maxSpawnCube = 6;
    

    public void CubeSpawn(Vector3 position, Vector3 size, int newShanceDecrease)
    {
        int countNewCubes = Random.Range(_minSpawnCube, _maxSpawnCube + 1);

        GameObject cube = _cubeView.gameObject;
        cube.transform.localScale = size;

        for (int i = 0; i < countNewCubes; i++)
        {
            GameObject spawnGameObject;
            spawnGameObject = Instantiate(_cubeView.gameObject, position, Quaternion.identity);

            CubeView spawnCubeView = spawnGameObject.GetComponent<CubeView>();

            if (spawnCubeView != null)
                spawnCubeView.RedefinitionShanceDerease(newShanceDecrease);

            _exploader.Expload(spawnGameObject);
        }
    }
}
