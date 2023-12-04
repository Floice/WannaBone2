using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Altar : MonoBehaviour
{
    public Sprite normal;
    public Sprite bone;
    public int state=0; //0祭坛,1骨头
    public int sacrifice;
    public bool random = false;
    public int randomMax;
    public int randomMin;
    public int randomTime;
    private TMP_Text number;

    public float attackRange;
    private GameObject[] monsters;
    private GameObject[] players;
    // Start is called before the first frame update
    void Start()
    {
        number = GetComponentInChildren<TMP_Text>();
        number.text = sacrifice.ToString();
        if (random == true)
        {
            number.text = "?";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (state == 0)
        {
            //杀怪物
            monsters = GameObject.FindGameObjectsWithTag("monster");
            if (monsters != null)
            {
                foreach (GameObject monster in monsters)
                {
                    //怪物要醒着
                    if (monster.GetComponent<Monster>().state != 3)
                    {
                        float distance = Vector3.Distance(transform.position, monster.transform.position);
                        if (distance <= attackRange)
                        {
                            monster.GetComponent<Monster>().changeToFlame();
                            sacrifice -= 1;
                            number.text = sacrifice.ToString();
                        }
                    }
                }
            }
            //杀玩家
            players = GameObject.FindGameObjectsWithTag("player");
            if (players != null)
            {
                foreach (GameObject player in players)
                {
                    //狗要活着
                    if (player.GetComponent<Dog>().state != 1)
                    {
                        float distance = Vector3.Distance(transform.position, player.transform.position);
                        if (distance <= attackRange)
                        {
                            player.GetComponent<LoseCondition>().lose();
                            sacrifice -= 1;
                            number.text = sacrifice.ToString();
                        }
                    }
                }
            }
            if (sacrifice <= 0)
            {
                changeToBone();
                number.text = "";
            }
        }
    }

    public void changeToNormal()
    {
        GetComponent<SpriteRenderer>().sprite = normal;
        state = 0;
    }

    public void changeToBone()
    {
        GetComponent<SpriteRenderer>().sprite = bone;
        transform.GetChild(0).gameObject.SetActive(false);
        transform.localScale = new Vector3(0.15f,0.15f,0.15f);
        state = 1;
    }
    public void randomSacrifice()
    {
        if (random == true && state==0)
        {
            sacrifice = Random.Range(randomMin/randomTime, (randomMax+randomTime)/randomTime) * randomTime;
            number.text = sacrifice.ToString();
        }
    }
}
