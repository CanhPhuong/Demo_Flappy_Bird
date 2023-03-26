using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    //quản lí điểm
    //isovergame
    public bool isOverGame;
    private int gamePoint;
    public Text textPoint;
    public Text textEndPoint;
    public GameObject panelGameOver;
    public GameObject panel;
   

    void Start()
    {
        
        panelGameOver.SetActive(false);
        panel.SetActive(true);
        gamePoint = 0;
        isOverGame = false;
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
            if (isOverGame == false)

            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    panel.SetActive(false);
                    Time.timeScale = 1;
                }
            }
    }
    public void GamePoint()
    {
        gamePoint++;
        textPoint.text = "Point: " + gamePoint.ToString();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void GameOver()
    {
        isOverGame = true;
        Debug.Log("EndGame");
        Time.timeScale = 0;
        panelGameOver.SetActive(true);
        textEndPoint.text = "Your Point\n " + gamePoint.ToString();
       
    }


}
