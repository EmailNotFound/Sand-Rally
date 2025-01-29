using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;

public class TimeControl : MonoBehaviour
{
    private static int OneHour = 3600;

    private static int OneMininue = 60;

    public int timenum;
    public Text timetext;
    public GameObject OverUI;
    public CarController controller;
    //把秒变成时:分:秒
    public static string FormatSToHMS(int _time)
    {
        int _hour = _time / OneHour;
        int _min = 0;
        int _sec = 0;
        if (_hour > 0)
        {
            _min = (_time % OneHour) / OneMininue;
            _sec = _min > 0 ? (_time % OneHour) % OneMininue : _time % OneHour;
        }
        else
        {
            _min = _time / OneMininue;
            _sec = _min > 0 ? _time % OneMininue : _time;
        }

        return _hour > 0 ? string.Format("{0:00}:{1:00}:{2:00}", _hour, _min, _sec) : string.Format("{0:00}:{1:00}", _min, _sec);
    }
    void Start()
    {
        timetext.text = FormatSToHMS(timenum);
        InvokeRepeating("Asettime", 1, 1);
    }

    public void Asettime()
    {
        timenum--;
        timetext.text = FormatSToHMS(timenum);
        if (timenum == 0)
        {
            controller.m_Topspeed = 0;
            OverUI.SetActive(true);
            CancelInvoke("Asettime");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
