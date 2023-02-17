using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    public float speed = 10f;
    // Start is called before the first frame update
  

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.isGameOver) // 게임오버가 아닐시에만
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}
