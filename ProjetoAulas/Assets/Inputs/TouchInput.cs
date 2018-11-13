using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        if(Input.touchCount > 0) // Input.touchCount - quantos toques
        {
            Touch touch = Input.GetTouch(0);

            Vector2 posicao =  touch.position;

            // converter em coordenadas do mundo
            Vector3 coord = Camera.main.ScreenToWorldPoint(touch.position);


            //touch.tapCount

            TouchPhase phase = touch.phase;

            switch (phase)
            {
                case TouchPhase.Began:
                    break;
                case TouchPhase.Moved:
                    // movimento
                    Vector2 pos = touch.position;

                    if (pos.x > 50)
                        pos.x = 20;

                    Vector2 delta = touch.deltaPosition;
                    break;
                case TouchPhase.Stationary:
                    break;
                case TouchPhase.Ended:
                    break;
                case TouchPhase.Canceled:
                    break;
                default:
                    break;
            }

            // recuperar e iterar todos os toques
            foreach (Touch t in Input.touches)
            {
                
            }



        }
        
	}
}
