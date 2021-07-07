using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour
{
    public GameObject IconPrefab;
    List<QuestMarker> questMarkers = new List<QuestMarker>();

    public RawImage CompassImage;
    public GameObject Player;

    float compassUnit;

    public QuestMarker one;
    public QuestMarker two;
    public QuestMarker three;

    private float _maxDistance = 100f;

    private void Start()
    {
        compassUnit = CompassImage.rectTransform.rect.width / 360f;

        AddQuestMarker(one);
        AddQuestMarker(two);
        AddQuestMarker(three);
    }

    private void Update()
    {
        CompassImage.uvRect = new Rect(Player.transform.localEulerAngles.y / 360f, 0f, 1f, 1f);

        foreach (QuestMarker marker in questMarkers)
        {
            marker.Image.rectTransform.anchoredPosition = GetPosOnCompass(marker);

            float dst = Vector2.Distance(new Vector2(Player.transform.position.x, Player.transform.position.z), marker.position);
            float scale = 0;

            if (dst< _maxDistance)
            {
                scale = 1f - (dst / _maxDistance);
            }

            marker.Image.rectTransform.localScale = Vector3.one * scale;
        }

        
        
    }

    public void AddQuestMarker(QuestMarker marker)
    {
        GameObject newMarker = Instantiate(IconPrefab, CompassImage.transform);
        marker.Image = newMarker.GetComponent<Image>();
        marker.Image.sprite = marker.Icon;

        questMarkers.Add(marker);
    }

    Vector2 GetPosOnCompass(QuestMarker marker)
    {
        Vector2 playerPos = new Vector2(Player.transform.position.x, Player.transform.position.z);
        Vector2 playerFwd = new Vector2(Player.transform.forward.x, Player.transform.forward.z);

        float angle = Vector2.SignedAngle(marker.position-playerPos,playerFwd);

        return new Vector2(compassUnit * angle,0f);
    }
}
