using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnemyWhere : MonoBehaviour
{
    public string targetObjectName; // Ŀ�����������
    public GameObject addlinebtn;
    // Start is called before the first frame update
    void Start()
    {
        // ��ȡ��ť���
        Button button = GetComponent<Button>();
        // ��ӵ���¼�������
        button.onClick.AddListener(OnClick);
    }
    private void OnClick()
    {
        FindObjectOfType<ConfirmSelection>().currentButton = this;
    }
    public void CreatePrefabInParents(GameObject prefab)
    {
        Transform parent = transform.parent;

        while (parent != null)
        {
            Transform target = parent.Find(targetObjectName);
            if (target != null)
            {
                Vector3 targetPosition = target.position;
                target.gameObject.SetActive(false);
                // ����Ԥ����ʵ�������ø�����
                GameObject instantiatedPrefab = Instantiate(prefab, targetPosition, Quaternion.identity);
                instantiatedPrefab.transform.SetParent(target.parent);
                instantiatedPrefab.transform.localScale = Vector3.one;
                break;
            }

            parent = parent.parent;
        }
    }
    public void CommandButton(string instruction)
    {
        // ��ȡ��ǰ����
        Transform ppppp = transform.parent.parent.parent.parent.parent;
        TextMeshProUGUI LineNumberText = ppppp.GetComponentInChildren<TextMeshProUGUI>();
        string text = LineNumberText.text;
        int thisLineNumber = int.Parse(text);

        // ��ȡ OrderController �ű�
        OrderController orderController = FindObjectOfType<OrderController>();

        //print(instruction);
        // ��ָ����ӵ� OrderController ��ȫ�־�̬�б���
        orderController.AddInstruction(instruction, thisLineNumber);
    }
    public void Retract()
    {
        // ��ȡĿ������ĵ�ǰλ��
        Vector3 currentPosition = addlinebtn.transform.localPosition;

        // ��X��λ�����������ƶ�105
        float newX = currentPosition.x + 105f;
        float newY = currentPosition.y;
        float newZ = currentPosition.z;

        // �����µ�λ��
        Vector3 newPosition = new Vector3(newX, newY, newZ);
        addlinebtn.transform.localPosition = newPosition;
    }
}
