using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    public Sprite normal;
    public Sprite flame;
    public float speed;
    public int state = 0;//0Õı³££¬1ËÀÍö£¬2»ñÊ¤
    public void changeToFlame()
    {
        GetComponent<SpriteRenderer>().sprite = flame;
        state = 1;
    }
}
