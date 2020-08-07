using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{

    float originX, originY, originZ;
    Character nowPlay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        nowPlay = GameObject.Find("CharacterOrder").GetComponent<CharacterOrder>().characters[0];
        originX = nowPlay.pos.x;
        originY = nowPlay.pos.y + 10.0f;
        originZ = nowPlay.pos.z;

        this.transform.position = new Vector3(originX, originY, originZ);
    }
}
