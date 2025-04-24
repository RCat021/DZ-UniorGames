using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBlastInfo : MonoBehaviour
{
    [SerializeField] private float _minExplosionRadius = 100.0f;
    [SerializeField] private float _minExplosionForce = 100.0f;

    [SerializeField] private float explosionRadiusMultiplier = 2;
    [SerializeField] private float explosionForceMultiplier = 2;

    private  float _explosionRadius;
    private float _explosionForce;

    private void Awake() 
    { 
        _explosionRadius = _minExplosionRadius;
        _explosionForce = _minExplosionForce;
    }

    public CubeBlastInfo GetCopyCubeBlastInfo()
    {
        CubeBlastInfo cubeBlastInfo = new CubeBlastInfo();

        cubeBlastInfo._explosionRadius = _explosionRadius;
        cubeBlastInfo._explosionForce = _explosionForce;

        return cubeBlastInfo;
    }

    public void UpdateExplosionData(CubeBlastInfo oldInfo)
    {
        _explosionRadius = oldInfo.GetRadius() * explosionRadiusMultiplier;
        _explosionForce = oldInfo.GetForce() * explosionForceMultiplier;
    }

    public float GetRadius() => _explosionRadius;

    public float GetForce() => _explosionForce;
}
