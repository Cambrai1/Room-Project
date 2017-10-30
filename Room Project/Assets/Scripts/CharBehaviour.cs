using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

namespace ISS
{
    public class CharBehaviour : MonoBehaviour
    {
        [SerializeField]
        private float m_speed = 20.0f;

        [SerializeField]
        private Slider slider;

        [SerializeField]
        private Image image;

        private Transform m_transform;
        public Rigidbody rb;
        public float speed = 10.0f;
        public int moveSpeed = 10;
        public float downTime, upTime, power;
        public float minJump = 10;
        public float maxJump = 20;
        public float heightY;

        Vector3 down = new Vector3(0, -1, 0);
        void Start()
        {
            m_transform = GetComponent<Transform>();
            rb = GetComponent<Rigidbody>();
        }

        
        // Update is called once per frame
        void Update()
        {
            heightY = transform.position.y;

            print(heightY);
            image.enabled = !(slider.value == 10);

                //if statement for W key press.
                if (Input.GetKey("w"))
                {
                    //if statement that increases the capsule character's forward velocity by 3x the standard movement speed
                    //when the left shift key and the W key is held down.
                    if (Input.GetKey("left shift"))
                    {
                        rb.transform.position += m_transform.forward * m_speed * Time.deltaTime * 3.0f;
                    }
                    //else statement that increases the capsule character's forward velocity by just the standard movement speed
                    //when just the W key is held down.
                    else
                    {
                        rb.velocity += m_transform.forward * m_speed * Time.deltaTime;
                    }
                }
            
             
            //if statement for S key press.
            if (Input.GetKey("s"))
            {
                //if statement that decreases the capsule character's forward velocity by 3x the standard movement speed
                //when the left shift key and the S key is held down.
                if (Input.GetKey("left shift"))
                {
                    rb.velocity -= m_transform.forward * m_speed * Time.deltaTime * 3.0f;
                }
                //else statement that decreases the capsule character's forward velocity by just the standard movement speed
                //when just the W key is held down.
                else
                {
                    rb.velocity -= m_transform.forward * m_speed * Time.deltaTime;
                }
            }
            
            //if statement for A key press.
            if (Input.GetKey("a"))
            {
                //if statement that decreases the capsule character's right velocity by 3x the standard movement speed
                //when the left shift key and the A key is held down.
                if (Input.GetKey("left shift"))
                {
                    rb.velocity -= m_transform.right * m_speed * Time.deltaTime * 3.0f;
                }
                //else statement that decreases the capsule character's right velocity by just the standard movement speed
                //when just the A key is held down.
                else
                {
                    rb.velocity -= m_transform.right * m_speed * Time.deltaTime;
                }
            }

            //if statement for D key press.
            if (Input.GetKey("d"))
            {
                //if statement that increases the capsule character's right velocity by 3x the standard movement speed
                //when the left shift key and the D key is held down.
                if (Input.GetKey("left shift"))
                {
                    rb.velocity += m_transform.right * m_speed * Time.deltaTime * 3.0f;
                }
                //else statement that increases the capsule character's right velocity by just the standard movement speed
                //when just the D key is held down.
                else
                {
                    rb.velocity += m_transform.right * m_speed * Time.deltaTime;
                }
            }
            
            //Sets the variable downTime to that of the current Time.time stamp when the SPACE key is initially pressed.
            if (Input.GetKeyDown("space"))
            {
                downTime = Time.time;
            }

            if (Input.GetKey("space"))
            {
                //sets the variable upTime to that of the current Time.time stamp continuously whilst the SPACE key is pressed.
                upTime = Time.time;
                //sets the variable power to that of 10x that of the difference in upTime and downTime plus the minJump distance.
                power = (((upTime - downTime) * 10) + minJump);
                //sets the slider.value to that of the current power variable value. This makes the fill area of the slider increase as the value of the power variable increases.
                slider.value = power;
            }

            if (Input.GetKeyUp("space"))
            {             
                Debug.DrawRay(transform.position, down, Color.red, 5);

                //if statement that measures whether the capsule character is close enough to the ground for a jump by using a raycast.
                if (Physics.Raycast(transform.position, down, 2))
                {
                    //Increases the capsule character's y axis velocity by the value of the power variable as long as power is less than the value for the max jump variable.
                    //If it is greater, then the y axis velocity increases by the max jump value.
                    rb.velocity = new Vector3(rb.velocity.x, (power > maxJump) ? maxJump : power, rb.velocity.z);

                    Debug.Log(power);

                    //sets the slider value back to its minimum.
                    slider.value = 10;
                }
            }

            //if statement for ESCAPE key press.
            if (Input.GetKeyDown("escape"))
            {
                //pauses the games timeScale between 0 and 1 every time the ESCAPE key is pressed.
                if (Time.timeScale == 1)
                {
                    Time.timeScale = 0;
                }
                else
                {
                    Time.timeScale = 1;
                }
            }
        }

        //reloads the scene everytime the capsule character collides with a game object with the tag "Sphere".
        void OnCollisionEnter(Collision Sphere)
        {
            if (Sphere.gameObject.tag == "Sphere")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            
        }

    }
}       


        
         





