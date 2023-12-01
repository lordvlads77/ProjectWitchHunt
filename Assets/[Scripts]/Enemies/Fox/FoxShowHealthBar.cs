using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxShowHealthBar : MonoBehaviour
{
    [SerializeField] private float _maxHealth = default;
    [SerializeField] private UIHealthBar _healthBar;
    [SerializeField] private float _currentHealth;
    private bool _isDead = false;
    [SerializeField] private Animator animator;
    [SerializeField] private EnemyBehaviour _enemyBehaviour;
    [SerializeField] private BoxCollider _boxCollider;
    [SerializeField] private MeshCollider _meshCollider;

    [Header("Dropeo de Objetos")]
    [SerializeField] private GameObject item1ToDrop;
    [SerializeField, Range(0f, 1f)] private float dropProbability1 = 0.33f;

    [SerializeField] private GameObject item2ToDrop;
    [SerializeField, Range(0f, 1f)] private float dropProbability2 = 0.33f;

    [SerializeField] private GameObject item3ToDrop;
    [SerializeField, Range(0f, 1f)] private float dropProbability3 = 0.34f;

    [SerializeField] EnemyChecker enemyChecker;

    private void Start()
    {
        _currentHealth = _maxHealth;
        _healthBar = GetComponentInChildren<UIHealthBar>();
        enemyChecker.isDead = false;
    }

    
    public void Dmg(float dmgAmount)
    {
        if (!_isDead)
        {
            _currentHealth -= dmgAmount;
            _healthBar.UpdateHealthBar(_maxHealth, _currentHealth);

        }
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (!_isDead)
        {
            // Ejecutar la animación de muerte si es necesario
            if (animator != null)
            {
                StartCoroutine(FoxDeathAnim());
            }

            ParticleController.Instance.SpawnDeathVFXFox();
            AudioController.Instance.PlayDeathSFX();
            _boxCollider.isTrigger = false;
            _meshCollider.enabled = false;

            // Desactivar el objeto o realizar otras acciones para indicar que el objeto ha muerto
            _isDead = true;

            // Suelta uno de los tres objetos al morir si no se ha soltado antes y las probabilidades se cumplen
            float randomValue = Random.value;

            if (randomValue <= dropProbability1)
            {
                DropItem(item1ToDrop);
            }
            else if (randomValue <= dropProbability1 + dropProbability2)
            {
                DropItem(item2ToDrop);
            }
            else
            {
                DropItem(item3ToDrop);
            }

            enemyChecker.isDead = true;

            /*gameObject.SetActive(false);*/ // Desactivar el objeto, por ejemplo
        }
    }

    private void DropItem(GameObject itemToDrop)
    {
        if (itemToDrop != null)
        {
            GameObject droppedItem = Instantiate(itemToDrop, transform.position, Quaternion.identity);
            // Ajusta la escala según tus necesidades
            droppedItem.transform.localScale = new Vector3(25f, 25f, 25f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Dmg(10f);
    }

    private IEnumerator FoxDeathAnim()
    {
        _enemyBehaviour.enabled = false;
        AnimationController.Instance.EnemyFoxDeath(animator);
        yield return new WaitForSeconds(4f);
        CoinManager.GetCoinManager().AddCoin();
        Destroy(gameObject);
    }
}