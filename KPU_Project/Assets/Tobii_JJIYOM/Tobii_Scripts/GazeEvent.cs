﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tobii
{
    //시선 후 -> 브레이크만 측정되게(그 전값 무시)
    public class GazeEvent : MonoBehaviour
    {
        public float EyesTime = 0f;
        public float BrakeTime = 0f;

        public bool IsSee = false;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            //스페이스 키 누르면 //이벤트 발생이후 //눈으로 본 후 //한번만 발생하게
            if (Input.GetKeyDown("space") && BrakeTime == 0 && Tobii_TrafficLight.TT.IsEvent && IsSee)
            {
                BrakeTime = Tobii_TrafficLight.TT.times;
                Debug.Log("브레이크 반응 시간 : " + Tobii_TrafficLight.TT.times);

                Manager.TOBII_Manager.Instance.Add_TOBII_Data("Tobii_Scenario1", EyesTime, BrakeTime);
                //시나리오4까지 미완성이므로 일단 값 넣어놓기
                Manager.TOBII_Manager.Instance.Add_TOBII_Data("Tobii_Scenario1", EyesTime, BrakeTime);
                Manager.TOBII_Manager.Instance.Add_TOBII_Data("Tobii_Scenario1", EyesTime, BrakeTime);
                Manager.TOBII_Manager.Instance.Add_TOBII_Data("Tobii_Scenario1", EyesTime, BrakeTime);

                UIManager.Instance.ViewResult();

                Manager.TOBII_Manager.Instance.Is_Danger();
            }
        }

        private void OnTriggerEnter(Collider other) //최초 시선 측정
        {
            //공이 나타나면 시선 측정하는데
            if (other.name == "Red_Light" && EyesTime == 0) //see_time자리에 Tobii_Manager Param
            {
                EyesTime = Tobii_TrafficLight.TT.times; //see_time자리에 Tobii_Manager Param
                IsSee = true;
                Debug.Log("공맞음 " + EyesTime);
            }
        }
    }
}