﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioTrigger : MonoBehaviour
{
    public GameObject BlueCar;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        switch (name)
        {
            case "Scenario3Trigger":
                if (other.name == "=====MyCar=====")
                {
                    Debug.Log("시나리오 3 진입");
                    BlueCar.gameObject.SetActive(true);
                }
                break;

            default:
                break;
        }


    }
}
