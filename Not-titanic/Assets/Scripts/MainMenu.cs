using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //https://www.youtube.com/watch?v=DX7HyN7oJjE Unity main menu tutorial

    private bool Playing;
    private float bannerTime = 1;
    public Image banner;

    private void Start()
    {
        Playing = false;
    }

    private void Update()
    {
        Debug.Log(bannerTime);
        if (!Playing && bannerTime > 0)
        {
            bannerTime -= Time.deltaTime;
            banner.color = new Color(0, 0, 0, bannerTime);
        }
        if (!Playing && bannerTime < 0)
        {
            banner.gameObject.SetActive(false);
        }
        if (Playing)
        {
            bannerTime += Time.deltaTime;
            banner.color = new Color(0, 0, 0, bannerTime);
        }
        if (Playing && bannerTime >= 1)
        {
            SceneManager.LoadSceneAsync(1);
        }
    }

    public void PlayGame()
    {
        banner.gameObject.SetActive(true);
        Playing = true;
    }

}
