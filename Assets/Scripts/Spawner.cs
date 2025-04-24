using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private CubeView _prefabCube;
    [SerializeField] private Exploader _exploader;

    [SerializeField] private int _minSpawnCube = 2;
    [SerializeField] private int _maxSpawnCube = 6;

    public void SpawnCube(Vector3 position, Vector3 size, int chanceDecrease, CubeBlastInfo oldCubeBlastInfo)
    {
        int countNewCubes = Random.Range(_minSpawnCube, _maxSpawnCube + 1);

        for (int i = 0; i < countNewCubes; i++)
        {
            CubeView spawnCube = Instantiate(_prefabCube, position, Quaternion.identity);

            spawnCube.transform.localScale = size;
            spawnCube.RedefineChanceDecrease(chanceDecrease);

            spawnCube.RedefineCubeBlastInfo(oldCubeBlastInfo);

            _exploader.Expload(spawnCube.GetRigidbody());
        }
    }

    public void SpawnExploadCube(Vector3 position, CubeBlastInfo cubeBlastInfo )
    {
        float force = cubeBlastInfo.GetForce();
        float radius = cubeBlastInfo.GetRadius();

        Collider[] overlappedColliders = Physics.OverlapSphere(position, radius);

        foreach (Collider hit in overlappedColliders)
        {
            if(hit.TryGetComponent<CubeView>(out CubeView cubeView))
            {
                _exploader.Expload(cubeView.GetRigidbody(), position, force, radius);
            }
        }
    }
}
