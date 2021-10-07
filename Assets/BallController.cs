using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{

    private float visiblePosZ = -6.5f;
    private float score;

    private GameObject gameoverText;
    private GameObject scoreText;

    void Start()
    {
        this.gameoverText = GameObject.Find("GameOverText");
        this.scoreText = GameObject.Find("ScoreText");
    }

    void Update()
    {
        if (this.transform.position.z < this.visiblePosZ)
        {
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }

        this.scoreText.GetComponent<Text>().text = "Score: " + score;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "SmallStarTag")
        {
            score += 10;
        }
        else if (collision.gameObject.tag == "LargeStarTag")
        {
            score += 20;
        }
        else if (collision.gameObject.tag == "SmallCloudTag")
        {
            score += 5;
        }
        else if (collision.gameObject.tag == "LargeCloudTag")
        {
            score += 25;
        }
    }
}
