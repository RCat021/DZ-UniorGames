using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class CubeView : MonoBehaviour
{
    [SerializeField] private int _cubeSizeReduction = 2;

    [SerializeField] private int _cubeSplitChanceDecrease = 2;

    private int _maxChanceDecrease = 100;
    private int _chanceDecrease;

    private void Awake()
    {
        _chanceDecrease = _maxChanceDecrease;
    }

    private Vector3 GetSizeNewCube()
    {
        return transform.localScale / _cubeSizeReduction;
    }

    private bool IsTriggerEvent()
    {
        int percent = Random.Range(0, _maxChanceDecrease + 1);
        bool isTriggerEvent = false;

        if (_chanceDecrease >= percent)
            isTriggerEvent = true;

        return isTriggerEvent;
    }

    public bool IsTriggerEventSpawn(out Vector3 newCubeSize, out int newShanceDecrease)
    {
        bool isTrigger = false;
        newCubeSize = GetSizeNewCube();
        newShanceDecrease = _chanceDecrease / _cubeSplitChanceDecrease;

        if (IsTriggerEvent())
            isTrigger = true;

        return isTrigger;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void RedefinitionShanceDerease(int chanceDecrease)
    {
        _chanceDecrease = chanceDecrease;
    }
}
