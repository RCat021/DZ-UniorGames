using UnityEngine;

public class CubeView : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;

    [SerializeField] private int _cubeSizeReduction = 2;

    [SerializeField] private int _cubeSplitChanceDecrease = 2;

    private int _maxChanceDecrease = 100;
    private int _chanceDecrease;

    public static CubeView Instance;

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _chanceDecrease = _maxChanceDecrease;
    }

    public void HandleCubeDestruction(Transform transform)
    {
        if (IsTriggerEvent())
        {
            Vector3 size = GetSizeNewCube(transform.localScale);

            _spawner.CubeSpawn(transform.position, size);
        }
    }

    private Vector3 GetSizeNewCube(Vector3 size)
    {
        return size / _cubeSizeReduction;
    }

    private bool IsTriggerEvent()
    {
        int percent = Random.Range(0, _maxChanceDecrease + 1);
        bool isTriggerEvent = false;

        if (_chanceDecrease >= percent)
        {
            _chanceDecrease /= _cubeSplitChanceDecrease;
            isTriggerEvent = true;
        }

        return isTriggerEvent;
    }
}
