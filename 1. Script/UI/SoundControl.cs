using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundControl : MonoBehaviour
{
    public Image soundImg; //���� �̹���
    public Sprite off; //�ٲ���� �̹���
    public Sprite on;

    void Awake()
    {
        soundImg = GetComponent<Image>();

        if (PlayerPrefs.GetInt("Mute", 0) == 1)//������ �����ִٸ�
        {
            AudioListener.volume = 0;//�Ҹ� 0���� �ʱ�ȭ
            soundImg.sprite = off;
        }
        else//������ �����ִٸ�
        {
            AudioListener.volume = 1;//�Ҹ� 1�� �ʱ�ȭ
            soundImg.sprite = on;
        }
    }

    void ChangeImage()
    {
        /*
        https://netpilgrim.net/778?category=659393
        */
        Debug.Log("�� ����� ���װ� �� �ֳ�");
            if (PlayerPrefs.GetInt("Mute", 0) == 0)//������ �����ִٸ�
            {
            Debug.Log("�� 111��");
            AudioListener.volume = 0;//�Ҹ����̰�
                PlayerPrefs.SetInt("Mute", 1);//��Ʈ���·� ��ȯ
                soundImg.sprite = off;
            }
            else//������ �����ִٸ�
            {
            Debug.Log("��222��");
            AudioListener.volume = 1;//�Ҹ�Ű���
                PlayerPrefs.SetInt("Mute", 0);//��ƮǮ��
                soundImg.sprite = on;
            }
        PlayerPrefs.Save();

    }

}
