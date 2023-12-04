using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakIfCondition : MonoBehaviour
{   
    private int thisLinenum;
    private int Ifcount = 0;
    // Start is called before the first frame update
    void Start()
    {
        string parentObjectName = transform.parent.name;
        char lastChar = parentObjectName[parentObjectName.Length - 1];
        char last2Char = parentObjectName[parentObjectName.Length - 2];
        if(char.IsDigit(last2Char)){
            string lastTwoChars = parentObjectName.Substring(parentObjectName.Length - 2, 2);
            thisLinenum = int.Parse(lastTwoChars.ToString());
        }else{
            thisLinenum = int.Parse(lastChar.ToString());
        }
        //print("ssssssssssssssssssssssssssssssssssssss");
        //print(Wbcount);
        OrderController orderController = FindObjectOfType<OrderController>();
        foreach (string instruction in OrderController.instructionList)
        {
            if (instruction=="If Break")
            {
                Ifcount++;
            }
        }
        print("第" + Ifcount + "个If Break在第" + thisLinenum + "行");
        if (OrderController.IfBreakList.Count > Ifcount)
        {
            OrderController.IfBreakList[Ifcount] = thisLinenum ;
        }
        else
        {
            OrderController.IfBreakList.Add(thisLinenum );
        }
    }


}
