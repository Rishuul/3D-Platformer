using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI scoreText;
   

    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        scoreText.text = (player.transform.position.x + FindObjectOfType<BallMovement>().starsCollected*30).ToString("0") ;
    }
}
