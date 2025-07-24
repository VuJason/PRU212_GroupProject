using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject howToPlayPanel;        // Panel hướng dẫn
    public GameObject menuButtonsGroup;      // Nhóm nút: Start, How to Play, Quit

    public void StartGame()
    {
        SceneManager.LoadScene(1); // Thay bằng tên scene thật của bạn
    }

    public void QuitGame()
    {
        Debug.Log("Thoát game");
        Application.Quit();
    }

    public void ShowHowToPlay()
    {
        howToPlayPanel.SetActive(true);         // Hiện panel hướng dẫn
        menuButtonsGroup.SetActive(false);      // Ẩn các nút menu
    }

    public void HideHowToPlay()
    {
        howToPlayPanel.SetActive(false);        // Ẩn panel
        menuButtonsGroup.SetActive(true);       // Hiện lại các nút menu
    }
}