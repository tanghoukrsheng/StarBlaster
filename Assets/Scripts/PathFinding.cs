using Unity.VisualScripting;
using UnityEngine;

public class PathFinding : MonoBehaviour
{
    [SerializeField] WaveConfigSO waveConfig ;
    Transform[] waypoints;
    int waypointIndex = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        waypoints = waveConfig.GetWaypoints();
        transform.position = waveConfig.GetStartingWaypoint().position;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPath();
    }

    private void FollowPath()
    {
        if (waypointIndex <= waypoints.Length - 1)
        {
            var targetPosition = waypoints[waypointIndex].position;
            var movementDelta = waveConfig.GetEnemyMoveSpeed() * Time.deltaTime;
           
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementDelta);

            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
