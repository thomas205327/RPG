using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuzePlane : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver()
    {
        Character Obj1 = GameObject.Find("CharacterOrder").GetComponent<CharacterOrder>().characters[0];
        if (Obj1.skillDirection == 1)
        {
            GameObject[] planes;
            planes = GameObject.FindGameObjectsWithTag("MovePlane");
            int i;

            if (Mathf.Round(transform.position.x) == Mathf.Round(Obj1.pos.x) && Mathf.Round(transform.position.z) == Mathf.Round(Obj1.pos.z + 10))
            {
                Obj1.clearDisplay();
                
                for (i = 0; i < planes.Length; i++)
                {
                    if (Mathf.Round(planes[i].transform.position.x) == Mathf.Round(Obj1.pos.x) && Mathf.Round(planes[i].transform.position.z) == Mathf.Round(Obj1.pos.z + 10))
                    {
                        planes[i].GetComponent<MeshRenderer>().material.color = Color.red;
                    }
                    else if (Mathf.Round(planes[i].transform.position.x) == Mathf.Round(Obj1.pos.x - 10) && Mathf.Round(planes[i].transform.position.z) == Mathf.Round(Obj1.pos.z + 10))
                    {
                        planes[i].GetComponent<MeshRenderer>().material.color = Color.red;
                    }
                    else if (Mathf.Round(planes[i].transform.position.x) == Mathf.Round(Obj1.pos.x + 10) && Mathf.Round(planes[i].transform.position.z) == Mathf.Round(Obj1.pos.z + 10))
                    {
                        planes[i].GetComponent<MeshRenderer>().material.color = Color.red;
                    }
                    else if (Mathf.Round(planes[i].transform.position.x) == Mathf.Round(Obj1.pos.x) && Mathf.Round(planes[i].transform.position.z) == Mathf.Round(Obj1.pos.z + 20))
                    {
                        planes[i].GetComponent<MeshRenderer>().material.color = Color.red;
                    }
                    else if (Mathf.Round(planes[i].transform.position.x) == Mathf.Round(Obj1.pos.x - 10) && Mathf.Round(planes[i].transform.position.z) == Mathf.Round(Obj1.pos.z + 20))
                    {
                        planes[i].GetComponent<MeshRenderer>().material.color = Color.red;
                    }
                    else if (Mathf.Round(planes[i].transform.position.x) == Mathf.Round(Obj1.pos.x + 10) && Mathf.Round(planes[i].transform.position.z) == Mathf.Round(Obj1.pos.z + 20))
                    {
                        planes[i].GetComponent<MeshRenderer>().material.color = Color.red;
                    }
                }
            }
            else if (Mathf.Round(transform.position.x) == Mathf.Round(Obj1.pos.x + 10) && Mathf.Round(transform.position.z) == Mathf.Round(Obj1.pos.z))
            {
                Obj1.clearDisplay();
                for (i = 0; i < planes.Length; i++)
                {
                    if (Mathf.Round(planes[i].transform.position.x) == Mathf.Round(Obj1.pos.x + 10) && Mathf.Round(planes[i].transform.position.z) == Mathf.Round(Obj1.pos.z))
                    {
                        planes[i].GetComponent<MeshRenderer>().material.color = Color.red;
                    }
                    else if (Mathf.Round(planes[i].transform.position.x) == Mathf.Round(Obj1.pos.x + 10) && Mathf.Round(planes[i].transform.position.z) == Mathf.Round(Obj1.pos.z))
                    {
                        planes[i].GetComponent<MeshRenderer>().material.color = Color.red;
                    }
                    else if (Mathf.Round(planes[i].transform.position.x) == Mathf.Round(Obj1.pos.x + 10) && Mathf.Round(planes[i].transform.position.z) == Mathf.Round(Obj1.pos.z + 10))
                    {
                        planes[i].GetComponent<MeshRenderer>().material.color = Color.red;
                    }
                    else if (Mathf.Round(planes[i].transform.position.x) == Mathf.Round(Obj1.pos.x + 20) && Mathf.Round(planes[i].transform.position.z) == Mathf.Round(Obj1.pos.z + 10))
                    {
                        planes[i].GetComponent<MeshRenderer>().material.color = Color.red;
                    }
                    else if (Mathf.Round(planes[i].transform.position.x) == Mathf.Round(Obj1.pos.x + 20) && Mathf.Round(planes[i].transform.position.z) == Mathf.Round(Obj1.pos.z - 10))
                    {
                        planes[i].GetComponent<MeshRenderer>().material.color = Color.red;
                    }
                    else if (Mathf.Round(planes[i].transform.position.x) == Mathf.Round(Obj1.pos.x + 20) && Mathf.Round(planes[i].transform.position.z) == Mathf.Round(Obj1.pos.z - 10))
                    {
                        planes[i].GetComponent<MeshRenderer>().material.color = Color.red;
                    }
                }
            }
            else if (Mathf.Round(transform.position.x) == Mathf.Round(Obj1.pos.x - 10) && Mathf.Round(transform.position.z) == Mathf.Round(Obj1.pos.z))
            {
                Obj1.clearDisplay();
                for (i = 0; i < planes.Length; i++)
                {
                    if (Mathf.Round(planes[i].transform.position.x) == Mathf.Round(Obj1.pos.x - 10) && Mathf.Round(planes[i].transform.position.z) == Mathf.Round(Obj1.pos.z + 10))
                    {
                        planes[i].GetComponent<MeshRenderer>().material.color = Color.red;
                    }
                    else if (Mathf.Round(planes[i].transform.position.x) == Mathf.Round(Obj1.pos.x - 10) && Mathf.Round(planes[i].transform.position.z) == Mathf.Round(Obj1.pos.z - 10))
                    {
                        planes[i].GetComponent<MeshRenderer>().material.color = Color.red;
                    }
                    else if (Mathf.Round(planes[i].transform.position.x) == Mathf.Round(Obj1.pos.x - 10) && Mathf.Round(planes[i].transform.position.z) == Mathf.Round(Obj1.pos.z))
                    {
                        planes[i].GetComponent<MeshRenderer>().material.color = Color.red;
                    }
                    else if (Mathf.Round(planes[i].transform.position.x) == Mathf.Round(Obj1.pos.x - 20) && Mathf.Round(planes[i].transform.position.z) == Mathf.Round(Obj1.pos.z))
                    {
                        planes[i].GetComponent<MeshRenderer>().material.color = Color.red;
                    }
                    else if (Mathf.Round(planes[i].transform.position.x) == Mathf.Round(Obj1.pos.x - 20) && Mathf.Round(planes[i].transform.position.z) == Mathf.Round(Obj1.pos.z - 10))
                    {
                        planes[i].GetComponent<MeshRenderer>().material.color = Color.red;
                    }
                    else if (Mathf.Round(planes[i].transform.position.x) == Mathf.Round(Obj1.pos.x - 20) && Mathf.Round(planes[i].transform.position.z) == Mathf.Round(Obj1.pos.z + 10))
                    {
                        planes[i].GetComponent<MeshRenderer>().material.color = Color.red;
                    }
                }
            }
            else if (Mathf.Round(transform.position.x) == Mathf.Round(Obj1.pos.x) && Mathf.Round(transform.position.z) == Mathf.Round(Obj1.pos.z - 10))
            {
                Obj1.clearDisplay();
                for (i = 0; i < planes.Length; i++)
                {
                    if (Mathf.Round(planes[i].transform.position.x) == Mathf.Round(Obj1.pos.x) && Mathf.Round(planes[i].transform.position.z) == Mathf.Round(Obj1.pos.z - 10))
                    {
                        planes[i].GetComponent<MeshRenderer>().material.color = Color.red;
                    }
                    else if (Mathf.Round(planes[i].transform.position.x) == Mathf.Round(Obj1.pos.x - 10) && Mathf.Round(planes[i].transform.position.z) == Mathf.Round(Obj1.pos.z - 10))
                    {
                        planes[i].GetComponent<MeshRenderer>().material.color = Color.red;
                    }
                    else if (Mathf.Round(planes[i].transform.position.x) == Mathf.Round(Obj1.pos.x + 10) && Mathf.Round(planes[i].transform.position.z) == Mathf.Round(Obj1.pos.z - 10))
                    {
                        planes[i].GetComponent<MeshRenderer>().material.color = Color.red;
                    }
                    else if (Mathf.Round(planes[i].transform.position.x) == Mathf.Round(Obj1.pos.x) && Mathf.Round(planes[i].transform.position.z) == Mathf.Round(Obj1.pos.z - 20))
                    {
                        planes[i].GetComponent<MeshRenderer>().material.color = Color.red;
                    }
                    else if (Mathf.Round(planes[i].transform.position.x) == Mathf.Round(Obj1.pos.x - 10) && Mathf.Round(planes[i].transform.position.z) == Mathf.Round(Obj1.pos.z - 20))
                    {
                        planes[i].GetComponent<MeshRenderer>().material.color = Color.red;
                    }
                    else if (Mathf.Round(planes[i].transform.position.x) == Mathf.Round(Obj1.pos.x + 10) && Mathf.Round(planes[i].transform.position.z) == Mathf.Round(Obj1.pos.z - 20))
                    {
                        planes[i].GetComponent<MeshRenderer>().material.color = Color.red;
                    }
                }
            }
        }
    }
}
