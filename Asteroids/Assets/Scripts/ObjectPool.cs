using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool<T> where T : MonoBehaviour
{
    private List<T> totalObjectsInPool;
    private Queue<T> availableObjectsInPool;
    private int poolSizeLimit;
    private GameObject objectPrefab;
    private Transform containerTransform;

    public void Init(GameObject projectilePrefab, int poolSizeLimit, int poolInitialSize, Transform containerTransform)
    {
        this.objectPrefab = projectilePrefab;
        this.poolSizeLimit = poolSizeLimit;
        this.containerTransform = containerTransform;
        totalObjectsInPool = new List<T>();
        availableObjectsInPool = new Queue<T>();

        for (int i = 0; i < poolInitialSize; i++)
        {
            GrowPool();
        }

        SubscribeToEvents();
    }

    protected void ReturnToPool(T returnedObject)
    {
        returnedObject.gameObject.SetActive(false);
        availableObjectsInPool.Enqueue(returnedObject);
    }

    protected T GetFromPool()
    {
        if (availableObjectsInPool.Count < 1)
        {
            GrowPool();
        }

        if (availableObjectsInPool.Count > 0)
        {
            T objectToReturn = availableObjectsInPool.Dequeue();
            objectToReturn.gameObject.SetActive(true);
            return objectToReturn;
        }

        return default;
    }

    private void GrowPool()
    {
        if (totalObjectsInPool.Count < poolSizeLimit)
        {
            GameObject newGameObject = GameObject.Instantiate(objectPrefab);
            newGameObject.transform.parent = containerTransform;
            T newComponent = newGameObject.GetComponent<T>();
            totalObjectsInPool.Add(newComponent);
            ReturnToPool(newComponent);
        }
    }

    protected void OnObjectDestroyed(T destroyedObject)
    {
        ReturnToPool(destroyedObject);
    }

    protected abstract void SubscribeToEvents();
}
