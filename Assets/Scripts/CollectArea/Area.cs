using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Area : MonoBehaviour
{
    Color color;
    Vector3 deneme;
    bool ısHere = true;
    private void Start()
    {
        color = GetComponent<MeshRenderer>().material.color;
        deneme = transform.position;
        gameObject.GetComponent<MeshRenderer>().material.color = Color.gray;
    }
    public Color getColor(GameObject other)
    {
        return other.GetComponent<Renderer>().material.color;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Block"))
        {
            other.GetComponent<Renderer>().material.color = color;
            if (other.gameObject)
            {
                if (ısHere)
                {
                    ısHere = false;
                    GetComponent<Collider>().enabled = false;
                    other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    other.GetComponent<Collider>().enabled = false;
                    other.gameObject.transform.position = new Vector3(deneme.x, deneme.y + 0.02f, deneme.z);
                    other.gameObject.layer = LayerMask.NameToLayer("CollectedBlock");
                }

            }

        }
    }
}