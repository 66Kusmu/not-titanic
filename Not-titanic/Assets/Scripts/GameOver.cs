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
    private float bannerTime = 0;
    private float textTime = 0;
    private float buttonTime = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf)
        {
            bannerTime += Time.deltaTime;
            banner.color = new Color(0, 0, 0, bannerTime);
            if (bannerTime >= 1)
            {
                textTime += Time.deltaTime * 0.5f;
            }
            gameOverText.color = new Color(255, 255, 255, textTime);
            if (textTime >= 1)
            {
                buttonTime += Time.deltaTime * 2.5f;
            }
            retry.image.color = new Color(255, 255, 255, buttonTime);
            quit.image.color = new Color(255, 255, 255, buttonTime);
            retryText.color = new Color(0, 0, 0, buttonTime);
            quitText.color = new Color(0, 0, 0, buttonTime);
        }
    }

    public void Retry()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Retrying");
    }
}
