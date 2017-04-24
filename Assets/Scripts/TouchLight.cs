using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchLights : MonoBehaviour
{

    // not created yet
    public GameObject testboi;



    // Update is called once per frame
    void Update()
    {
        // get input from touch
        if (Input.touchCount > 0)
        {

            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                transform.Rotate(0, 10, 0, Space.World);
            }

            /*switch (touch.phase)
            {   
                case TouchPhase.Began:
                    startPosition = touch.position;
                    directionChosen = false;
                    break;

                    // If we move and then stop and stands still
                case TouchPhase.Stationary:
                    directionChosen = false;
                    break;

                case TouchPhase.Moved:
                    direction = startPosition - touch.position;
                    directionChosen = true;
                    break;

                case TouchPhase.Ended:
                    // maybe change? 
                    directionChosen = false;
                    break;
            }
        }
        
        // event that should move the light source. 
        if (directionChosen)
        {
            float movedDistance = direction.y;

            // have to be more tested to create an appropriate distance in relation to finger swiping.
            //laserSource.transform.Rotate(Vector3.up, Space.World);


            print("The distance moved :" + movedDistance);


        }*/

        }
    }
}
