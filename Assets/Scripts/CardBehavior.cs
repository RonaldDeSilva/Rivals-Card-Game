using UnityEngine;

public class CardBehavior : MonoBehaviour
{
    private bool FollowMouse = false;
    public float[] Xvals;
    public int CardNum;
    private GameObject InPlay;
    private GameObject Discard;

    void Start()
    {
        InPlay = GameObject.Find("InPlay");
        Discard = GameObject.Find("Discard");
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
        if (transform.parent.name == InPlay.name)
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
