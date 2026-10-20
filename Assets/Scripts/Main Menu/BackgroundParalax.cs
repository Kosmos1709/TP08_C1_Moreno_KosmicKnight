using System;
using UnityEngine;

public class BackgroundParalax : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private float EndPoint;
    [SerializeField] private float StartPoint;
    [SerializeField] private GameObject Panel;
    [SerializeField] private RectTransform rec;

    void Start()
    {
        Panel = gameObject;
        rec = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        rec.anchoredPosition += Vector2.left * Speed * Time.deltaTime;

        if (rec.anchoredPosition.x <= EndPoint)
        {
            rec.anchoredPosition = new Vector2(StartPoint, rec.anchoredPosition.y);
        }
    }
}
