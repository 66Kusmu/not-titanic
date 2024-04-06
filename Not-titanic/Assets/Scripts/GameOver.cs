using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Image banner;
    public Text gameOverText;
    public Button retry;
    public Text retryText;
    public Button quit;
    public Text quitText;
    private float bannerTime = 1;
    private float textTime = 0;
    private float buttonTime = 0;

    public bool dead;
    private bool retrying;
    
    // Start is called before the first frame update
    void Start()
    {
        retrying = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead && bannerTime >= 0)
        {
            bannerTime -= Time.deltaTime;
            banner.color = new Color(0, 0, 0, bannerTime);
        }

        if (dead)
        {
            bannerTime += Time.deltaTime;
            banner.color = new Color(0, 0, 0, bannerTime);
            if (!retrying && bannerTime >= 1)
            {
                textTime += Time.deltaTime * 0.5f;
                gameOverText.gameObject.SetActive(true);
                retry.gameObject.SetActive(true);
                quit.gameObject.SetActive(true);
            }
            if (!retrying && textTime >= 1)
            {
                buttonTime += Time.deltaTime * 2.5f;
            }
            if (retrying)
            {
                textTime -= Time.deltaTime * 0.5f;
                buttonTime -= Time.deltaTime * 0.5f;
            }
            gameOverText.color = new Color(255, 255, 255, textTime);
            retry.image.color = new Color(255, 255, 255, buttonTime);
            quit.image.color = new Color(255, 255, 255, buttonTime);
            retryText.color = new Color(0, 0, 0, buttonTime);
            quitText.color = new Color(0, 0, 0, buttonTime);

            if (textTime <= 0 && buttonTime <= 0 && retrying)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    public void RetryLevel()
    {
        textTime = 1;
        buttonTime = 1;
        retrying = true;
    }
}
