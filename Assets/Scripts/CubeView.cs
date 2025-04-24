using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CubeBlastInfo))]
public class CubeView : MonoBehaviour
{
    private const int MaxChanceDecrease = 100;

    [SerializeField] private int _cubeSizeReduction = 2;
    [SerializeField] private int _cubeSplitChanceDecrease = 2;
    
    private CubeBlastInfo _cubeBlastInfo;
    private Rigidbody _rigidbody;

    private int _chanceDecrease;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _cubeBlastInfo = GetComponent<CubeBlastInfo>();
        _chanceDecrease = MaxChanceDecrease;
    }

    public void RedefineChanceDecrease(int chanceDecrease)
    {
        _chanceDecrease = chanceDecrease;
    }

    public int GetNewChanceDecrease()
    {
        return _chanceDecrease / _cubeSplitChanceDecrease;
    }

    public Vector3 GetSizeNewCube()
    {
        return transform.localScale / _cubeSizeReduction;
    }

    public bool IsTriggerSpawn()
    {
        bool isTrigger = false;
        int percent = Random.Range(0, MaxChanceDecrease + 1);

        if (_chanceDecrease >= percent)
            isTrigger = true;

        return isTrigger;
    }

    public Rigidbody GetRigidbody()
    {
        return _rigidbody;
    }

    public CubeBlastInfo GetCubeBlastInfo() => _cubeBlastInfo.GetCopyCubeBlastInfo();

    public void RedefineCubeBlastInfo(CubeBlastInfo oldCubeBlastInfo)
    {
        _cubeBlastInfo.UpdateExplosionData(oldCubeBlastInfo);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
