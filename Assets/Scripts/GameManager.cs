using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float timeRemaining = 60f;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI wintimerText;
    public GameObject winPanel;
    public GameObject losePanel;

    private bool gameActive = true;
    private bool gameStarted = false;
    private PiecesScript[] allPieces;

    void Start()
    {
        allPieces = FindObjectsOfType<PiecesScript>(); //buat nyari semua pieces
        
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        timerText.gameObject.SetActive(false);
        wintimerText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (gameActive && gameStarted)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                timerText.text = "Time: " + Mathf.Round(timeRemaining).ToString();
                wintimerText.text = "Waktu Tersisa: " + Mathf.Round(timeRemaining).ToString(); //buat tampilan sisa waktu pas menang
            }
            else
            {
                GameSelesai(false);
            }

            CekMenang();
        }

        // if (Input.GetKey(KeyCode.Space))
        // {
        //     GameSelesai(true);
        // }
    }
    
    void CekMenang()
    {
        bool allInRightPlace = true;
        foreach (PiecesScript piece in allPieces)
        {
            if (!piece.InRightPosition)
            {
                allInRightPlace = false;
                break;
            }
        }

        if (allInRightPlace)
        {
            GameSelesai(true);
        }
    }

    void GameSelesai(bool isWin)
    {
        gameActive = false;
        if (isWin)
        {
            winPanel.SetActive(true);
            timerText.gameObject.SetActive(false);
            wintimerText.gameObject.SetActive(true);
        }
        else
        {
            losePanel.SetActive(true);
            timerText.gameObject.SetActive(false);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        timerText.gameObject.SetActive(false);
    }

    public void GameStart()
    {
        gameStarted = true;
        //StartGame.SetActive(false);
        timerText.gameObject.SetActive(true);
    }

    // public void CloseGame()
    // {
    //     gameActive = false;
    //     timerText.gameObject.SetActive(false);
    // }

    public void PauseGame()
    {
        gameActive = false;
    }

    public void ResumeGame()
    {
        gameActive = true;
    }
}