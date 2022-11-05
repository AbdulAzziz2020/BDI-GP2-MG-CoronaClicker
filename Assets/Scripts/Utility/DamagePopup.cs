using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamagePopup : MonoBehaviour
{
    private TMP_Text _textMesh;
    private float _speed = 3f;
    private float _disappearTimer;
    private Color _textColor;

    private void Awake()
    {
        _textMesh = transform.GetComponent<TMP_Text>();
    }

    public void Setup(IDamagable dmg, int damageAmount,int critDamage, bool criticalHit)
    {
        int curDamage = damageAmount;
        
        if (!criticalHit)
        {
            _textMesh.fontSize = 3f;
            _textColor = new Color(238, 255, 0);
        }
        else
        {
            curDamage = damageAmount * critDamage;
            _textMesh.fontSize = 5f;
            _textColor = new Color(255, 0, 24);
        }

        dmg.TakeDamage(curDamage);
        _textMesh.text = "-" + curDamage.ToString();
        _textMesh.faceColor = _textColor;
        _disappearTimer = 1f;
    }

    public static DamagePopup Create(Vector3 pos, IDamagable damagable, int damageAmount, int critDamage, bool criticalHit)
    {
        // Transform dmg = Instantiate(UIManager.Instance.damagePopup, pos, Quaternion.identity);

        GameObject obj = ObjectPool.Instance.GetPooledObject();

        if (obj != null)
        {
            obj.transform.position = pos;
            obj.SetActive(true);
        }
        
        DamagePopup popup = obj.GetComponent<DamagePopup>();
        popup.Setup(damagable, damageAmount, critDamage, criticalHit);

        return popup;
    }

    private void Update()
    {
        transform.position += Vector3.up * _speed * Time.deltaTime;

        _disappearTimer -= Time.deltaTime;
        if (_disappearTimer < 0)
        {
            float _disappearSpeed = 4f;
            _textColor.a -= _disappearSpeed * Time.deltaTime;
            _textMesh.faceColor = _textColor;

            if (_textColor.a < 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
