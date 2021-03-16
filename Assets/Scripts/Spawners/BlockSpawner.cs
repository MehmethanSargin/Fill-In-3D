using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public static BlockSpawner instance;
    Vector3 blockPos = Vector3.zero;
    public Sprite sprite;
    public float size;
    public GameObject baseObj;
    Transform trans;
    public List<GameObject> createdCubes = new List<GameObject>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else 
        {
            Destroy(this.gameObject);
        }
        trans = GetComponent<Transform>();
        CreateBlockFromImage(trans);
    }
    public List<GameObject> CreateBlockFromImage(Transform transform)
    {
        for (int x = 0; x < sprite.texture.width; x++)
        {
            for (int y = 0; y < sprite.texture.height; y++)
            {
                Color color = sprite.texture.GetPixel(x, y);
                if (color.a == 0)
                {
                    continue;
                }
                blockPos = new Vector3(
                    size * (x - (sprite.texture.width * .5f)),
                    size * .5f,
                    size * (y - (sprite.texture.height * .5f)));

                GameObject cubeObj = Instantiate(baseObj, transform);
                cubeObj.transform.localPosition = blockPos;
                cubeObj.GetComponent<Renderer>().material.color = color;
                cubeObj.transform.localScale = Vector3.one * size;
                createdCubes.Add(cubeObj);
            }
        }
        return createdCubes;
    }

}
