using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PiecesScript : MonoBehaviour
{
    private Vector3 RightPosition;
    public bool InRightPosition; //menandakan piece puzzle sudah benar dan tidak bisa digerakkan lagi
    public bool Selected;
    
    //posisi random saat game dimulai
    void Start()
    {
        RightPosition = transform.position;
        transform.position = new Vector3(Random.Range(2f,7f), Random.Range(3f,-3f)); //posisi puzzle pieces ngerandom pas dimainin
    }

    void Update()
    {
        if (Vector3.Distance(transform.position,RightPosition) < 0.5f)
        {
            if (!Selected)
            {
                if (InRightPosition == false)
                {
                    transform.position = RightPosition;
                    InRightPosition = true;
                    GetComponent<SortingGroup>().sortingOrder = 0;
                }
            }
        }
    }
}
