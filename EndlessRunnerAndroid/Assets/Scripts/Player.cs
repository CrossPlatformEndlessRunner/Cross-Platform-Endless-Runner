using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    private SpriteRenderer      playerSprite = null;
    private bool                isAlive = true;
    private Vector3             startPosition;

    // The speed at which the player moves towards the startPosition after passing the distance threshold.
    public float                returnToPosSpeed = 4.0f;

    // Distance threshold the player must pass before they being to move towards the startPosition.
    public float                positionAdjustmentThreshold = 1.0f;

    // Use this for initialization
    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        startPosition = transform.position;
        startPosition.y = -2.8f;    //ground height TODO: set this properly
    }

    // Update is called once per frame
    void Update()
    {

    }



    // TODO: Fix not being able to jump whilst position is being adjusted.
    void OnCollisionStay2D(Collision2D other)
    {
        if (isAlive)
        {
            if (other.collider.CompareTag("Ground"))
            {
                float step = returnToPosSpeed * Time.deltaTime;
                Debug.Log(Vector3.Distance(startPosition, transform.position));

                if (transform.position.x - startPosition.x >= positionAdjustmentThreshold)
                {
                    transform.position = new Vector3(Mathf.MoveTowards(transform.position.x, startPosition.x, step), transform.position.y, transform.position.z);
                }
                //OLD CODE
                //if(Vector3.Distance(startPosition, transform.position) >= positionAdjustmentThreshold)
                //{
                //    transform.position = Vector3.MoveTowards(transform.position, startPosition, step);
                //}
            }
        }
    }

    public bool IsAlive
    {
        get { return isAlive; }
        set { isAlive = value; }
    }

}