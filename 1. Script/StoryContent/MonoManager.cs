using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MonoManager : MonoBehaviour
{
    Dictionary<int, string[]> monoTalkData;

    private void Awake()
    {
        monoTalkData = new Dictionary<int, string[]>();
        stackYumitalk_1();
        stackYumitalk_2();
        stackGangtalk_1();
        stackGangtalk_2();
        endingGuardtalk_1();
        endingYumitalk_1();
        endingFathertalk_1();
    }

    /*첫번째 스토리씬 Yumi대사*/
    void stackYumitalk_1()
    {
        /*first Main Story*/
        monoTalkData.Add(1, new string[] { "아버지의 실종 소식...", "아버지는 북한에서 내려온 간첩이었다.", "하지만... 내가 태어나고 자라면서","아버지는 북한을 배신할 마음을 가지셨다.", "남한에 정착하는 장밋빛 미래를 꿈꾼 것이다.", "오로지 나의 행복을 위해서...", "그런데 뭔가를 준비하던 아버지가 실종되었다.", "왜?", "진실을 찾아야만 해..."});
        monoTalkData.Add(2, new string[] { "이 분은 믿을 만한 국정원 아저씨", "아버지의 가치관이 바뀌는데 큰 도움을 주신 분이다.", "그의 말대로라면 경찰이 나를 잡을거야.", "당장 도망가야만 해!" });
    }

    /*두번째 스토리씬 Yumi대사*/
    void stackYumitalk_2()
    {
        monoTalkData.Add(3, new string[] { "무사히 경찰의 눈을 피해 도망쳤다.", "아버지는 정말 죽은 것일까?", "아버지의 노트북에서 단서를 더 찾아야만 해", "분명히 나를 위해 무언가를 남겨두셨을꺼야.", "누구보다도 치밀하신 분이었으니까." });
        monoTalkData.Add(4, new string[] { "이광철 삼촌이 리광철이었다고?","이럴 수가.....", "그러니까 리광철은 변심할 지 모르는 간첩을 색출하기 위해서", "북한이 심어둔 이중 간첩이었던거야!", "아버지는 리광철에게 당했어!", "제길..... 지금 나에겐 시간이 없어."});
        monoTalkData.Add(5, new string[] { "노트북 대화 기록을 보면", "아버지는 리광철의 존재를 깨닫고, 자신이 리광철에게 당할 때를 대비해서", "진짜 남한 국정원에게 나를 지켜달라고 부탁했어.", "<color=#44DCCF>S c h o o l...</color>", "당장 학교로 뛰어가야만 해!" });
    }

    /*첫번째 스토리씬 광철 대사*/
    void stackGangtalk_1()
    {
        monoTalkData.Add(10, new string[] { "Yumi?", "Yumi 맞니?", "무사히 살아있었구나!","국정원 내에서 네 아버지의 정체를 알고", "너희 가족의 남한 정착을 돕고 있었는데...", "어찌된 일인지 경찰 측에서 너희 아버지를 제거했단다.", "곧, 간첩의 딸인 너를 잡으러 경찰이 충돌할거야.", "일단 피해!" });
    }

    /*두번째 스토리씬 광철 대사*/
    void stackGangtalk_2()
    {
        monoTalkData.Add(11, new string[] { "Yumi.....", "아직 무사히 살아있니?", ". . .", "크큭. . . 멍청한 부녀의 결말답군.", "대답이 없는걸 보니 이제서야 상황을 파악했나?", "자신을 도와주려는 남한 경찰을 열심히 따돌리는 꼴이란!", "아직도 살아있다면 내 손에 죽어줘야겠어.", "곧 이중 간첩들이 너를 잡으러갈거야.", "도망갈 수 있으면 도망가봐." });

    }

    /*엔딩씬 국정원 대사*/
    void endingGuardtalk_1()
    {
        //노멀엔딩,진엔딩 유미_공통대사
        monoTalkData.Add(100, new string[] { "저 멀리 남한 국정원의 세단이 보인다.", "어서 다가가서 말을 걸어보자."});
        //노멀엔딩,진엔딩 국정원_공통대사
        monoTalkData.Add(20, new string[] { "너가 Yumi로군!", "네 아버지는 남한을 위해서 모든 북한 자료를 우리 국정원에게 넘기려고 했지." });
        //노멀엔딩_if(비밀문서가 없으면)
        monoTalkData.Add(21, new string[] { "네 아버지 시신은 발견되지 않았지만 실종 기간이 길어지고 있어.", "마지막 메시지 기록도 실종 전에 보내진거 같더군.", "일단 네 아버지 부탁대로 일급 공작원이었던 간첩의 딸 Yumi를", "우리 남한 국정원의 보호 아래 두도록 한다.", "그래도 국가의 보호 아래 사는 것이 너희 아버지의 마지막 부탁이었으니까." });
        //진엔딩_if(비밀문서가 있으면)
        monoTalkData.Add(23, new string[] { ". . . ! 이건 <color=#44DCCF>핵심 이중 간첩들의 신호집. . .!</color>", "Yumi 너는 일급 공작원이었던 자의 딸답게", "수색 능력이 뛰어나.", "우리 남한 국정원과 함께 진실을 추적하지 않겠나?", "평범한 학생의 삶은 힘들겠지만. . ." });

        //노멀엔딩,진엔딩 국정원_공통대사
        monoTalkData.Add(22, new string[] { "이제 차에 타도록 하지." });
        monoTalkData.Add(26, new string[] { "이제 차에 타도록 하지." });
    }
    /*엔딩씬 유미와 대사*/
    void endingYumitalk_1()
    {
        //노멀엔딩
        monoTalkData.Add(101, new string[] { "감사합니다. . .", "저는 평범한 남한의 학생으로 살기는 어렵겠죠. . .", "하지만 이게 최선인 것 같네요."});
        //진엔딩
        monoTalkData.Add(102, new string[] { ". . .", "좋아요. . ! 전 아버지가 어딘가에 꼭 살아계실 것이라 믿어요.", "저는 계속해서 진실을 찾기 위해 달릴거예요." });
    }
    void endingFathertalk_1()
    {
        monoTalkData.Add(50, new string[] { "Yumi. . .", "조금만 기다려줘 . . .", "안전한 때가 되면 다시 나타날게." });
    }

        public string GetMonoData(int _id, int str_Idx)
    {
        if (str_Idx == monoTalkData[_id].Length)
        {
            return null;
        }
        else
        {
            return monoTalkData[_id][str_Idx];
        }
    }


}
