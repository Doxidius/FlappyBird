using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooler : MonoBehaviour
{
    [SerializeField] private List<GameObject> pooledObjects;
    [SerializeField] private GameObject objectToPool;
    [SerializeField] private int amountToPool;

    private void Start()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(objectToPool);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }

    }

    public void ResetPooler()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            pooledObjects[i].SetActive(false);
        }
    }

    public List<GameObject> GetListOfObjects()
    {
        return pooledObjects;
    }

    public GameObject GetPooledObject()
    {
        
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
           
        return null;
    }

}
