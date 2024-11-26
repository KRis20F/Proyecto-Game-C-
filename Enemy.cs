class Enemy {
    
    public int health { get;  }
    public int level { get; }

    public Enemy(int health, int level) {
        health = new Random().Next(0,10);
        this.level = level;
    }


}