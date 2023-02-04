using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{       
    public List<Card> deck = new List<Card>();//卡堆
    public Transform[] cardSlots;// 卡槽位置
    public bool[] availableCardSlots;//卡槽false为满，true为空

    public TMP_Text deckSizeText;

    public void Drawcard()//随机抽卡
    {
        print("抽！");
        if(deck.Count>=1)
        {
            Card randCard = deck[Random.Range(0, deck.Count)];

            for (int i=0;i<availableCardSlots.Length; i++)//每个槽位试一遍
            {
                if(availableCardSlots[i]==true)//如果卡槽是空的
                {
                    randCard.gameObject.SetActive(true);
                    randCard.transform.position = cardSlots[i].position;//把牌堆里的卡打开放进去
                    availableCardSlots[i] = false;//此卡槽满了
                    deck.Remove(randCard);//从牌堆拿走
                    return;
                }
            }
        }
    }




    void Start()
    {
        
    }

    void Update()
    {
        deckSizeText.text = deck.Count.ToString();
    }
}
