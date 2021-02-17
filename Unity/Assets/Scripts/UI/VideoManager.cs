using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.UI;

public class VideoManager : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown VOptions;
    [SerializeField] private TMP_Dropdown ROptions;
    [SerializeField] private Button ApplyB;

    Resolution[] res;

    void Start()
    {
        ApplyB.onClick.AddListener(ApplyOptions);

        /*List<string> options = new List<string>();
        //res = Screen.resolutions;
        //int currentresi = 0;

        //ROptions.ClearOptions();
        //for (int i = 0; i < res.Length; i++)
        //{
        //    string option = res[i].width + " x " + res[i].height;
        //    options.Add(option);
        //    if (res[i].width == Screen.width && res[i].height == Screen.height)
        //    {
        //        currentresi = i;
        //    }
        //}

        //ROptions.AddOptions(options);
        //ROptions.value = currentresi;
        //ROptions.RefreshShownValue();//credit to https://answers.unity.com/questions/1680457/how-to-change-resolution-in-dropdown.html*/

        GetRes();
    }

    void GetRes()
    {
        List<string> options = new List<string>();
        res = Screen.resolutions;
        int currentresi = 0;

        ROptions.ClearOptions();
        for (int i = 0; i < res.Length; i++)
        {
            string option = res[i].width + " x " + res[i].height;
            options.Add(option);
            if (res[i].width == Screen.width && res[i].height == Screen.height)
            {
                currentresi = i;
            }
        }

        ROptions.AddOptions(options);
        ROptions.value = currentresi;
        ROptions.RefreshShownValue();//credit to https://answers.unity.com/questions/1680457/how-to-change-resolution-in-dropdown.html
    }

    void SetResolution(int resolutionIndex)
    {
        Resolution resolution = res[resolutionIndex]; Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreenMode);

        switch (VOptions.value)//0= excl full 1= windowed 2= windowed full
        {
            case 0:
                Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
                break;

            case 1:
                Screen.fullScreenMode = FullScreenMode.Windowed;
                break;

            case 2:
                Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
                break;

            default:
                Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
                break;
        }
    }

    void ApplyOptions()
    {
        SetResolution(ROptions.value);
    }
}