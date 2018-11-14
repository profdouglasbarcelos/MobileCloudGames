using UnityEngine;

public class MobileTouchInput : MonoBehaviour
{
    public GameObject cubo;

    private bool inTouch = false;
    private Vector2 startPosition;

    void Start()
    {
        Instantiate(cubo, transform);
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            // Swipe
            if (inTouch)
            {
                Touch t = Input.GetTouch(0);

                if (t.phase == TouchPhase.Moved)
                {
                    Debug.Log("Swipe");
                    Vector2 diff = t.position - startPosition;
                    inTouch = false;

                    // conversao ponto da tela em ponto do cenario
                    Vector3 v3 = Camera.main.ScreenToWorldPoint(t.position);
                }
            }

            // Tap
            Touch touch = Input.GetTouch(0);
            startPosition = touch.position;
            TouchPhase tp = touch.phase;
            inTouch = true;
        }

        if (Input.touchCount > 0)
        {
            Touch[]  touches= Input.touches;

            for (int i = 0; i < touches.Length; i++)
            {
                Touch touchAtual = touches[i];
                int finger = touchAtual.fingerId;
            }
        }
    }
}
