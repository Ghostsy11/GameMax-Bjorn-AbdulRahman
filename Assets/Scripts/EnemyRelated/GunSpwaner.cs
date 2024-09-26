using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSpwaner : MonoBehaviour
{
    public GameObject[] _gameObjects;
    public Vector3 _SpawnValue;
    public float _SpawnWait;
    public float _SpawnMost;
    public float _SpawnLeastWait;
    public int _StartsWait;
    public bool _Stop = false;
    int RandomEnemy;
    private void Start()
    {
        StartCoroutine(waitSpawner());

    }

    private void Update()
    {

        _SpawnWait = Random.Range(_SpawnLeastWait, _SpawnMost);


    }

    public IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(_StartsWait);

        while (!_Stop)
        {
            RandomEnemy = Random.Range(0, _gameObjects.Length);
            Vector3 spwanPos = new Vector3(Random.Range(-_SpawnValue.x, _SpawnValue.x), _SpawnValue.y, Random.Range(-_SpawnValue.z, _SpawnValue.z));
            Instantiate(_gameObjects[RandomEnemy], spwanPos + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
            yield return new WaitForSeconds(_SpawnWait);
        }

    }
}
