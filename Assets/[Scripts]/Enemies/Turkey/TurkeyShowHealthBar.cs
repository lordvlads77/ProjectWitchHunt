using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurkeyShowHealthBar : MonoBehaviour
{
    [SerializeField] private float _maxHealth = default;
    [SerializeField] private UIHealthBar _healthBar;
    [SerializeField] private float _currentHealth;
    private bool _isDead = false;
    [SerializeField] private Animator animator;
    [SerializeField] private EnemyBehaviour _enemyBehaviour;
    [SerializeField] private bool _isDeaad = true;
    [SerializeField] private BoxCollider _boxCollider;
    [SerializeField] private MeshCollider _meshCollider;

    [Header("Dropeo de Objetos")]
    [SerializeField] private GameObject item1ToDrop;
    [SerializeField, Range(0f, 1f)] private float dropProbability1 = 0.33f;

    [SerializeField] private GameObject item2ToDrop;
    [SerializeField, Range(0f, 1f)] private float dropProbability2 = 0.33f;

    [SerializeField] private GameObject item3ToDrop;
    [SerializeField, Range(0f, 1f)] private float dropProbability3 = 0.34f;

    private void Start()
    {
        _currentHealth = _maxHealth;
        _healthBar = GetComponentInChildren<UIHealthBar>();
    }

    public void Dmg(float dmgAmount)
    {
        if (!_isDead)
        {
            _currentHealth -= dmgAmount;
            _healthBar.UpdateHealthBar(_maxHealth, _currentHealth);

        }
        if (_currentHealth <= 0 /*&& _isDeaad == true*/)
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
                StartCoroutine(TurkeyDeathAnim());
            }

            ParticleController.Instance.SpawnDeathVFXTurkey();
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

    private IEnumerator TurkeyDeathAnim()
    {
        _enemyBehaviour.enabled = false;
        AnimationController.Instance.EnemyTurkeyDeath(animator);
        yield return new WaitForSeconds(0.5f);
        // ParticleController.Instance.SpawnDeathVFXTurkey();
        yield return new WaitForSeconds(1f);
        CoinManager.GetCoinManager().AddCoin();
        Destroy(gameObject);
    }
}