class EnemySpecial : Enemy{
    public int resistence { get; set; }

    public EnemySpecial(string name, int health, int level, int resistence) :base (name ,health, level) {
        this.resistence = resistence; 
    }
    public override int Attack()
    {
        int damage = base.Attack();
        if (resistence > 0)
        {
            damage -= resistence; 
            damage = Math.Max(damage, 0); 
            mecanicResistence(); 
        }
        return damage;
    }


    public void mecanicResistence() {
        if (resistence > 0) {
            resistence--;
        }
    }

    
}