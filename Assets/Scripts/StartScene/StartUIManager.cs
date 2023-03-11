using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartUIManager : MonoBehaviour
{
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    public void ClickBTN(string name)
    {
        switch(name)
        {
            case "GoLobby" :
            StartGame();
            break;

            case "Setting":
            ShowSettings();
            break;

            case "Quit":
            print("Quit");
            QuitGame();
            break;

            case "Traning" :
            SceneManager.LoadScene("BattleScene");
            break;

            case "Guild" :
            SceneManager.LoadScene("Guild");
            break;

            case "Store" :
            SceneManager.LoadScene("Store");
            break;

            case "Adventure" :
            SceneManager.LoadScene("Adventure");
            break;


            default:
            Debug.Log("Fail");
            break;
        }
    }
    // 게임 시작 버튼에 연결할 함수
    void StartGame()
    {
        SceneManager.LoadScene("Lobby");
    }

    // 환경설정 버튼에 연결할 함수
    void ShowSettings()
    {
        // 환경설정 팝업창을 띄워주는 코드 작성
        Debug.Log("Settings button clicked");
    }

    // 게임 종료 버튼에 연결할 함수
    void QuitGame()
    {
        Application.Quit();
    }
}
