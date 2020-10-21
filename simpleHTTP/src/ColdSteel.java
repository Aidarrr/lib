public class ColdSteel extends Weapon{
    private int length;
    private String material;

    public ColdSteel(String name, float range, float accuracy, float weight, int length, String material) {
        super(name, range, accuracy, weight);
        this.length = length;
        this.material = material;
    }

    public ColdSteel() {
    }

    public int getLength() {
        return length;
    }

    public String getMaterial() {
        return material;
    }

    public void setLength(int length) {
        this.length = length;
    }

    public void setMaterial(String material) {
        this.material = material;
    }
}
