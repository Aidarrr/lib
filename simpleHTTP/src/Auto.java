public class Auto {
    private String firm;
    private int maxSpeed;
    private String goverNum;

    public void setFirm(String firma){
        firm=firma;
    }

    public void setMaxSpeed(int speed){
        maxSpeed=speed;
    }

    public void setGoverNum(String goverNum) {
        this.goverNum = goverNum;
    }

    public int getMaxSpeed(){
        return maxSpeed;
    }

    public String getFirm(){
        return firm;
    }

    public String getGoverNum() {
        return goverNum;
    }

    public Auto(){
        firm="Без названия";
        maxSpeed=0;
    }

    public Auto(String firma, int speed){
        firm=firma;
        maxSpeed=speed;
    }

    public Auto(String firma, int speed, String gNum){
        firm=firma;
        maxSpeed=speed;
        goverNum = gNum;
    }
}