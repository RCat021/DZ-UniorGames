using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private CubeView _initialCube;
    [SerializeField] private CubeView _prefabCube;
    [SerializeField] private Exploader _exploader;

    [SerializeField] private int _minSpawnCube = 2;
    [SerializeField] private int _maxSpawnCube = 6;

    private List<CubeView> _activeCubes = new List<CubeView>();


    private void Start()
    {
        AddCube(_initialCube);
    }

    private void OnDisable()
    {
        foreach (var cube in _activeCubes)
        {
            cube.Split -= HandleCubeSplit;
            cube.Destroyed -= HandleCubeDestroyed;
        }
    }

    private void CubeSpawn(Vector3 position, Vector3 size, int chanceDecrease)
    {
        Debug.Log("Spawn");

        int countNewCubes = Random.Range(_minSpawnCube, _maxSpawnCube + 1);

        for (int i = 0; i < countNewCubes; i++)
        {
            CubeView spawnCubeView = Instantiate(_prefabCube, position, Quaternion.identity);

            spawnCubeView.transform.localScale = size;

            spawnCubeView.RedefineChanceDecrease(chanceDecrease);
            AddCube(spawnCubeView);

            _exploader.Expload(spawnCubeView.gameObject);
        }
    }

    private void AddCube(CubeView cube)
    {
        cube.Split += HandleCubeSplit;
        cube.Destroyed += HandleCubeDestroyed;
        _activeCubes.Add(cube);
    }

    private void HandleCubeSplit(CubeView cube)
    {
        cube.Split -= HandleCubeSplit;
        cube.Destroyed -= HandleCubeDestroyed;

        var size = cube.GetSizeNewCube();
        var shanceDecrease = cube.GetNewChanceDecrease();

        _activeCubes.Remove(cube);

        CubeSpawn(cube.transform.position, size, shanceDecrease);
    }

    private void HandleCubeDestroyed(CubeView cubeView)
    {
        cubeView.Split -= HandleCubeSplit;
        cubeView.Destroyed -= HandleCubeDestroyed;

        _activeCubes.Remove(cubeView);
    }
}
