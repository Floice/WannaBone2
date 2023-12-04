using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakForCirculation : MonoBehaviour
{   
    private int thisLinenum;
    private int Fbcount = 0;
    // Start is called before the first frame update
    void Start()
    {
        string parentObjectName = transform.parent.name;
        char lastChar = parentObjectName[parentObjectName.Length - 1];
        thisLinenum = int.Parse(lastChar.ToString());
        //print("ssssssssssssssssssssssssssssssssssssss");
        //print(Fbcount);
        OrderController orderController = FindObjectOfType<OrderController>();
        foreach (string instruction in OrderController.instructionList)
        {
            if (instruction=="For Break")
            {
                Fbcount++;
                
            }
        }
        if (OrderController.ForBreakList.Count > Fbcount)
        {
            OrderController.ForBreakList[Fbcount] = thisLinenum;
        }
        else
        {
            OrderController.ForBreakList.Add(thisLinenum);
        }
    }


}
