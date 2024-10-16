using UnityEngine;
using UnityEngine.SceneManagement;  // Để load lại scene
using UnityEngine.UI;  // Để làm việc với UI (Button)

public class UIManager : MonoBehaviour
{
    // Phương thức để xử lý khi nhấn nút Retry
    public void RetryGame()
    {
        Debug.Log("Retry button pressed!");

        // Đặt lại time scale về 1 để khôi phục trò chơi
        Time.timeScale = 1f;

        // Load lại scene hiện tại (tạo lại game)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Phương thức để xử lý khi nhấn nút Quit
    public void QuitGame()
    {
        Debug.Log("Quit button pressed!");

        // Thoát game
        Application.Quit();
    }
}
