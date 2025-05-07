using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public GameObject ballPrefab;
    public int poolSize = 10;
    public Transform poolOneParent;
    public Transform poolTwoParent;
    private GameObject[] pool;
    void Start()
    {
        pool = new GameObject[poolSize];

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(ballPrefab);
            obj.SetActive(false);                         
            obj.transform.SetParent(poolOneParent);        
            pool[i] = obj;
        }
    }
    public GameObject GetBallFromPool()
    {
      for (int i = 0; i < pool.Length; i++)
        {
            if (!pool[i].activeInHierarchy && pool[i].transform.parent == poolOneParent)
            {
                pool[i].SetActive(true);
                return pool[i];
            }
        }
        return null; 
    }
    public void MoveToSecondPool(GameObject obj)
    {
        obj.SetActive(false);                              
        obj.transform.SetParent(poolTwoParent);           
    }
}
