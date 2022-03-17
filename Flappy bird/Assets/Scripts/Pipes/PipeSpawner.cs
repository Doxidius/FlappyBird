using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _pipe;
    [SerializeField] private float _bottomBorder;
    [SerializeField] private float _upperBorder;
    [SerializeField] private Transform _spawnPoint;


    [SerializeField] private float _speed;

    [SerializeField] private Pooler _pooler;

    private List<GameObject> pooled;

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private void Update()
    {
        if (pooled == null)
            return;

        for(int i = 0; i< pooled.Count; i++)
        {
            if (pooled[i].activeInHierarchy)
            {
                pooled[i].transform.Translate(-_speed*Time.deltaTime,0,0);
            }
        }
    }

    public void ResetSpawner()
    {
        StopCoroutine(Spawner());
        _pooler.ResetPooler();
    }

    private IEnumerator Spawner()
    {
        while (true)
        {
            GameObject pipe = _pooler.GetPooledObject();
            if (pipe != null)
            {
                pipe.transform.position = new Vector2(_spawnPoint.position.x, Random.Range(_bottomBorder, _upperBorder));
                pipe.SetActive(true);
                pooled = _pooler.GetListOfObjects();
            }
            yield return new WaitForSeconds(2f);
        }
        
    }


}
