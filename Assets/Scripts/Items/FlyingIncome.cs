using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FlyingIncome : MonoBehaviour
{
    [SerializeField] private float minX, maxX, minY, maxY;
    private TextMeshPro text3D;
    private float speed;

    private void Start()
    {
        text3D = GetComponent<TextMeshPro>();

        text3D.text = "+$" + Money.income.ToString();
        text3D.color = Random.ColorHSV();

        transform.position = new(Random.Range(minX, maxX), Random.Range(minY, maxY), transform.position.z);
        speed = Random.Range(2.0f, 3);

        Destroy(gameObject, 2);
    }

    private void Update()
    {
        transform.Translate(transform.up * speed * Time.deltaTime);
        text3D.alpha = Mathf.Lerp(text3D.alpha, 0, 0.5f * Time.deltaTime);
    }
}
