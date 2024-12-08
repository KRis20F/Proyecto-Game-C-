class Enemy : Character {
    
    public Enemy(string name, int health, int level) : base(name, health,level){}

    public override int Attack () {
        return base.Attack();
    }
}