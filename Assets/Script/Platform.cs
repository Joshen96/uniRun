using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject[] obs;
    private bool steped = false; 
    private void OnEnable()
    {
        steped = false;

        for (int i = 0; i < obs.Length; i++)
        {
            if (Random.Range(0, 3) == 0)
            {
                obs[i].SetActive(true);
            }
            else
            {
                obs[i].SetActive(false);

            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" && !steped)
        {
            steped = true;
            GameManager.instance.AddScore(1); // 
        }
    }
}
