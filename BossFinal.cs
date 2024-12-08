class BossFinal : Enemy{
    public int resistence { get; set; }
    public int regenerate { get; set; }

    public BossFinal(string name,int health, int level, int resistence) : base (name, health, level)  {
        this.resistence = resistence;
    }

    public override int Attack() {return base.Attack() + dice();}

    public void regenerateBoss(int shift) {
        if ((shift + regenerate) >= 10) {
            health += 2;
            regenerate = 0;
        }
        else{regenerate += shift;}
    }
}