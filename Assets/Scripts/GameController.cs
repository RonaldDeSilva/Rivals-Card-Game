using UnityEngine;

public class GameController : MonoBehaviour
{
    private GameObject InHand;
    private GameObject Deck;
    private GameObject Discard;
    public int HandSize;

    void Start()
    {
        InHand = GameObject.Find("InPlay");
        Deck = GameObject.Find("Deck");
        Discard = GameObject.Find("Discard");
        DrawCardsToHand();
    }

    void Update()
    {
        //dfaeafefad

    }

    public void DrawCardsToHand()
    {
        
        var DeckCardsNum = Deck.transform.childCount;
        var DiscardNum = Discard.transform.childCount;
        if (DeckCardsNum >= HandSize)
        {
            var NumChosen = 0;
            while (NumChosen < 5)
            {
                DeckCardsNum = Deck.transform.childCount;
                GameObject[] DeckCards = new GameObject[DeckCardsNum];
                for (int j = 0; j < DeckCardsNum; j++)
                {
                    DeckCards[j] = Deck.transform.GetChild(j).gameObject;
                }
                var card = Random.Range(0, DeckCardsNum);
                if (DeckCards[card] != null)
                {
                    var obj = DeckCards[card];
                    obj.transform.parent = InHand.transform;
                    obj.GetComponent<CardBehavior>().CardNum = NumChosen;
                    obj.GetComponent<CardBehavior>().MoveToPosition();
                    NumChosen++;
                }
            }
        }
        else if (DiscardNum > 0)
        {
            for (int i = DiscardNum - 1; i > -1; i--)
            {
                var obj2 = Discard.transform.GetChild(i);
                obj2.transform.parent = Deck.transform;
                obj2.transform.localPosition = Vector3.zero;
            }
            DrawCardsToHand();
        }
    }
}
