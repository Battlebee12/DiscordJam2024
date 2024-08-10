public interface IHasHealth
{
    // Property to get and set the health of the object
    


    // Method to handle taking damage
    void TookDamage(float damageAmount);

    // Method to handle healing
    void Heal(float healAmount);

    // Method to handle what happens when the object dies
    void Died();
}

