using System;
using UnityEngine;


[RequireComponent (typeof(Rigidbody))]
public class CubeView : MonoBehaviour
{
    [SerializeField] private int _cubeSizeReduction = 2;
    [SerializeField] private int _cubeSplitChanceDecrease = 2;

    private int _maxChanceDecrease = 100;
    private int _chanceDecrease;

    public event Action<CubeView> Split;
    public event Action<CubeView> Destroyed;

    private void Awake()
    {
        _chanceDecrease = _maxChanceDecrease;
    }

    public void RedefineChanceDecrease(int chanceDecrease)
    {
        _chanceDecrease = chanceDecrease;
    }

    public void OnButton()
    {
        IsTriggerEventSpawn();
        Destroy();
    }

    public int GetNewChanceDecrease()
    {
        return _chanceDecrease / _cubeSplitChanceDecrease;
    }

    public Vector3 GetSizeNewCube()
    {
        return transform.localScale / _cubeSizeReduction;
    }

    private bool IsTriggerEvent()
    {
        int percent = UnityEngine.Random.Range(0, _maxChanceDecrease + 1);

        return _chanceDecrease >= percent;
    }

    private bool IsTriggerEventSpawn()
    {
        bool isTrigger = false;

        if (IsTriggerEvent())
        {
            Split?.Invoke(this);
            isTrigger = true;
        }

        return isTrigger;
    }

    private void Destroy()
    {
        Destroyed?.Invoke(this);
        Destroy(gameObject);
    }
}
