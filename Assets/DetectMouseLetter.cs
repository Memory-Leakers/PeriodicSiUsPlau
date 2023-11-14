using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectMouseLetter : MonoBehaviour
{
    bool isMouseIn = false;
    Letter letter;

    private void Awake()
    {
        letter = FindObjectOfType<Letter>();
    }

    private void Update()
    {
        if (isMouseIn && Input.GetMouseButtonDown(0))
        {
            letter.Send();
        }
    }

    private void OnMouseEnter()
    {
        transform.localScale = new Vector3(0.35f * 1.2f, 1 * 1.2f, 0.3f * 1.2f);
        Debug.Log("Enter");
        isMouseIn = true;
    }

    private void OnMouseExit()
    {
        transform.localScale = new Vector3(0.35f, 1, 0.3f);
        isMouseIn = false;
    }
}
