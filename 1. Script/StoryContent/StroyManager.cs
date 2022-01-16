using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StroyManager : MonoBehaviour
{
    Dictionary<int, string[]> storyData;


    private void Awake()
    {
        storyData = new Dictionary<int, string[]>();

        stackData();

    }
    void stackData()
    {
        /*first Main Story*/
        storyData.Add(2000, new string[] { "�ƹ����� ����Ʈ���̴�.", "��ȣ�� �ɷ��ִ�... ��� ������ ���� �ڴ�." });
        storyData.Add(3000, new string[] { "�������̴�.", "�ڼ��� ���� Ư�� ���ÿ� ��ũ�� ���� �ִ�." });

        /*Second Main Story*/
        storyData.Add(1000, new string[] { "�ƹ����� ��� ���� ��Ʈ���̴�.", "��ȣ ��Ʈ : ���󿡼� ���� ����ϴ�" });
        storyData.Add(4000, new string[] { "���� ���������̴�.", "���� ��ȣ�� �ɷ��ִ�." });

        /*Normal item*/
        storyData.Add(0, new string[] { "����� �����̴�." });
        storyData.Add(1, new string[] { "å���� ���� �� å���̴�." });
        storyData.Add(2, new string[] { "���� Ŀ�� ���̺��̴�." });
        storyData.Add(3, new string[] { "����� �����̴�." });
        storyData.Add(5, new string[] { "����� �繫�� �����̴�." });
        storyData.Add(7, new string[] { "�ƹ����� �Ʋ��� ȭ���̴�." });
        storyData.Add(8, new string[] { "����� �ǳ��� ȭ���̴�." });
        storyData.Add(9, new string[] { "���� ���̰� ���߱��� å���̴�." });
        storyData.Add(10, new string[] { "����� �����̴�." });
        storyData.Add(11, new string[] { "���ִ� Seoul�� ǳ���� �� ���� ���δ�." });
        storyData.Add(13, new string[] { "���ִ� Seoul�� ǳ���� �� ���� ���δ�." });
        storyData.Add(14, new string[] { "����� ��� �����̴�." });
        storyData.Add(15, new string[] { "����� ��� �����̴�." });
        storyData.Add(16, new string[] { "�ƹ����� �繫���� �� Ž���غ���." });
    }


    public string GetData(int _id, int str_Idx)
    {

        if (str_Idx == storyData[_id].Length)
        {
            return null;
        }
        else
        {
            return storyData[_id][str_Idx];
        }
    }

}
