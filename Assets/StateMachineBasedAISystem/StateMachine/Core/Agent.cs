using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.AI;

namespace EmirhanDur.AISystem
{
    public class Agent : MonoBehaviour
    {
        public StateMachine<Agent> stateMachine;
        public float Health;
        public NavMeshAgent navMeshAgent;
        public Animator animator;


        [SerializeField] TargetInSightTransition targetInSightTransition;
        private void Awake()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();
        }

        private void Start()
        {
            if (stateMachine != null)
            {
                stateMachine.Initialize(this);
            }
        }

        private void Update()
        {
            if (stateMachine != null)
            {
                stateMachine.UpdateState(this);
            }
        }


        public void OnDrawGizmosSelected()
        {
            var viewAngle = targetInSightTransition.viewAngle;
            var viewDistance = targetInSightTransition.viewDistance;

            Vector3 position = transform.position;
            Vector3 forward = transform.forward;

            Vector3 leftBoundary = Quaternion.Euler(0, -viewAngle / 2, 0) * forward * viewDistance;
            Vector3 rightBoundary = Quaternion.Euler(0, viewAngle / 2, 0) * forward * viewDistance;

            Gizmos.color = Color.yellow;

            Gizmos.DrawLine(position, position + forward * viewDistance);

            Gizmos.DrawLine(position, position + leftBoundary);
            Gizmos.DrawLine(position, position + rightBoundary);

            Gizmos.color = new Color(1, 1, 0, 0.3f);
            Gizmos.DrawMesh(CreateViewMesh(forward, viewAngle, viewDistance));
        }

        private Mesh CreateViewMesh(Vector3 forward, float angle, float distance)
        {
            Mesh mesh = new Mesh();

            int segments = 30; 
            Vector3[] vertices = new Vector3[segments + 2];
            int[] triangles = new int[segments * 3];

            vertices[0] = Vector3.zero;

            float stepAngle = angle / segments;

            for (int i = 0; i <= segments; i++)
            {
                float currentAngle = -angle / 2 + stepAngle * i;
                Vector3 vertex = Quaternion.Euler(0, currentAngle, 0) * forward * distance;
                vertices[i + 1] = vertex;

                if (i < segments)
                {
                    triangles[i * 3] = 0;
                    triangles[i * 3 + 1] = i + 1;
                    triangles[i * 3 + 2] = i + 2;
                }
            }

            mesh.vertices = vertices;
            mesh.triangles = triangles;
            mesh.RecalculateNormals();

            return mesh;
        }
    }
}
