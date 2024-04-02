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
    private float morePoints = 0.01f;
    private float alphaValue = 0.03f;
    private bool movingRight = true;
    // Update is called once per frame
    void Update()
    {

        if (Snail.transform.position.x >= startingPoint.transform.position.x && Snail.transform.position.x <= endingPoint.transform.position.x)  
        {
            if (Snail.transform.position.x == startingPoint.transform.position.x)
            {
                Snail.GetComponent<SpriteRenderer>().flipX = false;
                movingRight = true;
            }
            if(Snail.transform.position.x == endingPoint.transform.position.x)
            {
                Snail.GetComponent<SpriteRenderer>().flipX = true;
                movingRight = false;
            }
            if (movingRight) 
            {
                Snail.transform.position = Vector3.Lerp(Snail.transform.position, endingPoint.transform.position, alphaValue);
            }
            if (!movingRight)
            {
                Snail.transform.position = Vector3.Lerp(Snail.transform.position, startingPoint.transform.position, alphaValue);
            }
            points += morePoints;
        }
        

    }

    public void OnFasterClicked()
    {
        if (points > 100)
        {
            alphaValue += 0.02f;
            points -= 100;
        }
    }

    public void onMorePointsClicked()
    {
        if (points > 500)
        {
            morePoints += 0.03f;
            points -=500;
        }
    }

    public void onTeleportClicked()
    {
        if (points > 1000)
        {
            Snail.transform.Translate(3, 0, 0);
        }
    }

    
}
