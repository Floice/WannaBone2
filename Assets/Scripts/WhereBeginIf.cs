using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhereBeginIf : MonoBehaviour
{   
    private int thisLinenum;
    private int count = 0;
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
        foreach (string instruction in OrderController.instructionList)
        {
            if (instruction=="leftup" || instruction == "rightup" || instruction == "rightdown" || instruction == "left" || instruction == "right" 
                || instruction == "Monsterbefore" || instruction=="leftdown" || instruction=="EnemyUp" || instruction == "EnemyDown" 
                || instruction =="Signal1Open" || instruction=="Signal2Open" || instruction=="Signal3Open" || instruction=="Signal4Open")
            {
                count++;
            }
        }
        print("thisLinenum");
        print("第" + count + "个if在第" + thisLinenum + "行");
        if (OrderController.IfinstructionList.Count > count)
        {
            OrderController.IfinstructionList[count] = thisLinenum ;
        }
        else
        {
            OrderController.IfinstructionList.Add(thisLinenum );
        }
    }
}
