using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{

    private Transform bar;
    private GameObject healthBar;

    private void Start()
    {
        bar = transform.Find("Bar");
        healthBar = GameObject.Find("Hero/HealthBar");
    }

    public void setSize(float sizeNormailzed)
    {
        bar.localScale = new Vector3(sizeNormailzed, 1f);
    }
}