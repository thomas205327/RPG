using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class canvasController : MonoBehaviour
{
    //public Character Obj1;
    public CharacterOrder characterOrder;
    public GameObject canvas;
    public GameObject move;
    public GameObject attack;
    public GameObject skill;
    public GameObject item;
    public GameObject end;
    public GameObject backToChar;
    public GameObject characterName;
    public GameObject hp;
    public GameObject sp;
    public Image image;
    public static canvasController Instance;

    // Start is called before the first frame update

    void Start()
    {
        Instance = this;
        move.GetComponent<Button>().onClick.AddListener(moveOnclick);
        attack.GetComponent<Button>().onClick.AddListener(attackOnclick);
        skill.GetComponent<Button>().onClick.AddListener(skillOnclick);
        item.GetComponent<Button>().onClick.AddListener(itemOnclick);
        end.GetComponent<Button>().onClick.AddListener(endOnclick);
        backToChar.GetComponent<Button>().onClick.AddListener(backToCharOnclick);
    }

    void Awake()
    {
        image.GetComponent<Image>().sprite = Resources.Load<Sprite>("white");
        //image = GetComponent<Image>();
        move.SetActive(false);
        attack.SetActive(false);
        skill.SetActive(false);
        item.SetActive(false);
        image.enabled = false;
        end.SetActive(false);
        backToChar.SetActive(false);
        characterName.SetActive(false);
        hp.SetActive(false);
        sp.SetActive(false);
    }

    public void menuShow()
    {
        move.SetActive(true);
        attack.SetActive(true);
        skill.SetActive(true);
        item.SetActive(true);
        image.enabled = true;
        end.SetActive(true);
        characterName.SetActive(true);
        hp.SetActive(true);
        sp.SetActive(true);
        //Debug.Log(Resources.Load<Sprite>(characterOrder.characters[0].image));
        image.GetComponent<Image>().sprite = Resources.Load<Sprite>(characterOrder.characters[0].image);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void moveOnclick()
    {
        Debug.Log("移動");
        Character Obj1 = characterOrder.characters[0];
        Obj1.moveDisplay(Obj1.moveDis);
    }

    public void attackOnclick()
    {
        Debug.Log("攻擊");
        Character Obj1 = characterOrder.characters[0];
        Obj1.attackDisplay(Obj1.attackDis);
    }

    public void skillOnclick()
    {
        Debug.Log("技能");
        Character Obj1 = characterOrder.characters[0];
        GameObject Order = GameObject.Find("CharacterOrder");
        Order.GetComponent<CharacterOrder>().movingdis();
    }

    public void itemOnclick()
    {
        Debug.Log("道具");
        Character Obj1 = characterOrder.characters[0];
        Obj1.moveDisplay(Obj1.moveDis);
    }

    public void endOnclick()
    {
        Debug.Log("結束");
        Character Obj1 = characterOrder.characters[0];
        Obj1.clearDisplay();
        characterOrder.orderChange();
        move.GetComponent<Button>().interactable = true;
        attack.GetComponent<Button>().interactable = true;
        skill.GetComponent<Button>().interactable = true;
        item.GetComponent<Button>().interactable = true;

       GameObject.Find("Main Camera").GetComponent<MainCamera>().CameraReturn();

    }

    public void menuHide() {
        move.SetActive(false);
        attack.SetActive(false);
        skill.SetActive(false);
        item.SetActive(false);
        image.enabled = false;
        end.SetActive(false);
        characterName.SetActive(false);
        hp.SetActive(false);
        sp.SetActive(false);
        //Debug.Log(Resources.Load<Sprite>(characterOrder.characters[0].image));
        image.GetComponent<Image>().sprite = Resources.Load<Sprite>(characterOrder.characters[0].image);

    }

    public void showReturn() {
        
        backToChar.SetActive(true);

    }

    public void hideReturn()
    {

        backToChar.SetActive(false);

    }

    public void backToCharOnclick() {

        GameObject.Find("Main Camera").GetComponent<MainCamera>().CameraReturn();
        hideReturn();
    }
}
