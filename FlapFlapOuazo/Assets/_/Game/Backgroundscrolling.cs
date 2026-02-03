using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [Header("Backgrounds")]
    [SerializeField] private Sprite[] backgroundSprites;

    [Header("Scroll Settings")]
    [SerializeField] private float scrollSpeed = 2f;

    [Header("Sequence Settings")]
    [SerializeField] private int loopsPerBackground = 2;
    [SerializeField] private bool loopSequence = false;

    private SpriteRenderer bg1;
    private SpriteRenderer bg2;
    private float bgWidth;

    private int currentBackgroundIndex = 0;
    private int loopCount = 0;
    private bool sequenceFinished = false;

    void Start()
    {
        bg1 = transform.GetChild(0).GetComponent<SpriteRenderer>();
        bg2 = transform.GetChild(1).GetComponent<SpriteRenderer>();

        bgWidth = bg1.bounds.size.x;

        bg1.sprite = backgroundSprites[currentBackgroundIndex];
        bg2.sprite = backgroundSprites[currentBackgroundIndex];

        bg2.transform.position = bg1.transform.position + Vector3.right * bgWidth;
    }

    void Update()
    {
        if (sequenceFinished)
            return;

        float move = scrollSpeed * Time.deltaTime;
        bg1.transform.position += Vector3.left * move;
        bg2.transform.position += Vector3.left * move;

        if (bg1.transform.position.x <= -bgWidth)
        {
            Reposition(bg1, bg2);
        }
        else if (bg2.transform.position.x <= -bgWidth)
        {
            Reposition(bg2, bg1);
        }
    }

    void Reposition(SpriteRenderer exiting, SpriteRenderer other)
    {
        exiting.transform.position =
            other.transform.position + Vector3.right * bgWidth;

        loopCount++;

        if (loopCount >= loopsPerBackground)
        {
            loopCount = 0;
            currentBackgroundIndex++;

            // Si on a atteint la fin
            if (currentBackgroundIndex >= backgroundSprites.Length)
            {
                if (loopSequence)
                {
                    currentBackgroundIndex = 0;
                }
                else
                {
                    sequenceFinished = true;
                    return;
                }
            }
        }

        exiting.sprite = backgroundSprites[currentBackgroundIndex];
    }
}
