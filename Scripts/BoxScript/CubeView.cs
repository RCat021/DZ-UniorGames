using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class CubeView : MonoBehaviour
{
    [SerializeField] private GameObject _cube;
    [SerializeField] private GameObject _explosion;

    [SerializeField] private int _minSpawnCube = 2;
    [SerializeField] private int _maxSpawnCube = 6;
    [SerializeField] private int _cubeSizeReduction = 2;

    [SerializeField] private int _cubeSplitChanceDecrease = 2;

    private int _maxChanceDecrease = 100;
    private int _chanceDecrease;

    private void Start()
    {
        _chanceDecrease = _maxChanceDecrease;
    }

    public void IsDestroyedCube(Transform transform)
    {
        if (IsTriggerEvent())
        {
            int countNewCubes = Random.Range(_minSpawnCube, _maxSpawnCube + 1);
            _cube.transform.localScale = GetSizeNewCube(transform.localScale);

            SpawnObject(_cube, transform.position, countNewCubes);
            SpawnObject(_explosion, transform.position);
        }
    }

    private void SpawnObject(GameObject gameObject, Vector3 position, int countSpawn = 1)
    {
        for (int i = 0; i < countSpawn; i++)
            Instantiate(gameObject, position, Quaternion.identity);
    }

    private Vector3 GetSizeNewCube(Vector3 size)
    {
        return new Vector3(size.x / _cubeSizeReduction, size.y / _cubeSizeReduction, size.z / _cubeSizeReduction);
    }

    private bool IsTriggerEvent()
    {
        int percent = Random.Range(0, _maxChanceDecrease + 1);

        if (_chanceDecrease >= percent)
        {
            _chanceDecrease /= _cubeSplitChanceDecrease;
            return true;
        }
        else
        {
            return false;
        }
    }
}
