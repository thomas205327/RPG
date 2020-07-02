using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanMovePlane : MonoBehaviour
{
    public Character Obj1;
    public Vector3 pos;
    public bool moveLock;

    // Start is called before the first frame update
    void Start()
    {
        moveLock = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        if (moveLock == true)
        {
            Obj1.move(pos.x, pos.z);
        }
    }
}
