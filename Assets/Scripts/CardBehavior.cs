using UnityEngine;

public class CardBehavior : MonoBehaviour
{
    private bool FollowMouse = false;
    public float[] Xvals;
    public int CardNum;
    private GameObject InHand;
    private GameObject Discard;
    private GameObject Controller;

    void Start()
    {
        InHand = GameObject.Find("InPlay");
        Discard = GameObject.Find("Discard");
        Controller = GameObject.Find("GameController");
    }

    void Update()
    {
        if (FollowMouse)
        {
            var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0f;
            transform.position = mouseWorldPos;
        }
    }

    private void OnMouseDown()
    {
        if (transform.parent.name == InHand.name)
        {
            if (FollowMouse)
            {
                FollowMouse = false;
                if (transform.position.y >= -0.4)
                {
                    //------------Do Card stuff here
                    //--
                    //--
                    //--
                    //--
                    //--------------------------------
                    transform.parent = Discard.transform;
                    transform.localPosition = new Vector3(0,0,0);
                    CardNum = 0;
                    if (InHand.transform.childCount == 0)
                    {
                        Controller.GetComponent<GameController>().DrawCardsToHand();
                    }
                }
                else
                {
                    transform.position = new Vector3(Xvals[CardNum], -2.2f, 0);
                }
            }
            else
            {
                FollowMouse = true;
            }
        }
    }

    public void MoveToPosition()
    {
        
        transform.position = new Vector3(Xvals[CardNum], -2.2f, 0);
        
    }
}
