using UnityEngine;

public class TouchInput : MonoBehaviour
{
	// Update is called once per frame
	void Update ()
    {
        if (Input.touches.Length > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Posicao
            // Ponto inicial (0,0 canto inferior esquerdo)
            // Ponto final (Screen.width, Screen.height)
            Debug.Log("Posicao: " + touch.position);

            // contagem de toques sucessivos
            Debug.Log("Quantidade toques (tap): " + touch.tapCount);


            switch (touch.phase)
            {
                case TouchPhase.Began: // inicio do toque (primeiro quadro)
                    break;
                case TouchPhase.Moved: // movimentando o dedo
                    break;
                case TouchPhase.Stationary: // dedo parado (mas continua encostado)
                    break;
                case TouchPhase.Ended: // fim do toque (retirando)
                    break;
                case TouchPhase.Canceled: // cancelado pelo sistema operacional
                    break;
                default:
                    break;
            }


            // Deslocamento

            // Diferenca de posicao entre os quadros
            Debug.Log("deltaPosition: " + touch.deltaPosition);


            // todos os toques da tela
            Touch[] toques = Input.touches;

            foreach (Touch t in toques)
            {
                Debug.Log("Touch: " + t.fingerId + ", pos: " + t.position);
            }
        }
    }
}
