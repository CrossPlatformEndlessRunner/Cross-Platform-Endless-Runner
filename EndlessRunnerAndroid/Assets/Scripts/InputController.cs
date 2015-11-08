//Author: Callum Buerckner 2015
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//attach to camera

//todo: make sure finger is moving during release -> so cannot swipe and hold waiting to jump

public class InputController : MonoBehaviour
{

    //lame struct to hold swipe direction, tried bitwise stuff but c# seems lame
    struct Swipe_Direction
    {
        public bool up, down, left, right;
        public void clear() { up = down = left = right = false; }
    };

    //player object
    [SerializeField]
    public Rigidbody2D player;

    /*
     * option fields i guess 
    */

    public Text touchStatusText = null;
    //jump height that player will jump
    public float m_jump_height;
    //placeholder
    public float m_boost_speed;
    //time before boost can activate again (seconds)
    public float m_time_between_boosts;
    //distance finger/mouse must be dragged before activation
    public float m_swipe_distance;
    //the band width of which swipe is detected (0 < x < 0.5f)
    public float m_swipe_band;


    /*
     * private stuff
    */

    private string defaultTouchStatusText = "Touch Status: ";

    //keep track of boost cooldown remaining time
    private float m_boost_cd_time;

    //initial position of mousedown/touch
    private Vector2 m_orig_pos;
    //contains swipe directions
    private Swipe_Direction m_swipe_direction;

    //crossplatform stuff
    private bool m_touch_supported = false;

    // Cooldown timer for swipes.
    private float m_swipeTimer = 0.0f;

    // Cooldown time between swipes.
    private float m_swipeCooldown = 0.5f;

    private PauseMenuManager pauseMenuManager = null;

    void Start()
    {
        //detect if touch or mouse
        if (SystemInfo.deviceType == DeviceType.Handheld)
            m_touch_supported = true;
        m_swipe_direction = new Swipe_Direction();

        pauseMenuManager = FindObjectOfType<PauseMenuManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_touch_supported)
        {
            //handle swipe for touch
            swipe_touch();
        }
        else
        {
            //handle swipe for mouse
            swipe_mouse();
        }

        // Ensures that you can't add forces to player while paused.
        if (!pauseMenuManager.IsPaused)
        {
            //player is
            if (m_swipe_direction.up && player.velocity.y == 0.0f)
            {
                player.AddForce(new Vector2(0, m_jump_height));
            }
            else if (m_swipe_direction.down && player.velocity.y > 0.0f)
            {
                //swipe down: stop moving up and begin to move down
                player.velocity = new Vector2(player.velocity.x, 0.0f);
            }
            else if (m_swipe_direction.right && m_boost_cd_time <= 0.0f)
            {
                //do something boosty
                player.AddForce(new Vector2(m_boost_speed, 0));
                m_boost_cd_time = m_time_between_boosts;
            }
        }

        //reset swipe direction
        m_swipe_direction.clear();
        //decrement boost cd
        m_boost_cd_time -= Time.deltaTime;

        m_swipeTimer += Time.deltaTime;
    }

    private void swipe_touch()
    {
        //get orig pos of mousedown/fingerdown
        if (Input.touches.Length > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    m_orig_pos = touch.position;
                    break;
                case TouchPhase.Moved:
                    {
                        Vector2 end_pos = touch.position;
                        //if distance > minimum distance and is a swipe and not holding down
                        if (m_swipeTimer >= m_swipeCooldown)
                        {
                            if (Vector2.Distance(m_orig_pos, end_pos) > m_swipe_distance)
                            {
                                //create new swipe vector, normalise it and then calc direction of it
                                calc_swipe_direction((end_pos - m_orig_pos).normalized);
                            }
                            m_swipeTimer = 0.0f;
                        }
                        break;
                    }
                case TouchPhase.Ended:
                    {
                        //Vector2 end_pos = touch.position;
                        ////if distance > minimum distance and is a swipe and not holding down
                        //if (Vector2.Distance(m_orig_pos, end_pos) > m_swipe_distance)
                        //{
                        //    //create new swipe vector, normalise it and then calc direction of it
                        //    calc_swipe_direction((end_pos - m_orig_pos).normalized);
                        //}
                        break;
                    }
                default:
                    break;
            }
        }
    }

    private void swipe_mouse()
    {
        //get orig pos of mousedown/fingerdown
        if (Input.GetMouseButtonDown(0))
        {
            m_orig_pos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            return;
        }
        //only do stuff after swipe completed
        if (Input.GetMouseButtonUp(0))
        {
            Vector2 end_mouse_pos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            //only do stuff if the swipe distance > minimum swipe distance
            if (Vector2.Distance(m_orig_pos, end_mouse_pos) > m_swipe_distance &&
                (Input.GetAxis("Mouse X") != 0.0f || Input.GetAxis("Mouse Y") != 0.0f))
            {
                //create new swipe vector, normalise it and then calc direction of it
                calc_swipe_direction((new Vector2(end_mouse_pos.x - m_orig_pos.x, end_mouse_pos.y - m_orig_pos.y)).normalized);
            }
        }
    }

    private void calc_swipe_direction(Vector2 swipe)
    {
        //get mousemovement, so cannot hold mouse, must be moving mouse in order to have response
        //float mousex = Input.GetAxis ("Mouse X"), mousey = Input.GetAxis ("Mouse Y");
        //swipe up
        if (swipe.y > 0 && swipe.x > -m_swipe_band && swipe.x < m_swipe_band /*&& mousey>0.0f*/)
        {
            m_swipe_direction.up = true;
            if (touchStatusText != null)
            {
                touchStatusText.text = defaultTouchStatusText + "Swipe Up ";
            }
        }
        //swipe down
        else if (swipe.y < 0 && swipe.x > -m_swipe_band && swipe.x < m_swipe_band /*&& mousey<0.0f*/)
        {
            m_swipe_direction.down = true;
            if (touchStatusText != null)
            {
                touchStatusText.text = defaultTouchStatusText + "Swipe Down ";
            }
        }
        //swipe left
        if (swipe.x < 0 && swipe.y > -m_swipe_band && swipe.y < m_swipe_band /*&& mousex<0.0f*/)
        {
            m_swipe_direction.left = true;
            if (touchStatusText != null)
            {
                touchStatusText.text = defaultTouchStatusText + "Swipe Left ";
            }
        }
        //swipe right
        else if (swipe.x > 0 && swipe.y > -m_swipe_band && swipe.y < m_swipe_band /*&& mousex>0.0f*/)
        {
            m_swipe_direction.right = true;
            if (touchStatusText != null)
            {
                touchStatusText.text = defaultTouchStatusText + "Swipe Right ";
            }
        }
    }
}