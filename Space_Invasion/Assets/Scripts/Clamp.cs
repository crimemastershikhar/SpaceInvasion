using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clamp : MonoBehaviour
{
    [SerializeField] private float playerxMin;
    [SerializeField] private float playerxMax;
    [SerializeField] private float playeryMin;
    [SerializeField] private float playeryMax;
    [SerializeField] private Transform player;

    private void LateUpdate()
    {
        player.position = new Vector3(Mathf.Clamp(player.position.x, playerxMin, playerxMax), Mathf.Clamp(player.position.y, playeryMin, playeryMax));
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(new Vector2(playerxMin, playeryMax), new Vector2(playerxMax, playeryMax));
        Gizmos.DrawLine(new Vector2(playerxMax, playeryMax), new Vector2(playerxMax, playeryMin));
        Gizmos.DrawLine(new Vector2(playerxMax, playeryMin), new Vector2(playerxMin, playeryMin));
        Gizmos.DrawLine(new Vector2(playerxMin, playeryMin), new Vector2(playerxMin, playeryMax));
    }
}
