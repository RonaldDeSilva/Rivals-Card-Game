using UnityEngine;

public class GameController : MonoBehaviour
{
    private GameObject InPlay;
    private GameObject Deck;
    private GameObject Discard;

    void Start()
    {
        InPlay = GameObject.Find("InPlay");
        Deck = GameObject.Find("Deck");
        Discard = GameObject.Find("Discard");
        var DeckCardsNum = Deck.transform.childCount;
        GameObject[] DeckCards = new GameObject[DeckCardsNum + 1];
        Transform[] ts = Deck.GetComponentsInChildren<Transform>();
        var place = 0;
        foreach (Transform child in ts)
        {
            DeckCards[place] = child.gameObject;
            place++;
        }
        var NumChosen = 0;
        while (NumChosen < 5)
        {
            for (int i = 0; i < DeckCardsNum - 1; i++)
            {
                if (NumChosen < 5)
                {
                    var num = Random.Range(0, 10);
                    if (num < 3)
                    {
                        var obj = DeckCards[i];
                        obj.transform.parent = InPlay.transform;
                        obj.GetComponent<CardBehavior>().CardNum = NumChosen;
                        obj.GetComponent<CardBehavior>().MoveToPosition();
                        NumChosen++;
                    }
                }
            }
        }
    }

    void Update()
    {

    }
}
