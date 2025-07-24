using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelector : MonoBehaviour
{
    [Header("Tên nhân vật (để lưu lại)")]
    public string characterName;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        Debug.Log("▶ Đã chọn nhân vật: " + characterName);

        // Lưu vào PlayerPrefs
        PlayerPrefs.SetString("selectedCharacter", characterName);
        PlayerPrefs.Save();

        // ✅ Chuyển sang scene Level02
        SceneManager.LoadScene("Level01");
    }

    private void OnMouseEnter()
    {
        if (spriteRenderer != null)
            spriteRenderer.color = Color.yellow; // highlight
    }

    private void OnMouseExit()
    {
        if (spriteRenderer != null)
            spriteRenderer.color = Color.white; // reset màu
    }
}
