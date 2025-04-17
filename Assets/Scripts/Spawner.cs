using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private CubeDestroy _cubeDestroy;

    [SerializeField] private int _minSpawnCube = 2;
    [SerializeField] private int _maxSpawnCube = 6;
    [SerializeField] private int _spawnForceCube = 100;
    [SerializeField] private int _spawnRadiusCube = 10;

    public void CubeSpawn(Vector3 position, Vector3 size)
    {
        int countNewCubes = Random.Range(_minSpawnCube, _maxSpawnCube + 1);

        GameObject cube = _cubeDestroy.gameObject;
        cube.transform.localScale = size;

      SpawnObject(cube, position, countNewCubes);
    }

    private void SpawnObject(GameObject gameObject, Vector3 position, int countSpawn = 1)
    {
        for (int i = 0; i < countSpawn; i++)
        {
            GameObject spawnGameObject;
            spawnGameObject = Instantiate(gameObject, position, Quaternion.identity);

            Rigidbody rigidbodySpawnGameObject = spawnGameObject.GetComponent<Rigidbody>();
            rigidbodySpawnGameObject.AddExplosionForce(_spawnForceCube, transform.position, _spawnRadiusCube);

        }
    }
}
