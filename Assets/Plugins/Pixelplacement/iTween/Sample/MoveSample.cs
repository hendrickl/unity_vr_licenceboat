using UnityEngine;
using System.Collections;

public class MoveSample : MonoBehaviour
{
    void Start()
    {
        print("itwen works");
        iTween.MoveBy(gameObject, iTween.Hash("x", 2, "easeType", "easeInOutExpo", "loopType", "pingPong", "delay", .1));
    }
}

