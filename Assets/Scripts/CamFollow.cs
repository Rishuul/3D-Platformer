using UnityEngine;

public class CamFollow : MonoBehaviour
{
    // Start is called before the first frame update
   
   public Transform ball;
   public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        transform.position = ball.transform.position + offset;
    }
}
