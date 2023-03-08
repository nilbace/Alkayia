using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartUIManager : MonoBehaviour
{
    // 게임 시작 버튼에 연결할 함수
    public void StartGame()
    {
        SceneManager.GetSceneByName("asdf");
    }

    // 환경설정 버튼에 연결할 함수
    public void ShowSettings()
    {
        // 환경설정 팝업창을 띄워주는 코드 작성
        Debug.Log("Settings button clicked");
    }

    // 게임 종료 버튼에 연결할 함수
    public void QuitGame()
    {
        Application.Quit();
    }
}
