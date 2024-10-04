using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointerController : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public RectTransform safeZone;
    public float moveSpeed = 100f;

    private RectTransform pointerTransform;
    private Vector3 targetPosition;

    [Header("Score Text")]
    public TextMeshProUGUI scoreText;
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        pointerTransform = GetComponent<RectTransform>();
        targetPosition = pointB.position;
    }

    // Update is called once per frame
    void Update()
    {
        pointerTransform.position = Vector3.MoveTowards(pointerTransform.position, targetPosition, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(pointerTransform.position, pointA.position) < 0.1f)
        {
            targetPosition = pointB.position;
        }
        else if (Vector3.Distance(pointerTransform.position, pointB.position) < 0.1f)
        {
            targetPosition = pointA.position;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CheckSuccess();
        }
       
    }

    void CheckSuccess()
    {
        if (RectTransformUtility.RectangleContainsScreenPoint(safeZone, pointerTransform.position, null))
        {
            Add300();
            Debug.Log("Success");
        }

        else 
        {
            Add30();
            Debug.Log("Failure");
        }
    }

    public void Add300()
    {
        score += 150;
        scoreText.text = score.ToString();
    }

    public void Add30()
    {
        score += 15;
        scoreText.text = score.ToString();
    }

}
