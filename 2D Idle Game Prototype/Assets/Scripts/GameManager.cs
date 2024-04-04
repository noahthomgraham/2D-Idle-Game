using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject startingPoint;
    [SerializeField] GameObject endingPoint;
    [SerializeField] GameObject Snail;
    [SerializeField] float points = 0;
    [SerializeField] TMP_Text pointsLabel;
    private float morePoints = 0.5f;
    private float alphaValue = 0.0001f;
    private bool movingRight = true;
    // Update is called once per frame
    void Update()
    {

        if (movingRight)
        {
            if (Snail.transform.position.x >= endingPoint.transform.position.x)
            {
                Snail.GetComponent<SpriteRenderer>().flipX = true;
                movingRight = false;
            }
            Snail.transform.position = Vector3.Lerp(Snail.transform.position, endingPoint.transform.position, alphaValue);
        }
        else
        {
            if (Snail.transform.position.x <= startingPoint.transform.position.x)
            {
                Snail.GetComponent<SpriteRenderer>().flipX = false;
                movingRight = true;
            }
            Snail.transform.position = Vector3.Lerp(Snail.transform.position, startingPoint.transform.position, alphaValue);
        }

        points += morePoints;
        pointsLabel.text = "Points: " + points.ToString();
    }

    public void OnFasterClicked()
    {
        if (points > 100)
        {
            alphaValue += 0.0005f;
            points -= 100;
        }
    }

    public void onMorePointsClicked()
    {
        if (points > 1000)
        {
            morePoints += 0.1f;
            points -=1000;
        }
    }

    public void onTeleportClicked()
    {
        if (points > 500)
        {
            if (movingRight)
            {
                Snail.transform.Translate(3, 0, 0);
            }
            if(!movingRight)
            {
                Snail.transform.Translate(-3, 0, 0);
            }
            if (Snail.transform.position.x < 0)
            {
                Snail.transform.position = new Vector3(0, 0, 0);
            }
            if(Snail.transform.position.x > 16)
            {
                Snail.transform.position = new Vector3(16, 0, 0);
            }
            points -= 500;
        }
    }

    
}
