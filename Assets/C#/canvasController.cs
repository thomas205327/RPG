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
    public GameObject image;
    public static canvasController Instance;
    // Start is called before the first frame update

    void Start()
    {
        Instance = this;
        move.GetComponent<Button>().onClick.AddListener(moveOnclick);
        attack.GetComponent<Button>().onClick.AddListener(attackOnclick);
        skill.GetComponent<Button>().onClick.AddListener(skillOnclick);
        item.GetComponent<Button>().onClick.AddListener(itemOnclick);
    }

    void Awake()
    {
        move.SetActive(false);
        attack.SetActive(false);
        skill.SetActive(false);
        item.SetActive(false);
        image.SetActive(false);
    }

    public void menuShow()
    {
        move.SetActive(true);
        attack.SetActive(true);
        skill.SetActive(true);
        item.SetActive(true);
        image.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void moveOnclick()
    {
        Character Obj1 = characterOrder.characters[0];
        Obj1.moveDisplay(Obj1.moveDis);
    }

    public void attackOnclick()
    {
        Character Obj1 = characterOrder.characters[0];
        Obj1.attackDisplay(Obj1.attackDis);
    }

    public void skillOnclick()
    {
        Character Obj1 = characterOrder.characters[0];
        Obj1.moveDisplay(Obj1.moveDis);
    }

    public void itemOnclick()
    {
        Character Obj1 = characterOrder.characters[0];
        Obj1.moveDisplay(Obj1.moveDis);
    }
}
