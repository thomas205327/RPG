using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanMovePlane : MonoBehaviour
{
    public Character Obj1;
    public Object plane;
    public Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        pos.x = Mathf.Round(GetComponent<Transform>().position.x);
        pos.y = Mathf.Round(GetComponent<Transform>().position.y);
        pos.z = Mathf.Round(GetComponent<Transform>().position.z);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        if (GetComponent<MeshRenderer>().material.color == Color.blue)
        {
            Obj1.move(pos.x, pos.z);
        }
    }

    void OnMouseOver()
    {

    }
}
