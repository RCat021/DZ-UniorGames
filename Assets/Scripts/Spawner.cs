using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private CubeView _prefabCube;
    [SerializeField] private Exploader _exploader;

    [SerializeField] private int _minSpawnCube = 2;
    [SerializeField] private int _maxSpawnCube = 6;

    public void CubeSpawn(Vector3 position, Vector3 size, int chanceDecrease)
    {
        int countNewCubes = Random.Range(_minSpawnCube, _maxSpawnCube + 1);

        for (int i = 0; i < countNewCubes; i++)
        {
            CubeView spawnCube = Instantiate(_prefabCube, position, Quaternion.identity);

            spawnCube.transform.localScale = size;

            spawnCube.RedefineChanceDecrease(chanceDecrease);

            if (spawnCube.TryGetComponent<Rigidbody>(out Rigidbody cubeRigidbody))
                _exploader.Expload(cubeRigidbody);
        }
    }
}
