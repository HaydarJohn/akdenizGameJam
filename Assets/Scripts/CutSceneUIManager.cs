using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using Unity.VisualScripting;

public class CutSceneUIManager : MonoBehaviour
{
    public float letterDelay = 0.1f; // Her harfin ekrana yazdýrýlma aralýðý
    public TMP_Text textComponent; // Yazýyý tutan TextMeshProUGUI bileþeni
    public string[] texts; // Yazdýrýlacak metinler
    public float startDelay = 5f;
    private int currentIndex = 0; // Þu anki metnin dizideki indeksi
    private string currentText = ""; // Þu anki yazý
    private float timer = 0f;
    private bool isTimer = false;
    [SerializeField] private AudioSource daktilo;
    [SerializeField] private Image blackScreen;
    [SerializeField] private Image[] cutImages;
    [SerializeField] private Animator anim;


    private void Awake()
    {
        daktilo = GetComponent<AudioSource>();
    }
    private void Update()
    {

    }
    IEnumerator Start()
    {
        yield return new WaitForSeconds(startDelay);
        isTimer = true;
        // Baþlangýçta ilk metni yazdýr
        yield return StartCoroutine(TypeText(texts[currentIndex]));

        // Diðer metinleri yazdýr
        while (true)
        {
            anim.SetBool("isOpen", true);
            daktilo.Stop();
            textComponent.gameObject.SetActive(false);
            cutImages[currentIndex].gameObject.SetActive(false);
            yield return new WaitForSeconds(1f); // Kýsa bir bekleme ekleyebilirsiniz
            currentIndex = (currentIndex + 1) % texts.Length; // Bir sonraki metne geç
            yield return StartCoroutine(TypeText(texts[currentIndex])); // Yeni metni yazdýr
        }
    }

    IEnumerator TypeText(string text)
    {
        daktilo.Play();
        cutImages[currentIndex].gameObject.SetActive(true);
        textComponent.gameObject.SetActive(true);
        anim.SetBool("isOpen", false);
        // Her harfi ekrana yazdýrmak için döngü
        for (int i = 0; i < text.Length; i++)
        {
            currentText = text.Substring(0, i + 1);
            textComponent.text = currentText;
            yield return new WaitForSeconds(letterDelay);
        }
    }
}
