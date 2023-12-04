using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolVariableScript : MonoBehaviour
{
    public bool boolVariable1 = false;
    public bool boolVariable2 = false;
    public bool boolVariable3 = false;
    public bool boolVariable4 = false;

    public void SetBoolVariableTrue(int index)
    {
        switch (index)
        {
            case 1:
                boolVariable1 = true;
                break;
            case 2:
                boolVariable2 = true;
                print("2 has been opened");
                break;
            case 3:
                boolVariable3 = true;
                break;
            case 4:
                boolVariable4 = true;
                break;
            default:
                Debug.LogWarning("Invalid index. Please enter a value between 1 and 4.");
                break;
        }
    }

    public void SetBoolVariableFalse(int index)
    {
        switch (index)
        {
            case 1:
                boolVariable1 = false;
                break;
            case 2:
                boolVariable2 = false;
                break;
            case 3:
                boolVariable3 = false;
                break;
            case 4:
                boolVariable4 = false;
                break;
            default:
                Debug.LogWarning("Invalid index. Please enter a value between 1 and 4.");
                break;
        }
    }
}
