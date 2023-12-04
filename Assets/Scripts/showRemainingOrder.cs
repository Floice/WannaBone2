using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class showRemainingOrder : MonoBehaviour
{
    private TMP_Text tmpText;

    private void Update()
    {
        tmpText = GetComponent<TMP_Text>();
        UpdateInstructionCount();
    }

    public void UpdateInstructionCount()
    {
        int remainingSteps = GameManager.Instance.GetMaxCounter() - OrderController.instructionList.Count;
        tmpText.text = "Now remain " + remainingSteps.ToString();
    }
}
