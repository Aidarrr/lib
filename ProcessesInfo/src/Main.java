import java.io.*;
import java.util.*;

class MyProcess
{
    private String name;
    private ArrayList<Integer> memory; //K
    private int PID;

    public MyProcess() {
        memory = new ArrayList<>();
    }

    public MyProcess(String name, int memVal, int PID) {
        this.name = name;
        memory = new ArrayList<>();
        memory.add(memVal);
        this.PID = PID;
    }

    public String getName() {
        return name;
    }

    public ArrayList<Integer> getMemory() {
        return memory;
    }

    public int getPID() {
        return PID;
    }

    public void setName(String name) {
        this.name = name;
    }

    public void setMemory(ArrayList<Integer> memory) {
        this.memory = memory;
    }

    public void setPID(int PID) {
        this.PID = PID;
    }

    public void addMemoryValue(Integer mem)
    {
        memory.add(mem);
    }

    public float memAvg()
    {

        int sum = 0;
        for (Integer e : memory)
        {
            sum += e;
        }

        return (sum/(float)(memory.size()));
    }

    @Override
    public String toString() {
        return  "name = '" + name + '\'' + ", PID = " + PID +
                ", average memory usage = " + memAvg();
    }
}

public class Main
{
    private static void ParseLine(String line, ArrayList<MyProcess> processes)
    {
        ArrayList<String> words = new ArrayList<>();

        for (int i = 0; i < line.length() - 1; i++)
        {
            int start, end;
            if(line.charAt(i) == ' ' && line.charAt(i + 1) == ' ')
            {
                while(line.charAt(i + 1) == ' ')
                    i++;
            }
            else if(line.charAt(i) != ' ')
            {
                start = i;
                while ((i != line.length() - 2) && ( (line.charAt(i) != ' ' && line.charAt(i + 1) != ' ') || (line.charAt(i) == ' ' && line.charAt(i + 1) != ' ') || (line.charAt(i) != ' ' && line.charAt(i + 1) == ' ')))
                {
                    i++;
                }
                end = i;
                words.add(line.substring(start, end));
            }

        }

        var pid = Integer.parseInt(words.get(1).split(" ")[0]);
        var mem = Integer.parseInt(words.get(words.size() - 1).split(",")[0]);

        for (MyProcess e : processes)
        {
            if (e.getPID() == pid)
            {
                e.addMemoryValue(mem);
                return;
            }

        }

        processes.add(new MyProcess(words.get(0), mem, pid));
    }

    private static void TasksAnalyze(ArrayList<MyProcess> processes)
    {
        try
        {
            String line;
            Process p = Runtime.getRuntime().exec(System.getenv("windir") +"\\system32\\"+"tasklist.exe");
            BufferedReader input = new BufferedReader(new InputStreamReader(p.getInputStream()));
            input.readLine();
            input.readLine();
            input.readLine();
            while ((line = input.readLine()) != null)
            {
                ParseLine(line, processes);
            }
            input.close();
        }
        catch (Exception err)
        {
            err.printStackTrace();
        }
    }

    public static void main(String[] args)
    {
        ArrayList<MyProcess> processes = new ArrayList<>();
        int count = 0;



        while(true)
        {
            TasksAnalyze(processes);
            count++;
            try {
                Thread.sleep(4 * 1000);
            } catch (InterruptedException ie) {
                Thread.currentThread().interrupt();
            }

            if(count % 8 == 0)
            {
                for (MyProcess e : processes)
                {
                    try {
                        BufferedWriter writer = new BufferedWriter(new FileWriter("file.txt",true));
                        writer.append(e.toString());
                        writer.newLine();
                        writer.close();
                    } catch (IOException e2) {
                        e2.printStackTrace();
                    }
                }
            }
        }



    }
}
