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
        storyData.Add(2000, new string[] { "아버지의 스마트폰이다.", "암호가 걸려있다... 배경 사진이 눈에 뛴다." });
        storyData.Add(3000, new string[] { "지구본이다.", "자세히 보니 특정 도시에 마크가 찍혀 있다." });

        /*Second Main Story*/
        storyData.Add(1000, new string[] { "아버지가 즐겨 쓰던 노트북이다.", "암호 힌트 : 세상에서 가장 사랑하는" });
        storyData.Add(4000, new string[] { "각진 서류가방이다.", "숫자 암호가 걸려있다." });

        /*Normal item*/
        storyData.Add(0, new string[] { "평범한 램프이다." });
        storyData.Add(1, new string[] { "책으로 가득 찬 책장이다." });
        storyData.Add(2, new string[] { "작은 커피 테이블이다." });
        storyData.Add(3, new string[] { "평범한 의자이다." });
        storyData.Add(5, new string[] { "평범한 사무용 의자이다." });
        storyData.Add(7, new string[] { "아버지가 아꼈던 화분이다." });
        storyData.Add(8, new string[] { "평범한 실내용 화분이다." });
        storyData.Add(9, new string[] { "여러 종이가 나뒹구는 책장이다." });
        storyData.Add(10, new string[] { "평범한 전등이다." });
        storyData.Add(11, new string[] { "멋있는 Seoul의 풍경이 한 눈에 보인다." });
        storyData.Add(13, new string[] { "멋있는 Seoul의 풍경이 한 눈에 보인다." });
        storyData.Add(14, new string[] { "깔끔한 흰색 쇼파이다." });
        storyData.Add(15, new string[] { "깔끔한 흰색 쇼파이다." });
        storyData.Add(16, new string[] { "아버지의 사무실을 더 탐색해보자." });
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
