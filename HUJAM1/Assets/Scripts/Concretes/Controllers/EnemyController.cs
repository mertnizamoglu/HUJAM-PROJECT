using HUJAM1.Abstracts.Components;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HUJAM1.Concretes.Controllers
{
    public class EnemyController : RotateComponent
    {
        private float _moveSpeed;
        private CharacterController2D _character;

        private void Awake()
        {
            _character = FindObjectOfType<CharacterController2D>();
        }
        private void OnEnable()
        {
            _moveSpeed = Random.Range(2.0f, 6.0f);
        }
        protected override void Update()
        {
            base.Update();
            MoveToPlayer();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Die();
            }
        }

        private void MoveToPlayer()
        {
            this.transform.position = Vector3.Lerp(transform.position, _character.transform.position, (Time.deltaTime / _moveSpeed));
        }

        private void Die()
        {
            SceneManager.LoadScene(0); // Change Here Later!
        }
    }
}