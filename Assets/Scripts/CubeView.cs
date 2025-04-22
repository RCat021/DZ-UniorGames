using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
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
        int percent = Random.Range(0, _maxChanceDecrease + 1);

        if (_chanceDecrease >= percent)
            isTrigger = true;

        return isTrigger;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
