using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpAndDown : MonoBehaviour
{
    public float speed;
    public float waitTime;
    public Transform[] movePos;
    private int i = 0;
    private bool movingUp = true;
    public float wait;
    private OrderController orderController;
    // Start is called before the first frame update
    void Start()
    {
        orderController = FindObjectOfType<OrderController>();
        wait = waitTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Monster>().isAttacking == false && orderController.isRunning==true && gameObject.GetComponent<Monster>().state!=3)
        {
            transform.position = Vector2.MoveTowards(transform.position, movePos[i].position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, movePos[i].position) < 0.1f)
            {
                if (waitTime > 0)
                {
                    waitTime -= Time.deltaTime;
                }
                else
                {
                    if (movingUp)
                    {
                        movingUp = false;
                    }
                    else
                    {
                        movingUp = true;
                    }
                    if (i == 0)
                    {
                        i = 1;
                    }
                    else
                    {
                        i = 0;
                    }
                    waitTime = wait;
                }
            }
        }
    }
}
