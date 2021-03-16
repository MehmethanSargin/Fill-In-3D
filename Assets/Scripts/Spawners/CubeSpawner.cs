using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject baseObj;
    public float size;
    public List<GameObject> spawnedObjects;
    private void Start()
    {
        GetCubes();
    }
    void GetCubes() 
    {
        spawnedObjects = new List<GameObject>();
        for (int i = 0; i <= BlockSpawner.instance.createdCubes.Count-1; i++)
        {
            GameObject cubeObj = Instantiate(baseObj, transform);
            spawnedObjects.Add(cubeObj);
            cubeObj.GetComponent<Renderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            cubeObj.transform.localScale = Vector3.one * size;
        }
        RepositionObjectsInOrder(0.2f, 0.2f, 0.2f);
    }
    public void RepositionObjectsInOrder(float xOffset, float yOffSet, float zOffset)
    {
        float x = 0;
        float y = 0;
        float z = 0;
        foreach (GameObject go in spawnedObjects)
        {
            if (x != 0 && x % 6 == 0)
            {
                x = 0;
                z++;
            }
            if (z != 0 && z % 6 == 0)
            {
                z = 0;
                y++;
            }
            Vector3 targetPos = new Vector3(x * xOffset +1.4f, (y + 1) * yOffSet, z * zOffset - 2f);
            go.transform.position = targetPos;
            x++;
        }
    }
}
