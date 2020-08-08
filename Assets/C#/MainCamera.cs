using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;



public class MainCamera : MonoBehaviour
{

    float originX, originY, originZ;
    Character nowPlay;
    

    // Start is called before the first frame update



    void Start()
    {
        


    }

    public float speed = 0.1f;

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKey(KeyCode.RightArrow))
        {
            canvasController.Instance.menuHide();
            canvasController.Instance.showReturn();
            transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            canvasController.Instance.menuHide();
            canvasController.Instance.showReturn();
            transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            canvasController.Instance.menuHide();
            canvasController.Instance.showReturn();
            transform.position = new Vector3(transform.position.x, transform.position.y , transform.position.z - speed);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            canvasController.Instance.menuHide();
            canvasController.Instance.showReturn();
            transform.position = new Vector3(transform.position.x, transform.position.y , transform.position.z + speed);
        }
        if (Input.GetKey(KeyCode.Z)) {
            CameraReturn();
            canvasController.Instance.hideReturn();
            canvasController.Instance.menuShow();
        }
        */
        nowPlay = GameObject.Find("CharacterOrder").GetComponent<CharacterOrder>().characters[0];
        originX = nowPlay.pos.x;
        originY = nowPlay.pos.y + 40.0f;
        originZ = nowPlay.pos.z - 30.0f;

        Camera.main.transform.position = new Vector3(originX, originY, originZ);








    }

    public void CameraReturn() {

        nowPlay = GameObject.Find("CharacterOrder").GetComponent<CharacterOrder>().characters[0];
        originX = nowPlay.pos.x;
        originY = nowPlay.pos.y + 40.0f;
        originZ = nowPlay.pos.z - 30.0f;
        
        Camera.main.transform.position = new Vector3(originX, originY, originZ);
    }
}
