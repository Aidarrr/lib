public abstract class Weapon {
    private String name;
    private float range;
    private float accuracy;
    private float weight;

    public Weapon(String name, float range, float accuracy, float weight) {
        this.name = name;
        this.range = range;
        this.accuracy = accuracy;
        this.weight = weight;
    }

    public Weapon() {
    }

    public String getName() {
        return name;
    }

    public float getRange() {
        return range;
    }

    public float getAccuracy() {
        return accuracy;
    }

    public float getWeight() {
        return weight;
    }

    public void setName(String name) {
        this.name = name;
    }

    public void setRange(float range) {
        this.range = range;
    }

    public void setAccuracy(float accuracy) {
        this.accuracy = accuracy;
    }

    public void setWeight(float weight) {
        this.weight = weight;
    }
}
