using UnityEngine;

namespace Leadership.Attribute
{
    [CreateAssetMenu(menuName = "Leadership Project/AttributesSO")]
    public class AttributesSO : ScriptableObject
    {
        [SerializeField] float moraleOrganization;
        [SerializeField] float money;

        public float Money
        {
            get{return money;} set{money = value;}
        }
    }
}