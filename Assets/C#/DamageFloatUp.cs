using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageFloatUp : MonoBehaviour
{

    //private GameObject turnScript;            //回合控制腳本的引用

    //受到傷害單位的位置
    private Vector3 takeDamageUnit3DPosition;
    private Vector2 takeDamageUnit2DPosition;
    private int updateLock = 0;

    void Start()
    {
        //turnScript = GameObject.Find("CharacterOrder");         //查找引用
    }

    public void beAttack(Character Obj1, int damage)
    {
        //計算傷害者的3D位置並轉化為屏幕2D位置
        takeDamageUnit3DPosition = Obj1.transform.position + new Vector3(0, 1, 0);         //適當上移修正位置
        takeDamageUnit2DPosition = Camera.main.WorldToScreenPoint(takeDamageUnit3DPosition);
        gameObject.GetComponent<RectTransform>().position = takeDamageUnit2DPosition;
        Debug.Log(takeDamageUnit2DPosition);

        //設置數字内容
        gameObject.GetComponent<Text>().text = "-" + damage;

        //延遲銷毀自身
        StartCoroutine("WaitAndDestory");
        updateLock = 1;
    }

    void Update()
    {
        if (updateLock == 1)
        {
            //向上漂浮控制
            gameObject.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition + new Vector2(0, 1);
        }
    }

    //延遲銷毀
    IEnumerator WaitAndDestory()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
        updateLock = 0;
    }
}
