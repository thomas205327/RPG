using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiritoPlane : MonoBehaviour
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
            if (Mathf.Round(transform.position.x) == Mathf.Round(Obj1.pos.x) && Mathf.Round(transform.position.z) == Mathf.Round(Obj1.pos.z + 10))
            {
                Obj1.clearDisplay();
                GetComponent<MeshRenderer>().material.color = Color.red;
                //GetComponent<CanMovePlane>().Obj1 = this;
            } 
            else if (Mathf.Round(transform.position.x) == Mathf.Round(Obj1.pos.x + 10) && Mathf.Round(transform.position.z) == Mathf.Round(Obj1.pos.z))
            {
                Obj1.clearDisplay();
                GetComponent<MeshRenderer>().material.color = Color.red;
            }
            else if (Mathf.Round(transform.position.x) == Mathf.Round(Obj1.pos.x - 10) && Mathf.Round(transform.position.z) == Mathf.Round(Obj1.pos.z))
            {
                Obj1.clearDisplay();
                GetComponent<MeshRenderer>().material.color = Color.red;
            }
            else if (Mathf.Round(transform.position.x) == Mathf.Round(Obj1.pos.x) && Mathf.Round(transform.position.z) == Mathf.Round(Obj1.pos.z - 10))
            {
                Obj1.clearDisplay();
                GetComponent<MeshRenderer>().material.color = Color.red;
            }
        }
    }
}
