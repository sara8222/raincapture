using UnityEngine;

public class RainDrop : MonoBehaviour
{
    // ارجاع به ScoreManager را به صورت متغیر ذخیره می‌کنیم 
    private ScoreManager scoreManager;

    void Start()
    {
        // پیدا کردن ScoreManager تنها یک بار در شروع بازی
        scoreManager = FindObjectOfType<ScoreManager>();

        // اگر ScoreManager پیدا نشد، نمایش خطا
        if (scoreManager == null)
        {
            Debug.LogError("ScoreManager not found!");
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // فقط در صورتی که ScoreManager معتبر باشد، ادامه بده
        if (scoreManager == null) return;

        // تشخیص برخورد با بازیکن یا زمین و اعمال امتیاز
        if (other.CompareTag("Player"))
        {
            HandleCollision("Player", 1);
        }
        else if (other.CompareTag("Ground"))
        {
            HandleCollision("Ground", -1);
        }
    }

    // تابعی برای مدیریت برخورد‌ها و حذف قطره
    void HandleCollision(string tag, int scoreChange)
    {
        Debug.Log($"Hit {tag}!");
        scoreManager.AddScore(scoreChange); // تغییر امتیاز
        Destroy(gameObject); // حذف قطره باران
    }
}
